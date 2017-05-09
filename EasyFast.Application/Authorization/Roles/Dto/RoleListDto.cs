﻿using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using EasyFast.Core.Authorization.Roles;

namespace EasyFast.Application.Authorization.Roles.Dto
{
    [AutoMapFrom(typeof(Role))]
    public class RoleListDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
