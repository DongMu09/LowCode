using LowCode.DTO;
using LowCode.Helper;
using LowCode.Helper.EmailHelper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LowCode.IService.IServiceRBAC
{
    public interface IRoleService : IApplicationService
       // ICrudAppService<RoleModelDto, int, PagedAndSortedResultRequestDto, CreateUpDateRoleModelDto>
    {
       public Task<DataResult<int>>     AddAsync(RoleModelDto roleModelDto);

        public Task<DataResult<RoleModelDto>>   DeleteAsync(int id);

        public int Email([FromForm] Mail mails);

        public Task<DataResult<int>> UpdateAsync(RoleModelDto roleModelDto);

        public Task<DataResult<List<RoleModelDto>>> QueryAsync(int PageIndex,int PageSize);


    }



}
