using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using System.Diagnostics;
using Hangfire.MissionControl;
using Hangfire.Dashboard.Dark;
using Hangfire.Heartbeat;
using Hangfire.Heartbeat.Server;
using Demo_HangFire.Models;

[assembly: OwinStartup(typeof(Demo_HangFire.Startup))]

namespace Demo_HangFire
{
    public class Startup
    {
        private IEnumerable<IDisposable> GetHangfireServers()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=.\\SQLEXPRESS; Database=HangfireTest; Integrated Security=True;", new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true
                });

            yield return new BackgroundJobServer();
        }

        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkID=316888

            //app.UseHangfireAspNet(GetHangfireServers);

            GlobalConfiguration.Configuration
                .UseSqlServerStorage(@"Server=TONYHUANG-PC\SQLEXPRESS; Database=Northwind0; Integrated Security=True;")
                .UseMissionControl(typeof(EmailSenderMissions).Assembly)
                .UseDarkDashboard()
                .UseHeartbeatPage(checkInterval: TimeSpan.FromSeconds(1));
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            app.UseHangfireServer(additionalProcesses: new[] { new ProcessMonitor(checkInterval: TimeSpan.FromSeconds(1)) });
            

        }
    }
}
