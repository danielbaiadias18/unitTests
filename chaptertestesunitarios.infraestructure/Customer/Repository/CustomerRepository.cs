using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaptertestesunitarios.infraestructure.Customer.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public List<Models.Customer> Get(string legalId)
        {
            var list = new List<Models.Customer>()
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

            return list.Where(x => x.LegalId == legalId).ToList();
        }
    }
}
