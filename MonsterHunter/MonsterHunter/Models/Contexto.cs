using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonsterHunter.Models
{
    public class Contexto: DbContext
    {
        public DbSet<Alatreon> Alatreons { get; set; }

        public DbSet<Fatalis> Fatalises { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {


        }
    }
}
