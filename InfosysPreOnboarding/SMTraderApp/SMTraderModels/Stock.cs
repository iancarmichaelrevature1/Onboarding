using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTraderModels
{
    public class Stock
    {
        public int StockId { get; set; }
        public string? TickerSymbol { get; set; }
        public double PricePerShare { get; set; }
        public int QuantityOfShares { get; set; }
        public double MarketCap { get; set; }

        public Stock()
        {
        }

        public Stock(int stockId, string? tickerSymbol, double pricePerShare, int quantityOfShares, double marketCap)
        {
            this.StockId = stockId;
            this.TickerSymbol = tickerSymbol;
            this.PricePerShare = pricePerShare;
            this.QuantityOfShares = quantityOfShares;
            this.MarketCap = marketCap;
        }

    }
}