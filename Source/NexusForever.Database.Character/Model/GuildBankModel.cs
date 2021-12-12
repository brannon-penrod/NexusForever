using System.Collections.Generic;

namespace NexusForever.Database.Character.Model
{
    public class GuildBankModel
    {
        public ulong Id { get; set; }
        public ulong Influence { get; set; }
        public ulong DailyInfluenceRemaining { get; set; }
        public ulong Credits { get; set; }

        public GuildModel Guild { get; set; }
        public ICollection<GuildBankTabModel> GuildBankTab { get; set; } = new HashSet<GuildBankTabModel>();
    }
}
