using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using EasyFast.Core.Authorization.Roles;

namespace EasyFast.Application.Authorization.Roles.Dto
{
    [AutoMap(typeof(Role))]
    public class RoleEditDto
    {
        public int? Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public bool IsDefault { get; set; }
    }
}
