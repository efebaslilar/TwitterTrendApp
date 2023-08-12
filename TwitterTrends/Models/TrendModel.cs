namespace TwitterTrends.Models
{
    public class TrendModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public byte TrendingHour { get; set; }
        public byte TrendingMinute { get; set; }
        public string hrefurl { get; set; }
    }
}
