namespace DealOrNoDeal;

public class Shared
{
    public static Dictionary<int, decimal> StartCases()
    {
        List<Decimal> values = new() {
            0.01M, 1M, 5M, 10M, 25M, 50M, 75M, 100M, 200M, 300M, 400M, 500M, 750M,
            1000M, 5000M, 10000M, 25000M, 50000M, 75000M,
            100000M, 200000M, 300000M, 400000M, 500000M, 750000M, 1000000M
        };

        Random random = new Random();

        List<decimal> scrambledValues = values.OrderBy(x => random.Next()).ToList();

        return scrambledValues
            .Select((valor, index) => new KeyValuePair<int, decimal>(index + 1, valor))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }

    public static decimal CalculateBankerOffer(Dictionary<int, decimal> remainingCases, int round)
    {
        if (remainingCases.Count == 0)
            return 0;

        decimal average = remainingCases.Values.Average();

        decimal adjustmentFactor = 0.2m + (round * 0.15m);
        adjustmentFactor = Math.Min(adjustmentFactor, 1.0m);

        decimal offer = average * adjustmentFactor;
        return Math.Round(offer, 2);
    }
}
