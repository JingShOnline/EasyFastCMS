using System.Web;

namespace EasyFast.Core
{
    public class EasyFastConsts
    {
        static EasyFastConsts()
        {

        }

        public const string LocalizationSourceName = "EasyFastCMS";

        /// <summary>
        /// 最大分页条数
        /// </summary>
        public const int MaxPageSize = 100;

        /// <summary>
        /// 默认分页条数
        /// </summary>
        public const int DefaultPageSize = 10;

        /// <summary>
        /// 上传文件保存路径
        /// </summary>
        public const string UploadFilePath = "Upload";

        /// <summary>
        /// 域名+端口
        /// </summary>
        public static string HostUrl = $"http://{HttpContext.Current.Request.Url.Host.ToString()}:{HttpContext.Current.Request.Url.Port.ToString()}/";

        /// <summary>
        /// 地址
        /// </summary>
        public static string BaseDirectory = HttpContext.Current.Server.MapPath("~");

        /// <summary>
        /// 标签匹配正则表达式
        /// </summary>
        public const string TagRegex = @"\$.*?}";

        /// <summary>
        /// 标签路径
        /// </summary>
        public static string TagPath = $@"{HttpContext.Current.Server.MapPath("~")}\Template\Tag";

        /// <summary>
        /// 模板文件格式
        /// </summary>
        public const string TemplateType = ".cshtml";

        /// <summary>
        /// sql匹配正则
        /// </summary>
        public const string SqlRegex = "<t>(.+)</t>";

        /// <summary>
        /// 模板缓存池key
        /// </summary>
        public const string TemplateCacheKey = "TemplateCache";

        /// <summary>
        /// sql参数正则
        /// </summary>
        public const string SqlParameterRegex = "\".+\"";



    }
}