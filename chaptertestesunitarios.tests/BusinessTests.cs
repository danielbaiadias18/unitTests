using chaptertestesunitarios.infraestructure.Customer;
using System.Collections.Generic;
using Xunit;
using Moq;
using chaptertestesunitarios.business.Customer.Services;
using chaptertestesunitarios.infraestructure.Models;
using System.Linq;
using System;

namespace chaptertestesunitarios.tests
{
    public class BusinessTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly CustomerService service;

        public BusinessTests()
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
                    LastName = "Teste",
                    LegalId = "12345678900",
                    Name = "Testeeee"
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
            string mockLegalId = "1234567890011111111";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => service.Get(mockLegalId));
        }

        #endregion
    }
}
