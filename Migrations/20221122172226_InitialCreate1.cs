using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstProject.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FuelInfo",
                columns: table => new
                {
                    FuelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    FuelPrice = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.FuelInfo", x => x.FuelId);
                });

            migrationBuilder.CreateTable(
                name: "PetrolStation",
                columns: table => new
                {
                    StationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    NumberOfPumps = table.Column<int>(maxLength: 4, nullable: false),
                    PumpActivation = table.Column<bool>(nullable: false),
                    FuelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.PetrolStation", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_PetrolStation_FuelInfo_FuelId",
                        column: x => x.FuelId,
                        principalTable: "FuelInfo",
                        principalColumn: "FuelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FuelInfo",
                columns: new[] { "FuelId", "FuelPrice", "Type" },
                values: new object[] { 1, 130m, "Diesel" });

            migrationBuilder.InsertData(
                table: "FuelInfo",
                columns: new[] { "FuelId", "FuelPrice", "Type" },
                values: new object[] { 2, 100m, "Petrol" });

            migrationBuilder.InsertData(
                table: "FuelInfo",
                columns: new[] { "FuelId", "FuelPrice", "Type" },
                values: new object[] { 3, 50m, "Electric" });

            migrationBuilder.InsertData(
                table: "PetrolStation",
                columns: new[] { "StationId", "Address", "FuelId", "NumberOfPumps", "PumpActivation", "StationName" },
                values: new object[,]
                {
                    { 1, "Street, City, Postcode", 1, 10, false, "StationOne" },
                    { 4, "Street, City, Postcode", 1, 10, false, "StationFour" },
                    { 2, "Street, City, Postcode", 2, 8, false, "StationTwo" },
                    { 5, "Street, City, Postcode", 2, 8, false, "StationFive" },
                    { 3, "Street, City, Postcode", 3, 10, false, "StationThree" },
                    { 6, "Street, City, Postcode", 3, 6, false, "StationSix" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetrolStation_FuelId",
                table: "PetrolStation",
                column: "FuelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetrolStation");

            migrationBuilder.DropTable(
                name: "FuelInfo");
        }
    }
}
