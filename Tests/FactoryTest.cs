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
        IVehicleFactory factory;


        [TestMethod]
        public void Test()
        {
            factory = new SimpleVehicleFactory(Terrains.AIR);
            Assert.IsInstanceOfType(factory.Create(), typeof(Plane));

            factory = new SimpleVehicleFactory(Terrains.LAND);
            Assert.IsInstanceOfType(factory.Create(), typeof(Car));

            factory = new SimpleVehicleFactory(Terrains.SEA);
            Assert.IsInstanceOfType(factory.Create(), typeof(Ship));

        }
    }




}
