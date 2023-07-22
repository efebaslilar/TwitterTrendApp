using HtmlAgilityPack;
using System.Net;
using System.Xml;
using TwitterTrendApp.Models;

namespace TwitterTrendApp.Bussiness
{
    public static class GetData
    {
        private static List<TrendModel> ScrapingData(string html)
        {
            Random random = new Random();
            List<TrendModel> liste = new List<TrendModel>();

            string htmlContent = html;
                HtmlDocument htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(htmlContent);
                HtmlNode divNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'trend-card')]");
                htmlDocument.LoadHtml(divNode.OuterHtml);
                var listItems = htmlDocument.DocumentNode.SelectNodes("//div[@class='trend-card']//li");
                if (listItems != null)
                {
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
                                TrendingHour = 12,
                                TrendingMinute = 23,
                            });
                        }
                    }
                }
                 return liste;
        }
    }
}
