using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpPatterns;

namespace Tests
{
    [TestClass]
    public class SingletonTest
    {

        [TestMethod]
        public void StaticAccessibility()
        {
            Assert.AreEqual(Singleton.Instance.GetNumberTen(), 10);
            Assert.AreEqual(Singleton.Instance.GetNumberThree(), 3);

        }


    }
}
