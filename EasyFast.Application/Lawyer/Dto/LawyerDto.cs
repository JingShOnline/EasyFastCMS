using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EasyFast.Application.Content.Dto;
using EasyFast.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Lawyer.Dto
{
    /// <summary>
    /// 律师Dto
    /// </summary>
    [AutoMap(typeof(Content_Lawyer))]
    public class LawyerDto : AddContentDto
    {

        [DisplayName("律师姓名")]
        [Required(ErrorMessage = "请填写律师姓名")]
        public override string Title { get; set; }

        [DisplayName("律师列表小图")]
        [Required(ErrorMessage = "请上传律师列表小图")]
        public override string DefaultPicUrl { get; set; }

        [DisplayName("律师简介")]
        [Required(ErrorMessage = "请输入律师简介")]
        public override string Info { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [Required(ErrorMessage = "请填写职位信息")]
        [StringLength(50, ErrorMessage = "职位描述应在50字之内")]
        public string Position { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [Phone(ErrorMessage = "请输入并且格式正确的手机号")]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [EmailAddress(ErrorMessage = "请输入并且格式正确的邮箱地址")]
        public string Email { get; set; }

        /// <summary>
        /// 律师详细介绍
        /// </summary>
        [Required(ErrorMessage = "请输入律师详细介绍")]
        public string Content { get; set; }
    }
}
