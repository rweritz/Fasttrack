using Fasttrack.Orderbook;

namespace Fasttrack.Algo;

public interface ITactic
{
    public string Name { get; }
    
    public void ProcessOrderbook(Orderbook.Orderbook orderbook);

    public void ProcessParameter(Parameter parameter);
    
    public IReadOnlyList<string> ReferenceInstruments { get; }
}