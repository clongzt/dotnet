using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTechnology.EventAndDelegate
{
    public class ButtonClickArgs : EventArgs
    {
        public string Clicker;
    }

    //定义一个delegate委托
    public delegate void ClickHandler(object sender, ButtonClickArgs e);
   
    public class MyButton
    {

        //定义事件，类型为上面定义的ClickHandler委托
        public event ClickHandler OnClick;
        public void Click()
        {
            //...触发之前可能做了n多操作
            //.....

            //这时触发Click事件，并传入参数Clicker为本博主ivy
            OnClick(this, new ButtonClickArgs() { Clicker = "ivy" });
        }
    }
    class EventTest
    {
            public static void Main()
            {
                MyButton btn = new MyButton();

                //注册事件，把btn_OnClick方法压入事件队列，
                //可以+=多个，这里简单点就压入一个吧。
                btn.OnClick += new ClickHandler(btn_OnClick);
            }

            //怎么看到这个函数很熟悉吧，就是你原来双击button自动产生的代码
            public static void btn_OnClick(object sender, ButtonClickArgs e)
            {
                Console.WriteLine("真贱，我居然被ivy点击了！");
            }
    }
}
