namespace Fasttrack.Orderbook;

public class BidOrderComparer : IComparer<Order>
{
    public static BidOrderComparer OrderComparer { get; } = new BidOrderComparer();

    private BidOrderComparer()
    {
        
    }
    
    public int Compare(Order? x, Order? y)
    {
        return x.Price != y.Price ? x.Price.CompareTo(y.Price) : x.LastUpdate.CompareTo(y.LastUpdate);
    }
}