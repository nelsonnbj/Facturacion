using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminBSB.Models
{
    public class Permisos
    {

    //    public ActionResult ManejoUsuario()
    //    {
    //        var resp = "true";
    //        if (User.Identity.IsAuthenticated)
    //        {
    //            ApplicationDbContext dbs = new ApplicationDbContext();
    //            var idUsuarioActual = User.Identity.GetUserId();
    //            var roleManager = new RoleManager<IdentityRole>
    //                (new RoleStore<IdentityRole>(dbs));
    //            var roles = dbs.Roles.ToList().Count();
    //            if (roles == 0)
    //            {
    //                var resultados = roleManager.Create(new IdentityRole("Administrador"));
    //            }

    //            var userManager = new UserManager<ApplicationUser>(
    //              new UserStore<ApplicationUser>(dbs));
    //            var usuarios = dbs.Users.ToList().Count();



    //            var role = userManager.GetRoles(idUsuarioActual);
    //            if (role.Count() == 0)
    //            {
    //                if (usuarios == 1)
    //                {
    //                    userManager.AddToRole(idUsuarioActual, "Administrador");
    //                }
    //                else
    //                {
    //                    //Agregar Usuario a rol
    //                    var resultado = userManager.AddToRole(idUsuarioActual, "Usuario");
    //                }

    //            }

    //        }
    //        return Json(resp);
    //    }
    }
}