using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Problem
{
    class ClassWithArray
    {
        private int[] _myArray= { 6, 7,8 };

        public int[] MyArray { get { return _myArray; } set { _myArray = value; } }

        public ClassWithArray(int[] MyArray)
        {
            this.MyArray = MyArray;
        }
    }
}
