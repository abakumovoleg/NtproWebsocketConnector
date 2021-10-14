using System.Linq;

namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterSettingsUpdate
    {
        public QuoterSetting[] Data { get; set;  } = new QuoterSetting[0];
        public bool IsNextDataPending { get; set; }
        public long[] DeletedIds { get; set; }

        public override string ToString()
        {
            var data = string.Join(System.Environment.NewLine, Data.Select(x => x.ToString()));
            var deletedIds = string.Join(",", DeletedIds.Select(x => x.ToString()));

            return $"Data = {data}, IsNextDataPending = {IsNextDataPending}, DeletedIds = {deletedIds}";
        }
    }
}