﻿// <copyright file="ModelAssemblerExtensions.cs" company="Objective Advantage Europe Ltd.">
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

using System.Collections.Generic;

namespace Foghorn.Core
{
    public partial class SendingApplicationAssembler
    {
        static partial void OnDto(this SendingApplication entity, SendingApplicationDto dto)
        {
            dto.NotificationTypes = (List<NotificationTypeDto>) entity.NotificationTypes.ToDtos();
            dto.Subscribers = (List<SubscriberDto>) entity.Subscribers.ToDtos();
        }
    }

    public partial class NotificationAssembler
    {
        static partial void OnDto(this Notification entity, NotificationDto dto)
        {
            dto.SentToSubscribers = (List<SubscriberDto>) entity.SentToSubscribers.ToDtos();
        }
    }

//    public partial class SubscriberAssembler
//    {
//        static partial void OnDto(this Subscriber entity, SubscriberDto dto)
//        {
//            dto.SendingApplication = entity.SendingApplication.ToDto();
//        }
//    }
}