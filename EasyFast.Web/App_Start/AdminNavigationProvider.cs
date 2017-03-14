using Abp.Application.Navigation;
using Abp.Localization;
using EasyFast.Core;

namespace EasyFast.Web
{
    public class AdminNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            //后台管理菜单
            context.Manager.Menus["AdminMenu"] = new MenuDefinition("AdminMenu", L("EasyFastCmsAdminManager"))
                .AddItem(
                    new MenuItemDefinition(
                        "Column",
                        L("Column"),
                        url: "/Admin/Column/Index",
                        icon: "icon-docs"
                    ).AddItem(
                        new MenuItemDefinition(
                            "AddColumn",
                            L("AddColumn"),
                            url: "/Admin/Column/AddColumn"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            "AddSignleColumn",
                            L("AddSignleColumn"),
                            url: "/Admin/Column/AddSingle"
                        )
                        )
                ).AddItem(new MenuItemDefinition(
                        "ContentModel",
                        L("ContentModel"),
                        url: "/Admin/ContentModel/Index",
                        icon: "icon-note"
               )).AddItem(new MenuItemDefinition(
                        "ContentManger",
                        L("ContentManager"),
                        url: "/Admin/ContentManager/Index",
                        icon: "icon-grid"
                   ));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EasyFastConsts.LocalizationSourceName);
        }
    }
}