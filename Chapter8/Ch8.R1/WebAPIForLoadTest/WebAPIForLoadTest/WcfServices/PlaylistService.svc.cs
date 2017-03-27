using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebAPIForLoadTest.Controllers;
using WebAPIForLoadTest.Models;

namespace WebAPIForLoadTest.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlaylistService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlaylistService.svc or PlaylistService.svc.cs at the Solution Explorer and start debugging.
    public class PlaylistService : IPlaylistService
    {

        public PlaylistModel GetPlayList(int playlistId)
        {
            List<PlaylistModel> list = PlayListRepository.GetAllPlayLists();

            return PlayListRepository.GetAllPlayLists()[playlistId];

        }

        public IEnumerable<PlaylistModel> GetAllPlayLists()
        {
            return PlayListRepository.GetAllPlayLists();
        }
    }
}
