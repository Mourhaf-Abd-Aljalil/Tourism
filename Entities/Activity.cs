using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;

namespace ProjectTourism.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }

        public string ActivityName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int TripId { get; set; }

        public  Trip? Trip { get; set; }
    }
}
