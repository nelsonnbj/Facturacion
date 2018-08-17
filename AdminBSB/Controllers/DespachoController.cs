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
    public class DespachoController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Despacho
        public ActionResult Index()
        {
            var modelo = new DetalleVM();

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
        public ActionResult Cambio(int id, string Codigo)
        {

            var chimi = db.Detalle_Factura_T.Where(x => x.id == id).FirstOrDefault();

            if (Codigo == "Despachado")
            {
                chimi.Estado = "Despachado";

            }

            else
            {
                chimi.Estado = "Facturado";
            }

            db.Entry(chimi).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Despacho");
        }

        // GET: Despacho/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Despacho/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     

        // POST: Despacho/Create
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

        // GET: Despacho/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Despacho/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Despacho/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Despacho/Delete/5
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
