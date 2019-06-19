using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class SliderViewModel
    {
        public int Codigo { get; set; }
        public string Frase { get; set; }
        public string PathImg { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int Idioma { get; set; }
        public string Titulo { get; set; }

    }
}