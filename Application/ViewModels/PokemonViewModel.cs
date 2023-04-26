using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Core.Domain.Entities;

namespace Pokedex.Core.Application.ViewModels
{
    public class PokemonViewModel
    {
        public int idpoke { get; set; }
        public string name { get; set; }

        public string? description { get; set; }

        public int idtipo { get; set; }

        public string ImagePath { get; set; }

        public string subtipo { get; set; }
        public int idRegion
        {
            get; set;
        }

        public Region Region = new();

        public Tipo Tipo = new();

    }
}