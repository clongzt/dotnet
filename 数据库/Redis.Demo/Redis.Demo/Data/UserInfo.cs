using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Demo.Data
{
    [Serializable]
    public class UserInfo
    {
        public int Id;
        public string UserName;
        public int Age;
    }  
}
