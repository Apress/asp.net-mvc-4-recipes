using System.Web.Mvc;
using Ch5.R5_3.BasicFormValidation.Models;

namespace Ch5.R5_3.BasicFormValidation.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/ and Website Root

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Home/RequestAQuote

        public ActionResult RequestAQuote()
        {
            return View();
        }


        //
        // POST: /Home/RequestAQuote

        [HttpPost]
        public ActionResult RequestAQuote(RequestAQuoteModel quote)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("ThankYou");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/ThankYou

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
        