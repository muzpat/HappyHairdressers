using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hairdressers.Models
{
    public class Booking
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string style { get; set; }
        public string info { get; set; }
        public string stylist { get; set; }
        public string date { get; set; }
        public string time { get; set; }

    }
    public class Bookings
    {
        public List<Booking> currentBookings { get; set; }
        public Bookings()
        {
            HttpContext context = HttpContext.Current;
            if (context.Session["bookings"] != null)
            {
                currentBookings = (List<Booking>)context.Session["bookings"];
            }
            else
            {
                currentBookings = new List<Booking>();
             
                Booking addBooking = new Booking();
                addBooking.name = "Jackie";
                addBooking.phone = "0766554433";
                addBooking.style = "Perm";
                addBooking.info = "Frizzy hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.ToShortDateString();
                addBooking.time = "09:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Sam";
                addBooking.phone = "0700766433";
                addBooking.style = "Wet Cut";
                addBooking.info = "Very thin hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.ToShortDateString();
                addBooking.time = "10:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Amanda";
                addBooking.phone = "07225544353";
                addBooking.style = "Colour treatment";
                addBooking.info = "Second phase";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.ToShortDateString();
                addBooking.time = "12:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Jackie";
                addBooking.phone = "0766554433";
                addBooking.style = "Perm";
                addBooking.info = "Frizzy hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.ToShortDateString();
                addBooking.time = "14:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Jackie";
                addBooking.phone = "0766554433";
                addBooking.style = "Perm";
                addBooking.info = "Frizzy hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.ToShortDateString();
                addBooking.time = "15:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Jackie";
                addBooking.phone = "0766554433";
                addBooking.style = "Perm";
                addBooking.info = "Frizzy hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.AddDays(1).ToShortDateString(); 
                addBooking.time = "09:00";
                currentBookings.Add(addBooking);
                addBooking = new Booking();
                addBooking.name = "Jackie";
                addBooking.phone = "0766554433";
                addBooking.style = "Perm";
                addBooking.info = "Frizzy hair";
                addBooking.stylist = "Tina Sparkle";
                addBooking.date = DateTime.Today.AddDays(1).ToShortDateString();
                addBooking.time = "10:00";
                currentBookings.Add(addBooking);

                context.Session["bookings"] = currentBookings;






            }
        }
        public List<Booking> AddBooking(string name, string phone, string style, string info, string stylist, string date, string time)
        {
            HttpContext context = HttpContext.Current;
            Booking addBooking = new Booking();
            addBooking.name = name;
            addBooking.phone = phone;
            addBooking.style = style;
            addBooking.info = info;
            addBooking.stylist = stylist;
            addBooking.date = date;
            addBooking.time = time;
            currentBookings.Add(addBooking);
            context.Session["bookings"] = currentBookings;
            return currentBookings;
        }
        public List<Booking> GetBookings()
        {
            HttpContext context = HttpContext.Current;
            currentBookings = (List<Booking>)context.Session["bookings"];
            currentBookings = currentBookings.OrderBy(o => o.date).ThenBy(c => c.time).ThenBy(c => c.stylist).ToList();
            return currentBookings;
        }
    }
}
