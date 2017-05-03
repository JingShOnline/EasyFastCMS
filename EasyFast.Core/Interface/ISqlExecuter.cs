using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EasyFast.Core.Interface
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
        /// <param name="count"></param>
        /// <param name="parameters">要应用于命令字符串的参数</param>
        /// <returns>执行命令后由数据库返回的结果</returns>
        int Execute(string sql, int count = 0, params object[] parameters);

        /// <summary>
        /// 创建一个原始 SQL 查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql">SQL 查询字符串</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<object> SqlQuery(Type type, string sql, int count = 0, params SqlParameter[] parameters);

        /// <summary>创建一个原始 SQL 查询
        /// 
        /// </summary>
        /// <typeparam name="T">返回的类型</typeparam>
        /// <param name="sql"></param>
        /// <param name="count"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        List<T> SqlQuery<T>(string sql, int count = 0, params SqlParameter[] parameters);

    }
}
