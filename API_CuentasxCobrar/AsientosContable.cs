//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_CuentasxCobrar
{
    using System;
    using System.Collections.Generic;
    
    public partial class AsientosContable
    {
        public int id_Asiento { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> id_Cliente { get; set; }
        public string Cuenta { get; set; }
        public string TipoDeMovimiento { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
