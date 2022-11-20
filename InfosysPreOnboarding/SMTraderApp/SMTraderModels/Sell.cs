using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTraderModels
{
    public class Sell
    {
        public int SellId { get; set; }
        public int fk_StockId { get; set; }
        public string Symbol { get; set; }
        public double PricePerShare { get; set; }
        public int QuantityOfShares { get; set; }

        public Sell()
        {
        }

        public Sell(int sellId, int fk_StockId, string symbol, double pricePerShare, int quantityOfShares)
        {
            this.SellId = sellId;
            this.fk_StockId = fk_StockId;
            this.Symbol = symbol;
            this.PricePerShare = pricePerShare;
            this.QuantityOfShares = quantityOfShares;
        }

    }
}