using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

namespace SimpleCommand.Tests {
    public class Implementation {
        [Fact]
        public void Mock_db_save_changes_is_called() {
            var mockCrmDbContext = new Mock<ICrmDbContext>() { 
                DefaultValue = DefaultValue.Mock
            }; 
            var mockCustomerValidation = new Mock<ICustomerValidation>();

            var newCustomer = new Customer() {
                CustomerId = 1,
                CustomerFirstName = "William",
                CustomerLastName = "Wonka",
                CustomerMarket = "Chocolate",
                BillToAddressId = 10,
                ShipToAddressId = 20
            };

            CustomerManagement crm = new CustomerManagement(mockCrmDbContext.Object, mockCustomerValidation.Object);
            crm.AddNewCustomer(newCustomer);

            mockCrmDbContext.Verify(x => x.SaveChanges());
        }
    }

    public class When_salesperson_enters_new_customer {
        [Fact]
        public void Customer_with_empty_market_gets_default_value_1() {
            var mockCrmDbContext = new Mock<ICrmDbContext>();
            var customerValidation = new CustomerValidation();

            string actualCustomerMarket = string.Empty;
            mockCrmDbContext.Setup(x => x.Customers.Add(It.IsAny<Customer>()))
                // Spy on CustomerMarket submitted to DB
                .Callback((Customer c) => actualCustomerMarket = c.CustomerMarket);

            var newCustomer = new Customer() {
                // Salesperson didn't enter the CustomerMarket
                CustomerMarket = String.Empty,
            };

            CustomerManagement crm = new CustomerManagement(mockCrmDbContext.Object, customerValidation);
            crm.AddNewCustomer(newCustomer);
            
            // Verify CustomerMarket = "Default"
            actualCustomerMarket.Should().Be("Default");
        }

        [Fact]
        public void Customer_with_empty_market_gets_default_value() {
            CustomerValidation customerValidation = new CustomerValidation();

            var newCustomer = new Customer() {
                // Salesperson didn't enter the CustomerMarket
                CustomerMarket = String.Empty,
            };

            bool isValidCustomer = customerValidation.ValidateCustomer(newCustomer);

            newCustomer.CustomerMarket.Should().Be("Default");
        }
    }
}
