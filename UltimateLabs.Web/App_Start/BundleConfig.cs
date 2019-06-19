using System.Web;
using System.Web.Optimization;

namespace UltimateLabs.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/dropzone").Include(
            "~/Scripts/dropzone.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/bootstrap.css",
                       "~/Content/site.css",
                       "~/Content/basic.css",
                       "~/Content/dropzone.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Theme/css").Include(
                       "~/Content/Template/css/bootstrap.min.css",
                       //"~/Content/Template/css/font-awesome.min.css",
                       "~/Content/Template/css/medical-icons.css",
                       "~/Content/Template/css/vendors.css",
                       "~/Content/Template/css/style.css",
                       "~/Content/Template/css/components.css",
                       //"~/Content/Template/css/slider-revolution/revolution/css/settings.css",
                       //"~/Content/Template/css/slider-revolution/revolution/css/layers.css",
                       //"~/Content/Template/css/slider-revolution/revolution/css/navigation.css",
                       "~/Content/Template/plugins/revolution/revolution/css/settings.css",
                       "~/Content/Template/plugins/revolution/revolution/css/navigation.css",
                       "~/Content/Template/css/StyleC.css",
                       "~/Content/Template/css/skin-1.css",
                        "~/Content/Template/css/app-rtl.css",
                         "~/Content/Template/css/anicollection.css"

                        ));



            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                       "~/Content/Template/js/jquery.js",
                       "~/Content/Template/js/bootstrap.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/jquery.themepunch.tools.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/jquery.themepunch.revolution.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.slideanims.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.migration.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.actions.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.navigation.min.js",
                       //"~/Content/Template/slider-revolution/revolution/js/extensions/revolution.extension.parallax.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/jquery.themepunch.tools.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/jquery.themepunch.revolution.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.actions.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.carousel.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.kenburn.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.migration.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.navigation.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.parallax.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.slideanims.min.js",
                       "~/Content/Template/plugins/revolution/revolution/js/extensions/revolution.extension.video.min.js",
                       "~/Content/Template/js/owl.carousel.min.js",
                       "~/Content/Template/js/bootstrap-select.min.js",
                       "~/Content/Template/js/jquery-ui.min.js",
                       "~/Content/Template/js/script.js",
                       "~/Content/Template/js/anijs-min.js",
                       "~/Content/Template/js/anijs-helper-scrollreveal-min.js"));

                        


                        bundles.Add(new StyleBundle("~/ThemeAdmin/css").Include(
                     "~/ThemeAdmin/html5jquery/app/vendor/bootstrap/dist/css/bootstrap.min.css",
                      "~/ThemeAdmin/html5jquery/app/vendor/bootstrap-datepicker/dist/css/bootstrap-datepicker3.css",
                     "~/ThemeAdmin/html5jquery/app/vendor/ionicons/css/ionicons.css",
                     "~/ThemeAdmin/html5jquery/app/vendor/ionicons/css/font-awesome.min.css",
                     "~/ThemeAdmin/html5jquery/app/css/app.css",
                     "~/ThemeAdmin/angularjs/vendor/sweetalert/dist/sweetalert.css"));

            bundles.Add(new StyleBundle("~/ThemeChoco/css").Include(
                "~/ThemeChoco/CHOCO-V-2-0-3/css/bootstrap-light.css",
                "~/ThemeChoco/CHOCO-V-2-0-3/css/theme-light.css"));

            bundles.Add(new StyleBundle("~/ThemeBundle/css").Include(
                "~/ThemeChoco/CHOCO-V-2-0-3/css/bootstrap-light.css",
                "~/ThemeChoco/CHOCO-V-2-0-3/css/theme-light.css",
                "~/ThemeVega/VEGA-V-1-0-2/assets/bootstrap/css/bootstrap.css",
             "~/ThemeVega/VEGA-V-1-0-2/assets/theme/css/theme.css"));

            bundles.Add(new StyleBundle("~/ThemeBundle2/css").Include(
                "~/ThemeVega/VEGA-V-1-0-2/assets/bootstrap/css/bootstrap.css",
                "~/ThemeVega/VEGA-V-1-0-2/assets/theme/css/theme.css",
                "~/ThemeChoco/CHOCO-V-2-0-3/css/bootstrap-light.css",
                "~/ThemeChoco/CHOCO-V-2-0-3/css/theme-light.css"));

            bundles.Add(new StyleBundle("~/ThemeVega/css").Include(
             "~/ThemeVega/VEGA-V-1-0-2/assets/bootstrap/css/bootstrap.css",
             "~/ThemeVega/VEGA-V-1-0-2/assets/theme/css/theme.css"));

            bundles.Add(new StyleBundle("~/CssN/css").Include(
               "~/ThemeChoco/CHOCO-V-2-0-3/css/Whatsapp.css",
               "~/fonts/flaticon.css"));

            bundles.Add(new ScriptBundle("~/pluginsAdmin").Include(
                       "~/ThemeAdmin/html5jquery/app/vendor/jquery/dist/jquery.js",
                       "~/Scripts/jquery-ui-1.12.1.min.js",
                       "~/ThemeAdmin/html5jquery/app/vendor/bootstrap-datepicker/js/bootstrap-datepicker.js",
                       //"~/Theme/html5jquery/app/vendor/jquery-validation/dist/jquery.validate.js",
                       "~/ThemeAdmin/html5jquery/app/vendor/loaders.css/loaders.css.js",
                       "~/ThemeAdmin/html5jquery/app/js/app.js",
                       "~/ThemeAdmin/angularjs/vendor/bootstrap/dist/js/bootstrap.js",
                       "~/ThemeAdmin/angularjs/vendor/jquery.browser/dist/jquery.browser.js",
                       "~/ThemeAdmin/angularjs/vendor/material-colors/dist/colors.js",
                       "~/ThemeAdmin/angularjs/vendor/sweetalert/dist/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/pluginsChoco").Include(
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/wow.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/jquery-1.11.2.min.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/swiper.min.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/bootstrap.min.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/jquery.countTo.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/jquery.inview.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/vendor/jquery.countdown.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/tt-cart.js",
                "~/ThemeChoco/CHOCO-V-2-0-3/js/main.js"));

            BundleTable.EnableOptimizations = true;
        }
    }
}
