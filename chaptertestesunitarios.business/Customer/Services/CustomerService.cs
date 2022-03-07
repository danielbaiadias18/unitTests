using chaptertestesunitarios.business.Customer.Dto;
using chaptertestesunitarios.business.Customer.Models.Request;
using chaptertestesunitarios.infraestructure.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaptertestesunitarios.business.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;


        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public List<CustomerResponse> Get(string legalId)
        {
            if (!IsValidLegalId(legalId)) throw new ArgumentNullException();

            var result = repository.Get(legalId);

            var formattedResult = result.Select(x => (CustomerResponse)x).ToList();

            return formattedResult;
        }

        public void Post(CustomerPostRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentException("Nome Vazio ou Nulo");

            var existCustomerWithName = repository.GetCustomerByName(request.Name);
            if (existCustomerWithName.Any())
            {
                throw new ArgumentException("Existe cliente com o mesmo nome");
            }

            repository.Post((infraestructure.Models.Customer)request);

        }

        private bool IsValidLegalId(string legalId)
        {
            if (string.IsNullOrEmpty(legalId)) throw new ArgumentNullException();

            string formattedLegalId = legalId.Replace(".", "").Replace("-", "");
            return formattedLegalId.Length == 11;
        }
    }
}
