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
    public class EtiquetaAdminController : Controller
    {   
        // GET: IdiomaAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexEditar(int? id)
        {
            return View();
        }

        UltimateLabsEntities context = new UltimateLabsEntities();

        //CREATE

        public ActionResult CrearEtiqueta()
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
        public ActionResult CrearEtiqueta(EtiquetasAdminViewModel model, IdiomasAdminViewModel listmodel)
        {
            Etiquetas etiqueta = new Etiquetas()
            {
                CodEtiqueta = model.CodEtiqueta,
                DescripcionEtiqueta = model.DescripcionEtiqueta,
                Valor = model.Valor,
                Activo = true,
                Publicar=true,
                IdIdioma = model.IdIdioma,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = "/",
                UsuarioModificacion = "admin",
            };

            context.Etiquetas.Add(etiqueta);
            context.SaveChanges();

            return RedirectToAction("Index");
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
        public ActionResult ListadoEtiqueta(int? page)
        {

            List<EtiquetasAdminViewModel> etiqueta = new List<EtiquetasAdminViewModel>();
            IPagedList<EtiquetasAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Etiquetas.Where(x => x.Activo == true).OrderBy(x => x.CodEtiqueta).ToList())
            {
                var model = new EtiquetasAdminViewModel()
                {
                    Id = data.Id,
                    CodEtiqueta = data.CodEtiqueta,
                    Valor = data.Valor,
                };


                etiqueta.Add(model);
                lista = etiqueta.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarEtiqueta(int? id)
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

            Etiquetas etiqueta = context.Etiquetas.Find(id); //Tabla de BD

            EtiquetasAdminViewModel etiquetaViewModel = new EtiquetasAdminViewModel()
            {
                Id = etiqueta.Id,
                CodEtiqueta = etiqueta.CodEtiqueta,
                DescripcionEtiqueta = etiqueta.DescripcionEtiqueta,
                Valor = etiqueta.Valor,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = "/",
                UsuarioModificacion = "admin",
                IdIdioma = etiqueta.IdIdioma,
                Publicar = Convert.ToBoolean(etiqueta.Publicar),
            };
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiquetaViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEtiqueta(EtiquetasAdminViewModel model, int id)
        {
            Etiquetas etiqueta = context.Etiquetas.Find(id);

            if (ModelState.IsValid)
            {
                context.Entry(etiqueta).State = EntityState.Modified;
                etiqueta.Id = model.Id;
                etiqueta.CodEtiqueta = model.CodEtiqueta;
                etiqueta.DescripcionEtiqueta = model.DescripcionEtiqueta;
                etiqueta.Valor = model.Valor;
                etiqueta.Publicar = model.Publicar;
                etiqueta.FechaCreacion = DateTime.Now;
                etiqueta.UsuarioCreacion = "admin";
                etiqueta.FechaModificacion = "/";
                etiqueta.UsuarioModificacion = "admin";
                etiqueta.IdIdioma = model.IdIdioma;

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etiqueta);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Etiquetas etiqueta = context.Etiquetas.Find(id);
            if (etiqueta.Activo == true)
            {
                etiqueta.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}