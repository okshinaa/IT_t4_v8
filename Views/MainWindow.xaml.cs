using System.Windows;
using WpfApp1.Models;

namespace WpfApp1.Views
{
    public partial class TradePointWindow : Window
    {
        private readonly TradePoint _tradePoint;
        private readonly Customer _customer;

        public TradePointWindow()
        {
            InitializeComponent();

            _tradePoint = new TradePoint();

            _tradePoint.AddProduct(new Product { Name = "Апельсины", Price = 10.0, Quantity = 5 });
            _tradePoint.AddProduct(new Product { Name = "Помидоры", Price = 15.0, Quantity = 3 });
            _tradePoint.AddProduct(new Product { Name = "Огурцы", Price = 20.0, Quantity = 7 });

            _customer = new Customer();

            _tradePoint.ProductPurchased += TradePoint_ProductPurchased;
            _tradePoint.ProductSoldOut += TradePoint_ProductSoldOut;

            UpdateProductList();
        }

        private void UpdateProductList()
        {
            ProductListBox.Items.Clear();
            foreach (var product in _tradePoint.Products)
            {
                ProductListBox.Items.Add($"{product.Name} - {product.Price}$ ({product.Quantity} доступно)");
            }
        }

        private void TradePoint_ProductPurchased(object sender, Product e)
        {
            MessageBox.Show($"Товар {e.Name} успешно куплен!");
            UpdateProductList();
        }

        private void TradePoint_ProductSoldOut(object sender, Product e)
        {
            MessageBox.Show($"Товар {e.Name} закончился!");
            UpdateProductList();
        }

        private void buyButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListBox.SelectedIndex >= 0)
            {
                string productName = ProductListBox.SelectedItem.ToString().Split('-')[0].Trim();
                Product selectedProduct = _tradePoint.Products.FirstOrDefault(p => p.Name == productName);

                if (selectedProduct != null)
                {
                    _customer.BuyProduct(_tradePoint, selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для покупки.");
            }
        }
    }
}
