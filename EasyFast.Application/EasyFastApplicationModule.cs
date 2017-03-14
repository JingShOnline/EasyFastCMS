using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using EasyFast.Core;
using EasyFastCMS.Application.AutoMapper;

namespace EasyFast.Application
{
    [DependsOn(typeof(EasyFastCoreModule), typeof(AbpAutoMapperModule))]
    public class EasyFastApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
          
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            //配置AutpMapper
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                var mappers = IocManager.IocContainer.ResolveAll<IDtoMapping>();
                foreach (var map in mappers)
                {
                    map.CreateMapping(mapper);
                }
            });
        }
    }
}
