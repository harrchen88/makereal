namespace SmartHotel.Registration
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Microsoft.ApplicationInsights;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
    using Serilog;
    using SmartHotel.Registration.AzureKeyVault;
    using SmartHotel.Registration.BusinessLogic.Concrete;
    using SmartHotel.Registration.BusinessLogic.Interface;
    using SmartHotel.Registration.Repository;
    using Unity;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //// Use instrumentation key from app settings
            TelemetryConfiguration.Active.InstrumentationKey = System.Web.Configuration.WebConfigurationManager.AppSettings["InstrumentationKey"];

            // Initialize global shared logger instance for serilog with the application insights as sink
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
    .WriteTo
    .ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Events)
    .CreateLogger();

            // Register routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Inject DI using unity framework
            var container = this.AddUnity();

            container.RegisterType<IBookingManager, BookingManager>();
            container.RegisterType<IBookingRepository, BookingRepository>();

            container.RegisterInstance<ILogger>(logger);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exception = Server.GetLastError();

            if (exception is HttpUnhandledException)
            {
                if (exception.InnerException != null)
                {
                    exception = new Exception(exception.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
                        true);
                }
            }
        }
    }
}