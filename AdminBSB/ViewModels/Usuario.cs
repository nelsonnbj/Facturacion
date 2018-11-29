using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminBSB.ViewModels
{
    public class Usuario
    {
        public string Id { get; set; }
        [Display(Name="Nombre Completo")]
        public string FullName { get; set; }
        [Display(Name = "Usuario")]
        public string UserName { get; set; }
        [Display(Name = "Numero Telefonico")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
        public string RoleId { get; set; }
        [Display(Name = "Roles")]
        public string RoleName { get; set; }
               


    }
}