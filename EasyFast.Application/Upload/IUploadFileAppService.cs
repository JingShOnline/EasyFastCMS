using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<string> UploadImg(string ext, string columnName,string dir, HttpPostedFileBase file);
    }
}
