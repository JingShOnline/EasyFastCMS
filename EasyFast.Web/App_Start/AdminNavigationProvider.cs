using Abp.Application.Navigation;
using Abp.Localization;
using EasyFast.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyFast.Web.App_Start
{
    public class AdminNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            //后台管理菜单
            context.Manager.Menus["AdminMenu"] = new MenuDefinition("AdminMenu", L("EasyFastCmsAdminManager"))
                .AddItem(
                    new MenuItemDefinition(
                        "AdminHome",
                        L("AdminHome"),
                        url: "/Admin/Home/Index",
                        icon: "icon-home"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        "UserManager",
                        L("UserManager"),
                        url: "/Admin/Client/Index/",
                        icon: "fa fa-users"
                        ).AddItem(
                            new MenuItemDefinition(
                                "AdminUserManager",
                                L("AdminUserManager"),
                               url: "/Admin/User/AdminList"
                        )).AddItem(
                           new MenuItemDefinition(
                                "MemberManager",
                                L("MemberManager"),
                                url: "/Admin/User/MemberList"
                        )).AddItem(
                            new MenuItemDefinition(
                                "UserRoleManager",
                                L("UserRoleManager"),
                                url: "/Admin/User/UserRoleList"
                           ))
                 ).AddItem(new MenuItemDefinition(
                        "ContentManager",
                        L("ContentManager"),
                        icon: "fa fa-file-word-o"
                        ).AddItem(new MenuItemDefinition(
                            "ContentInfoManager",
                            L("ContentInfoManager"),
                            url: "/Admin/Content/Index"
                        ))

                ).AddItem(new MenuItemDefinition(
                        "HtmlGenerate",
                        L("HtmlGenerate"),
                        icon: "fa fa-file-code-o"
                    ).AddItem(new MenuItemDefinition(
                            "IndexGenerate",
                            L("IndexGenerate"),
                            url: "/Admin/HtmlGenerate/Index"
                    )).AddItem(new MenuItemDefinition(
                            "ContentGenerate",
                            L("ContentGenerate"),
                            url: "/Admin/HtmlGenerate/Content"
                    )).AddItem(new MenuItemDefinition(
                            "ColumnListGenerate",
                            L("ColumnListGenerate"),
                            url: "/Admin/HtmlGenerate/List"
                    )).AddItem(new MenuItemDefinition(
                            "CleanStaticFile",
                            L("CleanStaticFile"),
                           url: "/Admin/HtmlGenerate/CleanStaticFile"

                        )))
                .AddItem(new MenuItemDefinition(
                    "ColumnRelatedManager",
                    L("ColumnRelatedManager"),
                   icon: "icon-bar-chart"
                    ).AddItem(new MenuItemDefinition(
                        "ColumnManager",
                        L("ColumnManager"),
                        url: "/Admin/Column/Index"
                    )).AddItem(new MenuItemDefinition(
                        "ModelManager",
                        L("ModelManager"),
                        url: "/Admin/Model/Index"
                    )))
                .AddItem(new MenuItemDefinition(
                   "SiteManager",
                   L("SiteManager"),
                   icon: "icon-settings"
                 ).AddItem(new MenuItemDefinition(
                        "SiteInfo",
                        L("SiteInfo"),
                        url: "/Admin/SiteConfig/SiteInfo"
                 )).AddItem(new MenuItemDefinition(
                        "SiteOption",
                        L("SiteOption"),
                        url: "/Admin/SiteConfig/SiteOption"
                )));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EasyFastConsts.LocalizationSourceName);
        }
    }
}