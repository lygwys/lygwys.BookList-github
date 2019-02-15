
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using lygwys.BookList.BookListManagement.CloudBooksLists.Dtos;
using lygwys.BookList.BookListManagement.CloudBooksLists;

namespace lygwys.BookList.BookListManagement.CloudBooksLists
{
    /// <summary>
    /// CloudBookList应用层服务的接口方法
    ///</summary>
    public interface ICloudBookListAppService : IApplicationService
    {
        /// <summary>
		/// 获取CloudBookList的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<CloudBookListListDto>> GetPaged(GetCloudBookListsInput input);


		/// <summary>
		/// 通过指定id获取CloudBookListListDto信息
		/// </summary>
		Task<CloudBookListListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetCloudBookListForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改CloudBookList的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateCloudBookListInput input);


        /// <summary>
        /// 删除CloudBookList信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除CloudBookList
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出CloudBookList为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
