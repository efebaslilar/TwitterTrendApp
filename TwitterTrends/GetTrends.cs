using HtmlAgilityPack;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using TwitterTrends.Models;

namespace TwitterTrends
{
    public static class GetTrends
    {
        #region variables
        private static string WorldWideHtml= "WorldWideHtml.json";
        private static string USAHtml = "USAHtml.json";
        private static string UKHtml = "UKHtml.json";
        private static string IndiaHtml = "IndiaHtml.json";
        private static string GermanyHtml = "GermanyHtml.json";
        private static string FranceHtml = "FranceHtml.json";
        private static string BrazilHtml = "BrazilHtml.json";
        private static string SouthAfricaHtml = "SouthAfricaHtml.json";
        private static string TurkeyHtml = "TurkeyHtml.json";
        private static string SudiarabiaHtml = "SudiarabiaHtml.json";
        public static bool RefreshWorld;
        public static bool RefreshUSA;
        public static bool RefreshUK;
        public static bool RefreshIndia;
        public static bool RefreshGermany;
        public static bool RefreshFrance;
        public static bool RefreshBrazil;
        public static bool RefreshSouthAfrica;
        public static bool RefreshTurkey;
        public static bool RefreshSudi;
        public static bool RefreshSetting;
                                  
        private static List<TrendModel> _WorldOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _USAOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _UKOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _IndiaOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _GermanyOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _FranceOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _BrazilOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _SouthAfricaOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _TurkeyOuterHtml = new List<TrendModel>();
        private static List<TrendModel> _sudiarabiaOuterHtml = new List<TrendModel>();
        private static List<Settings> Settings = new List<Settings>();


        #endregion
        #region Propertys


        public static List<TrendModel> WorldOuterHtml
        {
            get
            {
                if (RefreshWorld)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(WorldWideHtml));
                    if (jsonData!="")
                    _WorldOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshWorld= false;
                }
                return _WorldOuterHtml;
            }
            set
            {
                _WorldOuterHtml = value;
            }
        }
        public static List<TrendModel> USAOuterHtml
        {
            get
            {
                if (RefreshUSA)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(USAHtml));
                    if (jsonData != "")
                        _USAOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshUSA= false;
                }
                return _USAOuterHtml;
            }
            set
            {
                _USAOuterHtml = value;
            }
        }
        public static List<TrendModel> UKOuterHtml
        {
            get
            {
                if (RefreshUK)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(UKHtml));
                    if (jsonData != "")
                        _UKOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshUK= false;
                }
                return _UKOuterHtml;
            }
            set
            {
                _UKOuterHtml = value;
            }
        }
        public static List<TrendModel> IndiaOuterHtml
        {
            get
            {
                if (RefreshIndia)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(IndiaHtml));
                    if (jsonData != "")
                        _IndiaOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshIndia= false;
                }
                return _IndiaOuterHtml;
            }
            set
            {
                _IndiaOuterHtml = value;
            }
        }
        public static List<TrendModel> GermanyOuterHtml
        {
            get
            {
                if (RefreshGermany)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(GermanyHtml));
                    if (jsonData != "")
                        _GermanyOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshGermany= false;
                }
                return _GermanyOuterHtml;
            }
            set
            {
                _GermanyOuterHtml = value;
            }
        }
        public static List<TrendModel> FranceOuterHtml
        {
            get
            {
                if (RefreshFrance)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(GermanyHtml));
                    if (jsonData != "")
                        _FranceOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshFrance= false;
                }
                return _FranceOuterHtml;
            }
            set
            {
                _FranceOuterHtml = value;
            }
        }
        public static List<TrendModel> BrazilOuterHtml
        {
            get
            {
                if (RefreshBrazil)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(BrazilHtml));
                    if (jsonData != "")
                        _BrazilOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshBrazil= false;
                }
                return _BrazilOuterHtml;
            }
            set
            {
                _BrazilOuterHtml = value;
            }
        }
        public static List<TrendModel> SouthAfricaOuterHtml
        {
            get
            {
                if (RefreshSouthAfrica)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(SouthAfricaHtml));
                    if (jsonData != "")
                        _SouthAfricaOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshSouthAfrica= false;
                }
                return _SouthAfricaOuterHtml;
            }
            set { _SouthAfricaOuterHtml = value; }
        }
        public static List<TrendModel> TurkeyOuterHtml
        {
            get
            {
                if (RefreshTurkey)
                {

                    var jsonData = File.ReadAllText(AppendToWwwRoot(TurkeyHtml));
                    if (jsonData != "")
                        _TurkeyOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshTurkey= false;
                }
                return _TurkeyOuterHtml;
            }
            set { _TurkeyOuterHtml = value; }
        }
        public static List<TrendModel> SudiarabiaOuterHtml
        {
            get 
            {
                if (RefreshSudi)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot(SudiarabiaHtml));
                    if (jsonData != "")
                        _sudiarabiaOuterHtml = JsonSerializer.Deserialize<List<TrendModel>>(jsonData);
                    RefreshSudi = false;
                }
                return _sudiarabiaOuterHtml;
            }
            set { _sudiarabiaOuterHtml = value; }
        }
        public static List<Settings> SettingList
        {
            get
            {
                if (RefreshSetting)
                {
                    var jsonData = File.ReadAllText(AppendToWwwRoot("Settings.json"));
                    if (jsonData!="")
                    Settings = JsonSerializer.Deserialize<List<Settings>>(jsonData);
                    RefreshSetting = false;
                }
                return Settings;
            }
            set { Settings = value; }
        }

        #endregion







        private static IApplicationBuilder app;
        public static IApplicationBuilder PrepareData(this IApplicationBuilder application)
        {
            app = application;
            getTrend("https://trends24.in/", WorldWideHtml, ref RefreshWorld);
            getTrend("https://trends24.in/united-states/", USAHtml,ref RefreshUSA);
            getTrend("https://trends24.in/united-kingdom/", UKHtml,ref RefreshUK);
            getTrend("https://trends24.in/india/", IndiaHtml,ref RefreshIndia);
            getTrend("https://trends24.in/germany/", GermanyHtml,ref RefreshGermany);
            getTrend("https://trends24.in/france/", FranceHtml,ref RefreshFrance);
            getTrend("https://trends24.in/brazil/", BrazilHtml,ref RefreshBrazil);
            getTrend("https://trends24.in/south-africa/", SouthAfricaHtml,ref RefreshSouthAfrica);
            getTrend("https://trends24.in/turkey/", TurkeyHtml,ref RefreshTurkey);
            getTrend("https://trends24.in//saudi-arabia/", SudiarabiaHtml,ref RefreshSudi);
            //syncTrend();

            return app;
        }

        private static void getTrend(string url, string path,ref bool refresh)
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
            using (WebClient client = new WebClient())
            {
                string htmlContent = client.DownloadString(url);
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);
                HtmlNode divNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'trend-card')]");
                htmlDocument.LoadHtml(divNode.OuterHtml);
                var listItems = htmlDocument.DocumentNode.SelectNodes("//div[@class='trend-card']//li");
                if (listItems != null)
                {
                    liste.Clear();
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
                                Name = linkText,
                                Count = count != 0 ? count : random.Next(20, 110),
                                hrefurl = "https://twitter.com/search?q=" + linkText,
                                TrendingHour = GetTrendingTime.trendingTimes[sayac].TrendingHour,
                                TrendingMinute = GetTrendingTime.trendingTimes[sayac].TrendingMinute,
                            });
                            sayac++;
                        }

                    }
                    if (liste.Count > 10)
                    {
                        SaveJsonData(JsonSerializer.Serialize(liste),path);
                        refresh=true;
                    }
                }

            }
        }
        public static void SaveJsonData(string jsonData, string filePath)
        {
            File.WriteAllText(AppendToWwwRoot(filePath), jsonData);
        }

        public static string AppendToWwwRoot(string input)
        {
            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string result = Path.Combine(wwwRootPath, input);

            // Dosya yolunda dosya yoksa oluşturulur
            if (!File.Exists(result))
            {
                using (File.Create(result)) { }
            }

            return result;
        }
        //private static void syncTrend()
        //{
        //    foreach (Settings item in SettingList)
        //    {
        //        if (item.Country== "worldwide")
        //        {
        //            WorldWideHtml[((item.Index-1)*2)]= new TrendModel() { Name = item.Name,Count = item.Count, TrendingHour=item.TrendingHour,TrendingMinute=item.TrendingMinute} ;
        //        }
        //        else if (item.Country == "usa")
        //        {
        //            USAHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "United Kingdom")
        //        {
        //            UKHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "india")
        //        {
        //            IndiaHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "germany")
        //        {
        //            GermanyHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "france")
        //        {
        //            FranceHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "brazil")
        //        {
        //            BrazilHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "southafrica")
        //        {
        //            SouthAfricaHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "turkey")
        //        {
        //            TurkeyHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }
        //        else if (item.Country == "Saudi Arabia")
        //        {
        //            SudiarabiaHtml[((item.Index - 1) * 2)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute };
        //        }

        //    }

        //}

    }
}
