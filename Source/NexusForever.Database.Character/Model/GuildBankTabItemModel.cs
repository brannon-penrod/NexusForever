namespace NexusForever.Database.Character.Model
{
    public class GuildBankTabItemModel
    {
        public ulong Id { get; set; }
        public byte TabIndex { get; set; }
        public uint SlotIndex { get; set; }
        public ulong ItemId { get; set; }
        public uint StackCount { get; set; }
        public uint Charges { get; set; }
        public float Durability { get; set; }
        public uint ExpirationTimeLeft { get; set; }

        public GuildBankTabModel GuildBankTab { get; set; }

    }
}
