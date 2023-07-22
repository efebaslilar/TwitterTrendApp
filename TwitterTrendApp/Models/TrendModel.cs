using System.Diagnostics.Metrics;

namespace TwitterTrendApp.Models
{
    public class TrendModel:TrendingTime
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public byte HastagIndex { get; set; }
        public string HastagName { get; set; }
        public int Quantity { get; set; }
        public string hrefurl { get; set; }


        //    CREATE TABLE Trend (
        //        ID INT IDENTITY(1,1) PRIMARY KEY,
        //        Country VARCHAR(255),
        //        HastagIndex TINYINT,
        //        HastagName VARCHAR(255),
        //        Quantity INT,
        //        hrefurl VARCHAR(255),
        //        TrendingHour TINYINT,
        //        TrendingMinute TINYINT
        //    );
    }
}
