// <copyright file="FoghornWindowsServiceInstaller.cs" company="Confero Ltd.">
// 
// Copyright (c) 2011 - 2013 All Right Reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// 
// </copyright>

using System.ComponentModel;
using System.Configuration.Install;

namespace Foghorn.WindowsService
{
    [RunInstaller(true)]
    public partial class FoghornWindowsServiceInstaller : Installer
    {
        public FoghornWindowsServiceInstaller()
        {
            InitializeComponent();
        }
    }
}