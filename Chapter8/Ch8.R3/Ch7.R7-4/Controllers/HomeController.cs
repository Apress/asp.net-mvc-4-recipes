using Ch8.R7_4.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ch8.R7_4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CallWCFService()
        {
            PlaylistServiceClient client = new PlaylistServiceClient();
            PlaylistModel[] playlistArray = client.GetAllPlayLists();
            return View(playlistArray);
        }

        public async Task<ActionResult> CallWCFServiceAsync()
        {
            PlaylistServiceClient client = new PlaylistServiceClient();
            PlaylistModel[] playlistArray = await client.GetAllPlayListsAsync();
            return View(playlistArray);
        }

        public async Task<ActionResult> CallWCFWithWaitAllAsync()
        {
            PlaylistServiceClient client = new PlaylistServiceClient();
            Task<PlaylistModel> task1 = client.GetPlayListAsync(1);
            Task<PlaylistModel> task2 = client.GetPlayListAsync(2);
            Task<PlaylistModel> task3 = client.GetPlayListAsync(3);
            PlaylistModel[] playlistArray = await Task.WhenAll(new Task<PlaylistModel>[] { task1, task2, task3 });
            return View(playlistArray);
        }


    }
}
