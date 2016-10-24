using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ch8.R2.Controllers
{
    public class HomeController : Controller
    {

        // this URL is a seperate project that is used for Recipe 7-3
        // you could replace this with any valid URL.
        private const string webserviceURL = "http://localhost/WebAPIForLoadTest/api/playlist/{0}";

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> CallThreeServicesAsync()
        {
            Task<string> t1, t2, t3;

            using (WebClient webClient = new WebClient())
            {
                Uri uri1 = new Uri(string.Format(webserviceURL, 1));
                t1 = webClient.DownloadStringTaskAsync(uri1);
            }
            using (WebClient webClient = new WebClient())
            {
                Uri uri2 = new Uri(string.Format(webserviceURL, 2));
                 t2 = webClient.DownloadStringTaskAsync(uri2);
            }
            using (WebClient webClient = new WebClient())
            {
                Uri uri3 = new Uri(string.Format(webserviceURL, 3));
                 t3 = webClient.DownloadStringTaskAsync(uri3);
            }
            string[] results = await Task.WhenAll(new Task<string>[] { t1, t2, t3 });
            ViewBag.Results = results;


            return View();
        }


        public async Task<ActionResult> CallTenServicesAsync()
        {
            List<Task<byte[]>> dataTasks = new List<Task<byte[]>>();
            for (int i = 0; i < 10; i++)
            {
                using (WebClient webClient = new WebClient())
                {
                    Uri uri = new Uri(string.Format(webserviceURL, i));
                    dataTasks.Add(webClient.DownloadDataTaskAsync(uri));
                }
            }
            byte[][] allBytes = await Task.WhenAll(dataTasks);

            ViewBag.totalLength = allBytes.Sum(w => w.Length);

            return View();
        }

        public async Task<ActionResult> GetPhotoAndComments()
        {
            List<Task> tasks = new List<Task>();

            using (WebClient webClient = new WebClient())
            {
                Uri uri1 = new Uri(PhotoCommentServiceURL);
                tasks.Add(webClient.DownloadStringTaskAsync(uri1));
            }

            using (WebClient webClient = new WebClient())
            {
                Uri uri2 = new Uri(DynamicImgServiceUrl);
                tasks.Add(webClient.DownloadDataTaskAsync(uri2));
            }
            await Task.WhenAll(tasks);

            ViewBag.PhotoComments = ((Task<string>)tasks[0]).Result;
            string imageBase64 = Convert.ToBase64String(((Task<byte[]>)tasks[1]).Result);
            string imageSrc = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            ViewBag.Photo = imageSrc;

            return View();
        }

        private string PhotoCommentServiceURL
        {
            get
            {
                return string.Concat(getRootUrl(),
                Url.Content("~/Content/PhotoComments.txt"));
            }
        }

        private string DynamicImgServiceUrl
        {
            get
            {
                return string.Concat(getRootUrl(),
                    Url.Content("~/Content/SomePicture.jpg"));
            }
        }

        private string getRootUrl()
        {
            string scheme = Request.Url.GetComponents(UriComponents.Scheme, UriFormat.SafeUnescaped);
            string rootURL = Request.Url.GetComponents(UriComponents.HostAndPort, UriFormat.SafeUnescaped);
            return string.Concat(scheme, "://", rootURL,"/");
        }


    }
    
}
