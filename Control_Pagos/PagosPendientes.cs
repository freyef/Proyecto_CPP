//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Control_Pagos
{
    using System;
    using System.Collections.Generic;
    
    public partial class PagosPendientes
    {
        public int IDPago { get; set; }
        public Nullable<int> CodigoAlumno { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
    
        public virtual Alumno Alumno { get; set; }
    }
}