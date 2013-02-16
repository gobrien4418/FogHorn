// <copyright file="WcfTests.cs" company="Objective Advantage Europe Ltd.">
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
using System.Data;
using System.IO;
using System.ServiceModel;
using Excel;
using Foghorn.Core;
using Foghorn.WcfService;
using NLog;
using Xunit;

namespace Foghorn.Test
{
    public class WcfTests
    {
        private const string ApplicationTestName = "TestApplication";
        private const string ServiceUrl = @"http://localhost:8733/Design_Time_Addresses/Foghorn.WcfService/FoghornService/";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [Fact]
        public void TestRegisterSendingApplication_LoadNotificationTypesFromExcel_AllLoaded()
        {
            var foghornClient =
                new ChannelFactory<IFoghornService>(new BasicHttpBinding(), new EndpointAddress(ServiceUrl)).CreateChannel();

            var notificationTypeDtos = new List<NotificationTypeDto>();
            LoadNotificationTypes(notificationTypeDtos);

            var sendingApplicationDto = new SendingApplicationDto {SendingApplicationName = ApplicationTestName};
            LoadApplicationIcon(sendingApplicationDto);

            foghornClient.RegisterSendingApplication(sendingApplicationDto, notificationTypeDtos);

            //TODO: Add Assertions
        }

        [Fact]
        public void TestRegisterSubscription_ApplicationExists_SubscriberRegistered()
        {
            var foghornClient =
                new ChannelFactory<IFoghornService>(new BasicHttpBinding(), new EndpointAddress(ServiceUrl)).CreateChannel();
            var subscriberDto = new SubscriberDto {HostName = "localhost", Password = "abc123!", SubscriberName = "jbloggs"};
            foghornClient.RegisterSubscription(subscriberDto, ApplicationTestName);

            //TODO: Add Assertions
        }

        [Fact]
        public void TestNotify_ApplicationExists_NotificationSent()
        {
            var foghornClient =
                new ChannelFactory<IFoghornService>(new BasicHttpBinding(), new EndpointAddress(ServiceUrl)).CreateChannel();

            var notificationDto = new NotificationDto
                {
                    NotificationMessage = "This is the message of the test notification.",
                    NotificationTypeName = "Error",
                    NotificationTitle = "Notification Title",
                    Priority = 2,
                    Sticky = true
                };
            foghornClient.Notify(notificationDto, ApplicationTestName);
            
            //TODO: Add Assertions
        }

        private static void LoadApplicationIcon(SendingApplicationDto sendingApplicationDto)
        {
            Stream iconStream = null;
            try
            {
                iconStream = File.OpenRead(Path.Combine(@"..\..\NotificationIcons", "Icon.png"));
                var buffer = new byte[iconStream.Length];
                iconStream.Read(buffer, 0, (int) iconStream.Length);
                sendingApplicationDto.SendingApplicationIcon = buffer;
            }
            catch (Exception exception)
            {
                Logger.LogException(LogLevel.Error, "Exception Ignored", exception);
                throw;
            }
            finally
            {
                if (iconStream != null) iconStream.Close();
            }
        }

        private static void LoadNotificationTypes(ICollection<NotificationTypeDto> notificationTypeDtos)
        {
            Stream excelFile = null;
            try
            {
                excelFile = File.OpenRead(@"..\..\NotificationTypes.xlsx");
                var excel = ExcelReaderFactory.CreateOpenXmlReader(excelFile);
                excel.IsFirstRowAsColumnNames = true;
                var excelData = excel.AsDataSet();

                var sheet = excelData.Tables["NotificationTypes"];
                foreach (DataRow row in sheet.Rows)
                {
                    var notificationTypeDto = new NotificationTypeDto
                        {
                            NotificationTypeName = row["NotificationTypeName"].ToString(),
                            NotificationTypeDisplayName = row["NotificationTypeDescription"].ToString(),
                        };
                    Stream notificationIconStream = null;
                    try
                    {
                        notificationIconStream =
                            File.OpenRead(Path.Combine(@"..\..\NotificationIcons", row["IconFileName"].ToString()));
                        var buffer = new byte[notificationIconStream.Length];
                        notificationIconStream.Read(buffer, 0, (int) notificationIconStream.Length);
                        notificationTypeDto.NotificationTypeIcon = buffer;
                        notificationTypeDtos.Add(notificationTypeDto);
                    }
                    catch (Exception exception)
                    {
                        Logger.LogException(LogLevel.Error, "Exception Ignored", exception);
                        throw;
                    }
                    finally
                    {
                        if (notificationIconStream != null) notificationIconStream.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.LogException(LogLevel.Error, "Exception Ignored", exception);
            }
            finally
            {
                if (excelFile != null) excelFile.Close();
            }
        }
    }
}