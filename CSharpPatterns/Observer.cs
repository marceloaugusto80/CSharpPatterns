using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPatterns
{
   

    public interface IListener<T>
    {
        void OnNotify(T args);
    }



    public class SubjectChangedArgs
    {
        public int OldValue { get; private set; }
        public int NewValue { get; private set; }

        public SubjectChangedArgs(int newVal, int oldVal)
        {
            OldValue = oldVal;
            NewValue = newVal;
        }

    }



    public class Subject
    {
        private List<IListener<SubjectChangedArgs>> _listeners;

        private int _val;


        public Subject()
        {
            _listeners = new List<IListener<SubjectChangedArgs>>();
        }


        public void SetValue(int newVal)
        {
            int oldVal = _val;
            _val = newVal;
            UpdateListeners(new SubjectChangedArgs(newVal, oldVal));
        }

        private void UpdateListeners(SubjectChangedArgs args)
        {
            _listeners.ForEach((l) =>
            {
                l.OnNotify(args);
            });
        }

        public void AddListener(IListener<SubjectChangedArgs> listener)
        {
            _listeners.Add(listener);
        }

        public void RemoveListener(IListener<SubjectChangedArgs> listener)
        {
            _listeners.Remove(listener);
        }

    }

}
