using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Tipo
    {
        public int idtipo { get; set; }

        public string? tipoName { get; set; }

        public string? ImagePath { get; set; }


        public ICollection<Pokemon>? Pokemons { get; set; }
    }
}
