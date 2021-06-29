using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using BasicWebApi.Common;
using BasicWebApi.Contracts.V1;

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
            var domainModel = await _service.GetByName(name);

            if (domainModel == null)
            {
                return NotFound($"Person with name {name} was not found");
            }

            var viewModel = domainModel.ToViewModel();
            return Ok(viewModel); //ternary
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var domainModels = await _service.GetAll();
            var viewModels = domainModels.Select(x => x.ToViewModel());
            return Ok(viewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonCreateModel createModel)
        {
            if (createModel.Age == null || createModel.Age == 0)
            {
                return BadRequest("Cannot create person when property 'age' is null or 0..");
            }

            if (string.IsNullOrEmpty(createModel.Name))
            {
                return BadRequest("Cannot create person when property 'name' is null or empty");
            }

            Console.WriteLine($"Saving {createModel.Name} to the database..");

            var domainModel = createModel.ToDomain();
            var createdPerson = await _service.CreateNewPerson(domainModel);

            if (createdPerson == null)
            {
                return BadRequest("Person can not be created, already exists in database");
            }

            var viewModel = createdPerson.ToViewModel();
            return Ok(viewModel); //ternary
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonUpdateModel updateModel)
        {
            if (updateModel.Age == null || updateModel.Age == 0)
            {
                return BadRequest("Cannot update person when property 'age' is null or 0..");
            }

            if (string.IsNullOrEmpty(updateModel.Name))
            {
                return BadRequest("Cannot update person when property 'name' is null or empty");
            }

            Console.WriteLine($"Updating {updateModel.Name} in the database..");

            var domainModel = updateModel.ToDomain();
            var updatedPerson = await _service.UpdatePerson(domainModel);

            if (updatedPerson == null)
            {
                return NotFound("Person can not be updated, because it does not exist in the database");
            }

            var viewModel = updatedPerson.ToViewModel();
            return Ok(viewModel); //ternary
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

            var viewModel = deletedPerson.ToViewModel();
            return Ok("Deleted"); //ternary
        }
    }
}