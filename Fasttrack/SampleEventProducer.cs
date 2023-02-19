using System.Runtime.InteropServices;
using Disruptor;
using Fasttrack.Orderbook;

namespace Fasttrack;

public class SampleEventProducer
{
    private readonly RingBuffer<SampleEvent> _ringBuffer;

    public SampleEventProducer(RingBuffer<SampleEvent> ringBuffer)
    {
        _ringBuffer = ringBuffer;
    }

    private static Order GenerateRandomOrder(int id)
    {
        return new Order()
        {
            Id = id,
            Instrument = id % 2 == 0 ? "ACME A 22" : "ACME B 22",
            LastUpdate = DateTimeOffset.UtcNow,
            Price = new Random(id).NextInt64(2000, 30000),
            Quantity = new Random(id).NextInt64(2000, 30000),
            Side = Side.Ask
        };
    }
    
    public void ProduceUsingRawApi(int id)
    {
        // (1) Claim the next sequence
        var sequence = _ringBuffer.Next();
        try
        {
            // (2) Get and configure the event for the sequence
            var data = _ringBuffer[sequence];
            data.Initialize(id, GenerateRandomOrder(id), null);
        }
        finally
        {
            // (3) Publish the event
            _ringBuffer.Publish(sequence);
        }
    }

}