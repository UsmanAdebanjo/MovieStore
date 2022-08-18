using MovieStore.Models;

namespace MovieStore.Repositories
{
    public interface IMovieRepo
    {
        IEnumerable<Genre> GetGenres();
        public IEnumerable<Movie> GetMovies();
        int AddMovie(Movie movie);
    }
}