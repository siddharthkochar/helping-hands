using System;

namespace BloodPlus.Database.Entities
{
    public class UserActivityLog
    {
        public Guid DeviceId { get; set; }
        public int ActivityId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
