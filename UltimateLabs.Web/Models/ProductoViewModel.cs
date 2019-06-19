using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class ProductoViewModel
    {
        public int Codigo { get; set; }
        public string NombreProducto { get; set; }
        public string NombreComun { get; set; }

        public string DescripcionCorta { get; set; }
        public string DescripcionLarga { get; set; }
        public string Indicaciones { get; set; }

        public string Dosis { get; set; }
        public int IdCategoria { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public string PathImg { get; set; }


    }
}