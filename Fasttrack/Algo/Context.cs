namespace Fasttrack.Algo;

public class Context
{
    public static Context Instance { get; } = new();

    private Context()
    {
        Orderbooks = new Dictionary<string, Orderbook.Orderbook>();
        _tacticsPerInstrument = new Dictionary<string, IList<ITactic>>();
    }

    public IReadOnlyDictionary<string, Orderbook.Orderbook> Orderbooks { get; }
    
    private IDictionary<string, IList<ITactic>> _tacticsPerInstrument { get; }

    
    
    public void AddTactic(ITactic tactic)
    {
        foreach (var referenceInstrument in tactic.ReferenceInstruments)
        {
            if(!_tacticsPerInstrument.ContainsKey(referenceInstrument))
                _tacticsPerInstrument.Add(referenceInstrument, new List<ITactic>());
            _tacticsPerInstrument[referenceInstrument].Add(tactic);
        }
    }
    
    public IReadOnlyList<ITactic> GetAllTacticsDependentOnInstrument(string instrument)
    {
        if(!_tacticsPerInstrument.ContainsKey(instrument))
            _tacticsPerInstrument.Add(instrument, new List<ITactic>());
        return _tacticsPerInstrument[instrument] as IReadOnlyList<ITactic>;
    }
}