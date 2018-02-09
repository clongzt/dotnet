using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.ReflectionTe
{
    public class PersonC:ICloneable
    {
        public string Name { get; set; }

        public string User { get; set; }

        private int _age = 0;

        public int Age
        {
            get { return _age; }
        }

        public int[] iArr = { 1, 2, 3 };

        public void SetAge(int age)
        {
            _age = age;
        }



        public void Excute(string para)
        {
            Console.WriteLine("this is a test {0}",para);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public PersonC Clone2() //深clone      
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Position = 0;
            return formatter.Deserialize(stream) as PersonC;
        }
    }
}
