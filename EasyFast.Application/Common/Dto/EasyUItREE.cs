using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Common.Dto
{
    /// <summary>
    /// EasyUi树形菜单
    /// </summary>
    public class EasyUITree<T>
    {
        public int Id { get; set; }
        /// <summary>
        /// 显示的文本 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 节点展开状态
        /// </summary>
        public string State { get { return "open"; } }


        /// <summary>
        /// 子节点
        /// </summary>
        public virtual List<T> Children { get; set; }

    }
}
