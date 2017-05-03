using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Dto
{
    /// <summary>
    /// 用于栏目表格显示Dto 仅有基本属性
    /// </summary>
    [AutoMapFrom(typeof(Core.Entities.Column))]
    public class SiteColumnModel
    {
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }

        public string Dir { get; set; }


        public string IndexHtmlRule { get; set; }

        /// <summary>
        /// 子栏目集合
        /// </summary>
        public List<SiteColumnModel> Children { get; set; }

        public int OrderId { get; set; }
    }
}
