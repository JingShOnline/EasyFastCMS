using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Abp.Dependency;

namespace EasyFastCMS.Application.AutoMapper
{
    public interface IDtoMapping: ITransientDependency
    {
        void CreateMapping(IMapperConfigurationExpression mapperConfig);
    }
}
