using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{
    public class Singleton
    {
        private static Singleton _instance;
        public static Singleton Instance
        {
            get
            {
                if (_instance == null) _instance = new Singleton();
                return _instance;
            }
        }

        private Singleton()
        { }

        public int GetNumberThree()
        {
            return 3;
        }

        public int GetNumberTen()
        {
            return 10;
        }
    }
}
