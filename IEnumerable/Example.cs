using System;
using System.Collections;
using System.Collections.Generic;

namespace IEnumerable
{

    // if we do not implement : IEnumerable<string> we can not use foreach for use of it
    class Example : IEnumerable<string>
    {
        List<string> _elements;

        public Example(string[] array)
        {
            this._elements = new List<string>(array);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            Console.WriteLine("HERE");
            return this._elements.GetEnumerator();
        }

        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this._elements.GetEnumerator();
        }


    }
}
