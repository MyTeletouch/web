using System.Web;
using System.Web.Optimization;

namespace MyTeletouch
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/site.css"));
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            BundleConfig.RegisterAngularjsBundles(bundles);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            // Typescript
            bundles.Add(new ScriptBundle("~/bundles/typescript").Include(
                      "~/Scripts/typescript/configurations/Routes.js"));
        }

        private static void RegisterAngularjsBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/application-angular").Include(
                    //Base Types
                    "~/Scripts/angular/types/basicTypes/ApplicationString.js",

                    // Configurations
                    "~/Scripts/angular/configurations/RouteLink.js",
                    "~/Scripts/angular/configurations/Routes.js",
                    "~/Scripts/angular/configurations/RoutingTable.js",

                    // App and App Routes
                    "~/Scripts/angular/app.module.js",
                    "~/Scripts/angular/app.routes.js",

                    // DOM Entities
                    // Form State
                    "~/Scripts/angular/entities/DOM/formElements/form/FormState.js",
                    "~/Scripts/angular/entities/DOM/formElements/form/Form.js",
                    // Submit Button
                    "~/Scripts/angular/entities/DOM/formElements/submitButton/SubmitButtonState.js",
                    "~/Scripts/angular/entities/DOM/formElements/submitButton/SubmitButton.js",
                    // Select Box
                    "~/Scripts/angular/entities/DOM/formElements/selectbox/SelectOption.js",

                    // Models
                    "~/Scripts/angular/models/BaseModel.js",
                    "~/Scripts/angular/models/ApplicationUser.js",
                    "~/Scripts/angular/models/applicationusershippingaddress.js",
                    "~/Scripts/angular/models/Country.js",
                    "~/Scripts/angular/models/CountryText.js",
                    "~/Scripts/angular/models/Product.js",
                    "~/Scripts/angular/models/ProductText.js",

                    // ViewModels
                    "~/Scripts/angular/models/viewModels/countryViewModels/CountryListItem.js",
                    "~/Scripts/angular/models/viewModels/productViewModels/ProductTotalCostItem.js",
                    "~/Scripts/angular/models/viewModels/productViewModels/ProductViewModelItem.js",
                    

                    // Database Services
                    "~/Scripts/angular/services/database/interfaces/IDatabaseService.js",
                    "~/Scripts/angular/services/database/ApplicationUserShippingAddressDatabaseService.js",
                    
                    // Controllers
                    "~/Scripts/angular/controllers/ApplicationUserShippingAddressController.js"));
        }
    }
}
