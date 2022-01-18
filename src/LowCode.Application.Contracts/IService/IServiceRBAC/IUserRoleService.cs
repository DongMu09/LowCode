using LowCode.DTO;
using LowCode.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LowCode.IService.IServiceRBAC
{
    public interface IUserRoleService : IApplicationService
    {
        public Task<DataResult<int>> AddAsync(UserRoleModelDto roleModelDto);

        public Task<DataResult<UserRoleModelDto>> DeleteAsync(int id);

        public Task<DataResult<int>> UpdateAsync(UserRoleModelDto roleModelDto);

        public Task<DataPageReuslt<List<UserRoleModelDto>>> QueryAsync(int PageIndex, int PageSize);
    }
}
