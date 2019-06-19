using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class NoticiasAdminViewModel
    {
        public int IdNoticia { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionCorta { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionLarga { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathPortada { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int? IdIdioma { get; set; }
    }
}