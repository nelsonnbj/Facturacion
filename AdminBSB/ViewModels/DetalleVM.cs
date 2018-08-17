using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminBSB.ViewModels
{
    public class DetalleVM: Producto
    {
        public string Productos { get; set; }
        public int id { get; set; }
        public int Cantidad { get; set; }
        public string Comentario { get; set; }
        public string Ticket { get; set; }
        public string Estado { get; set; }
        public string TipoServicio { get; set; }
        public string Nombre_producto { get; set; }
        public Nullable<int> Precio { get; set; }
        public string TipoProducto { get; set; }
    }
}