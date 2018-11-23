using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventPlanner.Models.EventPlannerModels
{
    public class EventLocationModel
    {
        [Key]
        [DisplayName("Venue Name")]
        public int Id { get; set; }
        public string VenueName { get; set; }
        public string Address { get; set; }
        [DisplayName("Zip Code")]

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Capacity { get; set; }
        public string Price { get; set; }


    }
}