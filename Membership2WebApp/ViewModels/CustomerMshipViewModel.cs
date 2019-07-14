using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Membership2WebApp.Models;

namespace Membership2WebApp.ViewModels
{
    public class CustomerMshipViewModel
    {
        public Customer Customer { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}