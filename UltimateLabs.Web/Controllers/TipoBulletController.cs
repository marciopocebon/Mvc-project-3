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
    public class TipoBulletController : Controller
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

        public ActionResult Upload()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Upload(BulletTmpAdminViewModel dataarchivo, HttpPostedFileBase file)
        {
            if (context.tmpFoto.Count() > 0)
            {
                //context.Database.ExecuteSqlCommand("DELETE FROM tmpFoto");
                var rows = from o in context.tmpFoto
                           select o;
                foreach (var row in rows)
                {
                    context.tmpFoto.Remove(row);
                }
                context.SaveChanges();
            }

            if (file == null)
            {
                return View("Index");
            }

            tmpFoto tmpBullet = new tmpFoto();

            var Bullettmp = context.tmpFoto.FirstOrDefault(x => x.Id > 1);

            using (var context = new UltimateLabsEntities())
            {
                tmpBullet.PathIcon = "/Content/Template/Imagenes/Icons/bullet/" + file.FileName;

                string archivo = file.FileName;

            }

            context.tmpFoto.Add(tmpBullet);
            context.SaveChanges();

            return RedirectToAction("Index");

        }



        public ActionResult CrearBullet()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CrearBullet(TipoBulletAdminViewModel model, HttpPostedFileBase Icono, IdiomasAdminViewModel listmodel)
        {
            var bulletTmp = context.tmpFoto.FirstOrDefault(x => x.Id > 0);

            TipoBullet tipoBullet = new TipoBullet()
            {
                NombreBullet = model.NombreBullet,
                //PathIcon = (pathIcono != "") ? "/Content/Template/Imagenes/Icons/bullet" + pathIcono : "/",
                PathIcon=bulletTmp.PathIcon,
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = "admin",
                UsuarioModificacion = "admin",
                FechaModificacion = "/"
            };

            context.TipoBullet.Add(tipoBullet);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        //public ActionResult CrearBullet()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CrearBullet(TipoBulletAdminViewModel dataarchivo, HttpPostedFileBase file, string filename)
        //{
        //    if (file == null)
        //    {
        //        return View("Index");
        //    }
        //    string pathPortada = "/";
        //    if (file != null)
        //    {
        //        pathPortada = SubirArchivo(file, "~/Content/Template/Imagenes/Icons/bullet");
        //    }

        //    TipoBullet tipoBullet = new TipoBullet();
        //    using (var context = new UltimateLabsEntities())
        //    {
        //        tipoBullet.NombreBullet = dataarchivo.NombreBullet;
        //        tipoBullet.PathIcon = "/Content/Template/Imagenes/Icons/bullet" + file.FileName;
        //        tipoBullet.Activo = true;
        //        tipoBullet.FechaCreacion = DateTime.Now;
        //        tipoBullet.FechaModificacion = "/";
        //        tipoBullet.UsuarioCreacion = "/";
        //        tipoBullet.UsuarioModificacion = "/";

        //        string archivo = file.FileName;

        //    }
        //    //var IdProducto = context.Productos.FirstOrDefault(x => x.CodigoMaestro == productoFotografias.CodigoMaestro);
        //    //productoFotografias.CodigoMaestro = IdProducto.CodigoMaestro;

        //    context.TipoBullet.Add(tipoBullet);
        //    context.SaveChanges();

        //    return RedirectToAction("Index");

        //}

        //public string SubirArchivo(HttpPostedFileBase file, string ruta)
        //{
        //    string path = "";
        //    var fileName = "";
        //    if (file.ContentLength > 0)
        //    {
        //        try
        //        {
        //            fileName = Path.GetFileName(file.FileName);
        //            path = Path.Combine(Server.MapPath(ruta), fileName);
        //            file.SaveAs(path);

        //        }
        //        catch { }
        //    }
        //    else if (file.ContentLength < 0)
        //    {
        //        path = "";
        //    }
        //    return fileName;

        //}


        //READ


        public ActionResult ListadoBullet(int? page)
        {
            List<TipoBulletAdminViewModel> tipoBullet = new List<TipoBulletAdminViewModel>();
            IPagedList<TipoBulletAdminViewModel> lista;
            lista = null;

            foreach (var data in context.TipoBullet.Where(x => x.Activo == true).OrderBy(x => x.IdTipoBullet).ToList())
            {
                var model = new TipoBulletAdminViewModel()
                {
                    IdTipoBullet = data.IdTipoBullet,
                    NombreBullet = data.NombreBullet
                };

                tipoBullet.Add(model);
                lista = tipoBullet.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }
        //UPDATE

        public ActionResult EditarBullet(int? id)
        {
            TipoBullet tipoBullet = context.TipoBullet.Find(id); //Tabla de BD

            TipoBulletAdminViewModel tipoBulletViewModel = new TipoBulletAdminViewModel()
            {
                IdTipoBullet = tipoBullet.IdTipoBullet,
                NombreBullet = tipoBullet.NombreBullet,
                Activo = true,
                PathIcon = tipoBullet.PathIcon,

            };
            if (tipoBullet == null)
            {
                return HttpNotFound();
            }
            return View(tipoBulletViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarBullet(TipoBulletAdminViewModel model, int id, HttpPostedFileBase file)
        {
            TipoBullet tipoBullet = context.TipoBullet.Find(id);

            var bulletTmp = context.tmpFoto.FirstOrDefault(x => x.Id > 0);


            //string pathIcono = "/";
            //if (Icono != null)
            //{
            //    pathIcono = SubirArchivo(Icono, "~/Content/Template/Imagenes/Icons/bullet");
            //}

                context.Entry(tipoBullet).State = EntityState.Modified;
                tipoBullet.IdTipoBullet = model.IdTipoBullet;
                tipoBullet.NombreBullet = model.NombreBullet;
                //tipoBullet.PathIcon = (pathIcono != "") ? "/Content/Template/Imagenes/Icons/bullet/" + pathIcono : "";
                tipoBullet.PathIcon = bulletTmp.PathIcon;

                if (tipoBullet.PathIcon == "/Content/Template/Imagenes/Icons/bullet//")
                {
                    tipoBullet.PathIcon = model.PathIcon;
                }

                context.SaveChanges();
                return RedirectToAction("Index");

            return View(tipoBullet);
        }

        //DELETE

        public ActionResult Inactivar(int? id)
        {

            TipoBullet bullet = context.TipoBullet.Find(id);
            if (bullet.Activo == true)
            {
                bullet.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}