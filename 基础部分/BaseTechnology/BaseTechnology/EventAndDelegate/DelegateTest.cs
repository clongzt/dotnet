using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.EventAndDelegate
{

    public delegate void MyTestDelegate(int i);
   public  class DelegateTest
    {
        // 声明delegate对象  
        public delegate void CompareDelegate(int a, int b);
        // 欲传递的方法，它与CompareDelegate具有相同的参数和返回值类型  
        public static void Compare(int a, int b)
        {
            Console.WriteLine((a > b).ToString());
        }

        public static void Test()
        {
            // 创建delegate对象  
            CompareDelegate cd = new CompareDelegate(DelegateTest.Compare);
            // 调用delegate  
            cd(1, 2);

            //创建delegate
            ReceiveDelegateArgsFunc(new MyTestDelegate(DelegateFunction));
        }

        //这个方法接收一个delegate类型的参数，也就是接收一个函数作为参数
        public static void ReceiveDelegateArgsFunc(MyTestDelegate func)
        {
            func(21);
        }
        //欲传递的方法
        public static void DelegateFunction(int i)
        {
            System.Console.WriteLine("传过来的参数为: {0}.", i);
        }
    }
}
