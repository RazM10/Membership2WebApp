using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership2WebApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short DiscountRate { get; set; }
    }
}