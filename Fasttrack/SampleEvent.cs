using Fasttrack.Algo;
using Fasttrack.Orderbook;

namespace Fasttrack;

/// <remarks>
/// Optional: use initialization methods to configure your events.
/// </remarks>
public class SampleEvent
{
    public int Id { get; private set; }
    
    public Order? Order { get; private set; }
    
    public Parameter? Parameter { get; private set; }

    public void Initialize(int id, Order order, Parameter parameter)
    {
        Id = id;
        Order = order;
        Parameter = parameter;
    }
}