using System.Collections.Generic;

namespace NexusForever.Database.Character.Model
{
    public class GuildBankTabModel
    {
        public ulong Id { get; set; }
        public byte Index { get; set; }
        public string Name { get; set; }

        public GuildBankModel GuildBank { get; set; }
        public ICollection<GuildBankTabItemModel> GuildBankTabItem { get; set; } = new HashSet<GuildBankTabItemModel>();
    }
}
