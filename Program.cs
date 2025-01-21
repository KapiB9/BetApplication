using Projekt;

internal class Program
{
    private static void Main(string[] args)
    {
        User u = new(10);
        User u2 = new(20);
        Console.WriteLine($"{u.balance}");
        wlBet bet = new("Real", "Barca");
        bet.AddCoupon(u, 10, "Barca");
        bet.AddCoupon(u2, 10, "Real");
        Console.WriteLine($"{u.balance} {u2.balance}");
        bet.CloseBet("Barca");
        Console.WriteLine($"{u.balance} {u2.balance}");

    }
}
