using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIForLoadTest.Models;

namespace WebAPIForLoadTest.Controllers
{
    public class Playlist2Controller : ApiController
    {
        //GET api/playlist/5
        public async Task<PlaylistModel> Get(int id)
        {
            List<PlaylistModel> list = await PlayListRepository.GetAllPlayListsAsync();

            if (id < list.Count)
            {
                return list[id];
            }
            else
            {
                return null;
            }
        }
    }
}
