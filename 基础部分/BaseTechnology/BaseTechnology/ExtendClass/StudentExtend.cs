using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.ExtendClass
{
    public static class StudentExtend
    {
        public static  string ShowTeacher(this Student student,string subject)
        {
            return student.Name;
        }

        //声明扩展方法  
        //要扩展的方法必须是静态的方法，Add有三个参数  
        //this 必须有，string表示我要扩展的类型，stringName表示对象名  
        //三个参数this和扩展的类型必不可少，对象名可以自己随意取如果需要传递参数，在此我们增加了两个string类型的参数  
        public static string ExtensionGetStuInfo(this Student student, string stuname, string stunum)
        {
            student.Name = stuname;
            return student.GetStuInfo(stuname, stunum) + "\n读取完毕";
        }  
    }
}
