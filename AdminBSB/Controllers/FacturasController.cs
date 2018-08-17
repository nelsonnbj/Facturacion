using AdminBSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    public class FacturasController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Facturas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PantallaPrincipal()
        {
            return View();
        }

        public JsonResult SaveOrder(string name, Detalle_Factura_T[] order, string servicio)
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

                var turno = db.SP_Generar_Turno(name).ToList();

                foreach (var item in order)
                {

                   Detalle_Factura_T Orden = new Detalle_Factura_T();
                    Orden.Cantidad = item.Cantidad;

                    Orden.comenatrio = item.comenatrio;
                    Orden.Precio = item.Precio;
                    Orden.IdProducto = item.IdProducto;
                    Orden.Ticket = turno[0];
                    Orden.fecha = DateTime.Now;
                    Orden.Estado = "Facturado";
                    Orden.TipoProducto = item.TipoProducto;
                    Orden.TipoServicio = servicio;
                    db.Detalle_Factura_T.Add(Orden);

                }


                db.SaveChanges();
                result = "Success! Order Is Complete!";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TiposProducto(string producto)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var Monto = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.Precio).ToList();
            var Tipos = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.TipoProducto).ToList();
            var Id = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.id).ToList();
            return Json(new { Tipos = Tipos, Monto = Monto, id = Id }, JsonRequestBehavior.AllowGet);
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
