namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class JsonOpenPosition
    {
        /// <summary>
        ///  Value of open position in principal main currency (usual USD) 
        /// </summary>
        public double? OpenPosition { get; set; }
        /// <summary>
        /// Percent of limit utilization
        /// </summary>
        public double? PercentLimitUsage { get; set; }
        /// <summary>
        /// Value of position limit
        /// </summary>
        public double? Limit { get; set; }
        /// <summary>
        /// Indicates whether limit checking is enabled
        /// </summary>
        public bool CheckLimit { get; set; }
    }
}