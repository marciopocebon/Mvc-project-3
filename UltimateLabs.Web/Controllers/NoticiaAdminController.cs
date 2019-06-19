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
    public class NoticiaAdminController : Controller
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

        public ActionResult CrearNoticia()
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
        public ActionResult CrearNoticia(NoticiasAdminViewModel model, HttpPostedFileBase Imagen, IdiomasAdminViewModel listmodel)
        {
            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            Noticias noticia = new Noticias()
            {
                Titulo = model.Titulo,
                DescripcionCorta=model.DescripcionCorta,
                DescripcionLarga=model.DescripcionLarga,
                Autor=model.Autor,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = "/",
                UsuarioModificacion = "admin",
                Activo = true,
                Publicar = true,
                IdIdioma = model.IdIdioma,
                PathPortada = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "/",
            };

            context.Noticias.Add(noticia);
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
        public ActionResult ListadoNoticia(int? page)
        {

            List<NoticiasAdminViewModel> noticia = new List<NoticiasAdminViewModel>();
            IPagedList<NoticiasAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Noticias.Where(x => x.Activo == true).OrderBy(x => x.IdNoticia).ToList())
            {
                var model = new NoticiasAdminViewModel()
                {
                    IdNoticia = data.IdNoticia,
                    Titulo = data.Titulo,
                    PathPortada = data.PathPortada,
                };


                noticia.Add(model);
                lista = noticia.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarNoticia(int? id)
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

            Noticias noticia = context.Noticias.Find(id); //Tabla de BD

            NoticiasAdminViewModel noticiaViewModel = new NoticiasAdminViewModel()
            {
                IdNoticia = noticia.IdNoticia,
                Titulo = noticia.Titulo,
                DescripcionCorta=noticia.DescripcionCorta,
                DescripcionLarga= noticia.DescripcionLarga,
                Autor= noticia.Autor,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = DateTime.Now,
                UsuarioModificacion = "admin",
                Activo = true,
                Publicar = Convert.ToBoolean(noticia.Publicar),
                IdIdioma = noticia.IdIdioma,
                PathPortada = noticia.PathPortada
            };
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticiaViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarNoticia(NoticiasAdminViewModel model, int id, HttpPostedFileBase Imagen)
        {
            Noticias noticia = context.Noticias.Find(id);

            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }

            if (ModelState.IsValid)
            {
                context.Entry(noticia).State = EntityState.Modified;
                noticia.IdNoticia = model.IdNoticia;
                noticia.Titulo = model.Titulo;
                noticia.DescripcionCorta = model.DescripcionCorta;
                noticia.DescripcionLarga = model.DescripcionLarga;
                noticia.Autor = model.Autor;
                noticia.FechaCreacion = DateTime.Now;
                noticia.UsuarioCreacion = "admin";
                noticia.FechaModificacion = "/";
                noticia.UsuarioModificacion = "admin";
                noticia.PathPortada = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "";
                noticia.IdIdioma = model.IdIdioma;
                noticia.Publicar = model.Publicar;

                if (noticia.PathPortada == "/Content/Template/Imagenes/Upload//")
                {
                    noticia.PathPortada = model.PathPortada;
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noticia);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Noticias noticia = context.Noticias.Find(id);
            if (noticia.Activo == true)
            {
                noticia.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //READ
        public ActionResult Imagenes(int? id)
        {

            var foto = context.SliderImg.Where(x => x.IdImg == id && x.Activo == true).ToList();

            var lista = new List<CarruselAdminViewModel>();

            if (foto.Count == 0)
            {
                var model = new CarruselAdminViewModel()
                {
                    IdImg = 0,
                    PathImg = "~/Upload/Productos/LogoRepuesto.png",
                    Activo = false,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now
                };


                lista.Add(model);
            }

            foreach (var item in foto)
            {
                if (Convert.ToBoolean(item.Activo))
                {

                    var model = new CarruselAdminViewModel()
                    {
                        IdImg = item.IdImg,
                        PathImg = item.PathImg,
                        Activo = Convert.ToBoolean(item.Activo),
                        FechaCreacion = DateTime.Now,
                        FechaModificacion = DateTime.Now
                    };

                    lista.Add(model);

                }
                else if (item.Activo == false)
                {
                    var model = new CarruselAdminViewModel
                        ()
                    {
                        IdImg = 0,
                        PathImg = "~/Upload/Productos/LogoRepuesto.png",
                        Activo = false,
                        FechaCreacion = DateTime.Now,
                        FechaModificacion = DateTime.Now
                    };


                    lista.Add(model);
                }

            }


            return View(lista);



        }
    }
}