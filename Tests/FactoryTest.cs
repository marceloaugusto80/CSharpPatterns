using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FactoryTest
    {
        IFooFactory factory;


        [TestMethod]
        public void FactoryHeaven()
        {
            factory = new FactoryHeaven();
            IFoo foo = factory.Create();
            Assert.AreEqual(foo.Bar(), "good");
        }


        [TestMethod]
        public void FactoryHell()
        {
            factory = new FactoryHell();
            IFoo foo = factory.Create();
            Assert.AreEqual(foo.Bar(), "evil");
        }


    }
}
