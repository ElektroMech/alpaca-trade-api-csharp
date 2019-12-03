using System;
using System.Collections.Generic;

namespace Alpaca.Markets
{
    /// <summary>
    /// Encapsulates historical trade information from Polygon REST API.
    /// </summary>
    public interface IHistoricalTrade
    {
        /// <summary>
        /// Gets condition 1 of this trade.
        /// </summary>
        Int32 Condition1 { get; }

        /// <summary>
        /// Gets condition 2 of this trade.
        /// </summary>
        Int32 Condition2 { get; }

        /// <summary>
        /// Gets condition 3 of this trade.
        /// </summary>
        Int32 Condition3 { get; }

        /// <summary>
        /// Gets condition 4 of this trade.
        /// </summary>
        Int32 Condition4 { get; }

        /// <summary>
        /// Gets trade source exchange.
        /// </summary>
        String Exchange { get; }

        /// <summary>
        /// Gets trade timestamp.
        /// </summary>
        Int64 TimeOffset  { get; }

        /// <summary>
        /// Gets trade price.
        /// </summary>
        Decimal Price { get; }

        /// <summary>
        /// Gets trade quantity.
        /// </summary>
        Int64 Size { get; }
    }
}
