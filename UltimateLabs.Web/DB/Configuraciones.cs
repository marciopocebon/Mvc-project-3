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
    
    public partial class Configuraciones
    {
        public int IdConfiguracion { get; set; }
        public string CodigoConfiguracion { get; set; }
        public string NombreConfiguracion { get; set; }
        public string DescripcionConfiguracion { get; set; }
        public string Valor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> IdIdioma { get; set; }
        public string PathImg { get; set; }
    
        public virtual Idiomas Idiomas { get; set; }
    }
}
