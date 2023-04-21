
using AutoMapper;
using Mentoria.Application;
using Mentoria.Application.Dtos;
using Mentoria.Domain;
using Microsoft.AspNetCore.Mvc;
using OneOf;

namespace Mentoria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICrudService<Customer> _customerService;
        private readonly IMapper _mapper;      

        public CustomerController(ICrudService<Customer> customerService,IMapper mapper)
        {
            _customerService= customerService;
             _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var customers = await _customerService.GetAll();
            return Ok(_mapper.Map<List<CustomerDto>>(customers));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var result=await _customerService.GetAsync(id);
            return Ok(_mapper.Map<CustomerDto>(result));
        }

        // POST api/MyController
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CustomerDto value)
        {
            var  createUserResult= await _customerService.Create(_mapper.Map<Customer>(value));
            return createUserResult.Match<IActionResult>(
                customer => Created(string.Empty,customer),
                validationResult => BadRequest(validationResult.Errors));
            
        }

        // PUT api/MyController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDto value)
        {
           var  updatedResult= await _customerService.UpdateAsync(_mapper.Map<Customer>(value));
           
           return updatedResult.Match<IActionResult>(
                customer => Ok(_mapper.Map<CustomerDto>(customer) ),
                _ => NotFound(),
                validationResult => BadRequest(validationResult.Errors));
        }

        // DELETE api/MyController/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _customerService.Delete(id);
            return Ok();
        }
    }

}

