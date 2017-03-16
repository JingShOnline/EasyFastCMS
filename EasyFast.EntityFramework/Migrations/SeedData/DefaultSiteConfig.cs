using EasyFast.Core.Entities;
using EasyFast.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (_context.SiteConfig.FirstOrDefault() == null)
            {
                //初始化种子数据
                _context.SiteConfig.Add(new SiteConfig
                {
                    TemplateDir = "/Template",
                    TagDir = "Tags",
                    PageDir = "Pages",
                    CodeDir = "Codes"
                });

                List<Model> models = new List<Model>() {new Model()
                {
                ModelName = "文章模型",
                TableName = "Content_Article",
                Description="文章模型文章模型文章模型文章模型",
                CreationTime=DateTime.Now,
                LastModificationTime=DateTime.Now,
                ManagerControlerPath = "Article",
               },new Model()
                {
                    ModelName = "律师模型",
                    TableName = "Content_Lawyer",
                    Description="律师模型律师模型律师模型律师模型",
                     CreationTime=DateTime.Now,
                LastModificationTime=DateTime.Now,
                    ManagerControlerPath = "Lawyer"
                } };
                _context.Model.Add(models[0]);
                _context.Model.Add(models[1]);

                _context.SaveChanges();

                _context.Column.Add(new Column
                {
                    ColumnTypeEnum = ColumnTypeEnum.Single,
                    Name = "站点首页",
                    Dir = "/",
                    SingleTemplate = "Index.html",
                    IsCreateSingle = true,
                    SingleHtmlRule = "Index.html",
                    ModelId = models[0].Id
                });

                var news = new Column
                {
                    ColumnTypeEnum = ColumnTypeEnum.Normal,
                    Name = "新闻中心",
                    Dir = "/",
                    ModelId = models[0].Id
                };
                _context.Column.Add(news);
                _context.SaveChanges();
                _context.Column.Add(new Column
                {
                    ParentId = news.Id,
                    ColumnTypeEnum = ColumnTypeEnum.Normal,
                    Name = "时势新闻",
                    Dir = "/",
                    ModelId = models[0].Id
                });

                var lawyers = new Column
                {
                    ColumnTypeEnum = ColumnTypeEnum.Normal,
                    Name = "律师团队",
                    Dir = "/",
                    ModelId = models[1].Id
                };
                _context.Column.Add(lawyers);
                _context.SaveChanges();
                _context.Column.Add(new Column
                {

                    ParentId = lawyers.Id,
                    ColumnTypeEnum = ColumnTypeEnum.Normal,
                    Name = "京师团队",
                    Dir = "/",
                    ModelId = models[1].Id
                });

                _context.SaveChanges();
            }


        }
    }
}
