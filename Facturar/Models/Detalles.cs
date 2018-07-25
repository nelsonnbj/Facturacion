using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Facturar.Models
{
    public class Detalles
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
    }
}