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
    public class ProductoAdminController : Controller
    {


        public ActionResult Template()
        {
            return View();
        }

        public JsonResult Template_GetCustomers()
        {
            var bullets = new UltimateLabsEntities().TipoBullet.Select(bullet => new TipoBulletAdminViewModel
            {
                IdTipoBullet = bullet.IdTipoBullet,
                NombreBullet = bullet.NombreBullet,
                PathIcon = bullet.PathIcon,
                Activo = Convert.ToBoolean(bullet.Activo),
                FechaCreacion = Convert.ToDateTime(bullet.FechaCreacion),
                UsuarioCreacion = bullet.UsuarioCreacion,
                FechaModificacion = bullet.FechaModificacion,
                UsuarioModificacion = bullet.UsuarioModificacion
            });

            return Json(bullets, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dropzone()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }



        // GET: IdiomaAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexEditar(int? id)
        {
            return View();
        }

        public ActionResult IndexCrear()
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
        public ActionResult Upload(ProductoFotografiasAdminViewModel dataarchivo, HttpPostedFileBase file)
        {
            if (file == null)
            {
                return View("IndexCrear");
            }

                ProductoFotografias productoFotografias = new ProductoFotografias();
                using (var context = new UltimateLabsEntities())
                {
                    productoFotografias.PathFoto = "/Content/Template/Imagenes/Upload/" + file.FileName;
                    productoFotografias.Activo = true;
                    productoFotografias.Publicar = true;
                    productoFotografias.FechaCreacion = DateTime.Now;
                    productoFotografias.FechaModificacion = "/";
                    productoFotografias.UsuarioCreacion = "/";
                    productoFotografias.UsuarioModificacion = "/";

                    string archivo = file.FileName;

                }
                //var IdProducto = context.Productos.FirstOrDefault(x => x.CodigoMaestro == productoFotografias.CodigoMaestro);
                //productoFotografias.CodigoMaestro = IdProducto.CodigoMaestro;

                context.ProductoFotografias.Add(productoFotografias);
                context.SaveChanges();

            return RedirectToAction("IndexCrear");

        }



        public ActionResult CrearProducto()
        {

                        IEnumerable<SelectListItem> listaBullet = context.TipoBullet
                .Where(x => x.Activo == true)
                .OrderBy(x => x.IdTipoBullet)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdTipoBullet.ToString(),
                     Text = x.NombreBullet
                 });

            ViewBag.Bullet = listaBullet;


            IEnumerable<SelectListItem> listaIdioma = context.Idiomas
                .Where(x => x.Activo == true)
                .OrderBy(x => x.IdIdioma)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdIdioma.ToString(),
                     Text = x.Idioma
                 });

            ViewBag.Idioma = listaIdioma;


                        IEnumerable<SelectListItem> listaCategoria = context.Categorias
                .Where(x => x.Activo == true &&x.IdIdioma==1)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.Categoria = listaCategoria;

                         IEnumerable<SelectListItem> listaCategoriaENG = context.Categorias
                .Where(x => x.Activo == true && x.IdIdioma == 2)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.CategoriaENG = listaCategoriaENG;


                                     IEnumerable<SelectListItem> listaBullets = context.Categorias
                .Where(x => x.Activo == true && x.IdIdioma == 2)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.CategoriaENG = listaCategoriaENG;

            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(ProductoAdminViewModel model, HttpPostedFileBase Imagen, HttpPostedFileBase ImagenENG, IdiomasAdminViewModel listmodel, CategoriaAdminViewModel categorialist)
        {

            ProductoFotografias productoFotografias = new ProductoFotografias();

            List<ProductoFotografiasAdminViewModel> productoFotografiasLista = new List<ProductoFotografiasAdminViewModel>();


            foreach (var data in context.ProductoFotografias.Where(x => x.Activo == true).OrderBy(x => x.IdFotografia).ToList())
            {
                var modelproductoFotografias = new ProductoFotografiasAdminViewModel()
                {
                    IdFotografia = data.IdFotografia,
                    PathFoto = data.PathFoto,
                    Activo = true,
                    Publicar = true,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = "/",
                    FechaModificacion = DateTime.Now,
                    UsuarioModificacion = "/",
                };

                productoFotografiasLista.Add(modelproductoFotografias);

            }

            //using (var db = new UltimateLabsEntities())
            //{
            //    db.ProductoFotografias.(incident);

            //    foreach (var item in LocationList)
            //    {
            //        db.Location.AddObject(location);
            //    }
            //    db.Comment.AddObject(comment);

            //    db.SaveChanges();
            //}



            //var tmpproductoFotografia = new List<tmpProductoFotografias>();
            //foreach (var loc in )
            //{
            //    var location = new Data.Location
            //    {
            //        PersonId = model.PersonId,
            //        SiteCode = loc.SiteCode,
            //        IncidentId = loc.IncidentId
            //    };
            //    locationList.Add(location);
            //}

            //using (var db = new MyEntities())
            //{
            //    db.Order.AddObject(incident);

            //    foreach (var item in LocationList)
            //    {
            //        db.Location.AddObject(location);
            //    }
            //    db.Comment.AddObject(comment);

            //    db.SaveChanges();
            //}



            IEnumerable<SelectListItem> listaIdioma = context.Idiomas
                .Where(x => x.Activo == true)
                .OrderBy(x => x.IdIdioma)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdIdioma.ToString(),
                     Text = x.Idioma
                 });

            ViewBag.Idioma = listaIdioma;


                        IEnumerable<SelectListItem> listaCategoria = context.Categorias
                .Where(x => x.Activo == true &&x.IdIdioma==1)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.Categoria = listaCategoria;

                         IEnumerable<SelectListItem> listaCategoriaENG = context.Categorias
                .Where(x => x.Activo == true && x.IdIdioma == 2)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.CategoriaENG = listaCategoriaENG;



            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            Productos producto = new Productos()
            {
                CodigoMaestro = context.Productos.Count()+1,
                NombreProducto = model.NombreProducto,
                NombreComun = model.NombreComun,
                DescripcionCortaProducto = model.DescripcionCortaProducto,
                DescripcionLargaProducto = model.DescripcionLargaProducto,
                IdCategoria = model.IdCategoria,

                Indicaciones = model.Indicaciones,
                Dosis = model.Dosis,

                Activo = true,
                Publicar = model.Publicar,
                IdIdioma = 1,
                PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "/",
            };

            context.Productos.Add(producto);

            context.SaveChanges();


            string pathImagenENG = "/";
            if (ImagenENG != null)
            {
                pathImagenENG = SubirArchivo(ImagenENG, "~/Content/Template/Imagenes/Upload");
            }
            Productos productoENG = new Productos()
            {
                CodigoMaestro = context.Productos.Count(),
                NombreProducto = model.NombreProductoENG,
                NombreComun = model.NombreComunENG,
                DescripcionCortaProducto = model.DescripcionCortaProductoENG,
                DescripcionLargaProducto = model.DescripcionLargaProductoENG,
                IdCategoria = model.IdCategoriaENG,

                Indicaciones = model.IndicacionesENG,
                Dosis = model.DosisENG,

                Activo = true,
                Publicar = model.PublicarENG,
                IdIdioma = 2,
                PathImg = (pathImagenENG != "") ? "/Content/Template/Imagenes/Upload/" + pathImagenENG : "/",
            };

            context.Productos.Add(productoENG);

            context.SaveChanges();

            var codigo = context.Productos.FirstOrDefault(x => x.NombreProducto==model.NombreProducto && x.NombreComun==model.NombreComun && x.DescripcionCortaProducto==model.DescripcionCortaProducto).CodigoMaestro;
            var lista= context.ProductoFotografias.Where(x => x.CodigoMaestro == null).ToList();

            foreach (var item in lista)
            {
                context.ProductoFotografias.Attach(item); // State = Unchanged
                item.CodigoMaestro = codigo;  // State = Modified, and only the FirstName property is dirty.

            }

                context.SaveChanges();
            

            return RedirectToAction("IndexCrear");
        }

        public ActionResult SaveDropzoneJsUploadedFiles()
        {
            bool isSavedSuccessfully = false;

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];

                //You can Save the file content here

                isSavedSuccessfully = true;
            }

            return Json(new { Message = string.Empty });

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
        public ActionResult ListadoProducto(int? page)
        {

            List<ProductoAdminViewModel> producto = new List<ProductoAdminViewModel>();
            IPagedList<ProductoAdminViewModel> lista;
            lista = null;

            foreach (var data in context.Productos.Where(x => x.Activo == true ).OrderBy(x => x.CodigoMaestro).ToList())
            {
                var model = new ProductoAdminViewModel()
                {
                    IdProducto = data.IdProducto,
                    NombreProducto = data.NombreProducto,
                    CodigoMaestro=Convert.ToInt32(data.CodigoMaestro)
                };

                producto.Add(model);
                lista = producto.ToPagedList(page ?? 1, 10);
            }
            return View(lista);
        }




        //UPDATE

        public ActionResult EditarProducto(int? id)
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


                        IEnumerable<SelectListItem> listaCategoria = context.Categorias
                .Where(x => x.Activo == true &&x.IdIdioma==1)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.Categoria = listaCategoria;

                         IEnumerable<SelectListItem> listaCategoriaENG = context.Categorias
                .Where(x => x.Activo == true && x.IdIdioma == 2)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.CategoriaENG = listaCategoriaENG;

            Productos producto = context.Productos.FirstOrDefault(x=>x.CodigoMaestro==id && x.IdIdioma==1); //Tabla de BD

            Productos productoENG = context.Productos.FirstOrDefault(x=>x.CodigoMaestro==id && x.IdIdioma==2); //Tabla de BD

            ProductoAdminViewModel productoViewModel = new ProductoAdminViewModel()
            {
                IdProducto = producto.IdProducto,
                NombreProducto=producto.NombreProducto,
                NombreComun = producto.NombreComun,
                DescripcionCortaProducto = producto.DescripcionCortaProducto,
                DescripcionLargaProducto = producto.DescripcionLargaProducto,
                Indicaciones = producto.Indicaciones,
                Dosis = producto.Dosis,
                IdCategoria = Convert.ToInt32(producto.IdCategoria),
                Publicar = Convert.ToBoolean(producto.Publicar),
                IdIdioma=1,
                PathImg=producto.PathImg,
                Presentacion=producto.Presentacion,
                CodigoMaestro=Convert.ToInt32(producto.CodigoMaestro),

                FechaCreacion=DateTime.Now,
                FechaModificacion=DateTime.Now,
                UsuarioCreacion="admin",
                UsuarioModificacion="admin",



                IdProductoENG = productoENG.IdProducto,
                NombreProductoENG = productoENG.NombreProducto,
                NombreComunENG = productoENG.NombreComun,
                DescripcionCortaProductoENG = producto.DescripcionCortaProducto,
                DescripcionLargaProductoENG = producto.DescripcionLargaProducto,
                IndicacionesENG = productoENG.Indicaciones,
                DosisENG = productoENG.Dosis,
                IdCategoriaENG = Convert.ToInt32(productoENG.IdCategoria),
                PublicarENG = Convert.ToBoolean(productoENG.Publicar),
                IdIdiomaENG = 2,
                PathImgENG = productoENG.PathImg,
                PresentacionENG = productoENG.Presentacion,
                CodigoMaestroENG = Convert.ToInt32(productoENG.CodigoMaestro),

                FechaCreacionENG=DateTime.Now,
                FechaModificacionENG=DateTime.Now,
                UsuarioCreacionENG="admin",
                UsuarioModificacionENG="admin"

            };
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(productoViewModel); //ViewModel
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(ProductoAdminViewModel model, int id, HttpPostedFileBase Imagen, HttpPostedFileBase ImagenENG)
        {
             IEnumerable<SelectListItem> listaCategoria = context.Categorias
                .Where(x => x.Activo == true &&x.IdIdioma==1)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.Categoria = listaCategoria;

                         IEnumerable<SelectListItem> listaCategoriaENG = context.Categorias
                .Where(x => x.Activo == true && x.IdIdioma == 2)
                .OrderBy(x => x.IdCategoria)
                 .Select(x => new SelectListItem
                 {
                     Value = x.IdCategoria.ToString(),
                     Text = x.NombreCategoria
                 });

            ViewBag.CategoriaENG = listaCategoriaENG;


            Productos producto = context.Productos.FirstOrDefault(x=>x.CodigoMaestro==id && x.IdIdioma==1);
            Productos productoENG = context.Productos.FirstOrDefault(x=>x.CodigoMaestro==id && x.IdIdioma==2);

            string pathImagen = "/";
            if (Imagen != null)
            {
                pathImagen = SubirArchivo(Imagen, "~/Content/Template/Imagenes/Upload");
            }
            string pathImagenENG = "/";
            if (ImagenENG != null)
            {
                pathImagenENG = SubirArchivo(ImagenENG, "~/Content/Template/Imagenes/Upload");
            }

            if (ModelState.IsValid)
            {
                context.Entry(producto).State = EntityState.Modified;
                producto.IdProducto = model.IdProducto;
                producto.NombreProducto = model.NombreProducto;
                producto.NombreComun = model.NombreComun;
                producto.DescripcionCortaProducto = model.DescripcionCortaProducto;
                producto.DescripcionLargaProducto = model.DescripcionLargaProducto;
                producto.Indicaciones = model.Indicaciones;
                producto.Dosis = model.Dosis;
                producto.IdCategoria = model.IdCategoria;
                producto.Publicar = model.Publicar;
                producto.IdIdioma = model.IdIdioma;
                producto.PathImg = (pathImagen != "") ? "/Content/Template/Imagenes/Upload/" + pathImagen : "";
                producto.Presentacion = model.Presentacion;
                producto.CodigoMaestro = model.CodigoMaestro;



                if (producto.PathImg == "/Content/Template/Imagenes/Upload//")
                {
                    producto.PathImg = model.PathImg;
                }




                context.Entry(productoENG).State = EntityState.Modified;
                productoENG.IdProducto = model.IdProductoENG;
                productoENG.NombreProducto = model.NombreProductoENG;
                productoENG.NombreComun = model.NombreComunENG;
                productoENG.DescripcionCortaProducto = model.DescripcionCortaProductoENG;
                productoENG.DescripcionLargaProducto = model.DescripcionLargaProductoENG;
                productoENG.Indicaciones = model.IndicacionesENG;
                productoENG.Dosis = model.DosisENG;
                productoENG.IdCategoria = model.IdCategoriaENG;
                productoENG.Publicar = model.PublicarENG;
                productoENG.IdIdioma = model.IdIdiomaENG;
                productoENG.PathImg = (pathImagenENG != "") ? "/Content/Template/Imagenes/Upload/" + pathImagenENG : "";
                productoENG.Presentacion = model.PresentacionENG;
                productoENG.CodigoMaestro = model.CodigoMaestroENG;



                if (productoENG.PathImg == "/Content/Template/Imagenes/Upload//")
                {
                    productoENG.PathImg = model.PathImgENG;
                }


                context.SaveChanges();
            }
            return RedirectToAction("IndexCrear");
        }




        //DELETE

        public ActionResult Inactivar(int? id)
        {

            Productos producto = context.Productos.FirstOrDefault(x=>x.CodigoMaestro==id &&x.IdIdioma==1);
            if (producto.Activo == true)
            {
                producto.Activo = false;
            }
            Productos producto2 = context.Productos.FirstOrDefault(x => x.CodigoMaestro == id &&x.IdIdioma==2);
            if (producto2.Activo == true)
            {
                producto2.Activo = false;
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}