using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;
using MyWeb.ViewModels;

namespace MyWeb.Controllers
{
    public class CustomerController : Controller
    {
        private Models.AppContext _context = new Models.AppContext();
        // GET: Customer
        [Route("Customers")]
        public ActionResult Index()
        {
            var customers = _context.Customers.ToList();

            var viewModel = new RandomMovieViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        [Route("Customers/{id}")]
        public ActionResult Customer(int id)
        {
            var customer = _context.Customers.Where(s => s.Id == id).ToList();
            var viewModel = new RandomMovieViewModel()
            {
                Customers = customer
            };
            return View(viewModel);
        }

        [Route("Customers/New")]
        public ActionResult CustomerForm()
        {
            Customer customer = new Customer();
            return View("CustomerForm",customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm");
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerUpdate = _context.Customers.Find(customer.Id);
                customerUpdate.Name = customer.Name;
                customerUpdate.Email = customer.Email;
                customerUpdate.Age = customer.Age;
                customerUpdate.DateOfBirth = customer.DateOfBirth;
                customerUpdate.Address = customer.Address;
                customerUpdate.Gender = customer.Gender;
                customerUpdate.Hobbies = customer.Hobbies;
            }   
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

        [Route("Customers/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();
            return View("CustomerForm", customer);
        }

        [Route("Customers/Remove/{id}")]
        public ActionResult Remove(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
                return HttpNotFound();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}