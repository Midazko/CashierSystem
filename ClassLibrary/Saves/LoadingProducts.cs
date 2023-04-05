using ClassLibrary.Functions;
using ClassLibrary.Model;

namespace ClassLibrary.Saves;

public class LoadingProducts
{
    public List<Product> LoadProducts()
    {
        const string productListFile = "Products.txt";
        var products = new List<Product>();

        if (!File.Exists(productListFile)) return products;

        foreach (var line in File.ReadLines(productListFile))
        {
            var parts = line.Split('/');
            if (parts.Length < 4) continue;

            if (!int.TryParse(parts[0], out var id) || id <= 0) continue;

            if (!decimal.TryParse(parts[2], out var price) || price <= 0) continue;

            if (!Enum.TryParse(parts[3], true, out Prices priceType)) continue;

            var product = new Product
            {
                Id = id,
                Name = parts[1],
                Price = price,
                PriceType = priceType
            };
            products.Add(product);
        }

        return products;
    }
}