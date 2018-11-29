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
    public class DetallesController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Detalles
        public ActionResult Index()
        {

            return View();

        }

        public ActionResult Datos()
        {
            var listaFactura = (from f in db.Detalle_Factura_T
                                join p in db.Producto on f.IdProducto equals p.id
                                select new DetalleVM()
                                {
                                    id = f.id,
                                    Nombre_producto = p.Nombre_producto,
                                    Cantidad = f.Cantidad,
                                    Precio = f.Precio,
                                    Comentario = f.comenatrio,
                                    Ticket = f.Ticket,
                                    Estado = f.Estado

                                }).ToList();

            var estado = listaFactura.Select(s => s.Estado).ToList();
            return Json(new { data = listaFactura, estado }, JsonRequestBehavior.AllowGet);

        }

        // Post: Detalles
        [HttpPost]
        public ActionResult Detalle(int id)
        {
            var resp = false;
            var chimi = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();
            try
            {
                if (chimi.Estado == "Cancelado")
                {
                    chimi.Estado = "Facturado";

                }

                else
                {
                    chimi.Estado = "Cancelado";
                }

                db.Entry(chimi).State = EntityState.Modified;
                db.SaveChanges();
                resp = true;
            }
            catch (Exception)
            {

                throw;
            }
        

            return Json(resp);
        }

   
        // GET: Detalles/Edit/5
        public ActionResult Edit(int id)
        {

            var chimi = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();
            ProductoVM producto = new ProductoVM();

            var product = db.Producto.Where(x => x.id == chimi.IdProducto).Select(x=>x.Nombre_producto).FirstOrDefault();
            producto.Productos = product;
            producto.Precio = chimi.Precio;
            producto.Comentario = chimi.comenatrio;
            producto.Cantidad = chimi.Cantidad;
            producto.Nombre = chimi.nombre;
            producto.Ticket = chimi.Ticket;

            var tipoProducto = db.Producto.ToList();

            ViewBag.tipoProducto = new SelectList(tipoProducto, "id", "Nombre_producto");
            return View(producto);
        }

        // POST: Detalles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductoVM Factura)
        {
            var resp = "false";
            if (ModelState.IsValid)
            {

            
            var factura = db.Detalle_Factura_T.Where(x => x.id == Factura.id).FirstOrDefault();
            Detalle_Factura_T modelo = new Detalle_Factura_T();
         

            try
            {
                factura.IdProducto = Convert.ToInt32(Factura.Productos) == 0 ? factura.IdProducto : Convert.ToInt32(Factura.Productos);
                factura.Precio = Factura.Precio == 0 ? factura.Precio : Factura.Precio;
                factura.comenatrio = Factura.Comentario == null ? factura.comenatrio : factura.comenatrio;
                factura.Cantidad = Factura.Cantidad == 0 ? factura.Cantidad : Factura.Cantidad;


                // TODO: Add update logic here
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                resp = "true";
          
                return Json(resp);

            }
            catch (Exception)
            {

                    return Json(resp);
                    throw;
            }
               
            }
            return Json(resp);
        }


        // POST: Detalles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
