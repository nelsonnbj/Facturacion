//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facturar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Factura_Chimi_T
    {
        [Key]
        public int id { get; set; }
        public string Producto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> Precio { get; set; }
        public string comenatrio { get; set; }
        public string Ticket { get; set; }
        public string nombre { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string telefono { get; set; }
        public string Estado { get; set; }
        public string TipoProducto { get; set; }
    }
}
