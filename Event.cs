using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_01_Seed_Data
{
    class Event
    {
        public int EventId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Flagged { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
