using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace No_Kill_Inventory.Migrations
{
    /// <inheritdoc />
    public partial class RecipientsPetsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95ac238e-fa26-47d8-aab2-4913b879b2fc", "AQAAAAIAAYagAAAAENPUUBgLR7r9MvsZIPz01Fio2bn9OhBh74FDgFuVVUEMpWHzRKXsqpssH1RsVlkC+A==", "8b5c7214-1454-4df1-8c83-a424f168dbcc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "deac9c1b-222c-499f-b02b-7d34179f98fb", "AQAAAAIAAYagAAAAEMJJ6YDFmNJh9bZsr0RNplTyng7lw3hpwVcrjo9MVVDSrJBPSuIZlDGgblHirQaEVQ==", "650d9a14-2b3f-4772-ae9f-3ee3eb0abb11" });
        }
    }
}
