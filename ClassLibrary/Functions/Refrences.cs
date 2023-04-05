using ClassLibrary.Model;
using ClassLibrary.Saves;

namespace ClassLibrary.Functions;

public class Refrences
{
    public List<Product> ReceiptProducts { get; } = new();

    public void FetchProduct(int id, int amount)
    {
        var productsLoader = new LoadingProducts();

        var product = productsLoader.LoadProducts().FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            Console.Clear();
            Console.WriteLine("Produkt saknas!");
            Console.ReadLine();
            return;
        }

        var existingProduct = ReceiptProducts.FirstOrDefault(x => x.Id == id);
        if (existingProduct != null)
        {
            existingProduct.Quantity += amount;
        }
        else
        {
            var newProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = amount,
            };
            ReceiptProducts.Add(newProduct);
        }
    }

    public decimal SumOfProducts(Product product)
    {
        decimal total = 0;
        foreach (var items in ReceiptProducts) total += items.Price * items.Quantity;
        product.Sum = total;
        return total;
    }
}