using System.Web.Http;

namespace Ch8.R5a.Controllers
{
    public class NormalController : ApiController
    {
        public int Get()
        {
            int i = 1;
            return i;
        }      
    }
}
