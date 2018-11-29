using AdminBSB.Models;
using AdminBSB.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    [Authorize]
    public class DespachoController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Despacho
        public ActionResult Index(string roles)
        {
            var modelo = new DetalleVM();
            if (roles == "DespachardorB")
            {
                var listaPedidos = (from f in db.Detalle_Factura_T
                                    join p in db.Producto on f.IdProducto equals p.id
                                    where f.Estado == "Facturado" && f.TipoProducto == 2
                                    select new DetalleVM()
                                    {
                                        id = f.id,
                                        Nombre_producto = p.Nombre_producto,
                                        Cantidad = f.Cantidad,
                                        Precio = f.Precio,
                                        Comentario = f.comenatrio,
                                        Ticket = f.Ticket,
                                        Estado = f.Estado,
                                        TipoServicio = f.TipoServicio

                                    }).ToList();
                return View(listaPedidos);
            }
            else if (roles == "DespachardorA")
            {
                var listaPedidos = (from f in db.Detalle_Factura_T
                                    join p in db.Producto on f.IdProducto equals p.id
                                    where f.Estado == "Facturado" && f.TipoProducto == 1
                                    select new DetalleVM()
                                    {
                                        id = f.id,
                                        Nombre_producto = p.Nombre_producto,
                                        Cantidad = f.Cantidad,
                                        Precio = f.Precio,
                                        Comentario = f.comenatrio,
                                        Ticket = f.Ticket,
                                        Estado = f.Estado,
                                        TipoServicio = f.TipoServicio

                                    }).ToList();
                return View(listaPedidos);
            }
            else
            {

                var listaPedidos = (from f in db.Detalle_Factura_T
                                    join p in db.Producto on f.IdProducto equals p.id
                                    where f.Estado == "Facturado"
                                    select new DetalleVM()
                                    {
                                        id = f.id,
                                        Nombre_producto = p.Nombre_producto,
                                        Cantidad = f.Cantidad,
                                        Precio = f.Precio,
                                        Comentario = f.comenatrio,
                                        Ticket = f.Ticket,
                                        Estado = f.Estado,
                                        TipoServicio = f.TipoServicio

                                    }).ToList();
                return View(listaPedidos);
            }


        }


        public ActionResult Cambio(int id)
        {

            var factura = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();

            if (factura.Estado == "Facturado")
            {
                factura.Estado = "Despachado";

            }


            db.Entry(factura).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Despacho");
        }


    }
}
