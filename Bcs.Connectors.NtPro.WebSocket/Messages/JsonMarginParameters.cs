namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class JsonMarginParameters
    {
        /// <summary>
        /// Balance in Principal main currency 
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// Profit in Principal main currency 
        /// </summary>
        public double Profit { get; set; }
        /// <summary>
        /// Initial margin in Principal main currency 
        /// </summary>
        public double InitialMargin { get; set; }
        /// <summary>
        /// Used margin in percent
        /// </summary>
        public double UsedMargin { get; set; }
    }
}