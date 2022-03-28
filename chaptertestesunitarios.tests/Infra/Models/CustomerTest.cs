using chaptertestesunitarios.infraestructure.Models;
using System;
using Xunit;

namespace Raizen.OtimizacaoCadastro.Tests.Model
{
    public class CustomerTest
    {
        [Fact]
        public void CreateCustomer_Sucess()
        {
            #region Arrange
            var expectedCustomer = new Customer()
            {
                Id = 0,
                Name = "New",
                LastName = "Customer",
                LegalId = "111.111.111-11"
            };

            var newCustomer = new Customer()
            {
                Id = 0,
                Name = "New",
                LastName = "Customer",
                LegalId = "111.111.111-11"
            };
            #endregion

            #region Assert
            Assert.Equal(expectedCustomer.Id, newCustomer.Id);
            Assert.Equal(expectedCustomer.Name, newCustomer.Name);
            Assert.Equal(expectedCustomer.LastName, newCustomer.LastName);
            Assert.Equal(expectedCustomer.LegalId, newCustomer.LegalId);
            #endregion
        }
    }
}
