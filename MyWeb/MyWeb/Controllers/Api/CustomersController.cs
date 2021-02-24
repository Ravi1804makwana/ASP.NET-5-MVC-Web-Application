using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using MyWeb.Models;

namespace MyWeb.Controllers.Api
{
    [Route("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly AppContext _context;
        public CustomersController()
        {
            _context = new AppContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.SingleOrDefault(s => s.Id == id);
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            customerFromDb.Name = customer.Name;
            customerFromDb.Email = customer.Email;
            customerFromDb.DateOfBirth = customer.DateOfBirth;
            customerFromDb.Address = customer.Address;
            customerFromDb.Hobbies = customer.Hobbies;
            customerFromDb.Gender = customer.Gender;

            _context.Customers.Update(customerFromDb);
            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerFromDb = _context.Customers.Find(id);

            if (customerFromDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Customers.Remove(customerFromDb);
            _context.SaveChanges();
        }
    }
}
