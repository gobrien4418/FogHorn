// <copyright file="Notifier.cs" company="Objective Advantage Europe Ltd.">
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
using System.Globalization;
using System.Linq;
using Foghorn.Core;
using Foghorn.WcfService.Properties;
using Growl.Connector;
using NLog;
using Notification = Foghorn.Core.Notification;

namespace Foghorn.WcfService
{
    public class Notifier
    {
        private const string FailureMessage = "Growl Notifier had a problem.";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static Notification Notify(NotificationDto notificationDto, string sendingApplicationName)
        {
            var dataContext = new FoghornEntities();

            var sendingApplication =
                dataContext.SendingApplications.FirstOrDefault(x => x.SendingApplicationName == sendingApplicationName);

            if (sendingApplication == null)
            {
                var exception =
                    new ArgumentException("sendingApplicationName must match a previously registered SendingApplication",
                                          "sendingApplicationName");
                Logger.ErrorException(FailureMessage, exception);
                throw exception;
            }

            if (notificationDto == null)
            {
                var exception = new ArgumentException("notification must not be null", "notificationDto");
                Logger.ErrorException(FailureMessage, exception);
                throw exception;
            }

            if (notificationDto.Priority > 2) notificationDto.Priority = 2;
            if (notificationDto.Priority < -2) notificationDto.Priority = -2;

            var growlNotification = new Growl.Connector.Notification(sendingApplication.SendingApplicationName,
                                                                     notificationDto.NotificationTypeName,
                                                                     notificationDto.NotificationId.ToString(
                                                                         CultureInfo.InvariantCulture),
                                                                     notificationDto.NotificationTitle,
                                                                     notificationDto.NotificationMessage)
                {
                    Sticky = notificationDto.Sticky,
                    Priority = (Priority) notificationDto.Priority
                };

            var notification = notificationDto.ToEntity();
            foreach (var subscriber in sendingApplication.Subscribers)
            {
                var port = subscriber.Port.HasValue ? subscriber.Port.Value : Settings.Default.GrowlDefaultPort;
                var growlConnector = new GrowlConnector(subscriber.Password, subscriber.HostName, port);
                growlConnector.Notify(growlNotification);
                subscriber.NotificationsSent.Add(notification);
            }

            notification.SentDateTime = DateTime.UtcNow;
            notification.NotificationType =
                dataContext.NotificationTypes.FirstOrDefault(
                    x => x.NotificationTypeName == notificationDto.NotificationTypeName);
            dataContext.Notifications.Add(notification);
            dataContext.SaveChanges();
            return notification;
        }
    }
}