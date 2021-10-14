using System;

namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class JsonAssetPosition
    {
        /// <summary>
        /// Asset
        /// </summary>
        public string Asset { get; set; }
        /// <summary>
        /// Value of open position
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// Value of open position in principal main currency (usual USD).
        /// </summary>
        public double AccountCurrencyAmount { get; set; }
 
        /// <summary>
        /// If empty then it’s total position across all sources.
        /// </summary>
        public long? SourceId { get; set; }

        public JsonDate Date { get; set; }
    }
}