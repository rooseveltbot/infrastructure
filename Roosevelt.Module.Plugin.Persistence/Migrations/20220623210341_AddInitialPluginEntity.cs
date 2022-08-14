using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Roosevelt.Module.Plugin.Persistence.Migrations
{
    public partial class AddInitialPluginEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "plugin");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plugin",
                schema: "plugin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Version = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plugin", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "plugin_developer",
                schema: "plugin",
                columns: table => new
                {
                    PluginId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plugin_developer", x => new { x.UserId, x.PluginId });
                    table.ForeignKey(
                        name: "FK_plugin_developer_plugin_PluginId",
                        column: x => x.PluginId,
                        principalSchema: "plugin",
                        principalTable: "plugin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_plugin_developer_PluginId",
                schema: "plugin",
                table: "plugin_developer",
                column: "PluginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plugin_developer",
                schema: "plugin");

            migrationBuilder.DropTable(
                name: "plugin",
                schema: "plugin");
        }
    }
}
