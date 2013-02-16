// <copyright file="IFoghornService.cs" company="Objective Advantage Europe Ltd.">
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
using System.ServiceModel;
using Foghorn.Core;

namespace Foghorn.WcfService
{
    [ServiceContract]
    public interface IFoghornService
    {
        [OperationContract]
        int RegisterSendingApplication(SendingApplicationDto sendingApplicationDto,
                                       IEnumerable<NotificationTypeDto> notificationTypes);

        [OperationContract]
        Guid RegisterSubscription(SubscriberDto subscriberDto, string sendingApplicationName);

        [OperationContract]
        NotificationDto Notify(NotificationDto notificationDto, string sendingApplicationName);

        [OperationContract]
        ICollection<SendingApplicationDto> GetRegisteredApplications();

        [OperationContract]
        ICollection<SubscriberDto> GetRegisteredSubscribers();

        [OperationContract]
        ICollection<NotificationDto> GetNotifications(string sendingApplicationName);

        [OperationContract]
        SendingApplicationDto GetSendingApplication(string sendingApplicationName);
    }
}