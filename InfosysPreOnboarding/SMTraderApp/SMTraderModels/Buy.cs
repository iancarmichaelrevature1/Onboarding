using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTraderModels
{
    public class Buy
    {
        public int BuyId { get; set; }
        public int fk_StockId { get; set; }
        public string Symbol { get; set; }
        public double PricePerShare { get; set; }
        public int QuantityOfShares { get; set; }

        public Buy()
        {
        }

        public Buy(int buyId, int fk_StockId, string symbol, double pricePerShare, int quantityOfShares)
        {
            this.BuyId = buyId;
            this.fk_StockId = fk_StockId;
            this.Symbol = symbol;
            this.PricePerShare = pricePerShare;
            this.QuantityOfShares = quantityOfShares;
        }

    }
}