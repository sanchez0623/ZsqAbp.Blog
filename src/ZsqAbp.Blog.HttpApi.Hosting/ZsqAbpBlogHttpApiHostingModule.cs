using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.BackgroundJobs;
using ZsqAbp.Blog.Domain.Configurations;
using ZsqAbp.Blog.EntityFrameworkCore;
using ZsqAbp.Blog.HttpApi;
using ZsqAbp.Blog.HttpApi.Hosting.Filters;
using ZsqAbp.Blog.HttpApi.Hosting.Middleware;
using ZsqAbp.Blog.Swagger;
using ZsqAbp.Blog.ToolKits.Base;
using ZsqAbp.Blog.ToolKits.Extensions;

namespace ZsqAbp.Blog.Web
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(ZsqAbpBlogHttpApiModule),
        typeof(ZsqAbpBlogSwaggerModule),
        typeof(ZsqAbpBlogFrameworkCoreModule),
        typeof(ZsqAbpBlogBackgroundJobsModule)
    )]
    public class ZsqAbpBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // 路由配置
            context.Services.AddRouting(options =>
            {
                // 设置URL为小写
                options.LowercaseUrls = true;
                // 在生成的URL后面添加斜杠
                options.AppendTrailingSlash = true;
            });

            // 认证
            context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ClockSkew = TimeSpan.FromSeconds(30),
                           ValidateIssuerSigningKey = true,
                           ValidAudience = AppSettings.JWT.Domain,
                           ValidIssuer = AppSettings.JWT.Domain,
                           IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())
                       };
                       options.Events = new JwtBearerEvents
                       {
                           OnChallenge = async context =>
                           {
                               // 跳过默认的处理逻辑，返回下面的模型数据
                               context.HandleResponse();

                               context.Response.ContentType = "application/json;charset=utf-8";
                               context.Response.StatusCode = StatusCodes.Status200OK;

                               var result = new ServiceResult();
                               result.IsFailed("UnAuthorized");

                               await context.Response.WriteAsync(result.ToJson());
                           }
                       };
                   });

            // 授权
            context.Services.AddAuthorization();

            // Http请求
            context.Services.AddHttpClient();

            Configure<MvcOptions>(options =>
            {
                var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                // 移除 AbpExceptionFilter
                options.Filters.Remove(filterMetadata);
                // 添加自己实现的 BlogExceptionFilter
                options.Filters.Add(typeof(BlogExceptionFilter));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            // 环境变量，开发环境
            if (env.IsDevelopment())
            {
                // 生成异常页面
                app.UseDeveloperExceptionPage();
            }

            // 路由
            app.UseRouting();

            // 异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // 认证
            app.UseAuthentication();

            // 授权
            app.UseAuthorization();

            // 路由映射
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
