using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityUtility;

namespace WebDemo.BLL
{
    [InterfaceAOP]
    public interface IEntity2DBService
    {
        [UnityUtility.LogMethod]
        [UnityUtility.EFTransaction]
        bool Save2DB(IExcelServer iExcelServer);
    }
}
