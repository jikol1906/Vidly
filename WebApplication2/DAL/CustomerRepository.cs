using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication2.DTA;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class CustomerRepository : ICustomerRepository
    {

        private ApplicationDbContext _context;


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList();
        }

        public Customer GetCustomerByID(int customerId)
        {
            return _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == customerId);
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }   
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            }

            _context.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = GetCustomerByID(customerId);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }

        public void UpdateCustomer(Customer customer)
        {
            InsertCustomer(customer);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}