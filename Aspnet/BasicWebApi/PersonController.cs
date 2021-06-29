using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BasicWebApi
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : Controller
    {
        private readonly PersonService _service;

        public PersonController(PersonService service)
        {
            _service = service;
        }


        [HttpGet("{name}")]
        public async Task<IActionResult> ReadSingle(string name)
        {
            var person = await _service.GetByName(name);

            if (person == null)
            {
                return NotFound($"Person with name {name} was not found");
            }

            return Ok(person);//ternary
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var data = await _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person payload)
        {
            if (payload.Age == null || payload.Age == 0)
            {
                return BadRequest("Cannot create person when property 'age' is null or 0..");
            }

            if (string.IsNullOrEmpty(payload.Name))
            {
                return BadRequest("Cannot create person when property 'name' is null or empty");
            }

            Console.WriteLine($"Saving {payload.Name} to the database..");

            var createdPerson = await _service.CreateNewPerson(payload);

            if (createdPerson == null)
            {
                return BadRequest("Person can not be created, already exists in database");
            }

            return Ok(createdPerson);//ternary
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person payload)
        {
            if (payload.Age == null || payload.Age == 0)
            {
                return BadRequest("Cannot update person when property 'age' is null or 0..");
            }

            if (string.IsNullOrEmpty(payload.Name))
            {
                return BadRequest("Cannot update person when property 'name' is null or empty");
            }

            Console.WriteLine($"Updating {payload.Name} in the database..");

            var updatedPerson = await _service.UpdatePerson(payload);

            if (updatedPerson == null)
            {
                return NotFound("Person can not be updated, because it does not exist in the database");
            }

            return Ok(updatedPerson);//ternary
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            Console.WriteLine($"Delete {name} in the database..");

            var deletedPerson = await _service.DeleteByName(name);

            if (deletedPerson == null)
            {
                return NotFound("Person can not be deleted, because it does not exist in the database");
            }

            return Ok("Deleted"); //ternary
        }
    }
}