using Abp.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Specification
{
    /// <summary>
    /// 生成首页规约
    /// </summary>
    public class GenerateIndexSpecification : Specification<Core.Entities.Column>
    {
        /// <summary>
        /// 是否生成所有
        /// </summary>
        public bool IsAll;

        public List<int> Ids;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isAll">拿到所有</param>
        /// <param name="ids">根据id集合</param>
        public GenerateIndexSpecification(bool isAll, List<int> ids)
        {
            IsAll = isAll;
            Ids = ids;
        }

        public override Expression<Func<Core.Entities.Column, bool>> ToExpression()
        {
            if (IsAll)
                return c => c.IsIndexHtml;
            return c => c.IsIndexHtml && Ids.Contains(c.Id);

        }
    }
}
