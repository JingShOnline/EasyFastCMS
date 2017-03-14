﻿using Abp.Application.Navigation;
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
                        icon: "icon-Users"
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
                        "ContentManger",
                        L("ContentManager"),
                        icon: "fa fa-file-word-o"
                        ).AddItem(new MenuItemDefinition(
                            "ContentInfoManager",
                            L("ContentInfoManger"),
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
                            "SingleGenerate",
                            L("SingleGenerate"),
                            url: "/Admin/HtmlGrnerate/Single"
                    )).AddItem(new MenuItemDefinition(
                            "ColumnGenerate",
                            L("SingleGenerate"),
                            url: "/Admin/HtmlGenerate/Column"
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
                        "ConentModelManager",
                        L("ConentModelManager"),
                        url: "/Admin/ContentModel/Index"
                    )))
                .AddItem(new MenuItemDefinition(
                   "SiteManager",
                   L("SiteManager"),
                   icon: "icon-settings"
                 ).AddItem(new MenuItemDefinition(
                        "SiteInfoManager",
                        L("SiteInfoManager"),
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