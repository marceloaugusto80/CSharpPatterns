using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{
    
        
    public interface IBehaviour
    {
        string GetText(int value);
    }


    public class RepeateBehaviour : IBehaviour
    {
        public string GetText(int value)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < value; i++)
            {
                sb.Append("I'm a repeater. ");
            }

            return sb.ToString();
        }
    }

    public class ParserBehaviour : IBehaviour
    {
        public string GetText(int value)
        {
            return value.ToString();
        }
    }

    public class Client
    {
        private IBehaviour _behaviour;

        private int _value;

        public Client(IBehaviour behaivour)
        {
            _behaviour = behaivour;
        }

        public void DoSometing()
        {
            Console.WriteLine(_behaviour.GetText(_value));
        }

    }

   
}
