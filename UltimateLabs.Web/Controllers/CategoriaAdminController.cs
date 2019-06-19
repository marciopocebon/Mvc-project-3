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
    public class CategoriaAdminController : Controller
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

        public ActionResult CrearCategoria()
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
        public ActionResult CrearCategoria(CategoriaAdminViewModel model, HttpPostedFileBase Imagen, HttpPostedFileBase Icono, IdiomasAdminViewModel listmodel)
        {
            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            string pathIcono = "/";
            if (Icono != null)
            {
                pathIcono = SubirArchivo(Icono, "~/Content/Template/Imagenes/Upload");
            }
            Categorias categoria = new Categorias()
            {
                NombreCategoria = model.NombreCategoria,
                DescripcionCategoria = model.DescripcionCategoria,
                Activo = true,
                Publicar = true,
                IdIdioma = model.IdIdioma,
                PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "/",
                IconPath = (pathIcono != "") ? "/Content/Template/Imagenes/Upload/" + pathIcono : "/",
            };

            context.Categorias.Add(categoria);
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
        public ActionResult ListadoCategoria(int? page)
        {

            List<CategoriaAdminViewModel> categoria = new List<CategoriaAdminViewModel>();
            IPagedList<CategoriaAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Categorias.Where(x => x.Activo == true).OrderBy(x => x.IdCategoria).ToList())
            {
                var model = new CategoriaAdminViewModel()
                {
                    IdCategoria = data.IdCategoria,
                    NombreCategoria = data.NombreCategoria
                };

                categoria.Add(model);
                lista = categoria.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarCategoria(int? id)
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

            Categorias categoria = context.Categorias.Find(id); //Tabla de BD

            CategoriaAdminViewModel categoriaViewModel = new CategoriaAdminViewModel()
            {
                IdCategoria = categoria.IdCategoria,
                NombreCategoria = categoria.NombreCategoria,
                DescripcionCategoria = categoria.DescripcionCategoria,
                Activo = true,
                Publicar = Convert.ToBoolean(categoria.Publicar),
                IdIdioma = categoria.IdIdioma,
                PathImg = categoria.PathImg,
                IconPath= categoria.IconPath
            };
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoriaViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCategoria(CategoriaAdminViewModel model, int id, HttpPostedFileBase Imagen, HttpPostedFileBase Icono)
        {
            Categorias categoria = context.Categorias.Find(id);

            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            string pathIcono = "/";
            if (Icono != null)
            {
                pathIcono = SubirArchivo(Icono, "~/Content/Template/Imagenes/Upload");
            }

            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                categoria.IdCategoria = model.IdCategoria;
                categoria.NombreCategoria = model.NombreCategoria;
                categoria.DescripcionCategoria = model.DescripcionCategoria;
                categoria.PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "";
                categoria.IconPath = (pathIcono != "") ? "/Content/Template/Imagenes/Upload/" + pathIcono : "";
                categoria.IdIdioma = model.IdIdioma;
                categoria.Publicar = model.Publicar;

                if (categoria.PathImg == "/Content/Template/Imagenes/Upload//")
                {
                    categoria.PathImg = model.PathImg;
                }

                if (categoria.IconPath == "/Content/Template/Imagenes/Upload//")
                {
                    categoria.IconPath = model.IconPath;
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Categorias categoria = context.Categorias.Find(id);
            if (categoria.Activo == true)
            {
                categoria.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}