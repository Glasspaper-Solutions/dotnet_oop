using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return domainModel == null
                ? NotFound($"Person with name {name} was not found")
                : Ok(domainModel.ToViewModel());
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
            var domainModel = createModel.ToDomain();
            var createdPerson = await _service.CreateNewPerson(domainModel);
            return createdPerson == null
                ? BadRequest("Person can not be created, already exists in database")
                : Ok(createdPerson.ToViewModel());
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PersonUpdateModel updateModel)
        {
            var domainModel = updateModel.ToDomain();
            var updatedPerson = await _service.UpdatePerson(domainModel);
            return updatedPerson == null
                ? NotFound("Person can not be updated, because it does not exist in the database")
                : Ok(updatedPerson.ToViewModel());
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var deletedPerson = await _service.DeleteByName(name);
            return deletedPerson == null
                ? NotFound("Person can not be deleted, because it does not exist in the database")
                : Ok(deletedPerson.ToViewModel());
        }
    }
}