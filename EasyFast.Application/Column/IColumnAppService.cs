using EasyFast.Application.Column.Dto;
using EasyFast.Application.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column
{
    public interface IColumnAppService
    {
        /// <summary>
        /// 添加单页栏目
        /// </summary>
        /// <param name="model"></param>
        void AddSingle(SingleColumnDto model);

        /// <summary>
        /// 添加栏目
        /// </summary>
        /// <param name="model"></param>
        void Add(ColumnDto model);

        /// <summary>
        /// 获取栏目列表
        /// </summary>
        /// <param name="search">搜索条件及分页设定</param>
        /// <returns></returns>
        EasyUIGridOutput<TreeGridOutput> GetTreeGrid(TreeGridInput search);
    }
}
