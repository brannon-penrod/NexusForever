using System;

namespace NexusForever.Database.Character.Model
{
    public class GuildActivePerkModel
    {
        public ulong Id { get; set; }
        public ulong PerkId { get; set; }
        public DateTime EndTime { get; set; }

        public GuildModel Guild { get; set; }
    }
}
