using System.Data.SqlClient;
using System.Data.SQLite; // https://www.codeguru.com/dotnet/using-sqlite-in-a-c-application/
using Microsoft.Data.Sqlite; // https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/?tabs=netcore-cli
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

    public Stock? RetrieveStockByTickerSymbolAsync(SymbolDto symbolDto)
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=C:\Users\ianta\Desktop\Onboarding\Onboarding\InfosysPreOnboarding\SMTraderApp\Database\SMTraderDb;");
        using SQLiteCommand command = new SQLiteCommand("SELECT * FROM Stock WHERE TickerSymbol = @TickerSymbol", connection);
        {
            command.Parameters.AddWithValue("@TickerSymbol", symbolDto.TickerSymbol);
            connection.Open();
            using SQLiteDataReader reader = command.ExecuteReader();
            {
                if (reader.Read()) 
                {
                    return new Stock(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDouble(2),
                        reader.GetInt32(3),
                        reader.GetDouble(4)
                    );
                }
            }   
        }
}

    private async List<Stock?> RetrieveStocksByMarketCapAsync(MarCapDto marCap)
    {
        SQLiteConnection connection = new SQLiteConnection("Data Source=C:\Users\ianta\Desktop\Onboarding\Onboarding\InfosysPreOnboarding\SMTraderApp\Database\SMTraderDb;");
        using SQLiteCommand command = new SQLiteCommand("SELECT * FROM Stock WHERE MarketCap >= @MarketCap", connection);
        {
            command.Parameters.AddWithValue("@MarketCap", marCap.MarketCap);
            connection.Open();
            SqliteDataReader? ret = (SqliteDataReader?)await command.ExecuteReaderAsync();
            List<Stock?> stocksByMarketCap = new List<Stock?>();
            while (ret.Read())
            {
                stocksByMarketCap.Add(new Stock(
                    ret.GetInt32(0),
                    ret.GetString(1),
                    ret.GetDouble(2),
                    ret.GetInt32(3),
                    ret.GetDouble(4)
                ));
            }
            return stocksByMarketCap;
        }
    }
}