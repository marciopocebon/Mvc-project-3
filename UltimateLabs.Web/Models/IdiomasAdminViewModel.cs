using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class IdiomasAdminViewModel
    {
        public int IdIdioma { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Idioma { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Abreviatura { get; set; }
        public string IconPath { get; set; }
        public bool Activo { get; set; }
    }
}