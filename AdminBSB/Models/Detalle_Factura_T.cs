//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminBSB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Detalle_Factura_T
    {
        public int id { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public string comenatrio { get; set; }
        public string Ticket { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string telefono { get; set; }
        public string Estado { get; set; }
        public Nullable<int> TipoProducto { get; set; }
        public string TipoServicio { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual TipoProducto TipoProducto1 { get; set; }
    }
}
