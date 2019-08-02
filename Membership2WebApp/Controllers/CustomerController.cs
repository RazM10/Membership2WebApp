using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Membership2WebApp.Models;
using Membership2WebApp.ViewModels;

namespace Membership2WebApp.Controllers
{
	public class CustomerController : Controller
	{
		private ApplicationDbContext _context;

		public CustomerController()
		{
			_context=new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		//
		// GET: /Customer/
		[Authorize]
		public ActionResult Index()
		{
			//var c = _context.Customers.ToList();
			var c = _context.Customers.Include(x => x.MembershipType).ToList();
			return View(c);
		}

        [Authorize]
		public ActionResult Index_Two()
		{
			return View();
		}


		public ActionResult Linq_test()
		{
			var result = _context.Customers.Where(c => c.MembershipTypeId == 2).ToList();
			var result2 = (from s in _context.Customers 
						   where s.MembershipTypeId == 2
						   select s
						   ).ToList();
			//where s.MembershipTypeId.Equals(2)

			return View(result2);
		}

		public ActionResult Edit(int? id)
		{
			var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
			var viewModel=new CustomerMshipViewModel()
			{
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
			};
			return View("CustomerForm",viewModel);
		}

		public ActionResult New()
		{
			var membershipType = _context.MembershipTypes.ToList();
			var viewModel = new CustomerMshipViewModel()
			{
				Customer = new Customer(),
				MembershipTypes = membershipType
			};
			return View("CustomerForm",viewModel);
		}

		[HttpPost]
		public ActionResult Save(Customer customer)
		{
			if (!ModelState.IsValid)
			{
				var customerViewModel = new CustomerMshipViewModel()
				{
					Customer = customer,
					MembershipTypes = _context.MembershipTypes.ToList()
				};
				return View("CustomerForm", customerViewModel);

			}
			if (customer.Id == 0)
				_context.Customers.Add(customer);
			else
			{
				var customerInDb = _context.Customers.Single(x => x.Id == customer.Id);

				customerInDb.Name = customer.Name;
				customerInDb.MembershipTypeId = customer.MembershipTypeId;
			}

			_context.SaveChanges();
			return RedirectToAction("Index", "Customer");
		}
	}
}