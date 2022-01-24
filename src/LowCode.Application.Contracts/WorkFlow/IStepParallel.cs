using System;
using System.Collections.Generic;
using System.Text;

namespace LowCodeProject.WorkFlow
{
    public interface IStepParallel
    {
        /// <summary>
        /// 一个并行任务
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IStepParallel Do(Action action);

        /// <summary>
        /// 开始一个分支
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        IStepBuilder StartWith(Action action = null);

        /// <summary>
        /// 必须使用此方法结束一个并行任务
        /// </summary>
        void EndParallel();
    }
    /// <summary>
    /// 并行任务
    /// <para>任意一个任务完成后，就可以跳转到下一个 step</para>
    /// </summary>
    public interface IStepParallelAny : IStepParallel
    {

    }

}
