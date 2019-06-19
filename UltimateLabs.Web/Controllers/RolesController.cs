using UltimateLabs.Web.DB;
using UltimateLabs.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PagedList;
using System.IO;

namespace UltimateLabs.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private ApplicationRoleManager _roleManager;


        UltimateLabsEntities context = new UltimateLabsEntities();
        //[Authorize(Roles = "Admin")]
        // GET: Roles
        public ActionResult Index(int? page)
        {

            List<Roles2ViewModel> rol = new List<Roles2ViewModel>();
            IPagedList<Roles2ViewModel> lista;
            lista = null;

            foreach (var data in context.AspNetRoles.OrderBy(x => x.Id).ToList())
            {
                var model = new Roles2ViewModel()
                {
                    Id=data.Id,
                    Name=data.Name
                };

                rol.Add(model);
                lista = rol.ToPagedList(page ?? 1, 10);
            }
            return View(lista);

            //if (cod != null || cod != 0)
            //{
            //    ViewBag.codigo = cod;
            //}
            //var roles = context.AspNetRoles.ToList();
            //RolesViewModel model = new RolesViewModel();
            //foreach (var item in roles)
            //{
            //    var temp = new RolesViewModel(item);
            //    model.Roles.Add(temp);
            //};

            //var elemento = context.AspNetRoles.OrderByDescending(x => x.Id).First();
            //int cont;
            //if (elemento != null)
            //{
            //    cont = int.Parse(elemento.Id);
            //    cont++;
            //    ViewBag.contador = cont;
            //}
            //else
            //{
            //    cont = 1;
            //    ViewBag.contador = cont;
            //}


            //return View(model);
        }

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _roleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }

        }



        public ActionResult CreandoRol()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreandoRol(RolesViewModel model)
        {

            var role = new IdentityRole { Name = model.Name };
            //var result = await this.Request.GetOwinContext().GetUserManager<ApplicationRoleManager>().CreateAsync(role);
            var result = await this.AppRoleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Roles");
            }

            //if (ModelState.IsValid)
            //{
            //    AspNetRoles Rol = new AspNetRoles()
            //    {
            //        Id = rol.Id,
            //        Name = rol.Name,
            //    };
            //    context.AspNetRoles.Add(Rol);
            //    context.SaveChanges();
            //}
            //return RedirectToAction("CreandoRol");
        }


        public ActionResult EditandoRol(string id)
        {
            AspNetRoles rol = context.AspNetRoles.FirstOrDefault(x => x.Id == id ); //Tabla de BD

            RolesViewModel rolViewModel = new RolesViewModel()
            {
                Id = rol.Id,
                Name = rol.Name
            };


            return View(rolViewModel);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditandoRol(RolesViewModel rol)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (rol.Id == "d3ed6b54-fc9e-4dee-9787-9f78ecb37cab")
                    {
                        throw new Exception();
                    }
                    var Roles = context.AspNetRoles.FirstOrDefault(x => x.Id == rol.Id);
                    context.AspNetRoles.Attach(Roles); // State = Unchanged
                    Roles.Name = rol.Name;  // State = Modified, and only the FirstName property is dirty.
                    context.SaveChanges();
                }
                catch
                {
                    return RedirectToAction("Index", new { cod = 1 });
                }

            }
            return RedirectToAction("Index");
        }
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        public ActionResult Inactivar(string id)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
            try
            {
                if (id == "d3ed6b54-fc9e-4dee-9787-9f78ecb37cab")
                {
                    throw new Exception();
                }
                //var Role = new AspNetRoles { Id = rol.Id };
                AspNetRoles rol = context.AspNetRoles.FirstOrDefault(x => x.Id == id);
                context.Entry(rol).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", new { cod = 1 });
                //PseudoCodigo/Chvrli3
            }


            return RedirectToAction("Index");
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Asignar()
        {
            var model = new AsignarUserModel();
            var usuarios = context.AspNetUsers.ToList();


            var roles = context.AspNetRoles.ToList();

            ViewBag.listRoles = roles;

            foreach (var item in usuarios)
            {
                var rol = UserManager.GetRoles(item.Id);

                var temp = new AsignarUserModel()
                {
                    Id = item.Id,
                    Name = item.UserName,
                    NameRol = rol.FirstOrDefault(),
                };
                model.Usuarios.Add(temp);
            }

            return View(model);
        }


        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Asignando(AsignarUserModel model)
        {
            var roles = context.AspNetRoles.ToList();
            List<string> roleslistado = new List<string>();
            string rol = "";

            foreach (var item in roles)
            {
                if (item.Id != model.IdRol)
                {
                    roleslistado.Add(item.Name);
                }
                else
                {
                    rol = item.Name;
                }
            }
            String[] rollistado = roleslistado.ToArray();

            var roleresult = UserManager.RemoveFromRoles(model.Id, rollistado);

            var roleresults = UserManager.AddToRole(model.Id, rol);


            return RedirectToAction("Asignar", "Roles");
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Resetear(AsignarUserModel model)
        {
            Session["Username"] = context.AspNetUsers.FirstOrDefault(x => x.Id == model.Id).UserName;

            string code = await UserManager.GeneratePasswordResetTokenAsync(model.Id);
            return RedirectToAction("ResetPassword", "Account", new { userId = model.Id, code = code });
        }

    }
}
