using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EasyFast.Application.Upload.Dto
{
    /// <summary>
    /// 上传文件所用Dto
    /// </summary>
    public class WebUploadDto
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string lastModifiedDate { get; set; }
        public int  size { get; set; }
        public HttpPostedFileBase File { get; set; }
        public string ColumnName { get; set; }
        public string Dir { get; set; }
    }
}
