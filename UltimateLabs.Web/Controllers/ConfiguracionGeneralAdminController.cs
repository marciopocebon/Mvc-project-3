using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltimateLabs.Web.DB;
using UltimateLabs.Web.Models;

namespace UltimateLabs.Web.Controllers
{
    [Authorize]
    public class ConfiguracionGeneralAdminController : Controller
    {
        // GET: IdiomaAdmin
        public ActionResult IndexGeneral()
        {
            return View();
        }

        public ActionResult IndexGeneralEditar(int? id)
        {
            return View();
        }

        UltimateLabsEntities context = new UltimateLabsEntities();

        //CREATE

        public ActionResult CrearGeneral()
        {
            IEnumerable<SelectListItem> listaIdioma = context.Idiomas
                .Where(x => x.Activo == true)
                .OrderBy(x => x.IdIdioma)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdIdioma.ToString(),
                     Text = x.Idioma
                 });

            ViewBag.Idioma = listaIdioma;

            return View();
        }
        [HttpPost]
        public ActionResult CrearGeneral(ConfiguracionesAdminViewModel model, HttpPostedFileBase Imagen, IdiomasAdminViewModel listmodel)
        {
            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            Configuraciones configuracion = new Configuraciones()
            {
                CodigoConfiguracion = model.CodigoConfiguracion,
                NombreConfiguracion = model.NombreConfiguracion,
                DescripcionConfiguracion = model.DescripcionConfiguracion,
                Valor = model.Valor,
                FechaCreacion=DateTime.Now,
                UsuarioCreacion="admin",
                FechaModificacion=DateTime.Now,
                UsuarioModificacion="admin",
                Activo = true,
                IdIdioma=model.IdIdioma,
                PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "/",
            };

            context.Configuraciones.Add(configuracion);
            context.SaveChanges();

            return RedirectToAction("IndexGeneral");
        }

        public string SubirArchivo(HttpPostedFileBase file, string ruta)
        {
            string path = "";
            var fileName = "";
            if (file.ContentLength > 0)
            {
                try
                {
                    fileName = Path.GetFileName(file.FileName);
                    path = Path.Combine(Server.MapPath(ruta), fileName);
                    file.SaveAs(path);

                }
                catch { }
            }
            else if (file.ContentLength < 0)
            {
                path = "";
            }
            return fileName;
        }


        //READ
        public ActionResult ListadoGeneral(int? page)
        {

            List<ConfiguracionesAdminViewModel> configuracion = new List<ConfiguracionesAdminViewModel>();
            IPagedList<ConfiguracionesAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Configuraciones.Where(x => x.Activo == true).OrderBy(x => x.IdConfiguracion).ToList())
            {
                var model = new ConfiguracionesAdminViewModel()
                {
                    IdConfiguracion = data.IdConfiguracion,
                    NombreConfiguracion = data.NombreConfiguracion,
                    CodigoConfiguracion = data.CodigoConfiguracion,
                };


                configuracion.Add(model);
                lista = configuracion.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarGeneral(int? id)
        {
                        IEnumerable<SelectListItem> listaIdioma = context.Idiomas
                .Where(x => x.Activo == true)
                .OrderBy(x => x.IdIdioma)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdIdioma.ToString(),
                     Text = x.Idioma
                 });

            ViewBag.Idioma = listaIdioma;

            Configuraciones configuracion = context.Configuraciones.Find(id); //Tabla de BD

            ConfiguracionesAdminViewModel configuracionViewModel = new ConfiguracionesAdminViewModel()
            {
                IdConfiguracion=configuracion.IdConfiguracion,
                CodigoConfiguracion = configuracion.CodigoConfiguracion,
                NombreConfiguracion = configuracion.NombreConfiguracion,
                DescripcionConfiguracion = configuracion.DescripcionConfiguracion,
                Valor = configuracion.Valor,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = DateTime.Now,
                UsuarioModificacion = "admin",
                Activo = true,
                IdIdioma = configuracion.IdIdioma,
                PathImg= configuracion.PathImg
            };
            if (configuracion == null)
            {
                return HttpNotFound();
            }
            return View(configuracionViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarGeneral(ConfiguracionesAdminViewModel model, int id, HttpPostedFileBase Imagen)
        {
            Configuraciones configuracion = context.Configuraciones.Find(id);

            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }

            if (ModelState.IsValid)
            {
                context.Entry(configuracion).State = EntityState.Modified;
                configuracion.IdConfiguracion = model.IdConfiguracion;
                configuracion.CodigoConfiguracion = model.CodigoConfiguracion;
                configuracion.NombreConfiguracion = model.NombreConfiguracion;
                configuracion.DescripcionConfiguracion = model.DescripcionConfiguracion;
                configuracion.Valor = model.Valor;
                configuracion.FechaCreacion = DateTime.Now;
                configuracion.UsuarioCreacion = "admin";
                configuracion.FechaModificacion = DateTime.Now;
                configuracion.UsuarioModificacion = "admin";
                configuracion.PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "";
                configuracion.IdIdioma = model.IdIdioma;

                if (configuracion.PathImg == "/Upload/Productos//")
                {
                    configuracion.PathImg = model.PathImg;
                }

                context.SaveChanges();
                return RedirectToAction("IndexGeneral");
            }
            return View(configuracion);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Configuraciones configuracion = context.Configuraciones.Find(id);
            if (configuracion.Activo == true)
            {
                configuracion.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("IndexGeneral");
        }
    }
}