using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using EasyFast.EntityFramework;
using EasyFast.Core;

namespace EasyFast
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(EasyFastCoreModule))]
    public class EasyFastDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<EasyFastDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
