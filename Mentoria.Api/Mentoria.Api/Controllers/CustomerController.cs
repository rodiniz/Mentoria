using Mentoria.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Mentoria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> Get()
        {
            // TODO: Implement GET method to retrieve all resources.
            return Ok();
        }


        [HttpGet("{id}")]
        public ActionResult<CustomerDto> Get(int id)
        {
            // TODO: Implement GET method to retrieve a specific resource by ID.
            return Ok();
        }

        // POST api/MyController
        [HttpPost]
        public ActionResult<CustomerDto> Post([FromBody] CustomerDto value)
        {

            return Ok();
        }

        // PUT api/MyController/5
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> Put(int id, [FromBody] CustomerDto value)
        {
            // TODO: Implement PUT method to update a specific resource by ID.
            return Ok();
        }

        // DELETE api/MyController/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            return Ok();
        }
    }

}
}
