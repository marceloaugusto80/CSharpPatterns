using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPatterns;


namespace Tests
{
    class FooListener : IListener<SubjectChangedArgs>
    {
        public int NewValue { get; private set; }
        public int OldValue { get; private set; }

        public void OnNotify(SubjectChangedArgs args)
        {
            NewValue = args.NewValue;
            OldValue = args.OldValue;
        }
    }


    [TestClass]
    public class SubjectTest
    {
        [TestMethod]
        public void SubjectUpdatesListeners()
        {
            Subject subject = new Subject();
            FooListener listener = new FooListener();

            subject.AddListener(listener);

            Assert.AreEqual(listener.OldValue, 0);
            Assert.AreEqual(listener.NewValue, 0);

            subject.SetValue(10);

            Assert.AreEqual(listener.OldValue, 0);
            Assert.AreEqual(listener.NewValue, 10);

            subject.SetValue(20);

            Assert.AreEqual(listener.OldValue, 10);
            Assert.AreEqual(listener.NewValue, 20);

        }
    }
}
