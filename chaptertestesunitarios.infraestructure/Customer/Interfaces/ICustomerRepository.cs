using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaptertestesunitarios.infraestructure.Customer
{
    public interface ICustomerRepository
    {
        List<Models.Customer> Get(string legalId);
    }
}
