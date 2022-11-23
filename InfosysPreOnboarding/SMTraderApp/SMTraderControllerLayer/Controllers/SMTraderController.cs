
using SMTraderBusinessLayer;
using SMTraderModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMTraderControllerLayer.Controllers;

/*

(10 points, SELECT COMPANY)
As a user, I can see a list of all companies in the system, including their stock ticker symbols and price per stock.
(Domain Knowledge: A “ticker symbol” is a UNIQUE abbreviation of a stock, for example, Amazon stock’s ticker symbol is AMZN and Telsa stock’s ticker symbol is TSLA)

*/

[ApiController]
[Route("[controller]")]
public class SMTraderController : ControllerBase
{
    private readonly BizLayer _businessLayer;
    public SMTraderController()
    {
        this._businessLayer = new BizLayer();
    }

    [HttpGet("all-stocks")]
    public async Task<List<Stock?>> RetrieveAllStocksAsync()
    {
        List<Stock?> allStocks = await this._businessLayer.RetrieveAllStocksAsync();
        return allStocks;
    }
/*

(10 points, SELECT SINGLE COMPANY)
As a user, I can select a SPECIFIC company **USING ITS STOCK TICKER SYMBOL** and see that stock’s market capitalization, price per stock, and quantity of stocks.
(Domain Knowledge: Market Capitalization is the total amount of money invested in that company’s stock. Market Cap = Price Per Stock * Quantity Of Stocks )

*/

    [HttpPost("RetrieveStockByTickerSymbol")]
    public async Task<Buy?> RetrieveStockByTickerSymbolAsync(SymbolDto symbolDto)
    {
        Buy? stock = await this._businessLayer.RetrieveStockByTickerSymbolAsync(symbolDto);
        return stock;
    }

/*

(10 points, SELECT COMPANY BASED ON A CRITERIA)
As a user, I can see a list of all companies whose stock market cap is above/below a specified number; I’m also able to see their ticker symbols and price per stock. You should be able to perform both the above AND below functionalities.

*/

    [HttpPost("RetrieveStocksByMarketCap")]
    public List<Stock?> RetrieveStocksByMarketCapAsync (MarCapDto marCap)
    {
        List<Stock?> stocks = this._businessLayer.RetrieveStocksByMarketCapAsync(marCap);
        return stocks;
    }

/*

(10 points, UPDATE COMPANY & BUSINESS LOGIC)
As a user, I can purchase a number of stocks for a given price. Calculate the difference between the CURRENT price per stock and the buy price. Decrease that stock’s market cap and price per stock by the appropriate amount. THE QUANTITY OF STOCKS DOES NOT CHANGE.

*/ // YET TO BE IMPLEMENTED

//     [HttpPost("PurchaseStocks")]
//     public Stock PurchaseStocks (PurchaseDto purchase)
//     {
//         return _businessLayer.PurchaseStocks(purchase);
//     }

//     [HttpPut("UpdateStocks")]
//     public Stock UpdateStocks (StockDto stock)
//     {
//         return _businessLayer.UpdateStocks(stock);
//     }

// }