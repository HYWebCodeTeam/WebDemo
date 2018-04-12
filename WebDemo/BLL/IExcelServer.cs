using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.BLL
{
    /// <summary>
    /// Excel服务接口
    /// </summary>
    public interface IExcelServer
    {
        bool DoConvert(string strFilePathName);
    }
}
