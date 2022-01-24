using LowCode.DTO;
using LowCode.Helper;
using LowCode.IService.IServiceRBAC;
using LowCode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LowCode.Service.ServiceRBAC
{
    public class TreeModelService : ApplicationService, ITreeService
    {

        private IRepository<TreeModel, int> repository;
        public TreeModelService(IRepository<TreeModel, int> _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public async Task<DataResult<List<TreeModelDto>>> treeModelDtos(int pid = 0)
        {
            try
            {
               var  dtos= await QueryTreeAsync(pid);
              return  new DataResult<List<TreeModelDto>>
                {
                    Result = dtos,
                    Message = "显示成功!",
                    TypeCode = HelperEnum.HttpCode.成功
                };
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        private  async Task<List<TreeModelDto>>  QueryTreeAsync(int pid=0)
        {
            var Tree = await repository.GetListAsync();

            Tree = Tree.Where(x => x.TreeTid.Equals(pid)).ToList();

            List<TreeModelDto> treeModel = new List<TreeModelDto>();

            Tree.ForEach(async x=>{
                TreeModelDto treeModelDto = new TreeModelDto();
                treeModelDto.TreeName = x.TreeName;
                treeModelDto.Level= x.Level;
                treeModelDto.TreeDetail = x.TreeDetail;
                treeModelDto.Node_type = x.Node_type;
                treeModelDto.Link_url = x.Link_url;
                treeModelDto.Path = x.Path;
                treeModelDto.TreeName = x.TreeName;
                treeModelDto.list = await QueryTreeAsync(x.Id);
                treeModel.Add(treeModelDto);
            });
            return treeModel;
        }
    }
}
