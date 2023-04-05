using ClassLibrary.Functions;
using ClassLibrary.Model;

namespace ClassLibrary.Saves;

public class SaveReceipt
{
    public int receiptnum;

    public void SaveToFile(Refrences refrences)
    {
        var receiptIdFile = "RECEIPT_ID" + DateTime.Now.ToString("yyyyMMMMdd") + ".txt";
        if (File.Exists(receiptIdFile))
        {
            var receiptIdString = File.ReadAllText(receiptIdFile);
            int.TryParse(receiptIdString, out receiptnum);
        }
        else
        {
            receiptnum = 1;
        }

        Product product = new();
        refrences.SumOfProducts(product);
        var strings = new List<string>();
        var kvitto = "\nKVITTO ID: " + receiptnum + " \nDatum: " + DateTime.Now;
        strings.Add(kvitto);
        foreach (var item in refrences.ReceiptProducts)
        {
            var userString = item.Name + " " + item.Quantity + " * " + item.Price + " = " + item.ValueOfProducts + " kr";
            strings.Add(userString);
        }

        var total = "Total priset var: " + product.Sum + " kr";
        strings.Add(total);

        File.AppendAllLines("RECEIPT_" + DateTime.Now.ToString("yyyyMMdd") + ".txt", strings);
        receiptnum++;
        File.WriteAllText(receiptIdFile, receiptnum.ToString());
    }
}