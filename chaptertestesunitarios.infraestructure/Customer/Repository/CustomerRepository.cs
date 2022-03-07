using System.Collections.Generic;
using System.Linq;

namespace chaptertestesunitarios.infraestructure.Customer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Models.Customer> list;

        public CustomerRepository()
        {
            list = new List<Models.Customer>()
            {
                new Models.Customer()
                {
                    Id = 1,
                    LastName = "Silva",
                    LegalId = "12345678900",
                    Name = "Luizinho"
                },
                new Models.Customer()
                {
                    Id = 2,
                    LastName = "Figueiredo",
                    LegalId = "45600078904",
                    Name = "José"
                }
            };
        }
        public List<Models.Customer> Get(string legalId)
        {
            return list.Where(x => x.LegalId == legalId).ToList();
        }

        public void Post(Models.Customer customer)
        {
            list.Add(customer);
        }

        public IEnumerable<Models.Customer> GetCustomerByName(string name)
        {
            return list.Where(e => e.Name.Equals(name));
        }
    }
}
