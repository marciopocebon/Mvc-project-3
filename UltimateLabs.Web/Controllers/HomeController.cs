using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UltimateLabs.Web.DB;
using UltimateLabs.Web.Models;

namespace UltimateLabs.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            UltimateLabsEntities context = new UltimateLabsEntities();

            List<SliderViewModel> lista = new List<SliderViewModel>();

            if (Session["Idioma"] != null)
            {
                int cod = int.Parse(Session["Idioma"].ToString());
                foreach (var data in context.SliderImg.Where(x => x.Activo == true && x.IdIdioma == cod && x.Publicar == true).OrderBy(x => x.IdImg).ToList())
                {
                    var model = new SliderViewModel()
                    {
                        Codigo = data.IdImg,
                        Frase = data.Frase,
                        PathImg = data.PathImg,
                        Activo = data.Activo.Value,
                        Publicar = data.Publicar.Value,
                        Idioma = data.IdIdioma.Value,
                        Titulo=data.Titulo

                    };
                    lista.Add(model);

                }
            }


            //return PartialView(lista);

            return View(lista);
        }

        public PartialViewResult About()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<ConfiguracionesViewModel> lista = new List<ConfiguracionesViewModel>();


            if(Session["Idioma"] != null) {
                int CodigoIdioma = int.Parse(Session["Idioma"].ToString());
                if (CodigoIdioma == 1)
                {
                    TempData["Valor"] = "Nuestros Valores";
                }
                else
                {
                    TempData["Valor"] = "Our Values";
                }
                string codigo = "S";
                var  valor = context.Configuraciones.Where(x => x.CodigoConfiguracion==codigo && x.IdIdioma==CodigoIdioma).FirstOrDefault();
                int valora = DateTime.Now.Year - int.Parse(valor.Valor);


            foreach (var data in context.Configuraciones.Where(x => x.Activo == true && x.IdIdioma==CodigoIdioma).OrderBy(x => x.IdConfiguracion).ToList())
            {
                    if (data.CodigoConfiguracion != "V") { 
                    var model = new ConfiguracionesViewModel()
                    {
                        IdConfiguracion = data.IdConfiguracion,
                        CodigoConfiguracion = data.CodigoConfiguracion,
                        NombreConfiguracion = data.NombreConfiguracion,
                        Valor = data.Valor,
                        PathImg = data.PathImg,
                     
                    };
                        lista.Add(model);
                    }
                    else
                    {
                        string text = data.Valor;

                       text=text.Replace("15", ""+valora);
                        var model = new ConfiguracionesViewModel()
                        {
                            IdConfiguracion = data.IdConfiguracion,
                            CodigoConfiguracion = data.CodigoConfiguracion,
                            NombreConfiguracion = data.NombreConfiguracion,
                            Valor = text,
                            PathImg = data.PathImg,

                        };
                        lista.Add(model);
                    }

                    

            }


            }
            return PartialView(lista);



           
        }

        public PartialViewResult Contact()
        {

            if (Session["Idioma"] != null)
            {
                if (int.Parse(Session["Idioma"].ToString()) == 1)
                {
                    TempData["Nombre"] = "Nombre";
                    TempData["Email"] = "Email";
                    TempData["Asunto"] = "Teléfono";
                    TempData["Mensaje"] = "Mensaje";
                    TempData["Contact"] = "Contáctanos";
                    TempData["Enviar"] = "Enviar";
                    TempData["Direccion"] = "Dirección";
                    TempData["Exp1"] = "¿Tienes una pregunta o necesitas más información?";
                    TempData["Exp2"] = "Llena el formulario y nos pondremos en contacto contigo lo antes posible.";



                }
                else
                {
                    TempData["Nombre"] = "Your Name";
                    TempData["Email"] = "Your Email";
                    TempData["Asunto"] = "Your Phone";
                    TempData["Mensaje"] = "Message";
                    TempData["Contact"] = "Contact Us";
                    TempData["Enviar"] = "Submit";
                    TempData["Direccion"] = "Address";
                    TempData["Exp1"] = "Do you have a question or do you need more information?";
                    TempData["Exp2"] = "Fill out the form and we will contact you as soon as possible.";
                }

            }



            return PartialView();
        }

        public PartialViewResult Header()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<EtiquetasViewModel> lista = new List<EtiquetasViewModel>();

            if (Session["Idioma"] != null) {
            int cod = int.Parse(Session["Idioma"].ToString());
            foreach (var data in context.Etiquetas.Where(x => x.Activo == true && x.IdIdioma == cod &&x.Publicar==true ).OrderBy(x => x.CodEtiqueta).ToList())
            {
                var model = new EtiquetasViewModel()
                {
                 IdEtiqueta=data.Id,
                 Codigo=data.CodEtiqueta,
                 Descripcion=data.DescripcionEtiqueta,
                 Valor=data.Valor,
                 Activo=data.Activo.Value,
                 Publicar=data.Publicar.Value,
                 IdIdioma=data.IdIdioma.Value

                };
                lista.Add(model);

            }
            }


            return PartialView(lista);
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
                        PathImg = data.PathImg
                    };
                    lista.Add(model);

                }
            }
            TempData["Inicio"] = "<li><ul>";
            TempData["Cierre"] = "</ul></li>";



            return PartialView(lista);
        }

        public  PartialViewResult Languajes()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<IdiomasViewModel> lista = new List<IdiomasViewModel>();

            foreach (var data in context.Idiomas.OrderByDescending(x => x.IdIdioma).Where(x => x.Activo == true).ToList())
            {
                var model = new IdiomasViewModel()
                {
                  IdIdioma=data.IdIdioma,
                  Idioma=data.Idioma,
                  Abreviatura=data.Abreviatura,
                  IconPath=data.IconPath
                };
                lista.Add(model);

            }


            return PartialView(lista);
        }


        public ActionResult ChangeLanguaje(int? Id)
        {
            if (Id != null)
            {
                Session["Idioma"] = Id;

            }
           return RedirectToAction("Index", "Home");
            //return View();
        }
        public ActionResult Principal()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<IdiomasViewModel> lista = new List<IdiomasViewModel>();

            foreach (var data in context.Idiomas.OrderByDescending(x => x.IdIdioma).Where(x=>x.Activo==true).ToList())
            {
                var model = new IdiomasViewModel()
                {
                    IdIdioma = data.IdIdioma,
                    Idioma = data.Idioma,
                    Abreviatura = data.Abreviatura,
                    IconPath = data.IconPath
                };
                lista.Add(model);

            }


            return View(lista);
           

        }

        public PartialViewResult Search()
        {
            UltimateLabsEntities context = new UltimateLabsEntities();

            List<ConfiguracionesViewModel> lista = new List<ConfiguracionesViewModel>();


            if (Session["Idioma"] != null)
            {
                int CodigoIdioma = int.Parse(Session["Idioma"].ToString());
               
                foreach (var data in context.Configuraciones.Where(x => x.Activo == true && x.IdIdioma == CodigoIdioma).OrderBy(x => x.IdConfiguracion).ToList())
                {
                    var model = new ConfiguracionesViewModel()
                    {
                        IdConfiguracion = data.IdConfiguracion,
                        CodigoConfiguracion = data.CodigoConfiguracion,
                        NombreConfiguracion = data.NombreConfiguracion,
                        Valor = data.Valor,
                        PathImg = data.PathImg,

                    };
                    lista.Add(model);

                }
            }
            return PartialView(lista);

        }
    }
}