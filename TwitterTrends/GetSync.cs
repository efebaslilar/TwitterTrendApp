using TwitterTrends.Models;

namespace TwitterTrends
{
    public static class GetSync
    {
        private static IApplicationBuilder app;
        public static IApplicationBuilder SyncData(this IApplicationBuilder application)
        {
            app = application;
            syncTrend();
            return app;
        }

        private static void syncTrend()
        {
            GetTrends.RefreshSetting = true;
            foreach (Settings item in GetTrends.SettingList)
            {
                if (item.Country == "worldwide" &&GetTrends.WorldOuterHtml!=null)
                {
                    GetTrends.WorldOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "usa"&& GetTrends.USAOuterHtml!=null)
                {
                    GetTrends.USAOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "United Kingdom"&& GetTrends.UKOuterHtml!=null)
                {
                    GetTrends.UKOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "india"&& GetTrends.IndiaOuterHtml!=null)
                {
                    GetTrends.IndiaOuterHtml[(item.Index - 1) ] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "germany"&& GetTrends.GermanyOuterHtml != null)
                {
                    GetTrends.GermanyOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "france"&& GetTrends.FranceOuterHtml!=null)
                {
                    GetTrends.FranceOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute ,hrefurl= "https://twitter.com/search?q="+ item.Name };
                }
                else if (item.Country == "brazil"&& GetTrends.BrazilOuterHtml!=null)
                {
                    GetTrends.BrazilOuterHtml[(item.Index - 1) ] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "southafrica"&& GetTrends.SouthAfricaOuterHtml!=null)
                {
                    GetTrends.SouthAfricaOuterHtml[(item.Index - 1) ] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "turkey" && GetTrends.TurkeyOuterHtml!=null)
                {
                    GetTrends.TurkeyOuterHtml[(item.Index - 1) ] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }
                else if (item.Country == "Saudi Arabia"&& GetTrends.SudiarabiaOuterHtml!=null)
                {
                    GetTrends.SudiarabiaOuterHtml[(item.Index - 1)] = new TrendModel() { Name = item.Name, Count = item.Count, TrendingHour = item.TrendingHour, TrendingMinute = item.TrendingMinute, hrefurl = "https://twitter.com/search?q=" + item.Name };
                }

            }

        }
    }
}
