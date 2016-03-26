using frontmiddleend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frontmiddleend.Controllers
{
    public class ReportsController : Controller
    {
        private Entities db = new Entities();
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AvailableSlotsAction(string dayChosen)
        {
            DateTime dateDay;
            //If for some reason datetime is not entered, it will be today
            if(!DateTime.TryParse(dayChosen,out dateDay))
            {
                dateDay = DateTime.Today;
            }
            SqlParameter sp = new SqlParameter("DT", dateDay);
            var result = db.Database.SqlQuery<AvailableSlots>("AvailableSlots @DT", sp).ToList();
            return View(result);
        }

    }
}