using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.EntityFramework;
using EasyFast.Core;

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

        /// <summary>
        /// Execute No Query
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<int> Execute(string sql, params object[] parameters)
        {
            return await _dbContextProvider.GetDbContext().Database.ExecuteSqlCommandAsync(sql, parameters);
        }

        /// <summary>
        /// Query
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<List<object>> SqlQuery(Type type, string sql, params SqlParameter[] parameters)
        {
            return await _dbContextProvider.GetDbContext().Database.SqlQuery(type, sql, parameters).ToListAsync();
        }
    }
}
