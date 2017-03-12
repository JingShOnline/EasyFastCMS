using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyFast.Application.Config.Dto;
using Abp.Domain.Repositories;
using EasyFast.Core.Entities;
using AutoMapper;

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

        public SiteInfoDto GetSiteInfo()
        {
            var data = _siteConfigRepository.GetAll().FirstOrDefault();
            return Mapper.Map<SiteInfoDto>(data);
        }

        public SiteOptionDto GetSiteOption()
        {
            var data = _siteConfigRepository.GetAll().FirstOrDefault();
            return Mapper.Map<SiteOptionDto>(data);
        }

        public void UpdateSiteInfo(SiteInfoDto model)
        {
            var data = Mapper.Map<SiteConfig>(model);
            _siteConfigRepository.InsertOrUpdate(data);
        }

        public void UpdateSiteOption(SiteOptionDto model)
        {
            var data = Mapper.Map<SiteConfig>(model);
            _siteConfigRepository.InsertOrUpdate(data);
        }
    }
}
