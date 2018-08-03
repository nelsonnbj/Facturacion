using Facturar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturar.Controllers
{
    public class DetallesController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Detalles
        [HttpGet]
        public ActionResult Detalles(string Codigo = "", string Area="")
        {
           
                List<Factura_Chimi_T> chimi = db.Factura_Chimi_T.Where(x => x.Ticket == Codigo).ToList();
            var total = chimi.Count();
            if (total ==0 && Codigo != "")
            {

                ViewBag.Error = "false";
             
            }

                return View(chimi);
            

           
        }

        [HttpPost]
        // Post: Detalles
        public ActionResult Detalle( int id, string Codigo="")
        {
            var chimi = db.Factura_Chimi_T.Where(x => x.id == id).FirstOrDefault();

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
        public ActionResult Busquedad()
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

        public ActionResult Edit(int id)
        {
            var chimi = db.Factura_Chimi_T.Where(x => x.id == id).FirstOrDefault();
            Factura_Chimi_T producto = new Factura_Chimi_T();

            producto.Producto = chimi.Producto;
            producto.Precio = chimi.Precio;
            producto.comenatrio = chimi.comenatrio;
            producto.Cantidad = chimi.Cantidad;
            producto.nombre = chimi.nombre;
            producto.Ticket = chimi.Ticket;


            return View(producto);
        }

        // POST: Detalles/Edit/5
        [HttpPost]
        public ActionResult Edit(Factura_Chimi_T Factura)
        {
              var modelo = db.Factura_Chimi_T.Where(x => x.id == Factura.id).FirstOrDefault();
            
            try
            {
                modelo.Producto = Factura.Producto;
                modelo.Precio = Factura.Precio;
                modelo.comenatrio =Factura.comenatrio;
                modelo.Cantidad = Factura.Cantidad;
                modelo.nombre = Factura.nombre;
                modelo.Ticket = Factura.Ticket;

                // TODO: Add update logic here
                db.Entry(modelo).State = EntityState.Modified;
                db.SaveChanges();

              
                return RedirectToAction("Detalles",new { Codigo= Factura.Ticket});
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
