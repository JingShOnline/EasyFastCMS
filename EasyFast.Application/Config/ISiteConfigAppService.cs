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
        SiteOptionDto GetSiteOption();
        void UpdateSiteOption(SiteOptionDto model);

        SiteInfoDto GetSiteInfo();
        void UpdateSiteInfo(SiteInfoDto model);
    }
}
