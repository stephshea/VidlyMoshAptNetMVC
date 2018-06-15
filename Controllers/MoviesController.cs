using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using VidlyMosh.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VidlyMosh.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        //public ViewResult Random()
        {
            var movie = new Movie() { Name = "Chef" };

            //inherited method from base Controller class
            //Action Results examples
            //could use return new ViewResult();
            return View(movie);
            //return Content("Good morning Abby!");
            //return HttpNotFound(); -- didn't work
            // return new EmptyResult(); -- blank page
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        [Route("movies/released/{year}/{month:regex(\\d{4});range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        //int? makes index nullable
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}
