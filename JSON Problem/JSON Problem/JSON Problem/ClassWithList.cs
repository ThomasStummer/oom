using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_Problem
{
    class ClassWithList
    {
        private List<int> _myList;

        public List<int> MyList { get { return _myList; } set { _myList = value; } }

        public ClassWithList(List<int> MyList)
        {
            this.MyList = MyList;
        }
    }
}
