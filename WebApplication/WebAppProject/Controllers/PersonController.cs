using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProject.Data.Interfaces;
using WebAppProject.Domain.Interfaces;
using WebAppProject.Models;
using WebAppProject.Models.DTO;

namespace WebAppProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly IPersonManager _personManager;

        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        [HttpGet("persons/getById")]
        public IActionResult GetById(int id)
        {
            var person = _personManager.GetById(id);
            return Ok(person);
        }

        [HttpGet("persons/search")]
        public IActionResult FindByName(string term)
        {
            var person = _personManager.Find(term);
            return Ok(person);
        }
        
        [HttpGet("persons/getListofPersons")]
        public IActionResult GetListOfPersons(int skip, int take)
        {
            var persons = _personManager.GetListOfItems(skip, take);
            return Ok(persons);
        }
        
        [HttpPost("persons/add")]
        public IActionResult Add([FromBody] CreatePersonRequest personDto)
        {
            var id = _personManager.CreateItem(personDto);
            return Ok(id);
        }
        
        [HttpPut("persons/edit")]
        public IActionResult Edit([FromBody] EditPersonRequest personDto)
        {
            var x = _personManager.EditItem(personDto);
            return Ok(x);
        }
        
        [HttpDelete("persons/delete")]
        public IActionResult Delete([FromQuery] int id)
        {
            _personManager.DeleteItem(id);
            return Ok($"Объект с индексом {id} удалён.");
        }

    }
}
