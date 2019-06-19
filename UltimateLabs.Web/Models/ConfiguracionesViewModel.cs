using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class ConfiguracionesViewModel
    {
        public int IdConfiguracion { get; set; }
        public string CodigoConfiguracion { get; set; }
        public string NombreConfiguracion { get; set; }
        public string DescripcionConfiguracion { get; set; }
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