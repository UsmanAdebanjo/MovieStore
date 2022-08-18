using MovieStore.Data;

namespace MovieStore.Models
{
    public  class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        public DataSeeder(ApplicationDbContext context)
        {
            _context=context;
        }
        public  void Seed()
        {
            if (!_context.MembershipTypes.Any()) 
            {
                var genres = new List<MembershipType>()
            {
                 new MembershipType
                {
                     Id=1,
                    Name = "Pay as you go",
                    SignUpFee = 0,
                    DiscountRate = 0,
                    DurationInMonth = 0
                },
                new MembershipType
                {
                    Id = 2,
                    Name = "Monthly",
                    SignUpFee = 30,
                    DiscountRate = 5,
                    DurationInMonth = 1
                },
                new MembershipType
                {
                    Id  =3,
                    Name = "Quarterly",
                    SignUpFee = 60,
                    DiscountRate=10,
                    DurationInMonth=3
                },
                new MembershipType
                {
                    Id=4,
                    Name = "Yearly",
                    SignUpFee = 100,
                    DiscountRate = 15,
                    DurationInMonth = 12
                }

            };
                foreach (var genre in genres)
                {
                    _context.MembershipTypes.Add(genre);
                }

                _context.SaveChanges();
            } 


        }
    }
}
