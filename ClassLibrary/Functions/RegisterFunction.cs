using ClassLibrary.Model;
using ClassLibrary.Saves;

namespace ClassLibrary.Functions;

public class RegisterFunction
{
    public void ReceiptMenu(Refrences refrences)
    {
        var receipt = new Receipt();
        SaveReceipt savereceipt = new();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("KASSA");

            ShowReceipt(refrences);
            Console.ResetColor();
            Console.Write("Kommandon: \n" +
                          "<productid> <antal>\n" +
                          "PAY\n" +
                          "Kommando: ");
            var answer = Console.ReadLine();
            if (answer == "PAY")
            {
                Console.WriteLine("saving to file.");
                savereceipt.SaveToFile(refrences);
            }
            else
            {
                SplitInput(answer, refrences);
            }
        }
    }

    public void ShowReceipt(Refrences calculate)
    {
        Product product = new();
        LoadingProducts products = new();
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("KVITTO:   " + DateTime.Now);
        foreach (var item in calculate.ReceiptProducts)
            Console.WriteLine(
                $"{item.Name} {item.Quantity} * {item.Price} = {item.ValueOfProducts = item.Price * item.Quantity}");
        calculate.SumOfProducts(product);
        Console.WriteLine($"Total: {product.Sum}");
    }

    public bool SplitInput(string answer, Refrences refrences)
    {
        var part = answer.Split(' ');
        if (part.Length != 2)
        {
            Console.WriteLine("Skriv rätt!");
            return false;
        }

        var id = Convert.ToInt32(part[0]);
        var amount = Convert.ToInt32(part[1]);
        refrences.FetchProduct(id, amount);
        return true;
    }
}