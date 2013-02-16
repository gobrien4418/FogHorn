﻿// <copyright file="FoghornWindowsService.cs" company="Objective Advantage Europe Ltd.">
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

using System.ServiceModel;
using System.ServiceProcess;
using Foghorn.WcfService;

namespace Foghorn.WindowsService
{
    partial class FoghornWindowsService : ServiceBase
    {
        private readonly ServiceHost _wcfServiceHost = new ServiceHost(typeof (FoghornService));

        public FoghornWindowsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (_wcfServiceHost != null) _wcfServiceHost.Open();
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            if (_wcfServiceHost != null) _wcfServiceHost.Close();
            base.OnStop();
        }
    }
}