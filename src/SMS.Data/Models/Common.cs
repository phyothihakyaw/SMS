using System;

namespace SMS.Data.Models
{
    public class Common
    {
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
    }
}
