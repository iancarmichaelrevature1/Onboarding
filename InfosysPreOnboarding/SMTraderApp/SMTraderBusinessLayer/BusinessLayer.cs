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

    public Task<List<Stock?>> RetrieveAllStocks()
    {
        List<Stock?> allStocks = this._repositoryLayer.RetrieveAllStocks();
        return allStocks;
    }
}


