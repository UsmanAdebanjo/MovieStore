using MovieStore.Models;
using MovieStore.ViewModels;

namespace MovieStore.Repositories
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomers();

        Customer GetCustomer(int id);

        bool AddCustomer(Customer customer);

        bool UpdateCustomer(Customer customerViewModel);
        bool DeleteCustomer(int id);

        IEnumerable<MembershipType> GetMembershipTypes();

    }
}
