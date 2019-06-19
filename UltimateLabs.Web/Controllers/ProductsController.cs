using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltimateLabs.Web.DB;
using UltimateLabs.Web.Models;

namespace UltimateLabs.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Categories()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<CategoriasViewModel> lista = new List<CategoriasViewModel>();
            if (Session["Idioma"] != null)
            {
                int cod = int.Parse(Session["Idioma"].ToString());
                foreach (var data in context.Categorias.Where(x => x.IdIdioma == cod).OrderBy(x => x.NombreCategoria).ToList())
                {
                    var model = new CategoriasViewModel()
                    {
                        CodCaegoria = data.IdCategoria,
                        NombreCategoria = data.NombreCategoria,
                        DescripcionCategoria = data.DescripcionCategoria,
                        PathImg = data.PathImg,
                        PathIcon = data.IconPath
                    };
                    lista.Add(model);

                }
                if (int.Parse(Session["Idioma"].ToString()) == 1)
                {
                    TempData["Productos"] = "Nuestros Productos";
                }
                else
                {
                    TempData["Productos"] = "Our Products";
                }
            }


          

            return PartialView(lista);
        }

        public PartialViewResult List(int? CodCategoria)
        {
            List<ProductoViewModel> lista = new List<ProductoViewModel>();
            UltimateLabsEntities context = new UltimateLabsEntities();


            var CatData = context.Categorias.Where(x => x.IdCategoria == CodCategoria).FirstOrDefault();

            if (CatData != null)
            {
                TempData["Nombre"] = CatData.NombreCategoria;
                TempData["PathImg"] = CatData.PathImg;
            }
            if (Session["Idioma"] != null)
            {
                int cod = int.Parse(Session["Idioma"].ToString());
                if (CodCategoria != null)
                {
                    foreach (var data in context.Productos.Where(x => x.IdIdioma == cod && x.Activo == true && x.Publicar == true && x.IdCategoria == CodCategoria).OrderBy(x => x.IdProducto).ToList())
                    {
                        var model = new ProductoViewModel()
                        {
                            Codigo = data.IdProducto,
                            NombreProducto = data.NombreProducto,
                            NombreComun = data.NombreComun,
                            DescripcionCorta = data.DescripcionCortaProducto,
                            DescripcionLarga = data.DescripcionLargaProducto,
                            Indicaciones = data.Indicaciones,
                            Dosis = data.Dosis,
                            IdCategoria = data.IdCategoria.Value,
                            Activo = data.Activo.Value,
                            Publicar = data.Publicar.Value,
                            PathImg = data.PathImg

                        };
                        lista.Add(model);

                    }
                }
            }
            return PartialView(lista);
        }


        public PartialViewResult Detail(int? CodProducto)
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            if (Session["Idioma"] != null)
            {
                int cod = int.Parse(Session["Idioma"].ToString());
                if (CodProducto != null)
                {
                    var data = context.Productos.Where(x => x.IdIdioma == cod && x.Activo == true && x.Publicar == true && x.IdProducto == CodProducto).FirstOrDefault();

                    var model = new ProductoViewModel()
                    {
                        Codigo = data.IdProducto,
                        NombreProducto = data.NombreProducto,
                        NombreComun = data.NombreComun,
                        DescripcionCorta = data.DescripcionCortaProducto,
                        DescripcionLarga = data.DescripcionLargaProducto,
                        Indicaciones = data.Indicaciones,
                        Dosis = data.Dosis,
                        IdCategoria = data.IdCategoria.Value,
                        Activo = data.Activo.Value,
                        Publicar = data.Publicar.Value,
                        PathImg = data.PathImg

                    };

                    var lineasdetalle = model.Indicaciones.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                    ViewBag.Detalle = lineasdetalle;


                    var detalledosis = model.Dosis.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                    ViewBag.DetalleDosis = detalledosis;


                    return PartialView(model);
                }
            }
            return PartialView();
        }
    }
}