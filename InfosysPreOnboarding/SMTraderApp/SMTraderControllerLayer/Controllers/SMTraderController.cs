
using SMTraderBusinessLayer;
using SMTraderModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMTraderControllerLayer.Controllers;

// 11/22/2022
// Made my SQLite database. I'm going to use it to store the data for the Stocks. 
// As per the assignment's suggestion, I am considering just having a *single* Stocks table with the following columns:
// 1. Stock Id (Primary Key) (INTEGER)
// 2. Stock Ticker Symbol (TEXT)
// 3. Price Per Share (REAL)
// 4. Number of Shares (INTEGER)
// 5. Market Cap (REAL)

// 11/21/2022
// I spent time shopping around for local DB options and settled on SQLite.
// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-5.0&tabs=visual-studio-code
// Resolved to install and learn to use SQLite in lieu of Azure SQL Server.

// 11/20/2022
// Trevin was SO right. PASSION is important. Boring projects are not the best way to learn and stay busy.
// In the thick of it now, I'm having to muster up the energy to do this project, and I'm not sure why.
// I think it's a mix of things: 
// 1. I was definitely not in the right headspace to be blind-sided by another revature training project.
//    I realize the goal wasn't for us to get stressed out like it was training all over again, but it feels like a solo P3.
//    I'm already stressed because I don't know where I'm going to LIVE in 2+ weeks, and because I'm not sure what I'm going to be doing once I get there!
// 2. Trevin didn't say it was mandatory. I'm too easy on myself and I definitely work better with a serious deadline.
//    While he did say it was a good idea to 'CYA' and do it, I still don't find that to be a good motivator. >>But that's on ME.<<
// 3. Azure SQL requires a subscription, and I don't have one. I was trained to use Azure SQL, 
//    but Revature was paying for the subscription then, and isn't any longer... Frustrating.
// 4. For the first time in my life, I had to hardcode data into my project. I don't like doing that. But it was 
//    the only way I could get the project to work. And it still doesn't work. At least for now.
// I know I could complete this project with an extension, but my batchmate told us on 11/19, he was charged more than $300
// for the Azure SQL subscription. Despite not using it! I'm about to move. I can't afford to forget and pay that kinda money.
// Going to look into other options.

// 11/18/2022
// Slow, steady progress. 
// I've followed my first route to the end of the line, and now I'm going to start working on the next route after I get back
// from my I-9 certification appointment.
// I'm hard coding some data for now until I set up a database (AZURE SQL is annoying to set up)

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
    public async Task<Buy?> RetrieveStockByTickerSymbolAsync(string tickerSymbol)
    {
        Buy? stock = await this._businessLayer.RetrieveStockByTickerSymbolAsync(tickerSymbol);
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