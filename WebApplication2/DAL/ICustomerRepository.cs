using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.DTA
{
       public interface ICustomerRepository : IDisposable
        {
            IEnumerable<Customer> GetCustomers();
            Customer GetCustomerByID(int customerId);
            void InsertCustomer(Customer customer);
            void DeleteCustomer(int customerId);
            void UpdateCustomer(Customer customer);
            void Save();
        }
    
}