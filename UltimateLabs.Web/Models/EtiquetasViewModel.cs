using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class EtiquetasViewModel
    {
        public int IdEtiqueta { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Valor { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int IdIdioma { get; set; }
        
    }
}