using System.Threading.Tasks;
using System.Web.Http;

namespace Ch8.R5a.Controllers
{
    public class AsyncController : ApiController
    {
        public async Task<int> Get()
        {
            int i = await Task.FromResult<int>(1); 
            return i;
        } 
    }
}
