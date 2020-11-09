﻿using System;

namespace SMS.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public long Version { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedUserId { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
