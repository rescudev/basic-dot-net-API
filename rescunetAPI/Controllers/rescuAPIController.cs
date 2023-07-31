

using Microsoft.AspNetCore.Mvc;
using rescunetAPI.Models.DTO;
using rescunetAPI.Structures;

namespace rescunetAPI.Controllers
{
    [Route("api/rescuAPI")]
    [ApiController]
    public class rescuAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers() 
        {
            return CustomerST.customers;
        }

    }
}
