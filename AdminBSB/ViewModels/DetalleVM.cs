using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminBSB.ViewModels
{
    public class DetalleVM 
    { [Key]
        public int id { get; set; }
        public string Productos { get; set; }       
        public int? Cantidad { get; set; }
        public string Comentario { get; set; }
        public string Ticket { get; set; }
        public string Estado { get; set; }
        public string TipoServicio { get; set; }
        public string Nombre_producto { get; set; }
        public Nullable<int> Precio { get; set; }
        public string TipoProducto { get; set; }
        public DateTime? fechaInicial { get; set; }
        public DateTime? fechaFin { get; set; }
        public Gastos gastos { get; set; }
        //public TipoProducto tipoProducto { get; set; }
        //public List<Producto> producto { get; set; }
        public VentaVM ventaVM { get; set; }
        public List<VentaVM> VentaVMs { get; set; }
    }
}