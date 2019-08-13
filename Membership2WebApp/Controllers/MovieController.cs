using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership2WebApp.Models;
using Membership2WebApp.ViewModels;

namespace Membership2WebApp.Controllers
{
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
            return View(movies);
		}

		public ActionResult New()
		{
            Movie movie=new Movie();
            return View(movie);
		}

        public ActionResult Edit(int id)
        {
            Movie movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            return View("New", movie);
        }

		[HttpPost]
		public ActionResult Save(Movie movie)
        {
            //var n=string.Format("{0:yyyy-MM-dd}", movie.ReleaseDate);
            //movie.ReleaseDate = Convert.ToDateTime(n);
            //var d = DateTime.Now.ToString("yyyy-mm-dd");
            //var d2=movie.ReleaseDate.ToString("yyyy-MM-dd");
            if (!ModelState.IsValid)
            {
                return View("New", movie);
            }
            movie.AddDate = DateTime.Now;
            
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                Movie movieInDb = _context.Movies.Single(x => x.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();
            //ViewBag.msg = "Save Successful";
            return RedirectToAction("Index", "Movie");
        }

        public JsonResult SaveJson(string name, string date)
        {
            Movie movie=new Movie()
            {
                Name = name,
                ReleaseDate = Convert.ToDateTime(date),
                AddDate = DateTime.Now
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            //just for show
            var movies = _context.Movies.ToList();

            List<MovieViewModel> movieViewModels=new List<MovieViewModel>();
            foreach (Movie movie1 in movies)
            {
                MovieViewModel movieViewModel=new MovieViewModel()
                {
                    Id = movie1.Id,
                    Name = movie1.Name,
                    RDate = movie1.ReleaseDate.ToString("yyyy-MM-dd"),
                    ADate = movie1.AddDate.ToString("yyyy-MM-dd")
                };
                movieViewModels.Add(movieViewModel);
            }

            return Json(movieViewModels);
        }

        public JsonResult DeleteJson(int id)
        {
            Movie movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb != null)
            {
                _context.Movies.Remove(movieInDb);
                _context.SaveChanges();
            }

            //just for show
            var movies = _context.Movies.ToList();

            List<MovieViewModel> movieViewModels = new List<MovieViewModel>();
            foreach (Movie movie1 in movies)
            {
                MovieViewModel movieViewModel = new MovieViewModel()
                {
                    Id = movie1.Id,
                    Name = movie1.Name,
                    RDate = movie1.ReleaseDate.ToString("yyyy-MM-dd"),
                    ADate = movie1.AddDate.ToString("yyyy-MM-dd")
                };
                movieViewModels.Add(movieViewModel);
            }

            return Json(movieViewModels);
        }

    }
}