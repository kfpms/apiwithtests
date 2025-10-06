namespace HundredX.API.Models
{
    public class HistoricalRecord
    {
        public int CryptocurrencyId { get; set; }
        public DateTime RecordDate { get; set; }
        public decimal? Price { get; set; }
        public decimal? Supply { get; set; }
        public decimal? Volume { get; set; }
        public int Rank { get; set; }
        public decimal? MarketCap { get; set; }
    }
}
