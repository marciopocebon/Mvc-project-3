using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class EtiquetasAdminViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string CodEtiqueta { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionEtiqueta { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Valor { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int? IdIdioma { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}