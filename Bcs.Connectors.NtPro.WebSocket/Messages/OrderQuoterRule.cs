namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class OrderQuoterRule

    {
        public long Id { get; set; }
        public long OwnerFirmId { get; set; }
        public long InstrumentBasisId { get; set; }
        public long LoginId { get; set; }
        public long SourceId { get; set; }
        public long TargetSourceId { get; set; }
        public long Quantity { get; set; }
        public long DelayAfterFillInMicrosec { get; set; }
        public long DelayAfterRejectInMicrosec { get; set; }
        public double Commission { get; set; }
        public bool IsEnabled { get; set; }
        public long ServiceId { get; set; }
        public long ReplaceTimeoutInMicrosec { get; set; }
        public bool DisableOnFill { get; set; }
    }
}