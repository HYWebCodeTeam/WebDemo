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
                //开启连接上下文
                using (var ctx = m_useContextCreater.CreatDbContext())
                {
                    //开启事务
                    using (var ta = ctx.Database.BeginTransaction())
                    {
                        returnValue = getNext()(input, getNext);
                        //若没有异常则提交事务
                        if (null == returnValue.Exception)
                        {
                            //事务提交
                            ta.Commit();
                            //设置返回值
                            returnValue.ReturnValue = true;
                        }
                        else
                        {
                            //事务回滚
                            ta.Rollback();
                            //设置返回值
                            returnValue.ReturnValue = false;
                        }

                        //设置返回值类型
                        returnValue = CustomMethodReturn.PrepareCustomReturn(input, returnValue);
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
