﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Snap.Hutao.Migrations
{
    /// <inheritdoc />
    public partial class Inventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachedUid",
                table: "cultivate_projects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "inventory_items",
                columns: table => new
                {
                    InnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_items", x => x.InnerId);
                    table.ForeignKey(
                        name: "FK_inventory_items_cultivate_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "cultivate_projects",
                        principalColumn: "InnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory_reliquaries",
                columns: table => new
                {
                    InnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    MainPropId = table.Column<int>(type: "INTEGER", nullable: false),
                    AppendPropIdList = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_reliquaries", x => x.InnerId);
                    table.ForeignKey(
                        name: "FK_inventory_reliquaries_cultivate_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "cultivate_projects",
                        principalColumn: "InnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory_weapons",
                columns: table => new
                {
                    InnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    PromoteLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory_weapons", x => x.InnerId);
                    table.ForeignKey(
                        name: "FK_inventory_weapons_cultivate_projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "cultivate_projects",
                        principalColumn: "InnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inventory_items_ProjectId",
                table: "inventory_items",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_reliquaries_ProjectId",
                table: "inventory_reliquaries",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_weapons_ProjectId",
                table: "inventory_weapons",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_items");

            migrationBuilder.DropTable(
                name: "inventory_reliquaries");

            migrationBuilder.DropTable(
                name: "inventory_weapons");

            migrationBuilder.DropColumn(
                name: "AttachedUid",
                table: "cultivate_projects");
        }
    }
}
