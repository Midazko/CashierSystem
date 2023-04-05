namespace ClassLibrary.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Prices PriceType { get; set; }
    public int Quantity { get; set; }
    public decimal Sum { get; set; }
    public decimal ValueOfProducts { get; set; }
}

public enum Prices
{
    Styck,
    Kilo
}