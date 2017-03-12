using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Column.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using AutoMapper;
using EasyFast.Application.Common.Dto;
using System.Linq.Dynamic;
using AutoMapper.QueryableExtensions;

namespace EasyFast.Application.Column
{
    public class ColumnAppService : EasyFastAppServiceBase, IColumnAppService
    {
        #region 依赖注入
        private readonly IRepository<Core.Entities.Column> _columnRepository;
        public ColumnAppService(IRepository<Core.Entities.Column> columnRepository)
        {
            _columnRepository = columnRepository;
        }

        public void Add(ColumnDto model)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void AddSingle(SingleColumnDto model)
        {
            var data = Mapper.Map<Core.Entities.Column>(model);
            data.ColumnTypeEnum = ColumnTypeEnum.Single;
            _columnRepository.Insert(data);
        }

        public EasyUIGridOutput<TreeGridOutput> GetTreeGrid(TreeGridInput search)
        {
            var list = Mapper.Map<List<TreeGridOutput>>(_columnRepository.GetAll());
            int total = list.Count();
            var rows = list.OrderBy(String.Format("{0} {1}", search.Sort, search.Order))
                .Skip((search.Page - 1) * search.Rows).Take(search.Rows);
            foreach (var item in rows)
            {
                ToEasyUITreeGrid(list, item);
            }
            return new EasyUIGridOutput<TreeGridOutput> { total = total, rows = rows };
        }

        private void ToEasyUITreeGrid(List<TreeGridOutput> all, TreeGridOutput parent)
        {
            var children = all.Where(o => o.ParentId == parent.Id).ToList();
            if (children != null)
            {
                parent.Children = new List<TreeGridOutput>();
                parent.Children.AddRange(children);
                foreach (var item in children)
                {
                    ToEasyUITreeGrid(all, item);
                }
            }
        }
    }
}
