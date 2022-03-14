using chaptertestesunitarios.business.Customer.Dto;
using chaptertestesunitarios.infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace chaptertestesunitarios.tests.Controller.EqualityComparer
{
    internal sealed class CustomerResponseComparer : IEqualityComparer<CustomerResponse>
    {
        bool IEqualityComparer<CustomerResponse>.Equals(CustomerResponse expected, CustomerResponse current)
        {
            return expected.Id == current.Id
               && expected.LegalId == current.LegalId
               && expected.Name == current.Name
               && expected.LastName == current.LastName;
        }

        int IEqualityComparer<CustomerResponse>.GetHashCode(CustomerResponse obj)
        {
            throw new NotImplementedException();
        }
    }
}
