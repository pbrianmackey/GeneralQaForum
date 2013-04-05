using Feedback.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Feedback.Controllers
{
    public class HomeController : Controller
    {
        ReportCRUD reportCrud = new ReportCRUD();

        public ActionResult Index()
        {
            var result = reportCrud.HottestQuestions();
            return View(result);
        }
    }

    public class T
    {
        public int id { get; set; }
        public string name { get; set; }

        public T(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
