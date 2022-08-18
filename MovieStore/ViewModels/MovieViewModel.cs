using MovieStore.Models;

namespace MovieStore.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public string DateAdded { get; set; }

        public string DateReleased { get; set; }
        public int NumberInStock { get; set; }

        public int AvailabileInStock { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
