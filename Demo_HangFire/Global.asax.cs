using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Hangfire;
using Hangfire.SqlServer;

namespace Demo_HangFire
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //private IEnumerable<IDisposable> GetHangfireServers()
        //{
        //    GlobalConfiguration.Configuration
        //        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        //        .UseSimpleAssemblyNameTypeSerializer()
        //        .UseRecommendedSerializerSettings()
        //        .UseSqlServerStorage(@"Server=TONYHUANG-PC\SQLEXPRESS; Database=Northwind0; Integrated Security=True;", new SqlServerStorageOptions
        //        {
        //            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        //            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        //            QueuePollInterval = TimeSpan.Zero,
        //            UseRecommendedIsolationLevel = true,
        //            UsePageLocksOnDequeue = true,
        //            DisableGlobalLocks = true
        //        });

        //    yield return new BackgroundJobServer();
        //}


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //HangfireAspNet.Use(GetHangfireServers);

            //BackgroundJob.Enqueue(() => Debug.WriteLine("Hello world from Hangfire!"));
        }


    }
}
