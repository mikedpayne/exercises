using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelearningConsole
{
    class GenericStack<T>
    {
        List<T> _stack = new List<T>();

        public void push(T obj)
        {
            if (obj == null)
                throw new InvalidOperationException();

            _stack.Add(obj);
        }

        public T pop()
        {
            if (_stack.Count == 0)
                throw new InvalidOperationException();

            T obj = _stack[_stack.Count - 1];
            _stack.Remove(obj);
            return obj;
        }
    }
}
