using EasyFast.Application.ContentModel.ModelRecord;
using EasyFast.Application.Model;
using EasyFast.Application.Model.Dto;
using EasyFast.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace EasyFast.Web.Areas.Admin.Controllers
{

    [AbpMvcAuthorize]
    public class ModelController : EasyFastControllerBase
    {
        // GET: Admin/Model
        private readonly IModelAppService _modelAppService;

        public ModelController(IModelAppService modelAppService)
        {
            _modelAppService = modelAppService;
        }


        public ActionResult Index()
        {
            return View();
        }

    }
}