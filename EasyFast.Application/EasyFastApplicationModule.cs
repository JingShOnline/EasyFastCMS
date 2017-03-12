using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using EasyFast.Core;

namespace EasyFast.Application
{
    [DependsOn(typeof(EasyFastCoreModule), typeof(AbpAutoMapperModule))]
    public class EasyFastApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
