using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class Roles2ViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre del Rol")]
        public string Name { get; set; }
    }
}