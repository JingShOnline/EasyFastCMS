using Abp.Application.Services;
using EasyFast.Application.Lawyer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyFast.Application.Lawyer
{
    /// <summary>
    /// 律师内容资源 
    /// </summary>
    public interface ILawyerAppService : IApplicationService
    {
       

        /// <summary>
        /// 添加或修改律师
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task AddOrUpdateAsync(LawyerDto dto);



        /// <summary>
        /// 获取律师
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<LawyerDto> GetAsync(int id);
    }
}
