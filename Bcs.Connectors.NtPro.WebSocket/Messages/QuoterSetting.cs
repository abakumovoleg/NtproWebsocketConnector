namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterSetting
    {
        public long Id { get; set; }
        public QuoterGroup QuoterGroup { get; set; }
        public long InstrumentBasisId { get; set; }
        public long TagId { get; set; }
        public long SourceId { get; set; }
        public double Tolerance { get; set; }
        public double BidShift { get; set; }
        public double OfferShift { get; set; }
        public long? ShiftGroupId { get; set; }
        public double? PriceStep { get; set; }
        public bool? UseSourceSwapQuotes { get; set; }
        public SideMode SideMode { get; set; }
        public long Amount { get; set; }
        public QuoterMode QuoterMode { get; set; }
        public double? Commission { get; set; }
        public double? Spread { get; set; }
        public double? MinSpread { get; set; }
        public double? MaxSpread { get; set; }
        public bool IsEnabled { get; set; }


        public override string ToString()
        {
            return $"Id = {Id}, QuoterGroup = {QuoterGroup}, BidShift = {BidShift}, OfferShift = {OfferShift}";
        }

        public override bool Equals(object obj)
        {
            var other = obj as QuoterSetting;
            return other?.Id == Id;
        }

        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Id.GetHashCode();
        }
    }
}