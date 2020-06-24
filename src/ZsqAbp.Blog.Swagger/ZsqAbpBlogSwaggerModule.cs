using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;
using ZsqAbp.Blog.Domain;

namespace ZsqAbp.Blog.Swagger
{
    [DependsOn(
        typeof(ZsqAbpBlogDomainModule)
    )]
    public class ZsqAbpBlogSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUI();
        }
    }
}
