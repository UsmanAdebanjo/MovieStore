using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


    }
}
