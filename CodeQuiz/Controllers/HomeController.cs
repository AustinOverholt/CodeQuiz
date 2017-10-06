using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeQuiz.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quizzes()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult CreateQuiz()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}