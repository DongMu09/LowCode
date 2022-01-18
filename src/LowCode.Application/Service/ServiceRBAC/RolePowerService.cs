﻿using LowCode.DTO;
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
    public class RolePowerService : ApplicationService, IRolePowerService
    {
        private readonly IRepository<MyRolePowerModel, int> repository;
        public RolePowerService(IRepository<MyRolePowerModel, int> _repository)
        {
            repository = _repository;
        }

        [HttpPost,Route("AddRolePower")]
        public async Task<DataResult<int>> AddAsync(RolePowerModelDto roleModelDto)
        {
            try
            {
                var data = ObjectMapper.Map<RolePowerModelDto, MyRolePowerModel>(roleModelDto);
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

        [HttpPost, Route("DeleteRolePower")]
        public async Task<DataResult<RolePowerModelDto>> DeleteAsync(int id)
        {
            try
            {
                var list = await repository.GetListAsync();
                var data = list.Where(x => x.Id.Equals(id)).FirstOrDefault();
                if (data != null)
                {
                    await repository.DeleteAsync(id);
                    return new DataResult<RolePowerModelDto>
                    {
                        Message = "删除成功",
                        TypeCode = HelperEnum.HttpCode.成功
                    };
                }
                return new DataResult<RolePowerModelDto>
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

        [HttpPost, Route("QueryRolePower")]
        public async Task<DataResult<List<RolePowerModelDto>>> QueryAsync(int PageIndex, int PageSize)
        {
            try
            {
                List<MyRolePowerModel> list = await repository.GetListAsync();
                var data = ObjectMapper.Map<List<MyRolePowerModel>, List<RolePowerModelDto>>(list);
                data = data.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
                return new DataResult<List<RolePowerModelDto>>
                {
                    Result = data,
                    Message = "显示",
                    TypeCode = HelperEnum.HttpCode.成功
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost, Route("UpdateRolePower")]
        public async Task<DataResult<int>> UpdateAsync(RolePowerModelDto roleModelDto)
        {
            try
            {
                var data = ObjectMapper.Map<RolePowerModelDto, MyRolePowerModel>(roleModelDto);
                var Count = await repository.UpdateAsync(data);
                if (Count != null)
                {
                    return new DataResult<int>
                    {
                        Message = "修改成功",
                        TypeCode = HelperEnum.HttpCode.成功
                    };
                }
                else
                {
                    return new DataResult<int>
                    {
                        Message = "修改失败",
                        TypeCode = HelperEnum.HttpCode.服务器内部错误
                    };
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
