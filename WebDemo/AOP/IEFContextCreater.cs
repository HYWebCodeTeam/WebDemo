using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UnityUtility
{
    /// <summary>
    /// Ef上下文创建器
    /// </summary>
    public interface IEFContextCreater
    {
        DbContext CreatDbContext();

    }
}