namespace WpfApp1.Models
{
    public class Customer
    {
        public string? Name { get; set; }

        public void BuyProduct(TradePoint tradePoint, Product product)
        {
            tradePoint.SellProduct(product);
        }
    }
}