using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Redis.Demo.Common;
using Redis.Demo.Data;
using Redis.Demo.Test;
using ServiceStack.Redis;
using ServiceStack.Redis.Support;

namespace Redis.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSimpTest_Click(object sender, EventArgs e)
        {
            RedisTest.Test();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            hashOperator.Save();
        }

        private IRedisClient Redis = RedisManager.GetClient();
        HashOperator hashOperator = new HashOperator();
        private void btnGet_Click(object sender, EventArgs e)
        {
            var hashId = this.txtHashId.Text;
            var key = this.txtKey.Text;
            var ser = new ObjectSerializer();

            if (string.IsNullOrEmpty(hashId))
            {

            }
            else
            {
                byte[] infos = hashOperator.Get<byte[]>("userInfosHash", "userInfos");
               var  userInfos = ser.Deserialize(infos) as UserInfo;
               var result ="name=" + userInfos.UserName + "   age=" + userInfos.Age;
                txtResult.Text = result;
            }

        }
    }
}
