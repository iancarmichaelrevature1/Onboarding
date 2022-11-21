using SMTraderModels;
using SMTraderRepositoryLayer;

namespace SMTraderBusinessLayer;
public class BizLayer
{
    private readonly RepoLayer _repositoryLayer;
    public BizLayer()
    {
        this._repositoryLayer = new RepoLayer();
    }

    public async Task<List<Stock?>> RetrieveAllStocksAsync()
    { // this is throwing an error because of hardcoding the data in the repo layer
        List<Stock?> allStocks = await this._repositoryLayer.RetrieveAllStocksAsync();
        return allStocks;
    } // Blocker: I don't want to be charged for azure sql, but i need a database to store the data in.
    // I was trained to use Azure SQL but Revature was paying for the subscription, and isn't any longer...

    public async Task<Buy?> RetrieveStockByTickerSymbolAsync(string tickerSymbol)
    {
        Buy? buy = await this._repositoryLayer.RetrieveStockByTickerSymbolAsync(tickerSymbol);
        return buy;
    }

    public List<Stock?> RetrieveStocksByMarketCapAsync(MarCapDto marCap)
    {
        List<Stock?> allStocks = this._repositoryLayer.RetrieveAllStocksAsync();
        List<Stock?> stocksByMarketCap = new List<Stock?>();
        foreach (Stock? stock in allStocks)
        {
            if (stock.MarketCap >= marCap.MarketCap)
            {
                stocksByMarketCap.Add(stock);
            }
        }
        return stocksByMarketCap;
    }
}



