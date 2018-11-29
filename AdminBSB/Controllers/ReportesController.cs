using AdminBSB.Models;
using AdminBSB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();
        // GET: Reportes
        public ActionResult Index()
        {
            var model = new DetalleVM();

            var tipos = db.TipoProducto.ToList();
          

            ViewBag.Tipo = new SelectList(tipos, "id", "Descripcion");
   

            return View();
        }

    

        // GET: Reportes/Create
        public ActionResult CreateReport()
        {
            var model = new ReporteVM();
            return View(model);
        }

        // POST: Reportes/Create
        [HttpPost]
        public ActionResult CreateReport(ReporteVM detalle)
        {
            string UrlreportesActivos = WebConfigurationManager.AppSettings["UrlreportesVenta"];
            string comandosReporte = "&rs:Command=Render&rs:Format=EXCEL";
            try
            {
                      var FF =  detalle.fechaInicial != null ? detalle.fechaInicial.Value.ToString("yyyy-MM-dd") : null;
                      var FI =  detalle.fechaFin != null ? detalle.fechaInicial.Value.ToString("yyyy-MM-dd") : null;
                    var tipo =  detalle.TipoProducto != null ? Convert.ToInt32(detalle.TipoProducto) : 0;
                var producto = detalle.Nombre_producto != null ? Convert.ToInt32(detalle.Nombre_producto) : 0;
                // TODO: Add insert logic here
                //Construye el link del reporte.

                Response.Redirect(string.Format("{0}{1}&{2}={3}&{4}={5}&{6}={7}&{8}={9}",
                    UrlreportesActivos, comandosReporte,
                    "fechaInicial", FI,
                        "fechaFin", FF,
                    "tipoProducto", tipo,
                        "producto", producto

                    //"grupo", String.Join(";", Filtro)

                    ));
                return View(); 
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CreateReportGastos(ReporteVM detalle)
        {
            string UrlreportesActivos = WebConfigurationManager.AppSettings["UrlreportesGastos"];
            string comandosReporte = "&rs:Command=Render&rs:Format=EXCEL";
            try
            {
                var FF = detalle.fechaInicial != null ? detalle.fechaInicial.Value.ToString("yyyy-MM-dd") : null;
                var FI = detalle.fechaFin != null ? detalle.fechaInicial.Value.ToString("yyyy-MM-dd") : null;

                // TODO: Add insert logic here
                //Construye el link del reporte.

                Response.Redirect(string.Format("{0}{1}&{2}={3}&{4}={5}&{6}={7}",
                    UrlreportesActivos, comandosReporte,
                    "fechaIni", FI,
                    "fechaFin", FF,
                      "Nombre", detalle.Nombre_producto
                      

                    //"grupo", String.Join(";", Filtro)

                    ));
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Reportes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reportes/Edit/5
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

        // GET: Reportes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reportes/Delete/5
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
