using System.Data.SqlClient;
using SMTraderModels;

namespace SMTraderRepositoryLayer;
public class RepoLayer
{
    public List<Stock?> RetrieveAllStocksAsync()
    {
        List<Stock?> allStocks = new List<Stock?>()
        { // hardcoding some data for now until i set up a database (AZURE SQL is annoying to set up)
            new Stock(1, "AMZN", 3_000.00, 1_000_000, 3_000_000_000.00),
            new Stock(2, "TSLA", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(3, "AAPL", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(4, "GOOG", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(5, "MSFT", 2_000.00, 2_000_000, 2_000_000_000.00),
            new Stock(6, "FB", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(7, "NFLX", 1_000.00, 1_000_000, 1_000_000_000.00),
            new Stock(8, "NVDA", 1_000.00, 1_000_000, 1_000_000_000.00),
        };

        return allStocks;

    }

    public async Task<Buy?> RetrieveStockByTickerSymbolAsync(string tickerSymbol)
    {
        SqlConnection connection = new SqlConnection("Server=tcp:smtrader.not.a.real.database.windows.net,1433;Initial Catalog=SMTrader;Persist Security Info=False;User ID=smtrader;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Stocks WHERE TickerSymbol = @TickerSymbol", connection))
        {
            cmd.Parameters.AddWithValue("@TickerSymbol", tickerSymbol);
            connection.Open();
            SqlDataReader? ret = await cmd.ExecuteReaderAsync();
            Buy? buy = new Buy();
            while (ret.Read())
            {
                return buy;
            }
        }
        return null;
    }

    public async List<Stock?> RetrieveStocksByMarketCapAsync(MarCapDto marCap)
    {
        SqlConnection connection = new SqlConnection("Server=tcp:smtrader.not.a.real.database.windows.net,1433;Initial Catalog=SMTrader;Persist Security Info=False;User ID=smtrader;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();
        SqlDataReader? ret = await cmd.ExecuteReaderAsync();
        List<Stock?> stocksByMarketCap = new List<Stock?>();

        while (ret.Read())
        {
            return stocksByMarketCap;
        }
        return null;
    }
}