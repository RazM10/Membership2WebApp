using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Membership2WebApp.Models;

namespace Membership2WebApp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select Membership Type")]
        public int MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}