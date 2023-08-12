using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using TwitterTrends.Models;

namespace TwitterTrends.Controllers
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
            ViewBag.trendlist = GetTrends.WorldOuterHtml;

            
            return View();
        }


        [HttpGet("Country")]
        public IActionResult Country(string country)
        {
            switch (country)
            {
                case "worldwide":
                    return Ok(GetTrends.WorldOuterHtml);
                case "United State":
                    return Ok(GetTrends.USAOuterHtml);
                case "United Kingdom":
                    return Ok(GetTrends.UKOuterHtml);
                case "india":
                    return Ok(GetTrends.IndiaOuterHtml);
                case "germany":
                    return Ok(GetTrends.GermanyOuterHtml);
                case "france":
                    return Ok(GetTrends.FranceOuterHtml);
                case "brazil":
                    return Ok(GetTrends.BrazilOuterHtml);
                case "south Africa":
                    return Ok(GetTrends.SouthAfricaOuterHtml);
                case "turkey":
                    return Ok(GetTrends.TurkeyOuterHtml);
                case "Saudi Arabia":
                    return Ok(GetTrends.SudiarabiaOuterHtml);
                default:
                    break;
            }
            return Ok();
        }


        #region Old Code
        //string trendlist = @" <li>
        //            <div class=""card-content"">
        //                <span class=""header"">DENEME1</span>
        //                <span class=""info"">
        //                    <span class=""trending-time"">Trending since 12 hours 24 minutes.</span>
        //                    <br>
        //                    <span class=""tweet-amount"">10K Tweets</span>
        //                    <a href=""#"">HASHTAG</a>
        //                </span>
        //            </div>
        //        </li>";

        //string hml;
        //string htmlHazirla()
        //{
        //    string html = "";
        //    Random random = new Random();
        //    hml = "";
        //    for (int i = 0; i < GetTrends.WorldOuterHtml.Count; i = i + 2)
        //    {
        //        string deger = GetTrends.WorldOuterHtml[i + 1] == "0" ? random.Next(10, 70).ToString() : GetTrends.WorldOuterHtml[i + 1];
        //        html += $@" <li>
        //            <div class=""card-content"">
        //                <span class=""header"">{GetTrends.WorldOuterHtml[i]}</span>
        //                <span class=""info"">
        //                <span class=""trending-time"">Trending since {random.Next(1, 4)} hours {random.Next(1, 59)} minutes.</span>
        //                    <br>
        //                    <span class=""tweet-amount"">{deger}K Tweets</span>
        //                    <a href=""#"">HASHTAG</a>
        //                </span>
        //            </div>
        //        </li>";
        //        hml += $@" <li>
        //                <span class=""info"">{(i / 2) + 1} · Trending</span><br>
        //                <span class=""title"">{GetTrends.WorldOuterHtml[i]}</span><br>
        //                <span class=""description"">{deger}k Tweet</span>
        //            </li>";
        //    }
        //    return html;
        //}

        #endregion

    }
}