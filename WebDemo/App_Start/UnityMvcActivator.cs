using NPOIUtility;
using System.Linq;
using System.Web.Mvc;
using ToolCode;
using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebDemo.UnityMvcActivator), nameof(WebDemo.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(WebDemo.UnityMvcActivator), nameof(WebDemo.UnityMvcActivator.Shutdown))]

namespace WebDemo
{
    /// <summary>
    /// Provides the bootstrapping for integrating Unity with ASP.NET MVC.
    /// </summary>
    public static class UnityMvcActivator
    {
        /// <summary>
        /// Integrates Unity when the application starts.
        /// </summary>
        public static void Start() 
        {
            /*
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
            */

            #region 初始化外部单例
            //excel映射器
            UnityUtility.ObjectIOCTypeInfo useExcelORM = new UnityUtility.ObjectIOCTypeInfo(typeof(ExcelORM.ExcelORMManger), new ExcelORM.ExcelORMManger());

            //excel图片管理器
            var usePictureManger = new PictureManger();

            //使用的图片工具
            ImageUtility useImageUtility = new ImageUtility();

            //使用的柱状图工具
            var useBarChartMaker = new BarChartMaker();

            //使用的饼状图工具
            var usePieChartMake = new PieChartMaker();

            System.Collections.Generic.HashSet<UnityUtility.ObjectIOCTypeInfo> useSet = new System.Collections.Generic.HashSet<UnityUtility.ObjectIOCTypeInfo>();

            useSet.Add(useExcelORM);
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(usePictureManger.GetType(), usePictureManger));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(useImageUtility.GetType(), useImageUtility));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(useBarChartMaker.GetType(), useBarChartMaker));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(usePieChartMake.GetType(), usePieChartMake)); 
            #endregion

            //外部注册ExcelManger
            var app = UnityUtility.UnityApplication.GetApplication(useSet);
            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(app.CoreUnityContainer));
            DependencyResolver.SetResolver(new UnityDependencyResolver(app.CoreUnityContainer));



            // TODO: Uncomment if you want to use PerRequestLifetimeManager
            // Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            UnityConfig.Container.Dispose();
        }
    }
}