using CSharpPatterns;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Foo
    {
        private int Bar()
        {
            return 1;
        }
    }

    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void CommandManager()
        {
            Target target = new Target();

            CommandManager manager = new CommandManager();

            Assert.AreEqual(target.Value, 0);

            manager.Execute(new SetTargetValueCommand(target, 5));
            Assert.AreEqual(target.Value, 5);

            manager.Execute(new MultiplyTargetValueCommand(target, 3));
            Assert.AreEqual(target.Value, 15);

            manager.Undo(); 
            Assert.AreEqual(target.Value, 5, "Undoing multiply 1");

            manager.Redo(); 
            Assert.AreEqual(target.Value, 15, "Redo multiply 1");

            manager.Undo(); 
            Assert.AreEqual(target.Value, 5, "Undo multiply 2");

            manager.Redo();
            Assert.AreEqual(target.Value, 15, "Redo multitply 2");

            manager.Undo();
            manager.Undo();
            Assert.AreEqual(target.Value, 0, "Undo sum 1");

        }


    }
}
