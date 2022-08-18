using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieStore.Models;
using MovieStore.Repositories;
using MovieStore.ViewModels;
using Newtonsoft.Json;
using System.Text.Json;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _movieRepo;

        public MovieController(IMovieRepo movieRepo)
        {
            _movieRepo=movieRepo;
        }
        public IActionResult Index()
        {
            var genre = _movieRepo.GetGenres();
            var movieViewModel = new MovieViewModel
            {
                Genres = genre
            };

            ViewBag.GenreId = new SelectList(_movieRepo.GetGenres(), "Id", "Name");
            return View(movieViewModel);
        }

        public PartialViewResult MovieFormPartial()
        {
            var genre = _movieRepo.GetGenres();
            var movieViewModel = new MovieViewModel
            {
                Genres = genre
            };

            ViewBag.GenreId = new SelectList(_movieRepo.GetGenres(),"Id","Name");
            return PartialView(movieViewModel);
        }

        public JsonResult Save(Movie movie)
        {

           var result= _movieRepo.AddMovie(movie);

            if (result == 1)
                return Json("Save Succesfully");
            else
                return Json("Movie not saved");
        }

        public  ActionResult GetMovies()
        {
            var movies= _movieRepo.GetMovies().ToList();

            var json = System.Text.Json.JsonSerializer.Serialize(movies);

            var model = JsonConvert.DeserializeObject<List<MovieViewModel>>(json);
            foreach (var movie in model)
            {
                var d =Convert.ToDateTime(movie.DateAdded);
                movie.DateAdded=d.ToString("dd/MM/yyyy");
            }

            return Json(model);
        }
    }
}
