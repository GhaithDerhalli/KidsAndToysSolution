using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class ErrorController : Controller
    {


        [Route("/error/exception")]  //behöver inte första /error
        public IActionResult ServerError()
        {
            //return Content("Oops - nåt gick snett");
            return View();
        }

        [Route("/error/http/{id}")]  //behöver inte första /error
        public IActionResult HttpError(int id)
        {
            //return Content("http-fel:"+id);
            return View(id);
        }
    }
}
