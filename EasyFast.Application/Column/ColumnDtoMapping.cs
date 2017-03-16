using EasyFastCMS.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EasyFast.Application.Column.Dto;
using EasyFast.Common.Extend.Object.Attribute;
using System.ComponentModel;
using EasyFast.Application.Common.Dto;

namespace EasyFast.Application.Column
{
    public class ColumnDtoMapping : IDtoMapping
    {
        public void CreateMapping(IMapperConfigurationExpression mapperConfig)
        {
            //表格Dto转换
            mapperConfig.CreateMap<Core.Entities.Column, ColumnGridOutput>().ForMember("ColumnType", o => o.MapFrom(c => c.ColumnTypeEnum.GetAttributeValue<DescriptionAttribute>("Description")));
            //easyUi tree转换
            //
            mapperConfig.CreateMap<Core.Entities.Column, ColumnTreeMenuOutput>().ForMember(o => o.Text, o => o.MapFrom(c => c.Name));
        }
    }
}
