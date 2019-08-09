using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership2WebApp.Models;

namespace Membership2WebApp.Controllers
{
	[AllowAnonymous]
	public class MovieController : Controller
	{
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
		//
		// GET: /Movie/
		public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            var start=new DateTime(2000,1,1);
            var end=new DateTime(2010,12,29);
            var sMovies = from m in movies
                where m.ReleaseDate >= start && m.ReleaseDate <= end
                select m;
            return View(sMovies);
		}

		public ActionResult New()
		{
            return View();
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
        {
            //var n=string.Format("{0:yyyy-MM-dd}", movie.ReleaseDate);
            //movie.ReleaseDate = Convert.ToDateTime(n);
            //var d = DateTime.Now.ToString("yyyy-mm-dd");
            //var d2=movie.ReleaseDate.ToString("yyyy-MM-dd");
            
            movie.AddDate = DateTime.Now;
            
            if (movie.Id == 0)
                _context.Movies.Add(movie);


            _context.SaveChanges();
            //ViewBag.msg = "Save Successful";
            return RedirectToAction("Index", "Movie");
        }
    }
}