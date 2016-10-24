using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SlowWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static string webserviceURL = ConfigurationManager.AppSettings["WebserviceUrl"];
        private  static int numberOfCalls = int.Parse(ConfigurationManager.AppSettings["NumberOfBackendCalls"]);

        //
        // GET: /Home/

        public async Task<ActionResult> Index()
        {
            int size = 0;
            size = await CallWebServiceAsync();
            ViewBag.RequestSize = size;
            return View();
        }



        static async Task<int> CallWebServiceAsync()
        {
            int totalLength = 0;
            List<Task<byte[]>> dataTasks = new List<Task<byte[]>>();
            for (int i = 0; i < numberOfCalls; i++)
            {
                using (WebClient webClient = new WebClient())
                {
                    Uri uri = new Uri(string.Format(webserviceURL, i));
                    dataTasks.Add(webClient.DownloadDataTaskAsync(uri));
                }
            }
            byte[][] allBytes = await Task.WhenAll(dataTasks);
            foreach (byte[] ar in allBytes)
                totalLength = ar.Length;

            return totalLength;

        }

        public ActionResult Index2()
        {
            int size = 0;
            size = CallWebService();

            ViewBag.RequestSize = size;
            return View();
        }
        static int CallWebService()
        {
            
                int totalLength = 0;
                using (WebClient webClient = new WebClient())
                {

                    for (int i = 0; i < numberOfCalls; i++)
                    {
                        Uri uri = new Uri(string.Format(webserviceURL, i));
                        var data = webClient.DownloadData(uri);
                        totalLength += data.Length;
                    }
                }
                return totalLength;          
        }

    }
}
