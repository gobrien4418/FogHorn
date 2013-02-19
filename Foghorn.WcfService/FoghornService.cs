// <copyright file="FoghornService.cs" company="Objective Advantage Europe Ltd.">
// 
// Copyright (c) Objective Advantage Europe Ltd. 2011 - 2013 All Right Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Foghorn.Core;
using Foghorn.WcfService.Properties;
using Growl.Connector;
using Growl.CoreLibrary;
using NLog;
using NotificationType = Foghorn.Core.NotificationType;

namespace Foghorn.WcfService
{
    public class FoghornService : IFoghornService
    {
        private const string FailureMessage = "Something went wrong receiving a service call.";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static readonly FoghornEntities DataContext = new FoghornEntities();

        #region IFoghornService Members

        public int RegisterSendingApplication(SendingApplicationDto sendingApplicationDto,
                                              IEnumerable<NotificationTypeDto> notificationTypeDtos)
        {
            var notificationTypes = new List<NotificationType>();

            foreach (var notificationTypeDto in notificationTypeDtos)
            {
                var notificationType =
                    DataContext.NotificationTypes.FirstOrDefault(
                        x => x.NotificationTypeName == notificationTypeDto.NotificationTypeName);
                if (notificationType == null)
                {
                    notificationType = notificationTypeDto.ToEntity();
                    DataContext.NotificationTypes.Add(notificationType);
                    Logger.Trace("Adding a new NotificationType: {0}, for application: {1}",
                                 notificationTypeDto.NotificationTypeName, sendingApplicationDto.SendingApplicationName);
                }
                notificationType.NotificationTypeIcon = notificationTypeDto.NotificationTypeIcon;
                notificationType.NotificationTypeDisplayName = notificationTypeDto.NotificationTypeDisplayName;
                notificationTypes.Add(notificationType);
            }

            var sendingApplication =
                DataContext.SendingApplications.FirstOrDefault(
                    x => x.SendingApplicationName == sendingApplicationDto.SendingApplicationName);
            if (sendingApplication == null)
            {
                sendingApplication = sendingApplicationDto.ToEntity();
                Logger.Trace("Adding a new SendingApplication: {0}", sendingApplicationDto.SendingApplicationName);
                DataContext.SendingApplications.Add(sendingApplication);
            }
            else
            {
                sendingApplication.SendingApplicationIcon = sendingApplicationDto.SendingApplicationIcon;
            }

            sendingApplication.NotificationTypes.Clear();
            foreach (var notificationType in notificationTypes)
            {
                sendingApplication.NotificationTypes.Add(notificationType);
            }
            DataContext.SaveChanges();
            return sendingApplication.SendingApplicationId;
        }


        public Guid RegisterSubscription(SubscriberDto subscriberDto, string sendingApplicationName)
        {
            var sendingApplication =
                DataContext.SendingApplications.FirstOrDefault(x => x.SendingApplicationName == sendingApplicationName);
            if (sendingApplication == null)
            {
                var exception =
                    new Exception("Cannot register a subscription for a SendingApplication that is not registered.");
                Logger.ErrorException(FailureMessage, exception);
                throw exception;
            }

            Subscriber subscriber;
            if (subscriberDto.SubscriberId != Guid.Empty)
            {
                subscriber = DataContext.Subscribers.FirstOrDefault(x => x.SubscriberId == subscriberDto.SubscriberId);
            }
            else
            {
                subscriber = subscriberDto.ToEntity();
                subscriber.SubscriberId = Guid.NewGuid();
                DataContext.Subscribers.Add(subscriber);
            }

            var port = subscriberDto.Port.HasValue ? subscriberDto.Port.Value : Settings.Default.GrowlDefaultPort;
            var growlConnector = new GrowlConnector(subscriberDto.Password, subscriberDto.HostName, port);

            var growlNotificationTypes = new List<Growl.Connector.NotificationType>();
            foreach (var notificationType in sendingApplication.NotificationTypes)
            {
                var growlNotificationType = new Growl.Connector.NotificationType(notificationType.NotificationTypeName,
                                                                                 notificationType.NotificationTypeDisplayName);
                if (notificationType.NotificationTypeIcon != null && notificationType.NotificationTypeIcon.Length > 0)
                {
                    growlNotificationType.Icon = new BinaryData(notificationType.NotificationTypeIcon);
                }
                growlNotificationTypes.Add(growlNotificationType);
            }

            var growlApplication = new Application(sendingApplicationName);
            if (sendingApplication.SendingApplicationIcon != null && sendingApplication.SendingApplicationIcon.Length > 0)
            {
                growlApplication.Icon = new BinaryData(sendingApplication.SendingApplicationIcon);
            }
            growlConnector.Register(growlApplication, growlNotificationTypes.ToArray());

            if (sendingApplication.Subscribers.Contains(subscriber)) return Guid.Empty;

            Debug.Assert(subscriber != null, "subscriber != null");
            subscriber.SendingApplication = sendingApplication;
            DataContext.SaveChanges();
            return subscriber.SubscriberId;
        }

        public NotificationDto Notify(NotificationDto notificationDto, string sendingApplicationName)
        {
            return Notifier.Notify(notificationDto, sendingApplicationName).ToDto();
        }

        public ICollection<SendingApplicationDto> GetRegisteredApplications()
        {
            return DataContext.SendingApplications.ToDtos();
        }

        public ICollection<SubscriberDto> GetRegisteredSubscribers()
        {
            return DataContext.Subscribers.ToDtos();
        }

        public ICollection<NotificationDto> GetNotifications(string subscriberId)
        {
            var subscriberIdGuid = new Guid(subscriberId);
            var subscriber = DataContext.Subscribers.FirstOrDefault(x => x.SubscriberId == subscriberIdGuid);
            return subscriber != null ? subscriber.NotificationsSent.ToDtos() : new List<NotificationDto>();
        }

        public SendingApplicationDto GetSendingApplication(string sendingApplicationName)
        {
            return
                DataContext.SendingApplications.FirstOrDefault(x => x.SendingApplicationName == sendingApplicationName)
                           .ToDto();
        }

        #endregion
    }
}