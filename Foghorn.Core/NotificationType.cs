//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Foghorn.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class NotificationType
    {
        public int NotificationTypeId { get; set; }
        public string NotificationTypeName { get; set; }
        public string NotificationTypeDisplayName { get; set; }
        public byte[] NotificationTypeIcon { get; set; }
    
        public virtual SendingApplication SendingApplication { get; set; }
    }
}
