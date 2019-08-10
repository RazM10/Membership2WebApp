using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Membership2WebApp.Models;

namespace Membership2WebApp.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RDate { get; set; }
        public string ADate { get; set; }
    }
}