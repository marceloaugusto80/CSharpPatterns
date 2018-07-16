using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;


namespace Tests
{
    class Bar
    {
        public int Id { get; private set; }

        public Bar()
        {
            for (int i = 0; i < 9_999; i++)
            {
                Id = i;
            }
        }
    }

    class BarFactory : IPoolFactory<Bar>
    {
        public Bar Create()
        {
            return new Bar();
        }
    }


    [TestClass]
    public class ObjectPoolTest
    {
        private int count = 100;
        [TestMethod]
        public void ObjectPool()
        {
            var pool = new ObjectPool<Bar>(new BarFactory(), count);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < count; i++)
            {
                using (var wrapper = pool.Get())
                {
                    var bar = wrapper.Use();
                }
            }
            sw.Stop();
            Debug.WriteLine($"Pool elapsed { sw.ElapsedMilliseconds } mili", "Tests");

        }

    }
}
