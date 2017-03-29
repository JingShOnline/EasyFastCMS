using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Web.Models;
using EasyFast.Application.Model.Dto;
using EasyFast.Application.Common.Dto;

namespace EasyFast.Application.Model
{
    /// <summary>
    /// 模型记录资源 
    /// </summary>
    public interface IModelAppService : IApplicationService
    {

        /// <summary>
        /// 分页获取内容模型记录基本信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [DontWrapResult]
        Task<EasyUIGridOutput<BasicModelOutput>> GetModels(TreeGridInput input);

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteModel(int id);

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ModelDto> GetAsync(int id);


        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateModel(ModelDto model);

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateModel(ModelDto model);

        /// <summary>
        /// 删除或修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateOrUpdate(ModelDto model);
    }
}
