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

