using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels
{
    public class FilterPokeViewModel
    {
        public int? RegionId { get; set; }

        public string? RegionName { get; set; }
    }
}
