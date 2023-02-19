using Disruptor;
using Fasttrack.Algo;

namespace Fasttrack;

public class SampleEventHandler : IEventHandler<SampleEvent>
{
    public void OnEvent(SampleEvent data, long sequence, bool endOfBatch)
    {
        if (data.Order is not null)
        {
            var orderbook = Context.Instance.Orderbooks[data.Order.Instrument];
            orderbook.UpsertOrder(data.Order);
            
            foreach (var tactic in Context.Instance.GetAllTacticsDependentOnInstrument(data.Order.Instrument))
            {
                tactic.ProcessOrderbook(orderbook);
            }
        }

        if(data.Parameter is not null)
            Console.WriteLine("Parameter Name: " + data.Parameter.Name);
    }
}