using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpPatterns;

namespace Tests
{
    [TestClass]
    public class StrategyTest
    {
        [TestMethod]
        public void Repeater()
        {
            RepeateBehaviour repeater = new RepeateBehaviour();

            Assert.AreEqual(repeater.GetText(1), "I'm a repeater. ");
            Assert.AreEqual(repeater.GetText(2), "I'm a repeater. I'm a repeater. ");
        }

        [TestMethod]
        public void Parser()
        {
            ParserBehaviour parser = new ParserBehaviour();
            Assert.AreEqual(parser.GetText(1), "1");
            Assert.AreEqual(parser.GetText(2), "2");
            Assert.AreEqual(parser.GetText(3), "3");
        }
    }
}
