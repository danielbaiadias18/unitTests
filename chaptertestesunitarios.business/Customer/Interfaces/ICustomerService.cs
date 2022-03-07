using chaptertestesunitarios.business.Customer.Dto;
using chaptertestesunitarios.business.Customer.Models.Request;
using System.Collections.Generic;

namespace chaptertestesunitarios.business.Customer
{
    public interface ICustomerService
    {
        List<CustomerResponse> Get(string legalId);
        void Post(CustomerPostRequest request);
    }
}
