using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class RolesViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre del Rol")]
        public string Name { get; set; }

        public List<RolesViewModel> Roles { get; set; }

        public RolesViewModel()
        {
            Roles = new List<RolesViewModel>();
        }

        public RolesViewModel(DB.AspNetRoles rol)
        {
            Id = rol.Id;
            Name = rol.Name;
            Roles = new List<RolesViewModel>();
        }
    }

    public class AsignarUserModel
    {
        [Required]
        [Display(Name = "ID")]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre del Usuario")]
        public string Name { get; set; }
        public List<AsignarUserModel> Usuarios { get; set; }

        [Required]
        [Display(Name = "Id")]
        public string IdRol { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nombre del Rol")]
        public string NameRol { get; set; }


        public AsignarUserModel()
        {
            Usuarios = new List<AsignarUserModel>();
        }
    }
}