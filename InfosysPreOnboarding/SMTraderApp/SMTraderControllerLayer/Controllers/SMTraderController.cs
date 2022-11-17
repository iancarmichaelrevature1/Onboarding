
using BusinessLayer;
using Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMTraderControllerLayer.Controllers;

// 11/17/2022
// DISCLAIMER: This is part of the pre-planning / re-remembering phase. This is not a working example. It is a work in progress.
// I always start with the controller layer, because it is the most visible layer. It is the layer that is most likely to change.
// I havent even started Models yet. I will get to that next! (Most would argue an even better place to start off!)

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

    [HttpGet("RetrieveAllStocksAndDetails")]
    public List<Stock> RetrieveAllStocksAndDetails(StocksDto stocks)
    {
        return _businessLayer.RetrieveAllStocksAndDetails(stocks);
    }

/*

(10 points, SELECT SINGLE COMPANY)
As a user, I can select a SPECIFIC company **USING ITS STOCK TICKER SYMBOL** and see that stock’s market capitalization, price per stock, and quantity of stocks.
(Domain Knowledge: Market Capitalization is the total amount of money invested in that company’s stock. Market Cap = Price Per Stock * Quantity Of Stocks )

*/

    [HttpPost("RetrieveStockByTickerSymbol")]
    public Stock RetrieveStockByTickerSymbol(StockDto stock)
    {
        return _businessLayer.RetrieveStockByTickerSymbol(stock);
    }

/*

(10 points, SELECT COMPANY BASED ON A CRITERIA)
As a user, I can see a list of all companies whose stock market cap is above/below a specified number; I’m also able to see their ticker symbols and price per stock. You should be able to perform both the above AND below functionalities.

*/

    [HttpPost("RetrieveStocksByMarketCap")]
    public List<Stock> RetrieveStocksByMarketCap (MarCapDto marCap)
    {
        return _businessLayer.RetrieveStocksByMarketCap(marCap);
    }

/*

(10 points, UPDATE COMPANY & BUSINESS LOGIC)
As a user, I can purchase a number of stocks for a given price. Calculate the difference between the CURRENT price per stock and the buy price. Decrease that stock’s market cap and price per stock by the appropriate amount. THE QUANTITY OF STOCKS DOES NOT CHANGE.

*/

    [HttpPost("PurchaseStocks")]
    public Stock PurchaseStocks (PurchaseDto purchase)
    {
        return _businessLayer.PurchaseStocks(purchase);
    }

    [HttpPut("UpdateStocks")]
    public Stock UpdateStocks (StockDto stock)
    {
        return _businessLayer.UpdateStocks(stock);
    }

}