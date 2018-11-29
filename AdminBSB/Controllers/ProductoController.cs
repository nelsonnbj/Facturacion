using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminBSB.Clases;
using AdminBSB.Models;
using AdminBSB.ViewModels;
using PagedList;
namespace AdminBSB.Controllers
{
    [Authorize]

    public class ProductoController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();

        // GET: Producto
        public ActionResult Index( int? page)
        {
            page = (page ?? 1);
            var producto = db.Producto.OrderBy(o=>o.TipoProducto).ToPagedList((int)page,10);

            return View(producto);
        }

        public ActionResult ObtenerDatos()
        {
            var producto = (from p in db.Producto
                            join t in db.TipoProducto on p.TipoProducto equals t.Id select new ProductoVM() {
                id = p.id,
                Productos    = p.Nombre_producto,
                Precios      = p.Precio,
                Tipo_Producto = t.Descripcion,
                imagen       = p.UrlImage,
                Estado       = p.Estado
            }).ToList();
         
            return Json(new { data = producto }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ObtenerProducto(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var productos = db.Producto.Where(x => x.Estado == true && x.TipoProducto == id).ToList();
            /*var data = new SelectList(productos, "id", "Nombre_Producto")*/;
            return Json( productos,  JsonRequestBehavior.AllowGet);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {          

            var listado = db.TipoProducto.ToList();
            ViewBag.Tipo = new SelectList(listado, "id", "Descripcion");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Producto producto, int tipo)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    producto.TipoProducto = tipo;
                    db.Producto.Add(producto);
                    db.SaveChanges();

                    if (producto.ImageFile != null)
                    {
                        var folder = "/Content/Product";
                        var file = string.Format("{0}.jpg", producto.id);
                        var response = FilesHelper.UploadPhoto(producto.ImageFile, folder, file);
                        if (response)
                        {
                            var pic = string.Format("{0}/{1}", folder, file);
                            producto.UrlImage = pic;
                            db.Entry(producto).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                  
                    ViewBag.Creado = "true";
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Creado = "false";
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Creado = "false";
            return RedirectToAction("Index");
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            var tipos = db.TipoProducto.ToList();
            var tipoActual = tipos.Where(x => x.Id == producto.TipoProducto);

            ViewBag.Tipo = new SelectList(tipos, "id", "Descripcion");
            ViewBag.TipoName = tipoActual;

            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Producto producto)
        {
            var resp = "false";
            if (ModelState.IsValid)
            {
                if (producto.ImageFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Product";
                    var file = string.Format("{0}.jpg", producto.id);
                    var response = FilesHelper.UploadPhoto(producto.ImageFile, folder, file);
                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        producto.UrlImage = pic;

                    }
                }
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                resp = "true";
                return Json(resp);
            }
            return Json(resp);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            var EstadoActual = db.Producto.Find(id).Estado.ToString();
            Producto producto = db.Producto.Find(id);
            if (EstadoActual.ToString() == "False")
            {
                producto.Estado = true;
            }
            else
            {
                producto.Estado = false;
            }
          

            db.Entry(producto).State = EntityState.Modified;
            //db.Producto.Remove(producto);
            var resultado= db.SaveChanges();
            return Json(new { ok = resultado > 0, Mensaje = resultado > 0 ? "" : "No fue posible actualizar la acción" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
