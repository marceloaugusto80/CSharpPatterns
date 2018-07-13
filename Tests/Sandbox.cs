using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class Sandbox
    {
        enum WeekDays
        {
            MON,
            TUE,
            WED,
            THU,
            FRI,
            SAT,
            SUN
        }


        [TestMethod]
        public void EnumTest()
        {
            WeekDays wd = WeekDays.TUE;

            int wdNum = (int)wd;
            WeekDays newWd = (WeekDays)wdNum;

            Assert.AreEqual(wdNum, 1);
            Assert.AreEqual(newWd, wd);

        }

        [TestMethod]
        public void CallTryFinnaly()
        {
            string result = TryCatchTest();
            Assert.AreEqual(result, "try");
        }

        public string TryCatchTest()
        {
            string result = "";
            try
            {
                result = "try";
            return result;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                result = "finally";
            }
        }

    }
}
