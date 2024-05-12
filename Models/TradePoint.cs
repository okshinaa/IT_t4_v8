using System.Windows;

namespace WpfApp1.Models
{
    public class TradePoint
    {
        public event EventHandler<Product>? ProductSoldOut;
        public event EventHandler<Product>? ProductPurchased;

        private readonly List<Product> _products = new List<Product>();

        public IReadOnlyList<Product> Products => _products;

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void SellProduct(Product product)
        {
            if (_products.Contains(product))
            {
                if (product.Quantity > 0)
                {
                    product.Quantity--;
                    ProductPurchased?.Invoke(this, product);
                }
                else
                {
                    ProductSoldOut?.Invoke(this, product);
                }
            }
            else
            {
                MessageBox.Show("Товар не найден!");
            }
        }
    }
}