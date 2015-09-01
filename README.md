# FogHorn
Growl notification for Service Oriented Architecture

<img src="http://www.growlforwindows.com/gfw/images/growl4windows.jpg"/>

Foghorn is a WCF wrapper for the Growl for Windows .NET SDK.

* http://www.growlforwindows.com
* http://growl-for-windows.googlecode.com/
* http://www.growlforwindows.com/gfw/developers.aspx#integration

Foghorn started because different modules of a large-scale ERP and production automation system needed to send notifications. That solution uses a Service-Oriented Architecture and various modules were written in different languages, running on different stacks and already communicating with each other using SOAP web services.

Foghorn goes on the server as part of the install, running as an independent Windows Service. User accounts are already being created in the ERP, they now have optional custom fields for Growl HostName; Port and Password. These are used to register a Foghorn subscription for the user via SOAP call. When various events occur in the Java-based ERP or in the C# .NET manufacturing management system they make a single SOAP call to Foghorn causing a notification from the server to all subscribers.

Note: This project is purely the Windows Service hosting a WCF service that wraps the Growl SDK. There is no UI as Foghorn is intended to be a service used as part of a solution that has its own UI.

# Introduction
Foghorn is simply a WCF wrapper around Growl.Connector from the Growl for Windows SDK http://www.growlforwindows.com/gfw/developers.aspx. It's purpose is to provide a single point of access for multiple _SendingApplications_ to _Notify_ _Subscribers_ via the various protocols supported by WCF.

## Why not just install Growl on the server?
1. Growl for Windows does not run as a Windows Service. You can do that manually, but I needed a clean Windows Service to handle notifications that installs directly from an msi. 
2. Only a single instance of Growl can run on a machine, so you would need to stop the Windows Service and start the desktop Growl each time you want to configure forwarding, (i.e. subscriptions). I need this to occur seamlessly when a user 's Growl host details are added in the ERP and with Foghorn it is, via SOAP.

## Step-by-step
Given it is just a Growl SDK wrapper, the steps are much like using Growl.

1. Register an Application (including the _NotificationTypes_ it supports)
2. Register a subscription, i.e. a Growl host that wants to receive notifications from this Application.
3. Notify

**Real-world:** Your installer should probably register the application using a custom action or command line program. Like Growl, Foghorn supports multiple Applications, so it can act as a hub for Growl messaging. It also logs all traffic to the database so could be an audit log of who was sent what notification when. This data is accessible through the WCF service.

## Development Prerequisites
1. The project source does NOT include anything that has been installed with NuGet. Look at the references and install-package as required.
2. EntitiesToDtos http://entitiestodtos.codeplex.com/ is used to create the Dto classes from the Entity Framework 5 edmx file. Use _Foghorn.etdtosconfig.xml_ to import the configuration once you have installed EntitiesToDtos.
3. Database: Using SQL Server create an empty database called Foghorn. Then execute _FoghornModel.edmx.sql_.

## Changes to Foghorn.Core
If you need to add to the data model use the EDMX as the starting point. The use _Generate Database from Model ..._ to update the SQL script. Remember the SQL script will be used by your installer to install the database. Once the data model is updated run EntitiesToDtos to regenerate the Dto classes.

## Examples
See the test project for examples including a way to load the notification types for an application from an Excel file, potentially useful when installing your solution in the field.
