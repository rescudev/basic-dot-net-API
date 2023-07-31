

using Microsoft.AspNetCore.Mvc;
using rescunetAPI.Models;
using rescunetAPI.Models.DTO;
using rescunetAPI.Structures;

namespace rescunetAPI.Controllers
{
    [Route("api/rescuAPI")]
    [ApiController]
    public class rescuAPIController : ControllerBase
    {
        [HttpGet(Name = "GetCustomers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult <IEnumerable<CustomerDTO>> GetCustomers() 
        {
            return Ok(CustomerST.customers);
        }

        [HttpGet("{IdCustomer:int}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDTO> GetCustomer(int IdCustomer)
        {
            if (IdCustomer <= 0) 
            {
                return BadRequest();
            }
            CustomerDTO customer = CustomerST.customers.Find(x => x.IdCustomer == IdCustomer);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerDTO> RegisterCustomer([FromBody]CustomerDTO customerDTO)
        {
            if(CustomerST.customers.FirstOrDefault(x => x.UserName == customerDTO.UserName) != null)
            {
                ModelState.AddModelError("DuplicatedError", "The UserName is duplicated.");
                return BadRequest(ModelState);
            }
            
            if (customerDTO == null)
            {
                return BadRequest(customerDTO);
            }
            if(customerDTO.IdCustomer > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            customerDTO.IdCustomer = CustomerST.customers.OrderBy(x => x.IdCustomer).Last().IdCustomer+1;
            CustomerST.customers.Add(customerDTO);

            return CreatedAtRoute("GetCustomer", new { idCustomer = customerDTO.IdCustomer }, customerDTO);
        }

        [HttpDelete("{IdCustomer:int}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteCustomer(int IdCustomer)
        {
            if (IdCustomer <= 0)
            {
                return BadRequest();
            }
            CustomerDTO customer = CustomerST.customers.Find(x => x.IdCustomer == IdCustomer);
            if (customer == null)
            {
                return NotFound();
            }
            CustomerST.customers.Remove(customer);
            return NoContent();
        }

    }

}
