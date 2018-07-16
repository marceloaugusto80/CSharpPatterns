using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{

    public interface IPoolFactory<T>
    {
        T Create();
    }



    public class Wrapper<T> : IDisposable
    {
        private T _obj;

        public bool IsAvailable { get; private set; }

        public Wrapper(T obj)
        {
            IsAvailable = true;
            _obj = obj;
        }

        public void Dispose()
        {
            IsAvailable = true;
        }

        public T Use()
        {
            IsAvailable = false;
            return _obj;
        }


    }


    public class ObjectPool<T> where T : class
    {
        private IPoolFactory<T> _factory;

        private Wrapper<T>[] _wrapperArr;

        public int Length { get; private set; }



        public ObjectPool(IPoolFactory<T> factory, int maxLenght)
        {

            _factory = factory;
            Length = maxLenght;
            _wrapperArr = new Wrapper<T>[Length];

        }


        public Wrapper<T> Get()
        {
            for (int i = 0; i < Length; i++)
            {
                Wrapper<T> currObj = _wrapperArr[i];

                if (currObj == null)
                {
                    currObj = new Wrapper<T>(_factory.Create());
                    _wrapperArr[i] = currObj;
                }

                if (!currObj.IsAvailable) continue;

                return currObj;
            }

            return null;

        }

    }

}
