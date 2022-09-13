using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductProject.API.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProductType = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Date", "Description", "ProductType", "State", "Value" },
                values: new object[] { 1, new DateTime(2022, 9, 7, 18, 39, 3, 672, DateTimeKind.Utc), "The one with that big park.", 0, 0, 100m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Date", "Description", "ProductType", "State", "Value" },
                values: new object[] { 2, new DateTime(2022, 9, 7, 18, 39, 3, 672, DateTimeKind.Utc), "The one with the cathedral that was never really finished.", 0, 0, 200m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Date", "Description", "ProductType", "State", "Value" },
                values: new object[] { 3, new DateTime(2022, 9, 7, 18, 39, 3, 672, DateTimeKind.Utc), "The one with that big tower.", 0, 0, 300m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
