using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestAdoNet.Common;

namespace TestAdonet.Test
{
    [TestClass]
    public class OracleAccessTest
    {

        private static  OracleAccess oracleAccess;
        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
            var connetionString =
                @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=orcl)));User ID=landuseconfig;Password=landuseconfig;";

            oracleAccess = new OracleAccess(connetionString);
            oracleAccess.Open();
        }

        [ClassCleanup]
        public static void TestOver()
        {
            oracleAccess.Close();
        }

        [TestMethod]
        public void TestGetAllTableNames()
        {
          
            var tableNames = oracleAccess.GetAllTableNames();
            Assert.AreEqual(tableNames.Count, 1);
        }

        [TestMethod]
        public void TestExecuteTable()
        {
            var sql = "select * from CUSTUMERS t";
            var datatable = oracleAccess.ExecuteTable(sql);
            var result= datatable.Rows[0][1].ToString();
            Assert.AreEqual(result, "ff");
        }
    }
}
