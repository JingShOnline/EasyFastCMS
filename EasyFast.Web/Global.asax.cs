using System;
using System.Reflection;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using EasyFast.Core;

namespace EasyFast.Web
{
    public class MvcApplication : AbpWebApplication<EasyFastWebModule>
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
                f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );
            base.Application_Start(sender, e);

            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                EasyFastStatics.ApplicationAss = Assembly.LoadFile(baseDirectory.Replace(@"EasyFast.Web\",
                @"EasyFast.Application\bin\Debug\EasyFast.Application.dll"));
            }
            catch
            {

                EasyFastStatics.ApplicationAss = Assembly.LoadFile($@"{baseDirectory}bin\EasyFast.Application.dll");
            }


        }
    }
}
