using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProject.Data.Interfaces;
using WebAppProject.Models;

namespace WebAppProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var x = _personRepository.GetById(id);
            return Ok(x);
        }

    }
}
