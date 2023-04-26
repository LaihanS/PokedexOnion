
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class SavePokemonViewModel
    {
//        Este formulario debe tener las siguientes validaciones que tanto el nombre,
//como la región, la foto y el tipo primario son campos requeridos
        public int idpoke { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del pookemon...")]
        public string name { get; set; }

        public string description { get; set; }

        [Required(ErrorMessage = "Debe colocar el tipo del pookemon...")]
        public int idtipo { get; set; }

        [Required(ErrorMessage = "Debe colocar la foto del pookemon...")]
        public string? ImagePath { get; set; }

        public string subtipo { get; set; }

        [Required(ErrorMessage = "Debe colocar la región del pookemon...")]
        public int idRegion
        {
            get; set;
        }

       public List<Region> regions  = new();
        public List<Tipo> tipos = new();
    }
}
