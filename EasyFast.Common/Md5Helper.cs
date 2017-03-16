using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Common
{
    /// <summary>
    /// md5散列处理帮助类
    /// </summary>
    public class Md5Helper
    {
        /// <summary>
        /// 获取文件的MD5散列值 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string GetFileMd5(Stream file)
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            var sb = new StringBuilder();
            foreach (var val in retVal)
            {
                sb.Append(val.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
