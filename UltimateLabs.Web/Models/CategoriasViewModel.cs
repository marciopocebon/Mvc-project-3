using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class CategoriasViewModel
    {
        public int CodCaegoria { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public string PathImg { get; set; }
        public int IdIdioma { get; set; }

        public string PathIcon { get; set; }

    }
}