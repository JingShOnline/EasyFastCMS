using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core.Entities
{
    /// <summary>
    /// 栏目领域服务
    /// </summary>
    public interface IColumnManager : IDomainService
    {
        /// <summary>
        /// 初始化栏目
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        void InitColumn(Column.Column column);

        /// <summary>
        /// 初始化单页
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        void InitSignleColumn(Column.Column column);

    }
}
