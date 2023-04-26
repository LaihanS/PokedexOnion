using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class SaveTipoViewModel
    {
        public int idtipo { get; set; }

        [Required(ErrorMessage = "Debe colocar el nombre del tipo...")]
        public string tipoName { get; set; }

        [Required(ErrorMessage = "Debe colocar el link del tipo...")]
        public string ImagePath { get; set; }
    }
}
