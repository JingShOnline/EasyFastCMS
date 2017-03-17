using System.Web;

namespace EasyFast.Core
{
    public class EasyFastConsts
    {
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

        public static string HostUrl = $"http://{HttpContext.Current.Request.Url.Host.ToString()}:{HttpContext.Current.Request.Url.Port.ToString()}/";
    }
}