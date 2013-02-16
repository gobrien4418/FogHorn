//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDtos.v3.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/02/15 - 18:47:38
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Foghorn.Core
{
    [DataContract()]
    public partial class SubscriberDto
    {
        [DataMember()]
        public Guid SubscriberId { get; set; }

        [DataMember()]
        public String SubscriberName { get; set; }

        [DataMember()]
        public Nullable<Int32> Port { get; set; }

        [DataMember()]
        public String HostName { get; set; }

        [DataMember()]
        public String Password { get; set; }

        [DataMember()]
        public List<NotificationDto> NotificationsSent { get; set; }

        [DataMember()]
        public SendingApplicationDto SendingApplication { get; set; }

        public SubscriberDto()
        {
        }

        public SubscriberDto(Guid subscriberId, String subscriberName, Nullable<Int32> port, String hostName, String password, List<NotificationDto> notificationsSent, SendingApplicationDto sendingApplication)
        {
			this.SubscriberId = subscriberId;
			this.SubscriberName = subscriberName;
			this.Port = port;
			this.HostName = hostName;
			this.Password = password;
			this.NotificationsSent = notificationsSent;
			this.SendingApplication = sendingApplication;
        }
    }

    [DataContract()]
    public partial class NotificationDto
    {
        [DataMember()]
        public Int32 NotificationId { get; set; }

        [DataMember()]
        public String NotificationTitle { get; set; }

        [DataMember()]
        public String NotificationMessage { get; set; }

        [DataMember()]
        public DateTime SentDateTime { get; set; }

        [DataMember()]
        public Int32 Priority { get; set; }

        [DataMember()]
        public Boolean Sticky { get; set; }

        [DataMember()]
        public List<SubscriberDto> SentToSubscribers { get; set; }

        [DataMember()]
        public NotificationTypeDto NotificationType { get; set; }

        public NotificationDto()
        {
        }

        public NotificationDto(Int32 notificationId, String notificationTitle, String notificationMessage, DateTime sentDateTime, Int32 priority, Boolean sticky, List<SubscriberDto> sentToSubscribers, NotificationTypeDto notificationType)
        {
			this.NotificationId = notificationId;
			this.NotificationTitle = notificationTitle;
			this.NotificationMessage = notificationMessage;
			this.SentDateTime = sentDateTime;
			this.Priority = priority;
			this.Sticky = sticky;
			this.SentToSubscribers = sentToSubscribers;
			this.NotificationType = notificationType;
        }
    }

    [DataContract()]
    public partial class SendingApplicationDto
    {
        [DataMember()]
        public Int32 SendingApplicationId { get; set; }

        [DataMember()]
        public String SendingApplicationName { get; set; }

        [DataMember()]
        public Byte[] SendingApplicationIcon { get; set; }

        [DataMember()]
        public List<SubscriberDto> Subscribers { get; set; }

        [DataMember()]
        public List<NotificationTypeDto> NotificationTypes { get; set; }

        public SendingApplicationDto()
        {
        }

        public SendingApplicationDto(Int32 sendingApplicationId, String sendingApplicationName, Byte[] sendingApplicationIcon, List<SubscriberDto> subscribers, List<NotificationTypeDto> notificationTypes)
        {
			this.SendingApplicationId = sendingApplicationId;
			this.SendingApplicationName = sendingApplicationName;
			this.SendingApplicationIcon = sendingApplicationIcon;
			this.Subscribers = subscribers;
			this.NotificationTypes = notificationTypes;
        }
    }

    [DataContract()]
    public partial class NotificationTypeDto
    {
        [DataMember()]
        public Int32 NotificationTypeId { get; set; }

        [DataMember()]
        public String NotificationTypeName { get; set; }

        [DataMember()]
        public String NotificationTypeDisplayName { get; set; }

        [DataMember()]
        public Byte[] NotificationTypeIcon { get; set; }

        [DataMember()]
        public SendingApplicationDto SendingApplication { get; set; }

        public NotificationTypeDto()
        {
        }

        public NotificationTypeDto(Int32 notificationTypeId, String notificationTypeName, String notificationTypeDisplayName, Byte[] notificationTypeIcon, SendingApplicationDto sendingApplication)
        {
			this.NotificationTypeId = notificationTypeId;
			this.NotificationTypeName = notificationTypeName;
			this.NotificationTypeDisplayName = notificationTypeDisplayName;
			this.NotificationTypeIcon = notificationTypeIcon;
			this.SendingApplication = sendingApplication;
        }
    }
}