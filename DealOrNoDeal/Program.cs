using DealOrNoDeal;

var cases = Shared.StartCases();
Dictionary<int, decimal> userCase = null;
int selectedCase = 0;
int round = 1;
Decimal BankerOffer = 0;
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("DEAL OR NO DEAL\n");

    Console.ResetColor();
    foreach (var item in cases)
        Console.WriteLine(item.Key);

    if (userCase == null)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n\nSELECT YOUR CASE:");
        selectedCase = Convert.ToInt32(Console.ReadLine());

        userCase = new();
        if (cases.ContainsKey(selectedCase))
        {
            userCase.Add(selectedCase, cases[selectedCase]);
            cases.Remove(selectedCase);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\nINVALID CASE!");
        }
    }
} while (userCase == null);

Console.Clear();

for (int i = 6; i > 0;)
{
    for (int j = 0; j < i; j++)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("DEAL OR NO DEAL\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\nYOUR CASE: {userCase.Keys.First()}");

        Console.ResetColor();
        foreach (var item in cases)
            Console.WriteLine(item.Key);
        Console.WriteLine("\n\nSELECT A CASE:");
        selectedCase = Convert.ToInt32(Console.ReadLine());

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n\nCASE {selectedCase} VALUE: $ {cases[selectedCase]}");

        cases.Remove(selectedCase);
        round++;
        Console.ReadLine();
        Console.Clear();
    }

    BankerOffer = Shared.CalculateBankerOffer(cases, round);
    Console.WriteLine($"BANK PROPOUSE $ {BankerOffer}");
    Console.WriteLine("Y - DEAL");
    Console.WriteLine("N - NO DEAL");
    Console.ResetColor();
    string dealOrNoDealBankPropouse = Console.ReadLine();
    if (dealOrNoDealBankPropouse == "Y" || dealOrNoDealBankPropouse == "y")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n\nYOU WON: $ {BankerOffer}");
        Console.ResetColor();
        break;
    }
        
    Console.Clear();
    Console.ResetColor();

    if (round == 25)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("DO YOU WANT TO CHANGE YOUR CASE?");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"YOUR CASE: {userCase.Keys.First()}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"LAST CASE: {cases.Keys.First()}");
        Console.ResetColor();
        string switchCaseChoice = Console.ReadLine();

        if (switchCaseChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\nYOU LOST: $ {userCase.Values.First()}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nYOU WON: $ {cases.Values.First()}");
            Console.ResetColor();
            break;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\nYOU LOST: $ {cases.Values.First()}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nYOU WON: $ {userCase.Values.First()}");
            Console.ResetColor();
            break;
        }
    }

    if (i > 1)
        i--;
}
