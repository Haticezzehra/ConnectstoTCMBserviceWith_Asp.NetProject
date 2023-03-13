namespace UI_MVC.Models.Domain
{
    public class Forex
    {
        public int ID { get; set; }
        public string CurrencyCode { get; set; }
        public string Unit { get; set; }
        public string CurrencyName { get; set; }
        public string ForexBuying { get; set; }
        public string ForexSelling { get; set; }
        public string BanknoteBuying { get; set; }
        public string BanknoteSelling { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;
    }
}
