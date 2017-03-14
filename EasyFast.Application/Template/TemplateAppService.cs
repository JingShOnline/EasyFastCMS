using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Column.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using AutoMapper;

namespace EasyFast.Application.Template
{
    public class TemplateAppService : EasyFastAppServiceBase, ITemplateAppService
    {
        #region 依赖注入
        private readonly IRepository<Core.Entities.Column.Column> _columnRepository;
        public TemplateAppService(IRepository<Core.Entities.Column.Column> columnRepository)
        {
            _columnRepository = columnRepository;
        }
        #endregion

        /// <summary>
        /// 模板方案
        /// </summary>
        private string skin = "";
    }
}
