using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITickerLast
    {
        /// <summary>
        /// Gets trade price level.
        /// </summary>
        Decimal Price { get; }

        /// <summary>
        /// Gets trade quantity.
        /// </summary>
        Int64 Size { get; }

        /// <summary>
        /// Gets trade conditions.
        /// </summary>
        IEnumerable<Int32> Conditions { get; }

        /// <summary>
        /// Gets trade timestamp.
        /// </summary>
        Int64 Time { get; }
    }
}
