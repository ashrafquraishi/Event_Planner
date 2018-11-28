using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventPlanner.Models.EventPlannerModels
{
    public class EventOwnerModel
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public  string Address { get; set; }
        [DisplayName("Zip Code")]
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }


        public int EventLocationModelId { get; set; }

        [ForeignKey("EventLocationModelId")]
        public virtual EventLocationModel EventLocationModel { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}