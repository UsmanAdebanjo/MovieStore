using Microsoft.AspNetCore.Mvc;
using MovieStore.Data;
using MovieStore.Models;
using MovieStore.ViewModels;

namespace MovieStore.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddCustomer(Customer customer)
        {
            var exceptionMessage = "";

            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                exceptionMessage =ex.Message;
                return false;
            }

        }

        public bool AddCustomer(CustomerViewModel customerViewModel)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            var customer=_context.Customers.SingleOrDefault(x => x.Id == id);
            
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers=_context.Customers.ToList();

            return customers;
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
           var membershipTypes= _context.MembershipTypes.ToList();

            return membershipTypes;
        }

        public bool UpdateCustomer(Customer customerViewModel)
        {
            throw new NotImplementedException();
        }
        public bool DeleteCustomer(int id)
        {
            var customer=_context.Customers.SingleOrDefault(x => x.Id == id);
            if(customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
