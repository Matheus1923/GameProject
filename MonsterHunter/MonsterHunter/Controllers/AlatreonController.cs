using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonsterHunter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlatreonController : ControllerBase
    {
        public Contexto contexto { get; set; }

        public AlatreonController(Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }

        [HttpGet]
        public List<Alatreon> Get()
        {
            return contexto.Alatreons.ToList();
        }


        [HttpGet("{id}")]
        public Alatreon Get(int id)
        {
            return contexto.Alatreons.First(e => e.IdAlatreon == id);
        }


        [HttpGet("idAlatreon/{idAlatreon}")]
        public List<Alatreon> filtrar(int id)
        {
            return contexto.Alatreons.Where(e => e.IdAlatreon == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Alatreon>> Create(Alatreon Alatreon)
        {
            Alatreon.IdAlatreon = 0;
            contexto.Alatreons.Add(Alatreon);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Alatreon.IdAlatreon, Alatreon });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Alatreon>> Update(Alatreon Alatreon)
        {
            contexto.Alatreons.Update(Alatreon);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Alatreon.IdAlatreon, Alatreon });
        }
    }
}
