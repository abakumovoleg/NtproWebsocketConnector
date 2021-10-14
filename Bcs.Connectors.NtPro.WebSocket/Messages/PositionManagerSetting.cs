namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class PositionManagerSetting
    {
        public long Id { get; set; }

        public PositionManagerGroup PositionManagerGroup { get; set; }
        public long AssetId { get; set; }
        public long InstrumentBasisId { get; set; }
        public long SourceId { get; set; }
        public double MaxOpenPosition { get; set; }
        public double CoverPart { get; set; }
        public double MinCoverAmount { get; set; }
        public double MaxCoverAmount { get; set; }
        public double CoverAmountStep { get; set; }
        public long OrderTimeout { get; set; }
        public long CoverInterval { get; set; }
        public bool CloseAllPositions { get; set; }
        public bool IsEnabled { get; set; }
    }
}