using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using EasyFast.Core.HtmlGenreate;

namespace EasyFast.Core.DoaminEvent.Column
{
    /// <summary>
    /// 栏目实体发生改变事件 
    /// </summary>
    public class ColumnChangedHandler : IEventHandler<EntityChangedEventData<Entities.Column>>, ITransientDependency
    {
        private readonly IBackgroundJobManager _jobManager;

        public ColumnChangedHandler(IBackgroundJobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public void HandleEvent(EntityChangedEventData<Entities.Column> eventData)
        {
            //清理该栏目
            _jobManager.Enqueue<CleanStaticFileJob, int?>(eventData.Entity.Id);
        }
    }
}
