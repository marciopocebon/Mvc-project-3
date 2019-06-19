﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class CarruselAdminViewModel
    {
        public int IdImg { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Frase { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathImg { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int? IdIdioma { get; set; }
        
    }
}