using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISingleTicker
    {
        /// <summary>
        /// 
        /// </summary>
        String Symbol { get; }

        /// <summary>
        /// 
        /// </summary>
        ITickerLast LastTrade { get; }

        /// <summary>
        /// 
        /// </summary>
        IAgg Day { get; }

        /// <summary>
        /// 
        /// </summary>
        IAgg PrevDay { get; }

        /// <summary>
        /// 
        /// </summary>
        ITickerQuote LastQuote { get; }
    }
}
