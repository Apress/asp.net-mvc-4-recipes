using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebAPIForLoadTest.Models;

namespace WebAPIForLoadTest.WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPlaylistService" in both code and config file together.
    [ServiceContract]
    public interface IPlaylistService
    {
        [OperationContract]
        PlaylistModel GetPlayList(int playlistId);

        [OperationContract]
        IEnumerable<PlaylistModel> GetAllPlayLists();
    }
}
