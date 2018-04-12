using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Attributes;
using UnityUtility;

namespace WebDemo.BLL
{
    [Compent(RegistByClass = false)]
    public class ExcelServerImp:IExcelServer
    {
        /// <summary>
        /// 注入ExcelManger
        /// </summary>
        [Dependency]
        public ExcelORM.ExcelORMManger useManger { set; get; }
    }
}
