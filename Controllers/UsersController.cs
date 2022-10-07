using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.Serialization;
using System.Text.Json;


namespace vue_dotnet_example.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ILogger<CustomersController> _logger;

        static readonly Models.ICustomerRepository repository = new Models.CustomerRepository();

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/customers")]
        public IEnumerable<Models.CustomerModel> GetAllCustomers()
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/customer")]
        [Consumes("application/json")]
        public Models.CustomerModel AddUser(Models.CustomerModel item)
        {
            return repository.Add(item);
        }


        [HttpGet]
        [Route("api/deletecustomers")]
        public IEnumerable<Models.CustomerModel> DeleteAllCustomers()
        {
            
            return repository.DeleteAll();
        }

        [HttpPost]
        [Route("api/deletecustomer")]
        [Consumes("application/json")]
        public Models.CustomerModel DeleteOne(Models.CustomerModel firstname) {
            return repository.DeleteOne(firstname);

        }


        [HttpPost]
        [Route("api/modifycustomer")]
        [Consumes("application/json")]
        public Models.CustomerModel ModifyCustomer(Models.CustomerModel model)
        {
            
            return repository.Modify(model);
            
        }


        


    }
}
