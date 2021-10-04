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
    public class FatalisController : ControllerBase
    {
        public Contexto contexto { get; set; }

        public FatalisController (Contexto novoContexto)
        {
            this.contexto = novoContexto;
        }

        [HttpGet]
        public List<Fatalis> Get()
        {
            return contexto.Fatalises.ToList();
        }


        [HttpGet("{id}")]
        public Fatalis Get(int id)
        {
            return contexto.Fatalises.First(e => e.IdFatalis == id);
        }


        [HttpGet("idFatalis/{idFatalis}")]
        public List<Fatalis> filtrar(int id)
        {
            return contexto.Fatalises.Where(e => e.IdFatalis == id).ToList();
        }


        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<Fatalis>> Create(Fatalis Fatalis)
        {
            Fatalis.IdFatalis = 0;
            contexto.Fatalises.Add(Fatalis);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Fatalis.IdFatalis, Fatalis });
        }


        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Fatalis>> Update(Fatalis Fatalis)
        {
            contexto.Fatalises.Update(Fatalis);
            await contexto.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = Fatalis.IdFatalis, Fatalis });
        }
    }
}
