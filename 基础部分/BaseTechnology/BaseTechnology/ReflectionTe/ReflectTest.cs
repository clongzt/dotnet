using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.ReflectionTe
{
    class ReflectTest
    {
        public void Test()
        {
            //通过DLL文件名称返回Assembly对象
            Assembly ass = Assembly.LoadFrom("ClassLibrary831.dll");

           // 通过Assembly获取程序集中类 
            Type t = ass.GetType("BaseTechnology.ReflectionTe.Person");   //参数必须是类的全名
        }
    }
}
