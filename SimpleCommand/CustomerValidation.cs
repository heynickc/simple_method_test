using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommand {
    public class CustomerValidation : ICustomerValidation {
        public bool ValidateCustomer(Customer customer) {
            ValidateCustomerMarket(customer);
            ValidateCustomerLastName(customer);
            ValidateCustomerBillToAddress(customer);
            ValidateCustomerFirstName(customer);

            return true;
        }
        private static void ValidateCustomerFirstName(Customer customer) {
            if (!String.IsNullOrEmpty(customer.CustomerFirstName)
                && customer.CustomerFirstName.Length > 50) {
                customer.CustomerFirstName.Substring(0, 49);
            }
        }
        private static void ValidateCustomerBillToAddress(Customer customer) {
            if (customer.BillToAddressId == null) {
                throw new Exception("Need a BillToAddress");
            }
        }
        private void ValidateCustomerLastName(Customer customer) {
            if (customer.CustomerLastName == "Sleazy") {
                throw new Exception("We don't sell to this guy");
            }
        }
        private void ValidateCustomerMarket(Customer customer) {
            if (customer.CustomerMarket == String.Empty) {
                customer.CustomerMarket = "Default";
            }
        }
    }
}
