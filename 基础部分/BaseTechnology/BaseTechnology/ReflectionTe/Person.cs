using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.ReflectionTe
{
    public class Person
    {
        public string Name { get; set; }

        public string User { get; set; }

        public void Excute(string para)
        {
            Console.WriteLine("this is a test {0}",para);
        }
    }
}
