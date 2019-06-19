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
    public class CarruselAdminController : Controller
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

        public ActionResult CrearCarrusel()
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
        public ActionResult CrearCarrusel(CarruselAdminViewModel model, HttpPostedFileBase Imagen, IdiomasAdminViewModel listmodel)
        {
            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            SliderImg carrusel = new SliderImg()
            {
                Frase = model.Frase,
                Titulo = model.Titulo,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = DateTime.Now,
                UsuarioModificacion = "admin",
                Activo = true,
                Publicar=true,
                IdIdioma = model.IdIdioma,
                PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "/",
            };

            context.SliderImg.Add(carrusel);
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
        public ActionResult ListadoCarrusel(int? page)
        {

            List<CarruselAdminViewModel> carrusel = new List<CarruselAdminViewModel>();
            IPagedList<CarruselAdminViewModel> lista;
            lista = null;

            foreach (var data in context.SliderImg.Where(x => x.Activo == true).OrderBy(x => x.IdImg).ToList())
            {
                var model = new CarruselAdminViewModel()
                {
                    IdImg = data.IdImg,
                    Titulo = data.Titulo,
                    PathImg = data.PathImg,
                };


                carrusel.Add(model);
                lista = carrusel.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarCarrusel(int? id)
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

            SliderImg carrusel = context.SliderImg.Find(id); //Tabla de BD

            CarruselAdminViewModel carruselViewModel = new CarruselAdminViewModel()
            {
                IdImg = carrusel.IdImg,
                Frase = carrusel.Frase,
                Titulo = carrusel.Titulo,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                FechaModificacion = DateTime.Now,
                UsuarioModificacion = "admin",
                Activo = true,
                Publicar=true,
                IdIdioma = carrusel.IdIdioma,
                PathImg = carrusel.PathImg
            };
            if (carrusel == null)
            {
                return HttpNotFound();
            }
            return View(carruselViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCarrusel(CarruselAdminViewModel model, int id, HttpPostedFileBase Imagen)
        {
            SliderImg carrusel = context.SliderImg.Find(id);

            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }

            if (ModelState.IsValid)
            {
                context.Entry(carrusel).State = EntityState.Modified;
                carrusel.IdImg = model.IdImg;
                carrusel.Frase = model.Frase;
                carrusel.Titulo = model.Titulo;
                carrusel.FechaCreacion = DateTime.Now;
                carrusel.UsuarioCreacion = "admin";
                carrusel.FechaModificacion = DateTime.Now;
                carrusel.UsuarioModificacion = "admin";
                carrusel.PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "";
                carrusel.IdIdioma = model.IdIdioma;
                carrusel.Publicar = model.Publicar;

                if (carrusel.PathImg == "/Content/Template/Imagenes/Upload//")
                {
                    carrusel.PathImg = model.PathImg;
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrusel);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            SliderImg carrusel = context.SliderImg.Find(id);
            if (carrusel.Activo == true)
            {
                carrusel.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //READ
        public ActionResult Imagenes(int? id)
        {

            var foto = context.SliderImg.Where(x => x.IdImg==id && x.Activo == true).ToList();

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