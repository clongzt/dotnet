using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.ExtendClass
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string GetRecode(string subject)
        {
            return string.Format("{0}的学习成绩为：100", subject);
        }

        public string GetStuInfo(string stuName, string stuNum)
        {
            
            return string.Format("学生信息：\n" + "姓名：{0} \n" + "学号：{1}", stuName, stuNum);
        }  
    }
}
