using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Region
    {
        public int idregion { get; set; }

        public string? regionName { get; set; }

        public string? ImagePath { get; set; }


        public ICollection<Pokemon>? Pokemons { get; set; }

    }
}
