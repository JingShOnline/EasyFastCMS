using EasyFast.Application.Config.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Config
{
    public interface ISiteConfigAppService
    {
        Task<SiteOptionDto> GetSiteOption();
        Task UpdateSiteOption(SiteOptionDto model);

        Task<SiteInfoDto> GetSiteInfo();
        Task UpdateSiteInfo(SiteInfoDto model);

        Task<SiteConfigDto> GetSiteConfig();

        Task UpdateSiteConfig(SiteConfigDto dto);
    }
}
