using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace EventPlanner.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemID { get; set; }
        [Display(Name = "Catering Company")]

        public string CateringCompany { get; set; }
      

        [Required(ErrorMessage = "A title is required for the menu item")]
        [Display(Name = "Title")]
        public string MenuItemTitle { get; set; }

        [Display(Name = "Description")]
        public string MenuItemDescription { get; set; }

        [Display(Name = "Nutrition Information")]
        public string MenuitemNutrition { get; set; }

        [Display(Name = "Information about Ingredients")]
        public string MenuItemIngredients { get; set; }

        [Display(Name = "How many in serving")]
        public int MenuItemQuantity { get; set; }

        [Display(Name = "Cost of Menu Item")]
        public Single MenuItemCost { get; set; }
        [Display(Name = "Enter Quantity")]

        public int EnterDishes { get; set; }
    }
}