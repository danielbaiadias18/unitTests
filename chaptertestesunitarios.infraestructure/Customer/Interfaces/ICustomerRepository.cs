using System.Collections.Generic;
using System.Threading.Tasks;

namespace chaptertestesunitarios.infraestructure.Customer
{
    public interface ICustomerRepository
    {
        List<Models.Customer> Get(string legalId);

        void Post(Models.Customer customer);
        IEnumerable<Models.Customer> GetCustomerByName(string name);
    }
}
