using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persons;

namespace WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("{term?}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Person>> Get(string term = "")
        {
            var query = new GetPersonQuery(term);
            query.Execute();
            if (!query.GetResult().Succeeded)
            {
                return BadRequest("The request for Persons failed.");
            }

            var result = query.GetResult() as GetPersonResult;

            if (result.Persons.Count == 0)
            {
                return NoContent();
            }

            return Ok(result.Persons);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Person> Post(CreatePersonModel model)
        {
            var command = model.ToCommand();
            command.Execute();
            if (!command.GetResult().Succeeded)
            {
                return BadRequest("Could not create a Person");
            }

            var result = command.GetResult() as CreatePersonResult;

            return CreatedAtAction(nameof(Post), result.Person);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Person> Put(UpdatePersonModel model)
        {
            var command = model.ToCommand();
            command.Execute();
            if (!command.GetResult().Succeeded)
            {
                return BadRequest("Could not update a Person");
            }

            var result = command.GetResult() as UpdatePersonResult;

            return Ok(result.Person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Person> Delete(int id)
        {
            var command = new DeletePersonCommand(id);
            command.Execute();
            if (!command.GetResult().Succeeded)
            {
                return BadRequest("Could not delete a person");
            }

            var result = command.GetResult() as DeletePersonResult;

            return Ok(result.Person);
        }
    }
}
