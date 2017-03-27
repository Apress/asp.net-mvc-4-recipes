using System.Web.Mvc;
using Spark;
using Spark.Web.Mvc;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Ch2.R_13SparkDemo.App_Start.SparkWebMvc), "Start")]

namespace Ch2.R_13SparkDemo.App_Start {
    public static class SparkWebMvc {
        public static void Start() {
            var settings = new SparkSettings();
            settings.SetAutomaticEncoding(true); 

            // Note: you can change the list of namespace and assembly
            // references in Views\Shared\_global.spark
            SparkEngineStarter.RegisterViewEngine(settings);
        }
    }
}
