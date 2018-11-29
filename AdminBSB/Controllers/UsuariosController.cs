using AdminBSB.Models;
using AdminBSB.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        // GET: Usuarios
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {

                var idUsuarioActual = User.Identity.GetUserId();
                var roleManager = new RoleManager<IdentityRole>
                    (new RoleStore<IdentityRole>(db));

                //Crear Rol

                //var resultado = roleManager.Create(new IdentityRole("Administrador"));

                var userManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(db));

                //Agregar Usuario a rol
                //resultado = userManager.AddToRole(idUsuarioActual, "Administrador");

                //Usuario esta en rol?
                var usuarioEstaRol = userManager.IsInRole(idUsuarioActual, "Administrador");
                var usuarioEstadoRol2 = userManager.IsInRole(idUsuarioActual, "usuario");

                //roles del usuario
                var role = userManager.GetRoles(idUsuarioActual);

                var users = userManager.Users.ToList();
                var userCount = users.Count();
                List<Usuario> usuarios = new List<Usuario>();

                for (int i = 0; i < userCount; i++)
                {
                    var usuario = users[i];
                    var roles = userManager.GetRoles(usuario.Id).FirstOrDefault();
                    var rolesUsuario = "No Role";
                    if (roles != null)
                    {
                        rolesUsuario = roles[0].ToString();
                    }

                    usuarios.Add(new Usuario
                    {
                        Id = usuario.Id,
                        FullName = usuario.FullName,
                        UserName = usuario.UserName,
                        Email = usuario.Email,
                        PhoneNumber = usuario.PhoneNumber,
                        RoleName = rolesUsuario


                    });


                }
                return View(usuarios.ToList());
            }
          
                return RedirectToAction("Login", "Account");
            
       
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
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

        // GET: Usuarios/Edit/5
        public ActionResult Edit(string id)
        {

            var roleManager = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(db));

            var userManager = new UserManager<ApplicationUser>(
                   new UserStore<ApplicationUser>(db));
            //roles del usuario
            var role = roleManager.Roles.ToList();

            var users = userManager.Users.Where(x => x.Id == id).FirstOrDefault();


            var roles = userManager.GetRoles(users.Id);
            var rolesId = "";
            var rolesUsuario = "No Role";
            if (roles.Count() !=0)
            {
                 rolesId = role.Where(x => roles.Contains(x.Name)).Select(x => x.Id).First();
                 rolesUsuario = roles[0].ToString();
            }
            
            Usuario usuario = new Usuario
            {

                FullName = users.FullName,
                UserName = users.UserName,
                Email = users.Email,
                PhoneNumber = users.PhoneNumber,
                RoleName = rolesUsuario,
                RoleId  = rolesId
                
            };

            ViewBag.Roles = new SelectList(role, "id", "Name");
            return View(usuario);

        }



        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario, string role)
        {

            try
            {
                var userManager = new UserManager<ApplicationUser>(
                      new UserStore<ApplicationUser>(db));

                var roleManager = new RoleManager<IdentityRole>
                   (new RoleStore<IdentityRole>(db));

                //var role = roleManager.Roles.ToList();
                //ViewBag.Roles = new SelectList(role, "id", "Name");

                ApplicationUser usuarios = userManager.FindById(usuario.Id);
                {
                    usuarios.PhoneNumber = usuario.PhoneNumber;
                    usuarios.UserName = usuario.UserName;
                    usuarios.Email = usuario.Email;
                    usuarios.FullName = usuario.FullName;

                };

                // TODO: Add update logic here
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();

                if (role != "")
                {
                    //roles del usuario
                    var roles = roleManager.Roles.Where(x => x.Id == role).Select(x => x.Name).FirstOrDefault();

                    //Remover a usuario del rol
                    if (usuario.RoleId =="" || usuario.RoleId !=null)
                    {
                        
                        userManager.RemoveFromRole(usuario.Id, usuario.RoleId);
                    }
                   

                    ////Agregar role a usuario
                    userManager.AddToRole(usuario.Id, roles);
                }
                return RedirectToAction("Index");

               
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuarios/Delete/5
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
             
                var userManager = new UserManager<ApplicationUser>(
               new UserStore<ApplicationUser>(db));
                var users = userManager.Users.Where(x => x.Id == id).FirstOrDefault();

                var roleManager = new RoleManager<IdentityRole>
               (new RoleStore<IdentityRole>(db));
                ///////trae nombre del el rol del usuario////
                var roles = userManager.GetRoles(users.Id).First();
                ///////trae el Id del el rol del usuario////
                var role = roleManager.Roles.Where(x=>x.Name== roles).FirstOrDefault().Id;

                /////Borrar rol del usuario
                userManager.RemoveFromRole(users.Id, role);

                //Borrar Usuario
                var UserVendedor = userManager.FindById(users.Id);
                userManager.Delete(UserVendedor);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CrearRoles(string name)
        {
            string result = "Error!";

            if (name =="")
            {
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
       
            try
            {
                var roleManager = new RoleManager<IdentityRole>
                                       (new RoleStore<IdentityRole>(db));
                var resultado = roleManager.Create(new IdentityRole(name));
                result = "Success!";
                return Json(new { result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                
                return Json(new { result }, JsonRequestBehavior.AllowGet);
                throw;
            }
           
        }
    }
}


