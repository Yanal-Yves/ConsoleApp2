using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace ConsoleApp2.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildA",
                columns: table => new
                {
                    ChildAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildA", x => x.ChildAId);
                });
            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildAChildAId = table.Column<int>(nullable: true),
                    Data = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parent_ChildA_ChildAChildAId",
                        column: x => x.ChildAChildAId,
                        principalTable: "ChildA",
                        principalColumn: "ChildAId");
                });
            migrationBuilder.CreateTable(
                name: "ChildB",
                columns: table => new
                {
                    ChildBId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<string>(nullable: true),
                    ParentParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildB", x => x.ChildBId);
                    table.ForeignKey(
                        name: "FK_ChildB_Parent_ParentParentId",
                        column: x => x.ParentParentId,
                        principalTable: "Parent",
                        principalColumn: "ParentId");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ChildB");
            migrationBuilder.DropTable("Parent");
            migrationBuilder.DropTable("ChildA");
        }
    }
}
