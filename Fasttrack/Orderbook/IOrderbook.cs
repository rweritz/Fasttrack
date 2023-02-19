namespace Fasttrack.Orderbook;

public interface IOrderbook
{
    void UpsertOrder(Order order);
    void RemoveOrder(long orderId);
    
    IReadOnlySet<Order> GetBidOrders();
    IReadOnlySet<Order> GetAskOrders();
    
    public long? BestBidPrice { get; }
    public long? BestAskPrice { get; }
}