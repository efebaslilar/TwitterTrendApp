using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Text.Json;

namespace TwitterTrends.Controllers
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
                ViewBag.Setting = GetTrends.SettingList;
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
                GetTrends.RefreshSetting = true;
                GetTrends.SettingList.Add(new Models.Settings() { Country=country,Index=Convert.ToByte(number),Name=name,Count=count,TrendingHour=trendinghour,TrendingMinute=trendingminute});
                GetTrends.SaveJsonData(JsonSerializer.Serialize(GetTrends.SettingList), "Settings.json");
                GetTrends.RefreshSetting = true;
                return Ok();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Username") == "dc647eb65e6711e155375218212b3964")
            {
                switch (GetTrends.SettingList[id].Country)
                {
                    case "worldwide":
                        GetTrends.RefreshWorld = true;
                        break;
                    case "usa":
                        GetTrends.RefreshUSA = true;
                        break;
                    case "United Kingdom":
                        GetTrends.RefreshUK = true;
                        break;
                    case "india":
                        GetTrends.RefreshIndia = true;
                        break;
                    case "germany":
                        GetTrends.RefreshGermany = true;
                        break;
                    case "france":
                        GetTrends.RefreshFrance = true;
                        break;
                    case "brazil":
                        GetTrends.RefreshBrazil = true;
                        break;
                    case "southafrica":
                        GetTrends.RefreshSouthAfrica = true;
                        break;
                    case "turkey":
                        GetTrends.RefreshTurkey = true;
                        break;
                    case "Saudi Arabia":
                        GetTrends.RefreshSudi = true;
                        break;
                    default:
                        break;
                }
                GetTrends.SettingList.RemoveAt(id);
                GetTrends.SaveJsonData(JsonSerializer.Serialize(GetTrends.SettingList), "Settings.json");
                GetTrends.RefreshSetting=true;
                return Ok();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}
