using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fuel_burning.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataGasFuelModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCalculation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GasFuelModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataGasFuelModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataLiquidFuelModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeCalculation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LiquidFuelModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLiquidFuelModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DataGasFuelModels",
                columns: new[] { "Id", "Description", "GasFuelModel", "IsActive", "Name", "TypeCalculation", "UserId" },
                values: new object[] { 3, "Пример", "{\"CO2\":0.3,\"CO\":0.0,\"H2\":0.0,\"CH4\":88.0,\"C2H6\":1.9,\"C3H8\":0.2,\"C4H10\":0.3,\"C5H12\":0.0,\"H2S\":0.0,\"N2\":9.3,\"H2O\":0.0,\"G\":5.0,\"Tг\":200.0,\"Tв\":200.0,\"Alfa\":1.1}", true, "Шаблонный вариант", "GasFuelBurning", 0 });

            migrationBuilder.InsertData(
                table: "DataLiquidFuelModels",
                columns: new[] { "Id", "Description", "IsActive", "LiquidFuelModel", "Name", "TypeCalculation", "UserId" },
                values: new object[] { 4, "Пример", true, "{\"C\":85.1,\"H\":9.9,\"S\":0.0,\"N\":0.5,\"O\":0.2,\"Wp\":3.9,\"Ap\":0.1,\"T_v\":280.0,\"T_t\":98.0,\"alfaG\":1.25,\"M_недожог\":4.0,\"gg\":13.0}", "Шаблонный вариант", "LiquidFuelBurning", 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "RoleId" },
                values: new object[] { 1, "admin", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataGasFuelModels");

            migrationBuilder.DropTable(
                name: "DataLiquidFuelModels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
