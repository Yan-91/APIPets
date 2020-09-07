using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPets.Domains;
using APIPets.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacaController : ControllerBase
    {
        //Chamando o Repositorio Pet
        RacaRepository repos = new RacaRepository();
        

        // GET: api/<RacaController>
        [HttpGet]
        public  List<Raca> Get()
        {
            return repos.LerTodos();
        }

        // GET api/<RacaController>/5
        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repos.BuscarPorId(id);
        }

        // POST api/<RacaController>
        [HttpPost]
        public Raca Post([FromBody] Raca d)
        {
            return repos.Cadastrar(d);
        }

        // PUT api/<RacaController>/5
        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca d)
        {
            return repos.Alterar(id, d);
        }

        // DELETE api/<RacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repos.Excluir(id);
        }
    }
}
