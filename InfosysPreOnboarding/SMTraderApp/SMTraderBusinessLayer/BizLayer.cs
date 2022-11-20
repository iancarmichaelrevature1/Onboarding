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
    {
        List<Stock?> allStocks = await this._repositoryLayer.RetrieveAllStocksAsync();
        return allStocks;
    }

    public async Task<Buy?> RetrieveStockByTickerSymbolAsync(string tickerSymbol)
    {
        Buy? buy = await this._repositoryLayer.RetrieveStockByTickerSymbolAsync(tickerSymbol);
        return buy;
    }

}



