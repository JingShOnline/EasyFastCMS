using System.Data.Common;
using Abp.Zero.EntityFramework;
using EasyFast.Core.Authorization.Roles;
using EasyFast.Core.MultiTenancy;
using EasyFast.Core.Users;
using System.Data.Entity;
using EasyFast.Core.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EasyFast.EntityFramework
{
    public class EasyFastDbContext : AbpZeroDbContext<Tenant, Role, User>
    {

        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public EasyFastDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in EasyFastDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of EasyFastDbContext since ABP automatically handles it.
         */
        public EasyFastDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public EasyFastDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        #region Entity
        public virtual IDbSet<Column> Column { get; set; }
        public virtual IDbSet<Common_Model> CommonTitle { get; set; }
        public virtual IDbSet<Content_Article> Content_Article { get; set; }
        public virtual IDbSet<Content_Lawyer> Content_Lawyer { get; set; }
        public virtual IDbSet<Model> Model { get; set; }
        public virtual IDbSet<SiteConfig> SiteConfig { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //将表名固定为单数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //关闭延迟加载
            this.Configuration.LazyLoadingEnabled = false;
            //关闭级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
