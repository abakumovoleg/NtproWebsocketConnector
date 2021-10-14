using System.Collections.Generic;

namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class JsonPositionSnapshot
    {
        /// <summary>
        ///  Contains open positions info for each asset on each source, or aggregated open position for asset on all sources if JSON Asset Position->SourceId is not set.
        /// </summary>
        public JsonAssetPosition[] SourceAssetPositions { get; set; }
        /// <summary>
        /// Open position info for each source
        /// </summary>
        public KeyValuePair<long, JsonOpenPosition> SourcesOpenPositionsInfo { get; set; }
        /// <summary>
        ///  Aggregated by all sources open position info
        /// </summary>
        public JsonOpenPosition AggregatedOpenPositions { get; set; }
        /// <summary>
        /// Total PL
        /// </summary>
        public double Profit { get; set; }
    }
}