using BaseTechnology.ExtendClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clong.BaseTech.Test.ExtendClass.Test
{
    [TestClass]
    public class StudentTest
    {
       

        [ClassInitialize]
        public static void Init(TestContext testContext)
        {
          
        }

        [ClassCleanup]
        public static void Clean()
        {
            
        }
        [TestMethod]
        public void ExtensionGetStuInfoTest()
        {
            var st = new Student();
            st.ExtensionGetStuInfo("kaw", "12");
            Assert.AreEqual(st.Name, "kaw");

        }
    }
}
