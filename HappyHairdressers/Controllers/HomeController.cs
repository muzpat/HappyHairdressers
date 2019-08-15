using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hairdressers.Models;

namespace Hairdressers.Controllers
{
    public class HomeController : Controller
    {
        public class bookingview
        {
            public string stylist { get; set; }
            public string customer { get; set; }
            public string date { get; set; }
            public string datedetail { get; set; }
            public string time { get; set; }

        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Appointment(string stylist)
        {

            List<bookingview> daycal = new List<bookingview>();
            if (stylist == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Stylist = stylist;

            Bookings myBookings = new Bookings();
            List<Booking> thebook = myBookings.GetBookings();

            List<string> myDates = new List<string>();
            List<string> myDays = new List<string>();
        //    myDates.Add(DateTime.Today.ToShortDateString());
            int i = 0;
            while (i <= 6)
            {
                int j = 9;
                while (j <= 17)
                {
                    bookingview calEntry = new bookingview();
                    calEntry.date = DateTime.Today.AddDays(i).ToShortDateString();
                    if (i ==0)
                    {
                        calEntry.datedetail = "Today";
                    }
                    else
                    {
                        calEntry.datedetail = DateTime.Today.AddDays(i).DayOfWeek.ToString();
                    }
                    var timeStr = j.ToString() + ":00";
                    if (j == 9)
                    {
                        timeStr = "0" + timeStr;
                    }
                    calEntry.time = timeStr;
                    calEntry.stylist = stylist;
                    calEntry.customer = "";
                    var result = thebook.Find(x => x.date == DateTime.Today.AddDays(i).ToShortDateString() && x.time == timeStr && x.stylist == stylist);
                    if (result != null)
                    {
                        calEntry.customer = result.name;
                    }
                    daycal.Add(calEntry);
                    j++;
                }

                myDates.Add(DateTime.Today.AddDays(i).ToShortDateString());
                i++;

            }
            ViewBag.BookingDates = myDates;

            myDays.Add("Today");
            i = 1;
            while (i <= 6)
            {
                myDays.Add(DateTime.Today.AddDays(i).DayOfWeek.ToString());
                i++;

            }
            ViewBag.BookingDays = myDays;
            return View("Appointment");


        }

        [HttpGet]
        public ActionResult GetAppointments(string stylist)
        {

            List<bookingview> daycal = new List<bookingview>();
            if (stylist == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Stylist = stylist;

            Bookings myBookings = new Bookings();
            List<Booking> thebook = myBookings.GetBookings();

            List<string> myDates = new List<string>();
            List<string> myDays = new List<string>();
            //    myDates.Add(DateTime.Today.ToShortDateString());
            int i = 0;
            while (i <= 6)
            {
                int j = 9;
                while (j <= 17)
                {
                    bookingview calEntry = new bookingview();
                    calEntry.date = DateTime.Today.AddDays(i).ToShortDateString();
                    if (i == 0)
                    {
                        calEntry.datedetail = "Today";
                    }
                    else
                    {
                        calEntry.datedetail = DateTime.Today.AddDays(i).DayOfWeek.ToString();
                    }
                    var timeStr = j.ToString() + ":00";
                    if (j == 9)
                    {
                        timeStr = "0" + timeStr;
                    }
                    calEntry.time = timeStr;
                    calEntry.stylist = stylist;
                    calEntry.customer = "";
                    var result = thebook.Find(x => x.date == DateTime.Today.AddDays(i).ToShortDateString() && x.time == timeStr && x.stylist == stylist);
                    if (result != null)
                    {
                        calEntry.customer = result.name;
                    }
                    daycal.Add(calEntry);
                    j++;
                }

                myDates.Add(DateTime.Today.AddDays(i).ToShortDateString());
                i++;

            }
            ViewBag.BookingDates = myDates;

            myDays.Add("Today");
            i = 1;
            while (i <= 6)
            {
                myDays.Add(DateTime.Today.AddDays(i).DayOfWeek.ToString());
                i++;

            }
            ViewBag.BookingDays = myDays;
            return Json(daycal, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult AddAppointment(string name, string phone, string style, string info, string stylist, string date, string time)
        {
            Bookings myBookings = new Bookings();
            myBookings.AddBooking(name, phone, style, info, stylist, date, time);
            //  myBookings.GetBookings();
            return Json(myBookings.currentBookings, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetAllAppointments()
        {
            Bookings myBookings = new Bookings();
            var thebook = myBookings.GetBookings();
            return Json(thebook, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GoToAppointment(string stylist)
        {
            return RedirectToAction("Appointment", new { stylist = stylist });
        }

        public ActionResult Hairdresser(string stylist)
        {
            List<bookingview> daycal = new List<bookingview>();
            if (stylist == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Stylist = stylist;



            return View();
        }
        public ActionResult Management()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}