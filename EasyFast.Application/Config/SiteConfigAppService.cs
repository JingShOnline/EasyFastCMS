using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.AutoMapper;
using EasyFast.Application.Config.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace EasyFast.Application.Config
{
    public class SiteConfigAppService : EasyFastAppServiceBase, ISiteConfigAppService
    {
        #region 依赖注入
        private readonly IRepository<SiteConfig> _siteConfigRepository;
        public SiteConfigAppService(IRepository<SiteConfig> siteConfigRepository)
        {
            _siteConfigRepository = siteConfigRepository;
        }
        #endregion

        public async Task<SiteInfoDto> GetSiteInfo()
        {
            return await _siteConfigRepository.GetAll().ProjectTo<SiteInfoDto>().FirstOrDefaultAsync();

        }

        public async Task<SiteOptionDto> GetSiteOption()
        {
            return await _siteConfigRepository.GetAll().ProjectTo<SiteOptionDto>().FirstOrDefaultAsync();
        }

        public async Task<SiteConfigDto> GetSiteConfig()
        {
            var model = await _siteConfigRepository.GetAll().FirstOrDefaultAsync();
            return model.MapTo<SiteConfigDto>();
        }

        public async Task UpdateSiteInfo(SiteInfoDto model)
        {
            var data = Mapper.Map<SiteConfig>(model);
            await _siteConfigRepository.InsertOrUpdateAsync(data);
        }

        //这种更新会把SiteInfo的覆盖掉
        public async Task UpdateSiteOption(SiteOptionDto model)
        {
            var data = Mapper.Map<SiteConfig>(model);
            await _siteConfigRepository.InsertOrUpdateAsync(data);
        }

        public async Task UpdateSiteConfig(SiteConfigDto dto)
        {
            await _siteConfigRepository.InsertOrUpdateAsync(dto.MapTo<SiteConfig>());
        }
    }
}
