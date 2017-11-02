using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAdoNet.Common;

namespace TestAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        private static void Test()
        {
            var oracleAccess = new OracleAccess();
            oracleAccess.Open();
           var tableNames= oracleAccess.GetAllTableNames();
           foreach (var tableName in tableNames)
           {
               Console.WriteLine(tableName);
           }
            Console.ReadLine();
        }
    }
}
