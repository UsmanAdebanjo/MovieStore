using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        public DateTime DateReleased { get; set; }

        public int NumberInStock { get; set; }

        public int AvailabileInStock { get; set; }

    }
}
