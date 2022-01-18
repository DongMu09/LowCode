using LowCode.DTO;
using LowCode.Helper;
using LowCode.Verification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace LowCode.IService.IServiceRBAC
{
    public interface IPowerService : IApplicationService
    {
        public Task<DataResult<int>> AddAsync(PowerModelDto powerModelDto);

        public Task<DataResult<PowerModelDto>> DeleteAsync(int id);

        public Task<DataResult<int>> UpdateAsync(PowerModelDto powerModelDto);

        public Task<DataResult<List<PowerModelDto>>> QueryAsync(int PageIndex, int PageSize);
    }
}
