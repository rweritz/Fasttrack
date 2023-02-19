using System.Net;
using Microsoft.VisualBasic.CompilerServices;

namespace Fasttrack.Orderbook;

public class Orderbook : IOrderbook
{
    public Orderbook(string instrument)
    {
        Instrument = instrument;
    }

    private readonly IDictionary<long, Order> _orders = new Dictionary<long, Order>();
    private readonly SortedSet<Order> _bidOrders = new(BidOrderComparer.OrderComparer);
    private readonly SortedSet<Order> _askOrders = new(AskOrderComparer.OrderComparer);

    public string Instrument { get; }
    
    public void UpsertOrder(Order order)
    {
        if (_orders.ContainsKey(order.Id))
        {
            var oldOrder = _orders[order.Id];
            _orders[order.Id] = order;
            
            if (oldOrder.Side == Side.Bid)
            {
                _bidOrders.Remove(oldOrder);
                _bidOrders.Add(order);
            }
            else
            {
                _askOrders.Remove(oldOrder);
                _askOrders.Add(order);
            }
        }
        else
        {
            _orders.Add(order.Id, order);
        
            if (order.Side == Side.Bid)
                _bidOrders.Add(order);
            else
                _askOrders.Add(order);
        }
    }

    public void RemoveOrder(long orderId)
    {
        if (!_orders.ContainsKey(orderId))
            return;
        
        var oldOrder = _orders[orderId];
        _orders.Remove(orderId);
        
        if (oldOrder.Side == Side.Bid)
        {
            _bidOrders.Remove(oldOrder);
        }
        else
        {
            _askOrders.Remove(oldOrder);
        }
    }

    public IReadOnlySet<Order> GetBidOrders()
    {
        return _bidOrders;
    }

    public IReadOnlySet<Order> GetAskOrders()
    {
        return _askOrders;
    }

    public long? BestBidPrice => _bidOrders.Max?.Price ?? null;

    public long? BestAskPrice => _askOrders.Max?.Price ?? null;
    
    
}