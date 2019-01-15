using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventPlanner.Models
{
    public class Main
    {
        [Key]
        [DisplayName("Venue Name")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string VenueName { get; set; }
        [DisplayName("Zip Code")]

        public string ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }

        //catering Business
        [Display(Name = "Catering Company Name")]

        public string CateringCompany { get; set; }
        [Display(Name = "Title")]
        public string MenuItemTitle { get; set; }

        [Display(Name = "Description")]
        public string MenuItemDescription { get; set; }

       

        [Display(Name = "How many in serving")]
        public int MenuItemQuantity { get; set; }

        [Display(Name = "Cost of Dish")]
        public double MenuItemCost { get; set; }
        [Display(Name = "How Many of this dish you want to serve")]

        public int EnterDishes { get; set; }

        //security business
        [Display(Name = "Security Agency Name")]
        public string SecurityName { get; set; }
        [Display(Name = "How Many Security Guard Would You Like To Have")]

        public int SecurityPersonal { get; set; }
        [Display(Name = "Charge Per Security Guard")]

        public int perSecurityPersonal { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}