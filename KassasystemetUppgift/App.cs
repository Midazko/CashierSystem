using ClassLibrary.Functions;
using ClassLibrary.Model;

public class App
{
    public void Run()
    {
        var Menu = true;
        RegisterFunction registerFunction = new();
        Refrences refrences = new();
        while (Menu)
        {
            Console.Clear();
            Console.WriteLine("KASSA \n" +
                              "1. Ny Kund \n" +
                              "0. Avsluta");
            if (int.TryParse(Console.ReadLine(), out var Meny))
            {
                switch (Meny)
                {
                    case 1:
                        registerFunction.ReceiptMenu(refrences);
                        break;
                    case 0:
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du måste ange en siffra!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.ReadLine();
            }
        }
    }
}