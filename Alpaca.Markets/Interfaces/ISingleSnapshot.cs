using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISingleSnapshot
    {
        /// <summary>
        /// Gets resulting status of historical data request.
        /// </summary>
        String Status { get; }

        /// <summary>
        /// 
        /// </summary>
        ISingleTicker Ticker { get; }

        /// <summary>
        /// 
        /// </summary>
        Decimal TodaysChange { get; }

        /// <summary>
        /// 
        /// </summary>
        Decimal TodaysChangePerc { get; }

        /// <summary>
        /// 
        /// </summary>
        Int32 UpdatedAt { get; }
    }
}
