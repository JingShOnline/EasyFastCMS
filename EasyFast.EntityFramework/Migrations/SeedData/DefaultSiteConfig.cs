using EasyFast.Core.Entities;
using EasyFast.EntityFramework;
using EntityFramework.DynamicFilters;
using EasyFast.Core.Entities;

namespace EasyFast.Migrations.SeedData
{
    public class DefaultSiteConfig
    {
        private readonly EasyFastDbContext _context;

        public DefaultSiteConfig(EasyFastDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.SiteConfig.Add(new SiteConfig
            {
                TemplateDir = "/Template",
                TagDir = "Tags",
                PageDir = "Pages",
                CodeDir = "Codes"
            });
            _context.Column.Add(new Column
            {
                ColumnTypeEnum = ColumnTypeEnum.Single,
                Name = "站点首页",
                Dir = "/",
                SingleTemplate = "Index.html",
                IsCreateSingle = true,
                SingleHtmlRule = "Index.html"
            });

            _context.SaveChanges();
        }
    }
}
