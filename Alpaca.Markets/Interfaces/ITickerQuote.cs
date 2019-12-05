using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITickerQuote
    {
        /// <summary>
        /// Gets bid price level.
        /// </summary>
        Decimal BidPrice { get; }

        /// <summary>
        /// Gets ask price level.
        /// </summary>
        Decimal AskPrice { get; }

        /// <summary>
        /// Gets bid quantity.
        /// </summary>
        Int64 BidSize { get; }

        /// <summary>
        /// Gets ask quantity.
        /// </summary>
        Int64 AskSize { get; }
    }
}
