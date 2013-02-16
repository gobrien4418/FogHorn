// <copyright file="FoghornServiceTests.cs" company="Objective Advantage Europe Ltd.">
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
using System.IO;
using System.Linq;
using Foghorn.Core;
using Foghorn.WcfService;
using NLog;
using Xunit;

namespace Foghorn.Test
{
    public class FoghornServiceTests
    {
        private const string ApplicationTestName = "TestApplication";
        private const int NumNotificationTypes = 3;
        private const string NotificationName = "TestNotification";
        private const string FailureMessage = "Failed while testing.";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private int _testApplicationId;

        [Fact]
        public void TestRegisterSendingApplication_3NotificationTypes_ApplicationAndNotificationsInDatabase()
        {
            var dataContext = new FoghornEntities();

            DeleteTestApplications(dataContext);
            var service = new FoghornService();
            RegisterTestApplication(service);

            Assert.True(_testApplicationId > 0);

            var application =
                dataContext.SendingApplications.FirstOrDefault(x => x.SendingApplicationName == ApplicationTestName);
            Assert.NotNull(application);
            Assert.Equal(NumNotificationTypes, application.NotificationTypes.Count);
            Assert.True(application.NotificationTypes.First().NotificationTypeName.StartsWith(NotificationName));
            Assert.Equal(_testApplicationId, application.SendingApplicationId);
        }

        [Fact]
        public void TestRegisterSubscription_ApplicationExists_SubscriberRegistered()
        {
            var service = new FoghornService();
            if (_testApplicationId <= 0)
            {
                RegisterTestApplication(service);
            }
            var subscriberDto = new SubscriberDto
                {
                    HostName = "localhost",
                    Password = "elmo123!",
                    SubscriberName = ApplicationTestName + "TestSubscriber",
                };
            var subscriberId = service.RegisterSubscription(subscriberDto, ApplicationTestName);
            var dataContext = new FoghornEntities();
            var subscriber = dataContext.Subscribers.FirstOrDefault(x => x.SubscriberId == subscriberId);
            Assert.NotNull(subscriber);
        }

        [Fact]
        public void TestNotify_SetUpConfigurationAndCallNotify_NotificationSentAndLogged()
        {
            TestRegisterSubscription_ApplicationExists_SubscriberRegistered();
            var service = new FoghornService();
            var notificationDto = new NotificationDto
                {
                    NotificationMessage = "This is the message of the test notification.",
                    NotificationTypeName = NotificationName + "1",
                    NotificationTitle = "Notification Title",
                    Sticky = true,
                    Priority = 2
                };
            var notificationDtoReturned = service.Notify(notificationDto, ApplicationTestName);
            var notificationId = notificationDtoReturned.NotificationId;
            var dataContext = new FoghornEntities();
            var checkNotification = dataContext.Notifications.FirstOrDefault(x => x.NotificationId == notificationId);
            Assert.NotNull(checkNotification);
        }

        [Fact]
        public void TestNotify_ApplicationNotRegistered_ReturnsErrorLogsFailure()
        {
            var service = new FoghornService();
            var notificationDto = new NotificationDto
                {
                    NotificationMessage = "This is the message of the test notification.",
                    NotificationTypeName = NotificationName + "1",
                    NotificationTitle = "Notification Title"
                };
            Assert.Throws<ArgumentException>(delegate { service.Notify(notificationDto, "IncorrectApplication"); });
        }

        private void RegisterTestApplication(IFoghornService service)
        {
            var notificationTypeDtos = new List<NotificationTypeDto>();
            for (var i = 0; i < NumNotificationTypes; i++)
            {
                var notificationTypeDto = new NotificationTypeDto
                    {
                        NotificationTypeName = NotificationName + i,
                        NotificationTypeDisplayName = "Test Notfication " + i
                    };
                try
                {
                    var iconFilePath = string.Format(@"..\..\NotificationIcons\{0}{1}.png", NotificationName, i);
                    var iconFile = File.OpenRead(iconFilePath);
                    var iconBuffer = new byte[iconFile.Length];
                    iconFile.Read(iconBuffer, 0, (int) iconFile.Length);
                    notificationTypeDto.NotificationTypeIcon = iconBuffer;
                }
                catch (Exception exception)
                {
                    Logger.LogException(LogLevel.Error, FailureMessage, exception);
                    throw;
                }
                notificationTypeDtos.Add(notificationTypeDto);
            }

            var sendingApplicationDto = new SendingApplicationDto {SendingApplicationName = ApplicationTestName};
            try
            {
                var iconFilePath = string.Format(@"..\..\NotificationIcons\Icon.png");
                var iconFile = File.OpenRead(iconFilePath);
                var iconBuffer = new byte[iconFile.Length];
                iconFile.Read(iconBuffer, 0, (int) iconFile.Length);
                sendingApplicationDto.SendingApplicationIcon = iconBuffer;
            }
            catch (Exception exception)
            {
                Logger.LogException(LogLevel.Error, FailureMessage, exception);
                throw;
            }

            _testApplicationId = service.RegisterSendingApplication(sendingApplicationDto, notificationTypeDtos);
        }

        private void DeleteTestApplications(FoghornEntities dataContext)
        {
            var testApplications =
                dataContext.SendingApplications.Where(x => x.SendingApplicationName.StartsWith(ApplicationTestName));
            foreach (var sendingApplication in testApplications)
            {
                var subscribersToRemove = sendingApplication.Subscribers;
                foreach (var subscriber in subscribersToRemove)
                {
                    var notifications = subscriber.NotificationsSent.ToList();
                    foreach (var notification in notifications)
                    {
                        dataContext.Notifications.Remove(notification);
                    }
                }
                dataContext.SendingApplications.Remove(sendingApplication);
            }
            dataContext.SaveChanges();
            _testApplicationId = 0;
        }
    }
}