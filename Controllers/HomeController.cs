using KutseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KutseApp.Controllers
{
	public class HomeController : Controller
	{
		public static string email;
		public ActionResult Index()
		{
			ViewBag.Greeting = CurrentTime();
			ViewBag.Message = "Head " + Month() + "i pidu!";
			return View();
		}
		[HttpGet]
		public ViewResult Ankeet()
		{
			return View();
		}
		[HttpPost]
		public ViewResult Ankeet(Guest guest)
		{
			if (ModelState.IsValid)
			{
				email = guest.Email;
				db.Guests.Add(guest);
				db.SaveChanges();
				return View("Thanks", guest);
			}
			else
				return View();
		}
		[HttpGet]
		public ActionResult GotIt()
		{
			Thanks(email);
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Haha.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Hehe.";

			return View();
		}
		public void Thanks(string email)
		{
			WebMail.SmtpServer = "smtp.gmail.com";
			WebMail.SmtpPort = 587;
			WebMail.EnableSsl = true;
			WebMail.UserName = "programmeeriminetthk2@gmail.com";
			WebMail.Password = "2.kuursus tarpv20";
			WebMail.From = "programmeeriminetthk2@gmail.com";
			WebMail.Send(email, "Hoiatus", "Ära unusta peole tulla, sõber! ");
		}
		
		GuestContext db = new GuestContext();
		[Authorize] //-только увидит залогиненный чел
		public ActionResult Guests()
		{
			IEnumerable<Guest> guests = db.Guests;
			return View(guests);
		}
		[Authorize]
		public ActionResult GuestsCome()
		{
			IEnumerable<Guest> guests = db.Guests.Where(g => g.Attend == true);
			return View(guests);
		}
		[Authorize]
		public ActionResult GuestsNotCome()
		{
			IEnumerable<Guest> guests = db.Guests.Where(g => g.Attend == false);
			return View(guests);
		}
		PiduContext pd = new PiduContext();
		[Authorize]
		public ActionResult Pidus()
		{
			IEnumerable<Pidu> pidus = pd.Pidus;
			return View(pidus);
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Guest guest)
		{
			db.Guests.Add(guest);
			db.SaveChanges();
			return RedirectToAction("Guests");
		}
		[HttpGet]
		public ActionResult Delete(int id)
		{
			Guest g = db.Guests.Find(id);
			if (g == null)
			{
				return HttpNotFound();
			}
			return View(g);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Guest g = db.Guests.Find(id);
			if(g == null)
			{
				return HttpNotFound();
			}
			db.Guests.Remove(g);
			db.SaveChanges();
			return RedirectToAction("Guests");
		}
		[HttpGet]
		public ActionResult Edit(int? id)
		{
			Guest g = db.Guests.Find(id);
			if (g == null)
			{
				return HttpNotFound();
			}
			return View(g);
		}
		[HttpPost, ActionName("Edit")]
		public ActionResult EditConfirmed(Guest guest)
		{
			db.Entry(guest).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Guests");
		}
		[HttpGet]
		public ActionResult Createpidus()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Createpidus(Pidu pidu)
		{
			pd.Pidus.Add(pidu);
			pd.SaveChanges();
			return RedirectToAction("Pidus");
		}
		[HttpGet]
		public ActionResult Deletepidus(int id)
		{
			Pidu p = pd.Pidus.Find(id);
			if (p == null)
			{
				return HttpNotFound();
			}
			return View(p);
		}
		[HttpPost, ActionName("Deletepidus")]
		public ActionResult DeleteConfirmedp(int id)
		{
			Pidu p = pd.Pidus.Find(id);
			if (p == null)
			{
				return HttpNotFound();
			}
			pd.Pidus.Remove(p);
			pd.SaveChanges();
			return RedirectToAction("Pidus");
		}
		[HttpGet]
		public ActionResult Editpidus(int? id)
		{
			Pidu p = pd.Pidus.Find(id);
			if (p == null)
			{
				return HttpNotFound();
			}
			return View(p);
		}
		[HttpPost, ActionName("Editpidus")]
		public ActionResult EditConfirmedp(Pidu p)
		{
			pd.Entry(p).State = System.Data.Entity.EntityState.Modified;
			pd.SaveChanges();
			return RedirectToAction("Pidus");
		}
		public string CurrentTime()
		{
			int h = DateTime.Now.Hour;
			if (h < 12 && h > 8)
			{
				return "Tere Hommikust";
			}
			else if (h < 18)
			{
				return "Tere päevast";
			}
			else if (h < 22)
			{
				return "Tere õhtu";
			}
			else if (h > 22 || h < 8)
			{
				return "Tere ööd";
			}
			return "";
		}
		public string Month()
		{
			return (new string[12] { "Jaanuari", "Veebruari", "Märtsi", "Aprilli", "Mai", "Juuni", "Juuli", "Augusti", "Septembri", "Oktoobri", "Novembri", "Detsemberi" })[DateTime.Now.Month - 1];
		}
	}
}