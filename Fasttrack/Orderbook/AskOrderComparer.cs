namespace Fasttrack.Orderbook;

public class AskOrderComparer : IComparer<Order>
{
    public static AskOrderComparer OrderComparer { get; } = new AskOrderComparer();
    
    public int Compare(Order? x, Order? y)
    {
        return x.Price != y.Price ? x.Price.CompareTo(y.Price) * -1 : x.LastUpdate.CompareTo(y.LastUpdate);
    }
}