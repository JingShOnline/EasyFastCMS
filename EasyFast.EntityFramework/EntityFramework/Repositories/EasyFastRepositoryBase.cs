using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace EasyFast.EntityFramework.Repositories
{
    public abstract class EasyFastRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EasyFastDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EasyFastRepositoryBase(IDbContextProvider<EasyFastDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EasyFastRepositoryBase<TEntity> : EasyFastRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected EasyFastRepositoryBase(IDbContextProvider<EasyFastDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
