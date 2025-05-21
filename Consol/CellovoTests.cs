using Microsoft.VisualStudio.TestTools.UnitTesting;
using celloveszetCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI.Tests
{
    [TestClass()]
    public class CellovoTests
    {

        //Ez osztály metódus
        [TestMethod()]
        /*22; 29; 12; 23 =&gt;29
        16; 45; 87; 33; =&gt;87
        96; 49;67; 45=&gt;96
        44; 3;12; 77=&gt;77*/
        [DataRow(22, 29, 12, 23, 29)]
        [DataRow(16, 45, 87, 33, 87)]
        public void LegnagyobbTest(int elso, int masodik, int harmadik, int negyedik, int elvart)
        {
            Cellovo c = new Cellovo($"Teszt;{elso};{masodik};{harmadik};{negyedik}");
            Assert.AreEqual(elvart, c.Legnagyobb());
        }


        //Ez sima metódus
        [TestMethod()]
        /*22; 29; 12; 23 =&gt;29
        16; 45; 87; 33; =&gt;87
        96; 49;67; 45=&gt;96
        44; 3;12; 77=&gt;77*/
        [DataRow(22, 29, 12, 23, 2)]
        [DataRow(16, 45, 87, 33, 3)]
        public void LegnagyobbIndex(int elso, int masodik, int harmadik, int negyedik, int elvart)
        {

            Assert.AreEqual(elvart, Program.LegnagyobbIndex(elso, masodik, harmadik, negyedik));
        }

    }
}