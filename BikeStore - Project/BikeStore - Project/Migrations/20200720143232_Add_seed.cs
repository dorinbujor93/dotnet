using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStore___Project.Migrations
{
    public partial class Add_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 1, (byte)6, 1, "Shimano", "Altus", 100 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 2, (byte)2, 2, "Kring", "Lighting", 10 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 3, (byte)1, 2, "Smith", "Ringer", 15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
