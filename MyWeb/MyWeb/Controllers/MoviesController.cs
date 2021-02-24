using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWeb.ViewModels;

namespace MyWeb.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Ravi"
            };

            var customers = new List<Customer>();
            customers.Add(new Customer() { Name = "A", Id = 1 });
            customers.Add(new Customer() { Name = "B", Id = 2 });
            customers.Add(new Customer() { Name = "C", Id = 3 });

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(viewModel);



            //return Content("Hello World!");
            //return RedirectToAction("Index", "Home/About", new { page = 1 });
            //return new EmptyResult();
        }
        public ActionResult Edit(int id)
        {
            return Content("Id = " + id);
        }
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("PageIndex = {0} & SortBy = {1}",pageIndex,sortBy));
        //}
        
        [Route("movies/released/{year:regex(\\d{4}):min(2000):max(2021)}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+" / "+month);
        }

        public ActionResult Index()
        {
            var movies = new List<Movie>();
            movies.Add(new Movie() { Id=1, Name="Movie 1" });
            movies.Add(new Movie() { Id=2, Name="Movie 2" });
            movies.Add(new Movie() { Id=3, Name="Movie 3" });
            movies.Add(new Movie() { Id=4, Name="Movie 4" });
            movies.Add(new Movie() { Id=5, Name="Movie 5" });

            var movieView = new RandomMovieViewModel()
            {
                Movies = movies
            };
            return View(movieView);
        }
    }
}