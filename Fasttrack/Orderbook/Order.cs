namespace Fasttrack.Orderbook;

public class Order
{
    public long Id { get; set; }
    
    public string Instrument { get; set; }
    public DateTimeOffset LastUpdate { get; set; }
    public long Quantity { get; set; }
    public long Price { get; set; }
    public Side Side { get; set; }
}