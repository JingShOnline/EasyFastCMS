using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EasyFast.Application.ContentModel.ModelRecord.Dto;

namespace EasyFast.Application.ContentModel.ModelRecord
{
    /// <summary>
    /// 内容模型记录资源
    /// </summary>
    public class ModelRecordAppService : ApplicationService, IModelRecordAppService
    {

        private readonly IRepository<Core.Entities.ModelRecord> _modelRecordRepository;

        public ModelRecordAppService(IRepository<Core.Entities.ModelRecord> modelrRepository)
        {
            this._modelRecordRepository = modelrRepository;
        }



        /// <summary>
        /// 分页获取内容模型记录基本信息带有搜索
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<BasicModelRecordOutput>> GetContentModels(GetModelsInput input)
        {
            var result = _modelRecordRepository.GetAll();
            if (!string.IsNullOrWhiteSpace(input.Filter))
            {
                result = result.Where(o => o.ModelName.Contains(input.Filter));
            }
            int totalCount = await result.CountAsync();

            var list = await result.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            return new PagedResultDto<BasicModelRecordOutput>(
                   totalCount,
                   list.MapTo<List<BasicModelRecordOutput>>()
                   );
        }

        /// <summary>
        /// 删除模型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteModel(int id)
        {
            //这里应该把相应的表删除
            await _modelRecordRepository.DeleteAsync(id);
        }



        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateModel(ModelRecordDto model)
        {
            await _modelRecordRepository.InsertAsync(model.MapTo<Core.Entities.ModelRecord>());
        }

        /// <summary>
        /// 修改模型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateModel(ModelRecordDto model)
        {
            var cModel = await _modelRecordRepository.GetAsync(model.Id);
            model.MapTo(cModel);
            await _modelRecordRepository.UpdateAsync(cModel);
        }

        /// <summary>
        /// 删除或修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task CreateOrUpdate(ModelRecordDto model)
        {
            if (model.Id == 0)
            {
                await CreateModel(model);
            }
            else
            {
                await UpdateModel(model);
            }

        }

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModelRecordDto> GetAsync(int id)
        {
            var model = await _modelRecordRepository.GetAsync(id);
            return model.MapTo<ModelRecordDto>();
        }
    }
}
