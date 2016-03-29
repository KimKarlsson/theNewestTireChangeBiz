using frontmiddleend.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// Input is only string so far, not datetime input
        /// </summary>
        /// <param name="dayOne"></param>
        /// <param name="dayTwo"></param>
        /// <returns></returns>
        public ActionResult CountSlots(string dayOne, string dayTwo)
        {

            DateTime dateOne;
            DateTime dateTwo;
            //If for some reason datetime is not entered, it will be today
            if (!DateTime.TryParse(dayOne, out dateOne))
            {
                dateOne = DateTime.Today;
            }
            SqlParameter sp = new SqlParameter("@firstDT", dateOne);

            SqlParameter sp1 = new SqlParameter();
            sp1.ParameterName = "@secondDT";
            sp1.IsNullable = true;
            if (DateTime.TryParse(dayTwo, out dateTwo))
            {
                sp1.Value = dateTwo;
            }
            //Stored procedure needs to be rewritten so the second parameter is not mandatory
            else
            {
                sp1.Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            var result = db.Database.SqlQuery<GetNumberOfSlots>("GetNumberOfSlots @firstDT, @secondDT", sp, sp1).ToList();
            return View(result);
        }

        public ActionResult CustomersPerDay()
        {
            var result = db.Database.SqlQuery<CustomersPerDay>("CustomersPerDay").ToList();
            return View(result);
        }

        public ActionResult GetAge(string sortingChoice)
        {
            SqlParameter sp = new SqlParameter("@SelectOrder", sortingChoice);
            sp.SqlValue = sortingChoice ?? System.Data.SqlTypes.SqlString.Null;
            var result = db.Database.SqlQuery<GetAge>("sp_getAge @SelectOrder", sp).ToList();
            return View(result);
        }
        public ActionResult TotalCustomers()
        {
            var result = db.Database.SqlQuery<TotalCustomers>("TotalCustomers").ToList();
            return View(result);
        }

        public ActionResult CustomerCity()
        {
            var result = db.Database.SqlQuery<CustomerCity>("CustomerCity").ToList();
            return View(result);
        }

        public ActionResult NumberOfBookingsPerCustomer()
        {


            var result = db.Database.SqlQuery<NumberOfBookingsPerCustomer>("sp_NumberOfBookingsPerCustomer1").ToList();
            return View(result);
        }
        public ActionResult GetAgeGroups()
        {
            var result = db.Database.SqlQuery<AgeGroups>("sp_getAgeGroup").ToList();
            return View(result);
        }



    }
}