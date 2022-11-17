using SMTraderModels;

namespace SMTraderRepositoryLayer;
public class RepoLayer
{
    public List<Stock?> RetrieveAllStocks()
    {
        List<Stock?> allStocks = new List<Stock?>()
        { // hardcoding some data for now until i set up a database (AZURE SQL is annoying to set up)
            new Stock(1, "AMZN", 3_000.00, 1_000_000, 3_000_000_000.00),
            new Stock(2, "TSLA", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(3, "AAPL", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(4, "GOOG", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(5, "MSFT", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(6, "FB", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(7, "NFLX", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(8, "NVDA", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(9, "PYPL", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(10, "TSM", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(11, "ADBE", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(12, "CRM", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(13, "INTC", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(14, "CSCO", 1_000.00, 1_000_000, 1_000_000_000.00),
        };

        return allStocks;

    }

}
