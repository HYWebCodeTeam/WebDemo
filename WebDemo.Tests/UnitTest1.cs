using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;

namespace WebDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TestServer server = new TestServer();
            server.TestMethod();
        }
    }
}
