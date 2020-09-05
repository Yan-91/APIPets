﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDePetController : ControllerBase
    {

        //Chamando o Repositorio Pet
        TipoDePetRepository repo = new TipoDePetRepository();
        // GET: api/<TipoDePetController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TipoDePetController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TipoDePetController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TipoDePetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TipoDePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
