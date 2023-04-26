using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pokedex.Core.Domain.Entities
{
    public class Pokemon
    {
        public int idpoke { get; set; }
        public string name { get; set; }

        public string? description { get; set; }

        public int idtipo { get; set; }

        public string? subtipo { get; set; }

        public string ImagePath { get; set; }

        public int idRegion { get; set; }

        public Region? Region { get; set;}

        public Tipo? Tipo { get; set;}
    }
}
