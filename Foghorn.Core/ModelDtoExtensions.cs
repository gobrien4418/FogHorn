// <copyright file="ModelDtoExtensions.cs" company="Objective Advantage Europe Ltd.">
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

using System.Runtime.Serialization;

namespace Foghorn.Core
{
    public partial class NotificationDto
    {
        [DataMember]
        public string NotificationTypeName { get; set; }
    }
}