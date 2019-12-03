using System;
using System.Collections.Generic;

namespace Alpaca.Markets
{
    /// <summary>
    /// Encapsulates trade information from Polygon streaming API.
    /// </summary>
    public interface IStreamTrade
    {
        /// <summary>
        /// Gets asset name.
        /// </summary>
        String Symbol { get; }

        /// <summary>
        /// Gets asset's exchange identifier.
        /// </summary>
        Int64 Exchange { get; }

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
        DateTime Time { get; }
    }
}
