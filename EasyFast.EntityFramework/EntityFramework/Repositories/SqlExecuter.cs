using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.UI;
using EasyFast.Core.Interface;

namespace EasyFast.EntityFramework.EntityFramework.Repositories
{
    /// <summary>
    /// EF Sql查询实现
    /// </summary>
    public class SqlExecuter : ISqlExecuter, ITransientDependency
    {

        private readonly IDbContextProvider<EasyFastDbContext> _dbContextProvider;



        public SqlExecuter(IDbContextProvider<EasyFastDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }


        public int Execute(string sql, int count = 0, params object[] parameters)
        {
            try
            {
                if (count >= 5)
                    throw new UserFriendlyException("生成失败,请重试");
                return _dbContextProvider.GetDbContext().Database.ExecuteSqlCommand(sql, parameters);
            }
            catch (Exception e)
            {
                return Execute(sql, count + 1, parameters);
            }


        }


        [UnitOfWork(IsDisabled = true)]
        public List<object> SqlQuery(Type type, string sql, int count = 0, params SqlParameter[] parameters)
        {
            try
            {
                if (count >= 5)
                    throw new UserFriendlyException("生成失败,请重试");
                return _dbContextProvider.GetDbContext().Database.SqlQuery(type, sql, parameters).Cast<object>().ToList();
            }
            catch (Exception e)
            {
                return SqlQuery(type, sql, count + 1, parameters);
            }

        }

        [UnitOfWork(IsDisabled = true)]
        public List<T> SqlQuery<T>(string sql, int count = 0, params SqlParameter[] parameters)
        {
            try
            {
                if (count >= 5)
                    throw new UserFriendlyException("生成失败,请重试");
                return _dbContextProvider.GetDbContext().Database.SqlQuery<T>(sql, parameters).ToList();
            }
            catch (Exception e)
            {
                return SqlQuery<T>(sql, count + 1, parameters);
            }
        }
    }
}
