using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movie
        public ActionResult Index()
        {

            var movies = _context.Movies
                .Include(m => m.Genre)
                .ToList();
             

            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {

            var movieDetails = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => id == m.MovieId);

            if (movieDetails == null)
                return HttpNotFound();

            return View(movieDetails);
        }
//
//        // GET: Movie/Create
//        public ActionResult Create()
//        {
//            return View();
//        }
//
//        // POST: Movie/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//
//        // GET: Movie/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }
//
//        // POST: Movie/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here
//
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//
//        // GET: Movie/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }
//
//        // POST: Movie/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here
//
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }


            if (movie.MovieId == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
               Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);



        }

        public void Delete(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(movie => id == movie.MovieId);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();


        }
    }
}
