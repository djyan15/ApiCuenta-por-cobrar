//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_CuentasxCobrar.Models
{
    using System;
    
    public partial class Transacciones_Consulta_Result
    {
        public int id_Transaccion { get; set; }
        public string TipoDeMovimiento { get; set; }
        public Nullable<int> id_TipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public int NumeroDeDocumento { get; set; }
        public string Fecha { get; set; }
        public Nullable<int> id_Cliente { get; set; }
        public string Nombre { get; set; }
        public decimal Monto { get; set; }
    }
}
