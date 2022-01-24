using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeProject.WorkFlow
{
    public interface IDoFlow
    {
        /// <summary>
        /// 全局唯一标识
        /// </summary>
        int Id { get; }

        /// <summary>
        /// 标识此工作流的名称
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 标识此工作流的版本
        /// </summary>
        int Version { get; }

        IDoFlowBuilder Build(IDoFlowBuilder builder);
    }
}
