using MovieStore.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.ViewModels
{
    [NotMapped]
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }
        public string BirthDate { get; set; }
        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}
