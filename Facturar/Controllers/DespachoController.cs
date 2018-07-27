using Facturar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturar.Controllers
{
    public class DespachoController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Despacho
        public ActionResult Index()
        {

            List<Factura_Chimi_T> chimi = db.Factura_Chimi_T.Where(x=> x.Estado =="Facturado").ToList();
            var total = chimi.Count();
         
        

            return View(chimi);
        }

        // GET: Despacho/Details/5
        public ActionResult Cambio(int id, string Codigo)
        {

            var chimi = db.Factura_Chimi_T.Where(x => x.id == id).FirstOrDefault();

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
