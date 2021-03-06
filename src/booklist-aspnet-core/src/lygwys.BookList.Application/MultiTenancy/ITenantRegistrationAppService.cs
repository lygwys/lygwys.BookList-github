﻿using System.Threading.Tasks;
using Abp.Application.Services;
using lygwys.BookList.MultiTenancy.Dto;

namespace lygwys.BookList.MultiTenancy
{
    public interface ITenantRegistrationAppService:IApplicationService
    {
        /// <summary>
        /// 公开注册租户功能
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TenantDto> RegisterTenantAsync(CreateTenantDto input);
    }
}