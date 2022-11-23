using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTraderModels
{
    public class SymbolDto
    {
        public string? TickerSymbol { get; set; }

        public SymbolDto()
        {
        }

        public SymbolDto(string? tickerSymbol)
        {
            this.TickerSymbol = tickerSymbol;
        }

    }
}
