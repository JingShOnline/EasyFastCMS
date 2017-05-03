using System;


namespace EasyFast.Core
{
    public static class EasyFastConsts
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



        /// <summary>
        /// 标签匹配正则表达式
        /// </summary>
        public const string TagRegex = @"\#.*?\#";

        /// <summary>
        /// 地址
        /// </summary>
        public static string BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        /// 标签路径
        /// </summary>
        public static string TagPath = $@"{BaseDirectory}Template\Tag";

        /// <summary>
        /// 模型type提取正则
        /// </summary>
        public const string ModelTypeRegex = @"@model.+\s+<t>?";

        /// <summary>
        /// 静态文件地址
        /// </summary>
        public static string StaticFile = $@"{BaseDirectory}StaticFile\";

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
        public const string SqlParameterRegex = "\'.+\'";


    }
}