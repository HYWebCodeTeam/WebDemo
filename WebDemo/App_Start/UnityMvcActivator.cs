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

            #region ��ʼ���ⲿ����
            //excelӳ����
            UnityUtility.ObjectIOCTypeInfo useExcelORM = new UnityUtility.ObjectIOCTypeInfo(typeof(ExcelORM.ExcelORMManger), new ExcelORM.ExcelORMManger());

            //excelͼƬ������
            var usePictureManger = new PictureManger();

            //ʹ�õ�ͼƬ����
            ImageUtility useImageUtility = new ImageUtility();

            //ʹ�õ���״ͼ����
            var useBarChartMaker = new BarChartMaker();

            //ʹ�õı�״ͼ����
            var usePieChartMake = new PieChartMaker();

            System.Collections.Generic.HashSet<UnityUtility.ObjectIOCTypeInfo> useSet = new System.Collections.Generic.HashSet<UnityUtility.ObjectIOCTypeInfo>();

            useSet.Add(useExcelORM);
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(usePictureManger.GetType(), usePictureManger));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(useImageUtility.GetType(), useImageUtility));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(useBarChartMaker.GetType(), useBarChartMaker));
            useSet.Add(new UnityUtility.ObjectIOCTypeInfo(usePieChartMake.GetType(), usePieChartMake)); 
            #endregion

            //�ⲿע��ExcelManger
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