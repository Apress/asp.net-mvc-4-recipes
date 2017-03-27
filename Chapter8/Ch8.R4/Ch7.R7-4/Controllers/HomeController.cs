using Ch8.R4.Models;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ch8.R4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public  ActionResult IPScanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> IPScanner(IPScannerModel model)
        {
            if (ModelState.IsValid)
            {
                model.IpList = generateListFromRange(model.RangeToScan);
                List<Task<PingReply>> taskList = new List<Task<PingReply>>();
                Dictionary<string, Task<PingReply>> cache = getDictionaryFromCache();
                foreach (var item in model.IpList)
                {
                    Task<PingReply> reply;
                    if (!areResultsInCache(item, cache, out reply))
                    {
                        Ping pingSender = new Ping();
                        reply = pingSender.SendPingAsync(item);
                        cache.Add(item, reply);
                    }
                    taskList.Add(reply);
                }
                HttpContext.Cache.Insert("CachedPingReply", cache, null, DateTime.UtcNow.AddMinutes(10), TimeSpan.Zero);
                PingReply[] results = await Task.WhenAll(taskList);
                model.IpList = updateStatus(model.IpList, results);
            }
            else
            {
                ModelState.AddModelError("", "Please enter a valid IP Address range.");
            }
            return View(model);
        }

        private Dictionary<string, Task<PingReply>> getDictionaryFromCache()
        {
            Dictionary<string, Task<PingReply>> cache;
            if (HttpContext.Cache["CachedPingReply"] != null)
            {
                cache = (Dictionary<string, Task<PingReply>>)HttpContext.Cache["CachedPingReply"];
            }
            else
            {
                cache = new Dictionary<string, Task<PingReply>>();
            }
            return cache;
        }



        private bool areResultsInCache(string item, Dictionary<string, Task<PingReply>> cache, out Task<PingReply> reply)
        {
            if (cache != null)
            {
                return cache.TryGetValue(item, out reply);
            }
            else
            {
                reply = null;
                return false;
            }
        }

     

        private List<string> updateStatus(List<string> list, PingReply[] results)
        {
            foreach (var item in results)
            {
                if (item.Status == IPStatus.Success)
                {
                    list.RemoveAll(s => s == item.Address.ToString());
                }
            }
            return list;
        }



        private List<string> generateListFromRange(IPRange iPRange)
        {
            if (iPRange != null)
            {
                //look at last octet in each string
               
                List<string> ipp = new List<string>();
                string ipTemplate = string.Concat(iPRange.StartAddress.Substring(0, (iPRange.StartAddress.LastIndexOf(".")+1)), "{0}");
                int start, end;
                start = Convert.ToInt32(iPRange.StartAddress.Substring((iPRange.StartAddress.LastIndexOf(".")+1)));
                end = Convert.ToInt32(iPRange.EndAddress.Substring((iPRange.EndAddress.LastIndexOf(".")+1)));
                for (int i = start; i <= end; i++)
                {
                    ipp.Add(string.Format(ipTemplate, i));
                }
                return ipp;
            }
            return null;
        }






    }
}
