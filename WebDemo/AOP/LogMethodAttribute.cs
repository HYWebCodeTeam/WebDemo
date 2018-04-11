using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;
using UnityUtility;

namespace UnityUtility
{
    class LogMethodAttribute : HandlerAttribute
    {

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new LogMethodHandler();
        }
    }
}