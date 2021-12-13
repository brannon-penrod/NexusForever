namespace NexusForever.Database.Character.Model
{
    public class GuildBankTabItemModel
    {
        public ulong Id { get; set; }
        public byte TabIndex { get; set; }
        public ulong ItemGuid { get; set; }

        public GuildBankTabModel GuildBankTab { get; set; }
        public ItemModel Item { get; set; }
    }
}
