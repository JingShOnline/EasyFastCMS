using System;
using Abp.Application.Services;
using Abp.UI;
using EasyFast.Common;
using EasyFast.Core;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace EasyFast.Application.Upload
{
    /// <summary>
    /// 上传文件资源
    /// </summary>
    public class UploadFileAppService : ApplicationService, IUploadFileAppService
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        public async Task<string> UploadImg(string ext, string columnName, string width, string height, string dir, HttpPostedFileBase file)
        {
            if (file == null)
                throw new UserFriendlyException("错误", "请选择上要传的图片");
            if (!ForMatterHelper.ValidImgExt(ext))
                throw new UserFriendlyException("图片格式不正确", "仅支持扩展名为.jpg .jpeg .gif .png格式");
            if (!ForMatterHelper.ValidImgLength(file.ContentLength))
                throw new UserFriendlyException("大小超出限制", "仅支持上传1M及1M以下大小的图片");


            var baseDirectory = EasyFastConsts.BaseDirectory;
            var fullDirectory = $"{baseDirectory}{EasyFastConsts.UploadFilePath}\\{columnName}\\{dir}\\";

            var newName = $"{Md5Helper.GetFileMd5(file.InputStream)}{ext}";

            if (!Directory.Exists(fullDirectory))
                Directory.CreateDirectory(fullDirectory);

            var fullName = $"{fullDirectory}{newName}";
            await Task.Factory.StartNew(() =>
            {
                using (Image img = Image.FromStream(file.InputStream))
                {
                    if (!string.IsNullOrWhiteSpace(width))
                    {
                        if (img.Width > Int32.Parse(width))
                            throw new UserFriendlyException($"请上传宽固定为{width}px的图片");
                    }
                    if (!string.IsNullOrWhiteSpace(height))
                    {
                        if (img.Width > Int32.Parse(height))
                            throw new UserFriendlyException($"请上传高固定为{height}px的图片");
                    }
                    img.Save(fullName);
                }
            });
            return $"/{EasyFastConsts.UploadFilePath}/{columnName}/{dir}/{newName}";

        }
    }
}
