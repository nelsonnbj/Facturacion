using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminBSB.ViewModels
{
    public class ProductoVM
    {
        public int id { get; set; }
        public string Productos { get; set; }
        public string Tipo_Producto { get; set; }
        public int Cantidad { get; set; }

        public string Comentario { get; set; }
        public string imagen { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int? Precios { get; set; }
        public string Ticket { get; set; }
        public bool? Estado { get; set; }
    }
}