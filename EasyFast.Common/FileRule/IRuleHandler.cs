using System.Text;

namespace EasyFast.Common.FileRule
{
    /// <summary>
    /// 文件名规则处理接口
    /// </summary>
    public interface IRuleHandler
    {
        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        StringBuilder Handler(StringBuilder sb,string id,string name);
    }
}
