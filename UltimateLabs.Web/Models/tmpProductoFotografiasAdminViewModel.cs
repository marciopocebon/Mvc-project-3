using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UltimateLabs.Web.Models
{
    public class tmpProductoFotografiasAdminViewModel
    {
        public int IdFotografia { get; set; }
        public string PathFoto { get; set; }
        public bool Activo { get; set; }
        public bool Publicar { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int CodigoMaestro { get; set; }
    }
}