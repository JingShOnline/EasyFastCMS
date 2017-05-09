using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper.QueryableExtensions;
using EasyFast.Core.DomainDto;
using EasyFast.Core.Entities;

namespace EasyFast.Core.HtmlGenreate
{
    public class CleanStaticFileJob : BackgroundJob<int?>, ITransientDependency
    {
        private readonly IHtmlGenerateManager _htmlGenerateManager;
        private readonly IRepository<Column> _columnRepository;

        public CleanStaticFileJob(IRepository<Column> columnRepository, IHtmlGenerateManager htmlGenerateManager)
        {
            _columnRepository = columnRepository;
            _htmlGenerateManager = htmlGenerateManager;
        }

        [UnitOfWork]
        public override void Execute(int? args)
        {
            List<CleanStaticFileOutput> columns;
            if (args != null && args != 0)
                //如果有指定的id,则不进行判断是否生成静态文件的属性,因为有可能栏目之前是生成但是修改为不生成,这样就无法进行请理
                columns = _columnRepository.GetAll().Where(o => o.Id == args).AsNoTracking().ProjectTo<CleanStaticFileOutput>().ToList();
            else
                columns = _columnRepository.GetAll().Where(c => c.IsIndexHtml || c.IsListHtml || c.IsContentHtml).AsNoTracking().ProjectTo<CleanStaticFileOutput>().ToList();
            var taskArray = new Task[columns.Count];
            for (var i = 0; i < columns.Count; i++)
            {
                var i1 = i;
                taskArray[i1] = Task.Factory.StartNew(() => _htmlGenerateManager.CleanStaticFile(columns[i1]));
            }
            Task.WaitAll(taskArray);
        }
    }
}
