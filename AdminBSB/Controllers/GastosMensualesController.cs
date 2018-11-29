using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    [Authorize]
    public class GastosMensualesController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: GastosMensuales
        public ActionResult Index()
        {
            List<Invetario> inventario = db.Invetario.ToList();
            return View(inventario);
        }

        // GET: GastosMensuales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GastosMensuales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GastosMensuales/Create
        [HttpPost]
        public ActionResult Create(Invetario inventario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Invetario modelo = new Invetario();

                    modelo.Cantidad = inventario.Cantidad;
                    modelo.Descripcion = inventario.Descripcion;
                    modelo.Fecha = DateTime.Now;
                    modelo.Precio = inventario.Precio;
                    modelo.Producto = inventario.Producto;
                    db.Invetario.Add(modelo);
                    db.SaveChanges();
                    ViewBag.Creado = "true";
                    return View();
                }
                catch
                {
                    ViewBag.Creado = "false";
                    return View();
                }


            }
            ViewBag.Creado = "false";
            return View();
       
    }

        // GET: GastosMensuales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GastosMensuales/Edit/5
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

        // GET: GastosMensuales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GastosMensuales/Delete/5
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
