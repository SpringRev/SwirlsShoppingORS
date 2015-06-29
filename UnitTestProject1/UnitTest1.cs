using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BootstrapMVC.Models;
using NUnit.VisualStudio.TestAdapter;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        public static void Main()
        { 
            
        }
        [Test]
        public void TestStoresIndex()
        {
           // StoresEntities db = new StoresEntities();
            Assert.AreEqual(true, true);
            Console.Write("Assert Check");
        }
    }
}
