using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class TipoBulletAdminViewModel
    {
        public int IdTipoBullet { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreBullet { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathIcon { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}