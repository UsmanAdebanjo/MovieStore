using Microsoft.AspNetCore.Mvc;
using MovieStore.ViewModels;
using MovieStore.Repositories;
using MovieStore.Data;
using MovieStore.Enryption;
using MovieStore.Models;
using Newtonsoft.Json;

namespace MovieStore.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerRepo _customerRepo;
        public CustomerController(ICustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            var membershipTypes=_customerRepo.GetMembershipTypes();
            var customers=_customerRepo.GetCustomers().ToList();
            var customerViewModel = new CustomerViewModel
            {
                
                MembershipTypes = membershipTypes
            };
            return View(customerViewModel);
        }

        public ActionResult CustomerForm(CustomerViewModel customerViewModel) 
        {
           customerViewModel.MembershipTypes= _customerRepo.GetMembershipTypes();
            //customerViewModel.Customer = new Models.Customer();
            return View(customerViewModel); 
        }

        public PartialViewResult ViewCustomerPartial(int id)
        {
            var customer=_customerRepo.GetCustomer(id);

            var customerViewModel = new CustomerViewModel {
                Customer= customer,
                Name = customer.Name,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter,
                MembershipTypeId = customer.MembershipTypeId,
                BirthDate = customer.BirthDate.Value.ToString("dd/MM/yyyy")
                };
            
            return PartialView(customerViewModel);
        }
        public ActionResult Save(Customer customer)
        {
             _customerRepo.AddCustomer(customer);
            //var decryptValue = Utility.DecryptStringAES(_data);
            //var customerr = JsonConvert.DeserializeObject<Customer>(decryptValue);

            return Ok(customer);
        }

        public ActionResult Create()
        {

           return RedirectToAction("Index");
        }

        public ActionResult GetCustomer()
        {
            var customers = _customerRepo.GetCustomers().ToList();
            var json = System.Text.Json.JsonSerializer.Serialize(customers);
            var model = JsonConvert.DeserializeObject<List<CustomerViewModel>>(json);
            foreach (var customer in model)
            {
                var d = Convert.ToDateTime(customer.BirthDate);
                customer.BirthDate = d.ToString("dd/MM/yyyy");
            }
            return Json(model);
        }

        public ActionResult DeleteCustomer(int id)
        {

            var customerDeleted= _customerRepo.DeleteCustomer(id);

            if (customerDeleted)
                return Ok();

            return BadRequest();

        }

    }
}
