using AdminBSB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    [Authorize]
    public class GastosController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Gastos
        public ActionResult Index()
        {
           
           List<Gastos> gastos = db.Gastos.ToList();
            return View(gastos);
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
            if (ModelState.IsValid)
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

       
        public ActionResult Cuadre()
        {
            var venta = db.Detalle_Factura_T.Select(x => x.Precio).ToList().Sum();
            
            var gastos = db.Gastos_Diario.Select(x => x.Precio).ToList().Sum();
           
        
            ViewBag.Venta = String.Format("{0:#,0.00}", venta );
            ViewBag.Gastos = String.Format("{0:#,0.00}",  gastos);
            ViewBag.Cuadre = String.Format("{0:#,0.00}", venta- gastos);
            return View();
        }

        public ActionResult Cierre()
        {
            db.SP_LimpiarTabla();
            return RedirectToAction("PaginaPrincipal","Facturas");
        }
    }
}
