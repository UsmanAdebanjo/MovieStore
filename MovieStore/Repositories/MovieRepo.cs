using Microsoft.EntityFrameworkCore;
using MovieStore.Data;
using MovieStore.Models;

namespace MovieStore.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private readonly ApplicationDbContext _context;
        public MovieRepo(ApplicationDbContext context)
        {
            _context = context;

        }

        public IEnumerable<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }

        public int AddMovie(Movie movie)
        {
            int success = 0;
            string message = "";
            try
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                success = 1;
            }
            catch (Exception exMessage)
            {
                message = exMessage.Message.ToString();
                throw;
            }
            return success;

        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.Include(c=>c.Genre).ToList();
        }
    }
}
