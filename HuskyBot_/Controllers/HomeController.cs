using Microsoft.AspNetCore.Mvc;

namespace HuskyBot_.Controllers
{

    public class HomeController
        : Controller
    {
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public ActionResult Index()
        {

            return View();
        }


    }


}
