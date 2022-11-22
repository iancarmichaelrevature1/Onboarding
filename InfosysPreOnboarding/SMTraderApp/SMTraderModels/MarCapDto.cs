using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTraderModels
{
    public class MarCapDto
    {
        public double MarketCap { get; set; }

        public MarCapDto()
        {
        }

        public MarCapDto(double marketCap)
        {
            this.MarketCap = marketCap;
        }

    }
}