//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UltimateLabs.Web.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Productos()
        {
            this.PresentacionXProducto = new HashSet<PresentacionXProducto>();
        }
    
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string NombreComun { get; set; }
        public string DescripcionCortaProducto { get; set; }
        public string DescripcionLargaProducto { get; set; }
        public string Indicaciones { get; set; }
        public string Dosis { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<bool> Publicar { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<int> IdIdioma { get; set; }
        public string PathImg { get; set; }
        public string Presentacion { get; set; }
        public Nullable<int> CodigoMaestro { get; set; }
        public Nullable<int> IdTipoBullet { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        public virtual Idiomas Idiomas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresentacionXProducto> PresentacionXProducto { get; set; }
        public virtual TipoBullet TipoBullet { get; set; }
    }
}