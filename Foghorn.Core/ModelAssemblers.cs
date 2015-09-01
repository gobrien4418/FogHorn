//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDtos.v3.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2013/02/15 - 18:47:39
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;


namespace Foghorn.Core
{

    /// <summary>
    /// Assembler for <see cref="Subscriber"/> and <see cref="SubscriberDto"/>.
    /// </summary>
    public static partial class SubscriberAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDto"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SubscriberDto"/> converted from <see cref="Subscriber"/>.</param>
        /// <param name="entity"><see cref="Subscriber"/> converted from <see cref="SubscriberDto"/>.</param>
        static partial void OnDto(this Subscriber entity, SubscriberDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SubscriberDto"/> converted from <see cref="Subscriber"/>.</param>
        /// <param name="entity"><see cref="Subscriber"/> converted from <see cref="SubscriberDto"/>.</param>
        static partial void OnEntity(this SubscriberDto dto, Subscriber entity);

        /// <summary>
        /// Converts this instance of <see cref="SubscriberDto"/> to an instance of <see cref="Subscriber"/>.
        /// </summary>
        /// <param name="dto"><see cref="SubscriberDto"/> to convert.</param>
        public static Subscriber ToEntity(this SubscriberDto dto)
        {
            if (dto == null) return null;

            var entity = new Subscriber();

            entity.SubscriberId = dto.SubscriberId;
            entity.SubscriberName = dto.SubscriberName;
            entity.Port = dto.Port;
            entity.HostName = dto.HostName;
            entity.Password = dto.Password;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Subscriber"/> to an instance of <see cref="SubscriberDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Subscriber"/> to convert.</param>
        public static SubscriberDto ToDto(this Subscriber entity)
        {
            if (entity == null) return null;

            var dto = new SubscriberDto();

            dto.SubscriberId = entity.SubscriberId;
            dto.SubscriberName = entity.SubscriberName;
            dto.Port = entity.Port;
            dto.HostName = entity.HostName;
            dto.Password = entity.Password;

            entity.OnDto(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="SubscriberDto"/> to an instance of <see cref="Subscriber"/>.
        /// </summary>
        /// <param name="dtos">An ICollection of <see cref="SubscriberDto"/>s</param>
        /// <returns>An ICollection of <see cref="Subscriber"/></returns>
        public static ICollection<Subscriber> ToEntities(this IEnumerable<SubscriberDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Subscriber"/> to an instance of <see cref="SubscriberDto"/>.
        /// </summary>
        /// <param name="entities">An ICollection of <see cref="Subscriber"/>s</param>
        /// <returns>An ICollection of <see cref="SubscriberDto"/></returns>
        public static ICollection<SubscriberDto> ToDtos(this IEnumerable<Subscriber> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDto()).ToList();
        }

    }

    /// <summary>
    /// Assembler for <see cref="Notification"/> and <see cref="NotificationDto"/>.
    /// </summary>
    public static partial class NotificationAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDto"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="NotificationDto"/> converted from <see cref="Notification"/>.</param>
        /// <param name="entity"><see cref="Notification"/> converted from <see cref="NotificationDto"/>.</param>
        static partial void OnDto(this Notification entity, NotificationDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="NotificationDto"/> converted from <see cref="Notification"/>.</param>
        /// <param name="entity"><see cref="Notification"/> converted from <see cref="NotificationDto"/>.</param>
        static partial void OnEntity(this NotificationDto dto, Notification entity);

        /// <summary>
        /// Converts this instance of <see cref="NotificationDto"/> to an instance of <see cref="Notification"/>.
        /// </summary>
        /// <param name="dto"><see cref="NotificationDto"/> to convert.</param>
        public static Notification ToEntity(this NotificationDto dto)
        {
            if (dto == null) return null;

            var entity = new Notification();

            entity.NotificationId = dto.NotificationId;
            entity.NotificationTitle = dto.NotificationTitle;
            entity.NotificationMessage = dto.NotificationMessage;
            entity.SentDateTime = dto.SentDateTime;
            entity.Priority = dto.Priority;
            entity.Sticky = dto.Sticky;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="Notification"/> to an instance of <see cref="NotificationDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="Notification"/> to convert.</param>
        public static NotificationDto ToDto(this Notification entity)
        {
            if (entity == null) return null;

            var dto = new NotificationDto();

            dto.NotificationId = entity.NotificationId;
            dto.NotificationTitle = entity.NotificationTitle;
            dto.NotificationMessage = entity.NotificationMessage;
            dto.SentDateTime = entity.SentDateTime;
            dto.Priority = entity.Priority;
            dto.Sticky = entity.Sticky;

            entity.OnDto(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="NotificationDto"/> to an instance of <see cref="Notification"/>.
        /// </summary>
        /// <param name="dtos">An ICollection of <see cref="NotificationDto"/>s</param>
        /// <returns>An ICollection of <see cref="Notification"/></returns>
        public static ICollection<Notification> ToEntities(this IEnumerable<NotificationDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="Notification"/> to an instance of <see cref="NotificationDto"/>.
        /// </summary>
        /// <param name="entities">An ICollection of <see cref="Notification"/>s</param>
        /// <returns>An ICollection of <see cref="NotificationDto"/></returns>
        public static ICollection<NotificationDto> ToDtos(this IEnumerable<Notification> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDto()).ToList();
        }

    }

    /// <summary>
    /// Assembler for <see cref="SendingApplication"/> and <see cref="SendingApplicationDto"/>.
    /// </summary>
    public static partial class SendingApplicationAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDto"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SendingApplicationDto"/> converted from <see cref="SendingApplication"/>.</param>
        /// <param name="entity"><see cref="SendingApplication"/> converted from <see cref="SendingApplicationDto"/>.</param>
        static partial void OnDto(this SendingApplication entity, SendingApplicationDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="SendingApplicationDto"/> converted from <see cref="SendingApplication"/>.</param>
        /// <param name="entity"><see cref="SendingApplication"/> converted from <see cref="SendingApplicationDto"/>.</param>
        static partial void OnEntity(this SendingApplicationDto dto, SendingApplication entity);

        /// <summary>
        /// Converts this instance of <see cref="SendingApplicationDto"/> to an instance of <see cref="SendingApplication"/>.
        /// </summary>
        /// <param name="dto"><see cref="SendingApplicationDto"/> to convert.</param>
        public static SendingApplication ToEntity(this SendingApplicationDto dto)
        {
            if (dto == null) return null;

            var entity = new SendingApplication();

            entity.SendingApplicationId = dto.SendingApplicationId;
            entity.SendingApplicationName = dto.SendingApplicationName;
            entity.SendingApplicationIcon = dto.SendingApplicationIcon;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="SendingApplication"/> to an instance of <see cref="SendingApplicationDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="SendingApplication"/> to convert.</param>
        public static SendingApplicationDto ToDto(this SendingApplication entity)
        {
            if (entity == null) return null;

            var dto = new SendingApplicationDto();

            dto.SendingApplicationId = entity.SendingApplicationId;
            dto.SendingApplicationName = entity.SendingApplicationName;
            dto.SendingApplicationIcon = entity.SendingApplicationIcon;

            entity.OnDto(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="SendingApplicationDto"/> to an instance of <see cref="SendingApplication"/>.
        /// </summary>
        /// <param name="dtos">An ICollection of <see cref="SendingApplicationDto"/>s</param>
        /// <returns>An ICollection of <see cref="SendingApplication"/></returns>
        public static ICollection<SendingApplication> ToEntities(this IEnumerable<SendingApplicationDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="SendingApplication"/> to an instance of <see cref="SendingApplicationDto"/>.
        /// </summary>
        /// <param name="entities">An ICollection of <see cref="SendingApplication"/>s</param>
        /// <returns>An ICollection of <see cref="SendingApplicationDto"/></returns>
        public static ICollection<SendingApplicationDto> ToDtos(this IEnumerable<SendingApplication> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDto()).ToList();
        }

    }

    /// <summary>
    /// Assembler for <see cref="NotificationType"/> and <see cref="NotificationTypeDto"/>.
    /// </summary>
    public static partial class NotificationTypeAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDto"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="NotificationTypeDto"/> converted from <see cref="NotificationType"/>.</param>
        /// <param name="entity"><see cref="NotificationType"/> converted from <see cref="NotificationTypeDto"/>.</param>
        static partial void OnDto(this NotificationType entity, NotificationTypeDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="NotificationTypeDto"/> converted from <see cref="NotificationType"/>.</param>
        /// <param name="entity"><see cref="NotificationType"/> converted from <see cref="NotificationTypeDto"/>.</param>
        static partial void OnEntity(this NotificationTypeDto dto, NotificationType entity);

        /// <summary>
        /// Converts this instance of <see cref="NotificationTypeDto"/> to an instance of <see cref="NotificationType"/>.
        /// </summary>
        /// <param name="dto"><see cref="NotificationTypeDto"/> to convert.</param>
        public static NotificationType ToEntity(this NotificationTypeDto dto)
        {
            if (dto == null) return null;

            var entity = new NotificationType();

            entity.NotificationTypeId = dto.NotificationTypeId;
            entity.NotificationTypeName = dto.NotificationTypeName;
            entity.NotificationTypeDisplayName = dto.NotificationTypeDisplayName;
            entity.NotificationTypeIcon = dto.NotificationTypeIcon;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="NotificationType"/> to an instance of <see cref="NotificationTypeDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="NotificationType"/> to convert.</param>
        public static NotificationTypeDto ToDto(this NotificationType entity)
        {
            if (entity == null) return null;

            var dto = new NotificationTypeDto();

            dto.NotificationTypeId = entity.NotificationTypeId;
            dto.NotificationTypeName = entity.NotificationTypeName;
            dto.NotificationTypeDisplayName = entity.NotificationTypeDisplayName;
            dto.NotificationTypeIcon = entity.NotificationTypeIcon;

            entity.OnDto(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="NotificationTypeDto"/> to an instance of <see cref="NotificationType"/>.
        /// </summary>
        /// <param name="dtos">An ICollection of <see cref="NotificationTypeDto"/>s</param>
        /// <returns>An ICollection of <see cref="NotificationType"/></returns>
        public static ICollection<NotificationType> ToEntities(this IEnumerable<NotificationTypeDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="NotificationType"/> to an instance of <see cref="NotificationTypeDto"/>.
        /// </summary>
        /// <param name="entities">An ICollection of <see cref="NotificationType"/>s</param>
        /// <returns>An ICollection of <see cref="NotificationTypeDto"/></returns>
        public static ICollection<NotificationTypeDto> ToDtos(this IEnumerable<NotificationType> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDto()).ToList();
        }

    }
}
