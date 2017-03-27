using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIForLoadTest.Models;

namespace WebAPIForLoadTest.Controllers
{
    public class PlaylistController : ApiController
    {
        
        // GET api/playlist
        public IEnumerable<PlaylistModel> Get()
        {
            return PlayListRepository.GetAllPlayLists();
        }
        //// GET api/playlist/5
        //public PlaylistModel Get(int id)
        //{
        //    List<PlaylistModel> list = PlayListRepository.GetAllPlayLists();

        //    if (id < list.Count)
        //    {
        //        return list[id];
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
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


    
    public static class PlayListRepository
    {
        public static async Task<List<PlaylistModel>> GetAllPlayListsAsync()
        {
            await Task.Delay(5000);
            return _GetAllPlayLists();
        }

        public static List<PlaylistModel> GetAllPlayLists()
        {
            Thread.Sleep(5000);
            return _GetAllPlayLists();
        }

        private static List<PlaylistModel> _GetAllPlayLists()
        {
            List<PlaylistModel> pl = new List<PlaylistModel>();
            
            for (int i = 0; i < 50; i++)
            {
                PlaylistModel item = new PlaylistModel();
                item.PlayListName = string.Concat("Playlist ", i);
                for (int j = 0; j < 10; j++)
                {
                    SongModel song = new SongModel
                    {
                        AlbumName = "Test",
                        PublishedDate = DateTime.Now.AddYears(-i),
                        SongArtist = new ArtistModel
                        {
                            ArtistHomePageUrl = "http://cnn.com",
                            ArtistName = string.Concat("Artist ", j, "-", i),
                            ArtistThumbnailImageUrl = string.Empty
                        },
                        SongOrder = j,
                        Title = string.Concat("Song ", j, "-", i)
                    };
                    item.Songs.Add(song);
                }
                pl.Add(item);
            }
            return pl;
        }
    }
}
