using System.Linq;

namespace EasyFast.Common
{
    /// <summary>
    /// 格式化验证帮助类
    /// </summary>
    public class ForMatterHelper
    {
        private static string[] imgExt = { ".jpg", ".jpeg", ".gif", ".png" };

        private static int MaxImgLength = (1024 * 8) * 1024;


        /// <summary>
        /// 是否是有效的图片文件
        /// </summary>
        /// <param name="ext"></param>
        public static bool ValidImgExt(string ext)
        {
            return imgExt.Contains(ext.ToLower());
        }

        /// <summary>
        /// 验证图片大小
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static bool ValidImgLength(int length)
        {
            return length < MaxImgLength;

        }

        /// <summary>
        /// 去除html标签
        /// </summary>
        /// <param name="html"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");
            strText = strText.Replace("\r\n", "").Trim();
            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}
