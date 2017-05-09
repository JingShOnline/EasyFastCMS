using System.Collections.Generic;
using EasyFast.Application.Authorization.Permissions.Dto;

namespace EasyFast.Web.Areas.Admin.Models.Common
{
    public interface IPermissionsEditViewModel
    {

        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}
