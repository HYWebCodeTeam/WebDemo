using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUtility;

namespace BLL
{
    [InterfaceAOP]
    public interface ITestServer
    {
        //[LogMethod]
        [EFTransaction]
        bool TestMethod();
    }
}