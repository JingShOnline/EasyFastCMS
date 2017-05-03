using Abp.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Column.Specification
{
    class CleanStaticFileSpecification : Specification<Core.Entities.Column>
    {
        public List<int> Ids;

        public CleanStaticFileSpecification(List<int> ids)
        {
            Ids = ids;
        }

        public override Expression<Func<Core.Entities.Column, bool>> ToExpression()
        {

            if (Ids.Count <= 0)
                return c => c.IsIndexHtml || c.IsListHtml || c.IsContentHtml;
            return c => (c.IsIndexHtml || c.IsListHtml || c.IsContentHtml) && Ids.Contains(c.Id);
        }
    }
}
