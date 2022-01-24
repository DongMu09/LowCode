using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeProject.WorkFlow
{
    public interface IDoFlowBuilder
    {
        /// <summary>
        /// 开始一个 step
        /// </summary>
        IStepBuilder StartWith(Action action = null);
        void EndWith(Action action);
        Task ThatTask { get; }
    }
}
