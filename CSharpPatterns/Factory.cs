using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{
    


    public interface IFoo
    {
        string Bar();
    }



    public class FooEvil : IFoo
    {
        public string Bar()
        {
            return "evil";
        }
    }



    public class FooGood : IFoo
    {
        public string Bar()
        {
            return "good";
        }
    }



    public interface IFooFactory
    {
        IFoo Create();
    }



    public class FactoryHeaven : IFooFactory
    {
        public IFoo Create()
        {
            return new FooGood();
        }
    }



    public class FactoryHell : IFooFactory
    {
        public IFoo Create()
        {
            return new FooEvil();
        }
    }



}
