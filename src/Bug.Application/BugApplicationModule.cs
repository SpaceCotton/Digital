using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bug.Authorization;
using Castle.MicroKernel.Registration;
using System.Reflection;

namespace Bug
{
    [DependsOn(
        typeof(BugCoreModule), 
        typeof(AbpAutoMapperModule))] //通过注解来定义依赖关系
    public class BugApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BugAuthorizationProvider>();//调用BugCoreModuleMethod1的方法。
        }

        public override void Initialize()//初始化模块
        {
            var thisAssembly = typeof(BugApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );


            //注册IDtoMapping
            IocManager.IocContainer.Register(
                Classes.FromAssembly(Assembly.GetExecutingAssembly())
                    .IncludeNonPublicTypes()
                    .BasedOn<IDtoMapping>()
                    .WithService.Self()
                    .WithService.DefaultInterfaces()
                    .LifestyleTransient()
            );

            //解析依赖，并进行映射规则创建
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var dtomap in mappers)
                    dtomap.CreateMapping(mapper);
            });


        }
    }
}
