using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Membership2WebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Range(1,10)]
        [Required]
        public string Name { get; set; }
        
        //version4
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Select Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}