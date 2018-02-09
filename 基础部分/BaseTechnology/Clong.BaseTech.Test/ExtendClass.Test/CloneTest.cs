using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTechnology.ReflectionTe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Clong.BaseTech.Test.ExtendClass.Test
{
    [TestClass]
   public class CloneTest
    {
        [TestMethod]
        public void ClonePersonTest()
        {
            var st = new PersonC
            {
                Name = "kaw",
                User = "12",
            };
            st.SetAge(8);
            st.iArr=new int[]{8,9,10};
            PersonC result2 = st.Clone2();
            var result = st.Clone() as PersonC;
            result.Name = "kkx";

            Assert.AreEqual(st.Name, "kaw");
            Assert.AreEqual(result.User, "12");
            Assert.AreEqual(result.Age, 8);
        }
    }
}
