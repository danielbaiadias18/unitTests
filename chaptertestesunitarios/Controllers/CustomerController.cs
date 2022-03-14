using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chaptertestesunitarios.business.Customer;
using chaptertestesunitarios.business.Customer.Dto;
using chaptertestesunitarios.business.Customer.Models.Request;

namespace chaptertestesunitarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet("{legalId}")]
        public ActionResult<CustomerResponse> Get(string legalId)
        {
            var result = service.Get(legalId);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(CustomerPostRequest request)
        {
            service.Post(request);
            return Ok();
        }
    }
}
