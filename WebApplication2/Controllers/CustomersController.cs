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

        private ICustomerRepository _customerContext;
        private IMembershipTypeRepository _membershipTypeContext;

        public CustomersController()
        {
            _customerContext = new CustomerRepository(new ApplicationDbContext());
            _membershipTypeContext = new MemberShipTypeRespository(new ApplicationDbContext());

        }
        
                public ActionResult New()
                {
                    var membershipTypes = _membershipTypeContext.GetMembershipTypes().ToList();
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = new Customer(),
                        MembershipTypes = membershipTypes
                    };
        
                    return View("CustomerForm",viewModel);
                }


        // GET: Customers
        public ActionResult Index()
        {
          
             return View(_customerContext.GetCustomers());
        }

        public ActionResult Details(int id)
        {

            var customer = _customerContext.GetCustomerByID(id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _membershipTypeContext.GetMembershipTypes().ToList()
                };

                return View("CustomerForm", viewModel);

            }


            _customerContext.InsertCustomer(customer);

          

            return RedirectToAction("Index", "Customers");
        }
//
        public ActionResult Edit(int id)
        {
            var customer = _customerContext.GetCustomerByID(id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _membershipTypeContext.GetMembershipTypes().ToList()

            };

            return View("CustomerForm",viewModel);

        }
    }
}