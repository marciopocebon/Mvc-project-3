using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class ConfiguracionesAdminViewModel
    {
        public int IdConfiguracion { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string CodigoConfiguracion { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreConfiguracion { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionConfiguracion { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Valor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Activo { get; set; }
        public int? IdIdioma { get; set; }
        public string PathImg { get; set; }
    }
}