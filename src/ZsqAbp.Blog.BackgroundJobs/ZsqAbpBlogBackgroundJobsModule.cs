using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.MySql.Core;
using Volo.Abp;
using Volo.Abp.BackgroundJobs.Hangfire;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain.Configurations;
using ZsqAbp.Blog.Domain.Shared;

namespace ZsqAbp.Blog.BackgroundJobs
{
    [DependsOn(typeof(AbpBackgroundJobsHangfireModule))]
    public class ZsqAbpBlogBackgroundJobsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHangfire(config =>
            {
                config.UseStorage(
                    new MySqlStorage(AppSettings.ConnectionStrings,
                    new MySqlStorageOptions
                    {
                        TablePrefix = ZsqAbpBlogConsts.DbTablePrefix + "hangfire"
                    }));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseHangfireServer();
            app.UseHangfireDashboard(options: new DashboardOptions
            {
                Authorization = new[]
                {
                    new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                    {
                        RequireSsl = false,
                        SslRedirect = false,
                        LoginCaseSensitive = true,
                        Users = new []
                        {
                            new BasicAuthAuthorizationUser
                            {
                                Login = AppSettings.Hangfire.Login,
                                PasswordClear =  AppSettings.Hangfire.Password
                            }
                        }
                    })
                },
                DashboardTitle = "任务调度中心"
            });

            var service = context.ServiceProvider;
            service.UseHangfireTest();
        }
    }
}
