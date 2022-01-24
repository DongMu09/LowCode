using DoFlow.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCodeProject.WorkFlow
{
    public class MyFlow1 : IDoFlow
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id => 2;

        public string Name =>"test";   

        public int Version =>1;

        public IDoFlowBuilder Build(IDoFlowBuilder builder)
        {

            //builder.StartWith(() =>
            //{
            //    Console.WriteLine("工作流开始");
            //}).Then(() =>
            //{
            //    Console.WriteLine("下一个节点");
            //}).Then(() =>
            //{
            //    Console.WriteLine("最后一个节点");
            //});

            builder.StartWith()
           .Parallel(steps =>
           {
                // 每个并行任务也可以设计后面继续执行其它任务
                steps.Do(() =>
               {
                   Console.WriteLine("并行1");
               }).Do(() =>
               {
                   Console.WriteLine("并行2");
               });
               steps.Do(() =>
               {
                   Console.WriteLine("并行3");
               });

                // 并行任务设计完成后，必须调用此方法
                // 此方法必须放在所有并行任务 .Do() 的最后
                steps.EndParallel();

                // 如果 .Do() 在 EndParallel() 后，那么不会等待此任务
                steps.Do(() => { Console.WriteLine("并行异步"); });

               // 开启新的分支
               steps.StartWith()
              .Then(() =>
              {
                Console.WriteLine("新的分支" + Task.CurrentId);
              }).Then(() => { Console.WriteLine("分支2.0" + Task.CurrentId); });

           }, false)
           .Then(() =>
           {
               Console.WriteLine("11111111111111111 ");
           });

            return builder;
        }
    }
}
