using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexusForever.Database.Character.Migrations
{
    public partial class GuildBank_GuildActivePerk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "guild_active_perk",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    perkId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    endTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id, x.perkId });
                    table.ForeignKey(
                        name: "FK__guild_active_perk_id__guild_id",
                        column: x => x.id,
                        principalTable: "guild",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guild_bank",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    influence = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    dailyInfluenceRemaining = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    credits = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul)
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
                name: "guild_bank_item",
                columns: table => new
                {
                    id = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    bankTabIndex = table.Column<byte>(type: "tinyint(1) unsigned", nullable: false, defaultValue: (byte)0),
                    tabSlotIndex = table.Column<uint>(type: "int(10) unsigned", nullable: false, defaultValue: 0u),
                    itemId = table.Column<ulong>(type: "bigint(20) unsigned", nullable: false, defaultValue: 0ul),
                    stackCount = table.Column<uint>(type: "int(10) unsigned", nullable: false, defaultValue: 0u),
                    charges = table.Column<uint>(type: "int(10) unsigned", nullable: false, defaultValue: 0u),
                    durability = table.Column<float>(type: "float", nullable: false, defaultValue: 0f),
                    expirationTimeLeft = table.Column<uint>(type: "int(10) unsigned", nullable: false, defaultValue: 0u)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.id, x.bankTabIndex, x.tabSlotIndex });
                    table.ForeignKey(
                        name: "FK__guild_bank_tab_item_id_tab_index__guild_bank_tab_id",
                        columns: x => new { x.id, x.bankTabIndex },
                        principalTable: "guild_bank_tab",
                        principalColumns: new[] { "id", "index" },
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guild_active_perk");

            migrationBuilder.DropTable(
                name: "guild_bank_item");

            migrationBuilder.DropTable(
                name: "guild_bank_tab");

            migrationBuilder.DropTable(
                name: "guild_bank");
        }
    }
}
