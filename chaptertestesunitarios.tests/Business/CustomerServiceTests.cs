using chaptertestesunitarios.business.Customer.Services;
using chaptertestesunitarios.infraestructure.Customer;
using chaptertestesunitarios.infraestructure.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace chaptertestesunitarios.tests.Business
{
    public class CustomerServiceTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly CustomerService service;

        public CustomerServiceTests()
        {
            this.mockCustomerRepository = new Mock<ICustomerRepository>();
            this.service = new CustomerService(mockCustomerRepository.Object);
        }


        #region Get

        [Fact]
        public void GetCustomer_ValidLegalId()
        {
            // Arrange
            string mockLegalId = "12345678900";
            List<Customer> mockCustomerResult = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    LastName = "Baia",
                    LegalId = "12345678900",
                    Name = "Gabriel"
                }
            };

            mockCustomerRepository.Setup(s => s.Get(It.IsAny<string>())).Returns(mockCustomerResult);

            // Act
            var result = service.Get(mockLegalId);

            // Assert
            Assert.True(result.Count() == 1);
        }

        [Fact]
        public void GetCustomer_InvalidLegalId()
        {
            // Arrange
            string mockLegalId = "123456789001212111";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => service.Get(mockLegalId));
        }

        #endregion
    }
}
