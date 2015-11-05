using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SimpleCommand {
    public interface ICustomerValidation {
        bool ValidateCustomer(Customer customer);
    }
}
