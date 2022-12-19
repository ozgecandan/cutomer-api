using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectDemo.Services.CustomerService;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace projectDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService CustomerService) 
        {
            _customerService = CustomerService;
        }
        
        
        [HttpGet] //bu olmadan swagger düzgün çalışmaz

        public async Task<ActionResult<List<Customer>>> GetAllCustomers() //<List<Customer>> ile proje çalışınca customer'ın schemasını görebiliyoruz.
        {
            
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")] // yukarda bir get methodu daha vardı, ikisi de get olduğu için hangisinin çalışacağı bilinemez hata verir, o yüzden buraya id verdik
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id) 
        {
            var result = _customerService.GetSingleCustomer(id);
            if (result is null)
                return NotFound("Customer not found");

            return Ok(result);
        }

        //Add with POST
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer singleCustomer) 
        {
            var result = _customerService.AddCustomer(singleCustomer);

            return Ok(result);
        }

        // Update with PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(int id, Customer request) 
        {
            var result = _customerService.UpdateCustomer(id, request);
            if (result is null)
                return NotFound("Customer not found");

            return Ok(result);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id) 
        {
            var result = _customerService.DeleteCustomer(id);
            if (result is null)
                return NotFound("Customer not found");

            return Ok(result);
        }

    }
}
