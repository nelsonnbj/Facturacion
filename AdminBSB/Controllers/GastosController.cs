using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    public class GastosController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Gastos
        public ActionResult Index()
        {
            List<Gastos> gastos = db.Gastos.ToList();
            return View(gastos);
        }

        // GET: Gastos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        public ActionResult Create(Gastos gastos)
        {
            try
            {
                Gastos modelo = new Gastos();

                modelo.Nombre = gastos.Nombre;
                modelo.Precio = gastos.Precio;
                modelo.Descripcion = gastos.Descripcion;
                modelo.Fecha = gastos.Fecha;
                db.Gastos.Add(modelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gastos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gastos/Edit/5
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

        // GET: Gastos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gastos/Delete/5
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
