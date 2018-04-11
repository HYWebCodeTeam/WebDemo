using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Unity.Interception.PolicyInjection.Pipeline;

namespace UnityUtility
{
    /// <summary>
    /// EF事务处理AOP
    /// </summary>
    internal class EFTransactionHandler : ICallHandler
    {
        private int m_useOrder;

        //使用的会话控制器
        private IEFContextCreater m_useContextCreater = UnityApplication.GetApplication().Reslove<IEFContextCreater>();

        public int Order
        {
            get
            {
                return m_useOrder;
            }

            set
            {
                m_useOrder = value;
            }
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {

            IMethodReturn returnValue = null;

            //若符合要求
            if (input.MethodBase is MethodInfo && (input.MethodBase as MethodInfo).ReturnType == typeof(bool))
            {
                using (var ctx = m_useContextCreater.CreatDbContext())
                {
                    using (var ta = ctx.Database.BeginTransaction())
                    {
                        returnValue = getNext()(input, getNext);
                        //若没有异常则提交事务
                        if (null == returnValue.Exception)
                        {
                            ta.Commit();
                            //设置返回值
                            returnValue.ReturnValue = true;
                        }
                        else
                        {
                            ta.Rollback();
                            //清空异常
                            returnValue.Exception = null;
                            //设置返回值
                            returnValue.ReturnValue = false;
                        }
                    } 

                }
               
            }
            //正常执行
            else
            {
                returnValue = getNext()(input, getNext);
            }

           
            return returnValue;
        }
    }
}
