using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using TwitterTrendApp.Bussiness;

namespace TwitterTrendApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            if (username == "lydia" && password == "98129001")
            { 
                HttpContext.Session.SetString("Username", "dc647eb65e6711e155375218212b3964");
                return RedirectToAction("Settings");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
            return RedirectToAction("Index");
        }

        public IActionResult Settings()
        {
            if (HttpContext.Session.GetString("Username") == "dc647eb65e6711e155375218212b3964")
            {
                ViewBag.Setting = SqlConneciton.GetData("Trend");

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult AddSettings(string country,string number,string name,int count, byte trendinghour,byte trendingminute)
        {
            if (HttpContext.Session.GetString("Username") == "dc647eb65e6711e155375218212b3964")
            {
                Hashtable TrendHT = new Hashtable();
                TrendHT.Add("Country", $"'{country}'");
                TrendHT.Add("HastagIndex", number);
                TrendHT.Add("HastagName", $"'{name}'");
                TrendHT.Add("Quantity", count);
                TrendHT.Add("hrefurl", $"'{country}'");
                TrendHT.Add("TrendingHour", trendinghour);
                TrendHT.Add("TrendingMinute", trendingminute);

                 var a =   SqlConneciton.InsertData("Trend", TrendHT);

                return Ok();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            if (HttpContext.Session.GetString("Username") == "dc647eb65e6711e155375218212b3964")
            {
                SqlConneciton.DeleteData("Trend", $"ID={id}");
                return Ok();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
