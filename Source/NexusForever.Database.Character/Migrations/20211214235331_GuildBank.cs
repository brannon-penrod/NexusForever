using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusForever.Database.Character.Migrations
{
    public partial class GuildBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guild_bank",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    influence = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    dailyInfluenceRemaining = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    money = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    warCoins = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK__guild_bank_id__guild_id",
                        column: x => x.id,
                        principalTable: "guild",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guild_bank_tab",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    index = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false, defaultValue: (byte)0),
                    name = table.Column<string>(type: "varchar(20)", nullable: true, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id, x.index });
                    table.ForeignKey(
                        name: "FK__guild_bank_tab_id__guild_bank_id",
                        column: x => x.id,
                        principalTable: "guild_bank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guild_bank_tab_item",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    tabIndex = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false, defaultValue: (byte)0),
                    slotIndex = table.Column<uint>(type: "int(10) unsigned", nullable: false, defaultValue: 0u),
                    itemGuid = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id, x.tabIndex });
                    table.ForeignKey(
                        name: "FK__guild_bank_tab_item_id_tab_index__guild_bank_tab_id",
                        columns: x => new { x.id, x.tabIndex },
                        principalTable: "guild_bank_tab",
                        principalColumns: new[] { "id", "index" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__guild_bank_tab_item_item_guid__item_id",
                        column: x => x.itemGuid,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "itemGuid",
                table: "guild_bank_tab_item",
                column: "itemGuid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guild_bank_tab_item");

            migrationBuilder.DropTable(
                name: "guild_bank_tab");

            migrationBuilder.DropTable(
                name: "guild_bank");
        }
    }
}
