using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Core
{
    /// <summary>
    /// Sql查询接口
    /// </summary>
    public interface ISqlExecuter
    {
        /// <summary>
        /// 执行给定的命令
        /// </summary>
        /// <param name="sql">命令字符串</param>
        /// <param name="parameters">要应用于命令字符串的参数</param>
        /// <returns>执行命令后由数据库返回的结果</returns>
        Task<int> Execute(string sql, params object[] parameters);

        /// <summary>
        /// 创建一个原始 SQL 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql">SQL 查询字符串</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>
        /// <returns></returns>
        Task<List<object>> SqlQuery(Type type, string sql, params SqlParameter[] parameters);
    }
}
