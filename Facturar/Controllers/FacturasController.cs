using Facturar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturar.Controllers
{
    public class FacturasController : Controller
    {

        private FacturacionEntities1 db = new FacturacionEntities1();
        // GET: Facturas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuPrincipal()
        {
            return View();
        }
        public JsonResult SaveOrder(string name, string comentario, Factura_Chimi_T[] order, string data)
        {
            string result = "Error! Orden No Completada!";
            if (name != null && order != null)
            {
                //    var cutomerId = Guid.NewGuid();
                //    Factura_Chimi_T model = new Factura_Chimi_T();

                //    model. = order;
                //    model.Name = name;
                //    model.Address = address;
                //    model.OrderDate = DateTime.Now;
                //    db.Customes.Add(model);

                foreach (var item in order)
                {

                    Factura_Chimi_T O = new Factura_Chimi_T();
                    O.Cantidad= item.Cantidad;
                    O.nombre = name;
                    O.comenatrio = item.comenatrio;
                    O.Precio = item.Precio;
                    O.Producto = item.Producto;
                    db.Factura_Chimi_T.Add(O);
                }
                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TiposActivos(string productos)
        {
            db.Configuration.ProxyCreationEnabled = false;
           var Tipos = db.ProductoChimis.Where(x => x.Nombre_producto == productos).Select(x=>x.Precio).ToList();
            return Json(Tipos, JsonRequestBehavior.AllowGet);
        }


        // GET: Facturas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturas/Create
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

        // GET: Facturas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturas/Edit/5
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

        // GET: Facturas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturas/Delete/5
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
