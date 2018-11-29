using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminBSB.ViewModels
{
    public class VentaVM
    {
        public string Nombre_producto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }

    }
}