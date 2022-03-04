using chaptertestesunitarios.business.Customer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaptertestesunitarios.business.Customer
{
    public interface ICustomerService
    {
        List<CustomerResponse> Get(string legalId);
    }
}
