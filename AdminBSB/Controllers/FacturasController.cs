using AdminBSB.Models;
using AdminBSB.ViewModels;
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
    public class FacturasController : Controller
    {
        private FacturacionEntities db = new FacturacionEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var producto = new Producto();

            var ImagesChimi = db.Producto.Where(s => s.TipoProducto == 1 && s.Estado == true).ToList();
            var ImagesBurrito = db.Producto.Where(s => s.TipoProducto == 2 && s.Estado == true).ToList();

            ViewBag.ImagesChimi = ImagesChimi;
            ViewBag.ImagesBurrito = ImagesBurrito;
            return View();
        }

        public ActionResult PantallaPrincipal(string layaout = "", string layaouts = "")
        {
            var role = ManejoUsuario();


            var venta = (from d in db.Detalle_Factura_T
                         group new { d.Producto, d } by new
                         {
                             d.Producto.Nombre_producto
                         } into g
                         select new VentaVM
                         {
                             Nombre_producto = g.Key.Nombre_producto,
                             Cantidad = g.Sum(p => p.d.Cantidad),
                             Precio = g.Sum(p => p.d.Precio)
                         }).ToList();

            DetalleVM model = new DetalleVM();
            model.VentaVMs = new List<VentaVM>();
            model.VentaVMs = venta.ToList();

            var gastos = db.Gastos.ToList();

            ViewBag.Role = role;
            ViewBag.venta = venta;
            ViewBag.gastos = gastos;
            if (layaouts == "")
            {
                ViewBag.layaout = layaout;
            }



            var ImagesChimi = db.Producto.Where(s => s.TipoProducto == 1 && s.Estado == true).ToList();
            var ImagesBurrito = db.Producto.Where(s => s.TipoProducto == 2 && s.Estado == true).ToList();

            ViewBag.ImagesChimi = ImagesChimi;
            ViewBag.ImagesBurrito = ImagesBurrito;
            return View(model);
        }

        public JsonResult SaveOrder(string name, Detalle_Factura_T[] order, string servicio)
        {
            var ticket = "";
            string result = "Error! Orden No Completada!";
            if (name != null && order != null)
            {

                try
                {
                    var turno = db.SP_Generar_Turno(name).ToList();
                    ticket = turno[0];
                    foreach (var item in order)
                    {

                        Detalle_Factura_T Orden = new Detalle_Factura_T();
                        Orden.Cantidad = item.Cantidad;

                        Orden.comenatrio = item.comenatrio;
                        Orden.Precio = item.Precio;
                        Orden.IdProducto = item.IdProducto;
                        Orden.Ticket = ticket;
                        Orden.fecha = DateTime.Now;
                        Orden.Estado = "Facturado";
                        Orden.TipoProducto = item.TipoProducto;
                        Orden.TipoServicio = servicio;
                        db.Detalle_Factura_T.Add(Orden);

                    }
                    db.SaveChanges();
                }

                catch
                {


                    result = "Success! Order Is Complete!";
                }
            }
            return Json(new { result, ticket }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult TiposProducto(string producto)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var Monto = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.Precio).ToList();
            var Tipos = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.TipoProducto).ToList();
            var Id = db.Producto.Where(x => x.Nombre_producto == producto).Select(x => x.id).ToList();
            return Json(new { Tipos = Tipos, Monto = Monto, id = Id }, JsonRequestBehavior.AllowGet);
        }

        public String ManejoUsuario()
        {
            var resp = "true";
            if (User.Identity.IsAuthenticated)
            {
                ApplicationDbContext dbs = new ApplicationDbContext();
                var idUsuarioActual = User.Identity.GetUserId();
                var roleManager = new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(dbs));
                var roles = dbs.Roles.ToList().Count();
                if (roles == 0)
                {
                    var resultados = roleManager.Create(new IdentityRole("Administrador"));
                }

                var userManager = new UserManager<ApplicationUser>(
                  new UserStore<ApplicationUser>(dbs));
                var usuarios = dbs.Users.ToList().Count();



                var role = userManager.GetRoles(idUsuarioActual);
                if (role.Count() == 0)
                {
                    if (usuarios == 1)
                    {
                        userManager.AddToRole(idUsuarioActual, "Administrador");
                    }
                    else
                    {
                        //Agregar Usuario a rol
                        var resultado = userManager.AddToRole(idUsuarioActual, "Usuario");
                    }
                    role = userManager.GetRoles(idUsuarioActual);
                }
                resp = role[0].ToString();
                if (resp == "DespachardorB")
                {
                    RedirectDespacho(resp);
                }
                if (resp == "DespachardorA")
                {
                    RedirectDespacho(resp);
                }
            }
            return resp;
        }

        public ActionResult RedirectDespacho(string roles)
        {
            if (roles == "DespachardorB")
            {
                return RedirectToAction("Index", "Despacho", new { roles = roles });
            }

            else
            {
                return RedirectToAction("Index", "Despacho", new { roles = roles });
            }

        }

    }
}
