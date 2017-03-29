using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Lawyer.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using Abp.AutoMapper;

namespace EasyFast.Application.Lawyer
{
    /// <summary>
    /// 律师内容资源 
    /// </summary>
    public class LawyerAppService : ApplicationService, ILawyerAppService
    {

        private readonly IRepository<Content_Lawyer> _contentLawyerRepository;

        public LawyerAppService(IRepository<Content_Lawyer> contentLawyerrepository)
        {
            _contentLawyerRepository = contentLawyerrepository;
        }


       
        public async Task AddOrUpdateAsync(LawyerDto dto)
        {
            var model = dto.MapTo<Content_Lawyer>();

            await _contentLawyerRepository.InsertOrUpdateAsync(model);

        }

        public async Task<LawyerDto> GetAsync(int id)
        {
            var model = await _contentLawyerRepository.GetAsync(id);
            return model.MapTo<LawyerDto>();
        }

 
    }
}
