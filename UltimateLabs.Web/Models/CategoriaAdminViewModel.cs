using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class CategoriaAdminViewModel
    {
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreCategoria { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionCategoria { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathImg { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string IconPath { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int? IdIdioma { get; set; }
    }
}