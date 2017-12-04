using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using WebApplication2.DAL;
using WebApplication2.DTA;
using WebApplication2.Models;
using WebApplication2.ViewModel;

namespace WebApplication2.Controllers
{
    public class CustomersController : Controller
    {

        private ICustomerRepository _context;

        public CustomersController()
        {
            _context = new CustomerRepository(new ApplicationDbContext());
        }
//
//        public ActionResult New()
//        {
//            var membershipTypes = _context.MembershipType.ToList();
//            var viewModel = new CustomerFormViewModel
//            {
//                Customer = new Customer(),
//                MembershipTypes = membershipTypes
//            };
//
//            return View("CustomerForm",viewModel);
//        }


        // GET: Customers
        public ActionResult Index()
        {
          
             return View(_context.GetCustomers());
        }

//        public ActionResult Details(int id)
//        {
//
//            var customer = _context.Customers
//                .Include(c => c.MembershipType)
//                .SingleOrDefault(c => c.Id == id);
//
//            if (customer == null)
//                return HttpNotFound();
//
//            return View(customer);
//
//        }
//
//
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Save(Customer customer)
//        {
//
//            if (!ModelState.IsValid)
//            {
//                var viewModel = new CustomerFormViewModel
//                {
//                    Customer = customer,
//                    MembershipTypes = _context.MembershipType.ToList()
//                };
//
//                return View("CustomerForm", viewModel);
//
//            }
//
//
//            if (customer.Id == 0)
//            {
//                _context.Customers.Add(customer);
//            }
//            else
//            {
//                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
//                customerInDb.Name = customer.Name;
//                customerInDb.BirthDay = customer.BirthDay;
//                customerInDb.MembershipTypeId = customer.MembershipTypeId;
//                customerInDb.IsSubscribedToNewsLetter= customer.IsSubscribedToNewsLetter;
//
//            }
//
//            _context.SaveChanges();
//
//            return RedirectToAction("Index", "Customers");
//        }
//
//        public ActionResult Edit(int id)
//        {
//            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
//
//            if (customer == null)
//                return HttpNotFound();
//
//            var viewModel = new CustomerFormViewModel
//            {
//                Customer = customer,
//                MembershipTypes = _context.MembershipType.ToList()
//
//            };
//
//            return View("CustomerForm",viewModel);
//
//        }
    }
}