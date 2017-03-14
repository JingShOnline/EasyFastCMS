using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using EasyFast.Application.ContentModel.ModelRecord.Dto;

namespace EasyFast.Application.ContentModel.ModelRecord
{
    /// <summary>
    /// 模型记录资源 
    /// </summary>
    public interface IModelRecordAppService : IApplicationService
    {

        /// <summary>
        /// 分页获取内容模型记录基本信息带有搜索
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BasicModelRecordOutput>> GetContentModels(GetModelsInput input);

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
        Task<ModelRecordDto> GetAsync(int id);


        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateModel(ModelRecordDto model);

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateModel(ModelRecordDto model);

        /// <summary>
        /// 删除或修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateOrUpdate(ModelRecordDto model);
    }
}
