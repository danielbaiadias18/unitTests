using chaptertestesunitarios.business.Customer.Dto;
using chaptertestesunitarios.business.Customer.Models.Request;
using chaptertestesunitarios.business.Customer.Services;
using chaptertestesunitarios.Controllers;
using chaptertestesunitarios.infraestructure.Customer;
using chaptertestesunitarios.infraestructure.Models;
using chaptertestesunitarios.tests.Controller.EqualityComparer;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace chaptertestesunitarios.tests.Controller
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerRepository> mockCustomerRepository;
        private readonly CustomerService service;
        private readonly CustomerController controller;

        public CustomerControllerTests()
        {
            this.mockCustomerRepository = new Mock<ICustomerRepository>();
            this.service = new CustomerService(mockCustomerRepository.Object);
            this.controller = new CustomerController(this.service);
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
                    Name = "Daniel"
                }
            };

            List<CustomerResponse> mockCustomerResponse = new List<CustomerResponse>()
            {
                (CustomerResponse)mockCustomerResult.First()
            };

            mockCustomerRepository.Setup(s => s.Get(It.IsAny<string>())).Returns(mockCustomerResult);

            // Act
            var actionResult = controller.Get(mockLegalId);

            var result = actionResult.Result as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int?)HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(mockCustomerResponse,(result.Value as List<CustomerResponse>), new CustomerResponseComparer());
        }

        [Fact]
        public void GetCustomer_InvalidLegalId()
        {
            // Arrange
            string mockLegalId = "123456789001212";

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => controller.Get(mockLegalId));
        }

        #endregion

        #region Post
        [Fact]
        public void PostCustomer_ValidLegalId()
        {
            //Arrange
            List<Customer> mockCustomerResult = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    LastName = "Souza",
                    LegalId = "12345478900",
                    Name = "Luciano"
                }
            };

            mockCustomerRepository.Setup(s => s.Get(It.IsAny<string>())).Returns(mockCustomerResult);

            var mockLegalCustomer = new CustomerPostRequest()
            {
                Id = 1,
                LastName = "Baia",
                LegalId = "12345678900",
                Name = "Daniel"
            };

            //Act
            var result = controller.Post(mockLegalCustomer);
            var okAccountStatement = result as OkResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal((int?)HttpStatusCode.OK, okAccountStatement.StatusCode);
        }
        #endregion
    }
}
