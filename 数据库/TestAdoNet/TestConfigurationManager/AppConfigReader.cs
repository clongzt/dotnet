using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConfigurationManager
{
    class AppConfigReader
    {
        public static void TestReader()
        {
            var userName = ConfigurationManager.AppSettings["userName"];
            var pwd = ConfigurationManager.AppSettings["password"];

            Console.WriteLine(string.Format("this the appsetting name is {0},password is {1}",userName,pwd));

           var connectstring= ConfigurationManager.ConnectionStrings["DataCenterMain"].ConnectionString;
            Console.WriteLine(connectstring);
            Console.ReadLine();
        }
    }
}
