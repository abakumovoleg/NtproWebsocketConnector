using System.Linq;

namespace Bcs.Connectors.NtPro.WebSocket.Messages
{
    public class QuoterGroupsUpdate
    {
        public QuoterGroup[] QuoterGroups { get; set; } = new QuoterGroup[0];

        public override string ToString()
        {
            return string.Join(System.Environment.NewLine, QuoterGroups.Select(x=>x.ToString()));
        }
    }
}