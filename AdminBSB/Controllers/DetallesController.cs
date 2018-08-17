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
    public class DetallesController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Detalles
        public ActionResult Index(string Codigo = "", string Area = "")
        {

            var modelo = new DetalleVM();

            //var producto = (from f in db.Factura_Chimi_T
            //                     join p in db.Producto on f.IdProducto equals p.id

            //                     select new
            //                     {
            //                        p.Nombre_producto,
            //                        f.Cantidad,
            //                        f.comenatrio,
            //                        f.Ticket,
            //                        f.Estado,


            //                     });
            //var ProductoFormato = producto.Select(S => new
            //{
            //    Nombre = S.Nombre_producto,
            //    Cantidad = S.Cantidad,
            //    Comentario=S.comenatrio,
            //    Ticket=S.Ticket,
            //    Estado=S.Estado

            //}).ToList();
            var listaFactura = (from f in db.Detalle_Factura_T
                                join p in db.Producto on f.IdProducto equals p.id
                                where f.Ticket == Codigo
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

            return View(listaFactura);


            //ViewBag.Detalles = "True";
            //var total = chimi.Count();
            //if (total ==0 && Codigo != "")
            //{

            //    ViewBag.Error = "false";

            //}

            //    return View(ProductoFormato);



        }

        [HttpPost]
        // Post: Detalles
        public ActionResult Detalle(int id, string Codigo = "")
        {
            var chimi = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();

            if (Codigo == "cancelado")
            {
                chimi.Estado = "Cancelado";

            }

            else
            {
                chimi.Estado = "Facturado";
            }

            db.Entry(chimi).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Detalles");
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int id)
        {

            var chimi = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();
            Detalle_Factura_T producto = new Detalle_Factura_T();

            producto.IdProducto = chimi.IdProducto;
            producto.Precio = chimi.Precio;
            producto.comenatrio = chimi.comenatrio;
            producto.Cantidad = chimi.Cantidad;
            producto.nombre = chimi.nombre;
            producto.Ticket = chimi.Ticket;


            return View(producto);
        }

        // POST: Detalles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Detalle_Factura_T Factura)
        {
            var modelo = db.Detalle_Factura_T.Where(x => x.id == Factura.id).FirstOrDefault();

            try
            {
                modelo.IdProducto = Factura.IdProducto;
                modelo.Precio = Factura.Precio;
                modelo.comenatrio = Factura.comenatrio;
                modelo.Cantidad = Factura.Cantidad;
                modelo.nombre = Factura.nombre;
                modelo.Ticket = Factura.Ticket;

                // TODO: Add update logic here
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Detalles", new { Codigo = Factura.Ticket });
            }
            catch
            {
                return RedirectToAction("Detalles", new { Codigo = Factura.Ticket });
            }
        }


        // GET: Detalles/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
