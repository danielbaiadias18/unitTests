using chaptertestesunitarios.business.Customer.Dto;
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

        private bool IsValidLegalId(string legalId)
        {
            if (string.IsNullOrEmpty(legalId)) throw new ArgumentNullException();
            
            string formattedLegalId = legalId.Replace(".", "").Replace("-", "");
            return formattedLegalId.Length == 11;
        }
    }
}
