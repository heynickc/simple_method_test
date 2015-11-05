using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommand {
    public class CustomerManagement {
        private readonly ICrmDbContext _db;
        private readonly ICustomerValidation _customerValidation;

        public CustomerManagement(ICrmDbContext db, ICustomerValidation customerValidation) {
            _db = db;
            _customerValidation = customerValidation;
        }
        public void AddNewCustomer(Customer customer) {

            var isValidCustomer = _customerValidation.ValidateCustomer(customer);

            _db.Customers.Add(customer);
            _db.SaveChanges();
        }
    }
}
