using AutoMapper;
using LowCode.DTO;
using LowCode.Helper;
using LowCode.IService.IServiceRBAC;
using LowCode.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace LowCode.Service.ServiceRBAC
{
    public class UserRoleModelService : ApplicationService, IUserRoleService
    {
        private IRepository<MyUserRoleModel, int> repository;
        public UserRoleModelService(IRepository<MyUserRoleModel, int> _repository)
        {
            repository = _repository;
        }

        [HttpPost, Route("AddUserRole")]
        public async Task<DataResult<int>> AddAsync(UserRoleModelDto roleModelDto)
        {
            try
            {
                var data = ObjectMapper.Map<UserRoleModelDto, MyUserRoleModel>(roleModelDto);
                await repository.InsertAsync(data);
                return new DataResult<int>
                {
                    Message = "成功",
                    TypeCode = HelperEnum.HttpCode.成功
                };
            }
            catch (Exception)
            {
                return new DataResult<int>
                {
                    Message = "添加失败",
                    TypeCode = HelperEnum.HttpCode.服务器内部错误

                };
            }
        }
        [HttpPost, Route("DeleteUserRole")]
        public async Task<DataResult<UserRoleModelDto>> DeleteAsync(int id)
        {
            try
            {
                var list = await repository.GetListAsync();
                var data = list.Where(x => x.Id.Equals(id)).FirstOrDefault();
                if (data != null)
                {
                    await repository.DeleteAsync(id);
                    return new DataResult<UserRoleModelDto>
                    {
                        Message = "删除成功",
                        TypeCode = HelperEnum.HttpCode.成功
                    };
                }
                return new DataResult<UserRoleModelDto>
                {
                    Message = "删除失败",
                    TypeCode = HelperEnum.HttpCode.服务器内部错误
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost, Route("QueryUserRole")]
        public async Task<DataPageReuslt<List<UserRoleModelDto>>> QueryAsync(int PageIndex, int PageSize)
        {
            try
            {
                List<MyUserRoleModel> list = await repository.GetListAsync();
                int total = list.Count();
                var data = ObjectMapper.Map<List<MyUserRoleModel>, List<UserRoleModelDto>>(list);
                data = data.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
                return new DataPageReuslt<List<UserRoleModelDto>>
                {
                    Result = data,
                    Total = total,
                    Message = "显示",
                    TypeCode = HelperEnum.HttpCode.成功
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
       

        [HttpPost,Route("UpdateUserRole")]
        public Task<DataResult<int>> UpdateAsync(UserRoleModelDto roleModelDto)
        {
            throw new NotImplementedException();
        }

        
    }
}

