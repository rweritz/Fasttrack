using Fasttrack.Orderbook;
using Xunit;

namespace Fasttrack.Test;

public class OrderbookTest
{
    [Fact]
    public void TestBestBidPrice()
    {
        var orderbook = new Orderbook.Orderbook("ACME A 22");
        Assert.Null(orderbook.BestBidPrice);
        
        orderbook.UpsertOrder(new Order()
        {
            Side = Side.Bid,
            Id = 1234,
            LastUpdate = new DateTimeOffset(2022, 10, 4, 13, 30, 1, 5, TimeSpan.Zero),
            Price = 2500,
            Quantity = 500
        });
        Assert.Equal(2500, orderbook.BestBidPrice);
        
        orderbook.UpsertOrder(new Order()
        {
            Side = Side.Bid,
            Id = 1234,
            LastUpdate = new DateTimeOffset(2022, 10, 4, 13, 30, 1, 5, TimeSpan.Zero),
            Price = 2600,
            Quantity = 500
        });
        Assert.Equal(2600, orderbook.BestBidPrice);
        
        orderbook.UpsertOrder(new Order()
        {
            Side = Side.Bid,
            Id = 1234,
            LastUpdate = new DateTimeOffset(2022, 10, 4, 13, 30, 1, 5, TimeSpan.Zero),
            Price = 2550,
            Quantity = 500
        });
        Assert.Equal(2550, orderbook.BestBidPrice);
        
        orderbook.UpsertOrder(new Order()
        {
            Side = Side.Bid,
            Id = 5,
            LastUpdate = new DateTimeOffset(2022, 10, 4, 13, 30, 1, 5, TimeSpan.Zero),
            Price = 2450,
            Quantity = 500
        });
        Assert.Equal(2550, orderbook.BestBidPrice);
    }
}