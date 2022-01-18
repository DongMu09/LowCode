using LowCode.DTO;
using LowCode.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace LowCode.IService.IServiceRBAC
{
    public interface ITreeService : IApplicationService
    {
        //递归
        public Task<DataResult<List<TreeModelDto>>> treeModelDtos(int pid = 0);
    }
}
