using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltimateLabs.Web.DB;
using UltimateLabs.Web.Models;
using PagedList;
using System.Data.Entity;

namespace UltimateLabs.Web.Controllers
{
    [Authorize]
    public class IdiomaAdminController : Controller
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

        public ActionResult CrearIdioma()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearIdioma(IdiomasAdminViewModel model)
        {
            Idiomas idioma = new Idiomas()
            {
                Idioma = model.Idioma,
                Abreviatura=model.Abreviatura,
                Activo=true
                
            };

            context.Idiomas.Add(idioma);
            context.SaveChanges();

            return RedirectToAction("Index");


        }


        //READ
        public ActionResult ListadoIdioma(int? page)
        {

            List<IdiomasAdminViewModel> idioma = new List<IdiomasAdminViewModel>();
            IPagedList<IdiomasAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Idiomas.Where(x => x.Activo==true).OrderBy(x => x.IdIdioma).ToList())
            {
                var model = new IdiomasAdminViewModel()
                {
                    IdIdioma = data.IdIdioma,
                    Idioma = data.Idioma,
                    Abreviatura = data.Abreviatura,
                };


                idioma.Add(model);
                lista = idioma.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarIdioma(int? id)
        {
            Idiomas idioma = context.Idiomas.Find(id); //Tabla de BD

            IdiomasAdminViewModel idiomaViewModel = new IdiomasAdminViewModel()
            {
                IdIdioma=idioma.IdIdioma,
                Idioma=idioma.Idioma,
                Abreviatura=idioma.Abreviatura
            };
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idiomaViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarIdioma(IdiomasAdminViewModel model, int id)
        {
            Idiomas idioma = context.Idiomas.Find(id);

            if (ModelState.IsValid)
            {
                context.Entry(idioma).State = EntityState.Modified;
                idioma.IdIdioma = model.IdIdioma;
                idioma.Idioma = model.Idioma;
                context.SaveChanges();
                return RedirectToAction("index");
            }
            return View(idioma);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Idiomas idioma = context.Idiomas.Find(id);
            if (idioma.Activo == true)
            {
                idioma.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}