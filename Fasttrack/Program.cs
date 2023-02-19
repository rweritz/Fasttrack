// See https://aka.ms/new-console-template for more information

// Size of the ring buffer, must be power of 2.

using System.Runtime.InteropServices;
using Disruptor.Dsl;
using Fasttrack;

const int bufferSize = 1024;

// Create the disruptor
var disruptor = new Disruptor<SampleEvent>(() => new SampleEvent(), bufferSize);

// Configure a simple chain
// SampleEventHandler -> OtherSampleEventHandler
disruptor.HandleEventsWith(new SampleEventHandler());

// Start the disruptor (start the consumer threads)
disruptor.Start();

var ringBuffer = disruptor.RingBuffer;

// Use the ring buffer to publish events

var producer = new SampleEventProducer(ringBuffer);

for (var i = 0; ; i++)
{
    producer.ProduceUsingRawApi(i);

    Thread.Sleep(1000);
}