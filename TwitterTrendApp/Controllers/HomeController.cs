using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using SmartLibrary.Statics;
using System.Data;
using System.Diagnostics;
using TwitterTrendApp.Bussiness;
using TwitterTrendApp.Models;

namespace TwitterTrendApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string htmlcontent = SmartData.Get("world").ToString();
            ViewBag.trendlist = FilterData(ScrapingData(htmlcontent), "worldwide");
            return View();
        }

        [HttpGet("Country")]
        public IActionResult Country(string country)
        {
            string html;
            switch (country)
            {
                case "worldwide":
                    html = SmartData.Get("world").ToString();
                    return Ok(FilterData(ScrapingData(html), "worldwide"));
                case "United State":
                    html = SmartData.Get("usa").ToString();
                    return Ok(FilterData(ScrapingData(html), "usa"));
                case "United Kingdom":
                    html = SmartData.Get("uk").ToString();
                    return Ok(FilterData(ScrapingData(html), "United Kingdom"));
                case "india":
                    html = SmartData.Get("india").ToString();
                    return Ok(FilterData(ScrapingData(html), "india"));
                case "germany":
                    html = SmartData.Get("germany").ToString();
                    return Ok(FilterData(ScrapingData(html), "germany"));
                case "france":
                    html = SmartData.Get("france").ToString();
                    return Ok(FilterData(ScrapingData(html), "france"));
                case "brazil":
                    html = SmartData.Get("brazil").ToString();
                    return Ok(FilterData(ScrapingData(html), "brazil"));
                case "south Africa":
                    html = SmartData.Get("africa").ToString();
                    return Ok(FilterData(ScrapingData(html), "southafrica"));
                case "turkey":
                    html = SmartData.Get("turkey").ToString();
                    return Ok(FilterData(ScrapingData(html), "turkey"));
                case "Saudi Arabia":
                    html = SmartData.Get("arabia").ToString();
                    return Ok(FilterData(ScrapingData(html), "Saudi Arabia"));
                default:
                    break;
            }
            return Ok();
        }

        private static List<TrendModel> FilterData(List<TrendModel> list, string country)
        {
            var a = SqlConneciton.GetData("Trend", "*", $"Country='{country}'").AsEnumerable();
            foreach (DataRow item in a)
            {
                list[Convert.ToInt32(item["HastagIndex"])-1] = new TrendModel()
                {
                    HastagName = item["HastagName"].ToString(),
                    Quantity = Convert.ToInt32(item["Quantity"]),
                    hrefurl = item["hrefurl"].ToString(),
                    TrendingHour = Convert.ToByte(item["TrendingHour"]),
                    TrendingMinute = Convert.ToByte( item["TrendingMinute"])

                };
            }
            return list;
        }
      
        private static List<TrendModel> ScrapingData(string html)
        {
            Random random = new Random();
            List<TrendModel> liste = new List<TrendModel>();
            // Fisher-Yates algoritmasıyla listeyi rastgele karıştırma
            for (int i = GetTrendingTime.trendingTimes.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                TrendingTime temp = GetTrendingTime.trendingTimes[i];
                GetTrendingTime.trendingTimes[i] = GetTrendingTime.trendingTimes[j];
                GetTrendingTime.trendingTimes[j] = temp;
            }
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            HtmlNode divNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'trend-card')]");
            htmlDocument.LoadHtml(divNode.OuterHtml);
            var listItems = htmlDocument.DocumentNode.SelectNodes("//div[@class='trend-card']//li");
            if (listItems != null)
            {
                int sayac = 0;
                foreach (var listItem in listItems)
                {
                    var link = listItem.SelectSingleNode(".//a");
                    var countSpan = listItem.SelectSingleNode(".//span[@class='tweet-count']");

                    string linkText = link?.InnerText;
                    int count = countSpan != null ? int.Parse(countSpan.InnerText.Replace("K", string.Empty)) : 0;
                    if (linkText != null && linkText != "")
                    {
                        liste.Add(new TrendModel()
                        {
                            HastagName = linkText,
                            Quantity = count != 0 ? count : random.Next(20, 110),
                            hrefurl = "https://twitter.com/search?q=" + linkText,
                            TrendingHour =  GetTrendingTime.trendingTimes[sayac].TrendingHour,
                            TrendingMinute = GetTrendingTime.trendingTimes[sayac].TrendingMinute,
                        });
                        sayac++;
                    }
                }
            }
            return liste;
        }

    }
}