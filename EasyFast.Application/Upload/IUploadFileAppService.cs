using Abp.Application.Services;
using System.Threading.Tasks;
using System.Web;

namespace EasyFast.Application.Upload
{
    /// <summary>
    /// 上伟文件资源
    /// </summary>
    public interface IUploadFileAppService : IApplicationService
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        Task<string> UploadImg(string ext, string columnName, string width, string height, string dir, HttpPostedFileBase file);
    }
}
