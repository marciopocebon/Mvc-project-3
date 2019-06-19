using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class ProductoAdminViewModel
    {
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreProducto { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreComun { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionCortaProducto { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionLargaProducto { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Indicaciones { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string Dosis { get; set; }

        public int IdCategoria { get; set; }

        public bool Activo { get; set; }
        public bool Publicar { get; set; }

        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

        public int IdIdioma { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathImg { get; set; }

        public string Presentacion { get; set; }

        public int IdBullet { get; set; }

        public int CodigoMaestro { get; set; }




        public int IdProductoENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreProductoENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string NombreComunENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionCortaProductoENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DescripcionLargaProductoENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string IndicacionesENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string DosisENG { get; set; }

        public int IdCategoriaENG { get; set; }

        public bool ActivoENG { get; set; }
        public bool PublicarENG { get; set; }

        public DateTime FechaCreacionENG { get; set; }
        public string UsuarioCreacionENG { get; set; }
        public DateTime FechaModificacionENG { get; set; }
        public string UsuarioModificacionENG { get; set; }

        public int IdIdiomaENG { get; set; }
        [Required(ErrorMessage = "El campo es necesario")]
        public string PathImgENG { get; set; }

        public string PresentacionENG { get; set; }
        public int IdBulletENG { get; set; }

        public int CodigoMaestroENG { get; set; }
    }
}