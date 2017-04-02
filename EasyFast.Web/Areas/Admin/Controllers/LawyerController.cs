using Abp.Threading;
using EasyFast.Application.Lawyer;
using EasyFast.Application.Lawyer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 律师模型
    /// </summary>
    [AbpMvcAuthorize]
    public class LawyerController : Controller
    {

        private readonly ILawyerAppService _lawyerAppService;

        public LawyerController(ILawyerAppService lawyerAppService)
        {
            _lawyerAppService = lawyerAppService;
        }

        /// <summary>
        /// 转到添加律师页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddContent()
        {
            return PartialView(new LawyerDto());
        }

        /// <summary>
        /// 转到更新律师页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateContent(int id)
        {
            var model = AsyncHelper.RunSync(() => _lawyerAppService.GetAsync(id));


            return PartialView("AddContent", model);
        }
    }
}