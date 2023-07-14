using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiLieuC
{
    public class CaseJson2
    {
        public class Student
        {
            public string name { get; set; }
        }

        public class Universities
        {
            public string university { get; set; }
            public IList<Student> students { get; set; }
        }

        public class ClassUniversities
        {
            public Universities universities { get; set; }
        }

        public class Orderdetail
        {
            public string name { get; set; }
            public string count { get; set; }
            public string price { get; set; }
        }

        public class Order
        {
            public string tableNo { get; set; }
            public bool paid { get; set; }
            public string starttime { get; set; }
            public List<Orderdetail> orderdetails { get; set; }
        }

        public class Example
        {
            public List<Order> orders { get; set; }
        }
    }
}
