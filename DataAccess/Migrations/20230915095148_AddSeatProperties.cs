using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Furniro.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeatProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeatProperties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesPackage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpholsteryMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpholsteryColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillingMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinishType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdjustableHeadrest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaximumLoadCapacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginofManufacture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeatHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LegHeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WarrantySummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarrantyServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoveredInWarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotCoveredInWarranty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DomesticWarranty = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatProperties_ProductId",
                table: "SeatProperties",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatProperties");
        }
    }
}
