using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaptertestesunitarios.business.Customer.Dto
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string LegalId { get; set; }

        public static explicit operator CustomerResponse(infraestructure.Models.Customer v)
        {
            return new CustomerResponse()
            {
                Id = v.Id,
                LastName = v.LastName,
                LegalId = v.LegalId,
                Name = v.LegalId
            };
        }
    }
}
