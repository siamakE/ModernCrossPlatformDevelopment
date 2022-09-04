using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Chapter13
{
    [TestClass]
    public class Chapter13
    {
        [TestMethod]
        public void SyncTestMethod()
        {
            MethodA();
            MethodB();
            MethodC();
        }
        [TestMethod]
        public void AsyncTestMethod()
        {
            var taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new System.Action(MethodC));

            Task.WaitAll(new Task[] { taskA, taskB, taskC });
        }
        private static object coach = new object();
        [TestMethod]
        public void SharedResourceTestMethod()
        {
            var taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new System.Action(MethodC));

            Task.WaitAll(new Task[] { taskA, taskB, taskC });
        }

        private void MethodA()
        {
            lock (coach)
            {
                WriteLine("Starting Method A...");
                Thread.Sleep(3000); // simulate three seconds of work
                WriteLine("Finished Method A.");
            }
           
        }
        private void MethodB()
        {
            lock (coach)
            {
                WriteLine("Starting Method B...");
                Thread.Sleep(2000); // simulate three seconds of work
                WriteLine("Finished Method B.");
            }
            
        }
        private void MethodC()
        {
            lock (coach)
            {
                WriteLine("Starting Method C...");
                Thread.Sleep(1000); // simulate three seconds of work
                WriteLine("Finished Method C.");
            }
        }
    }
}