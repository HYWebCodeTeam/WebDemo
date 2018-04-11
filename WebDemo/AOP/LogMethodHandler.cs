using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityUtility
{
    /// <summary>
    /// log
    /// </summary>
    internal class LogMethodHandler : ICallHandler
    {
        private int m_useOrder;

        public int Order
        {
            get
            {
                return 0;
            }

            set
            {
                m_useOrder = value;
            }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string strName = assembly.GetName().FullName;
            ILog log = LogManager.GetLogger(strName);

            string methodName = input.MethodBase.Name;
            log.Info(string.Format("Enter method " + methodName));

            Stopwatch sw = new Stopwatch();
            sw.Start();

            IMethodReturn result = getNext()(input, getNext);

            sw.Stop();
            log.Info(string.Format("Exit method {0}, use {1}s.", methodName, sw.ElapsedMilliseconds));


            return result;
        }
    }
}
