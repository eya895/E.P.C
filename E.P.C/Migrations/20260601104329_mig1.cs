using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.P.C.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AIO_SupportedSockets",
                value: "LGA1200, LGA1150, LGA1151, LGA1155, LGA1156, LGA1366, LGA2011, LGA2066, AM4, AM5, AM3, AM2, sTR4, sTRX4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AIO_SupportedSockets",
                value: "LGA1700, LGA1200, LGA1150, LGA1151, LGA1155, LGA1156, LGA1366, LGA2011, LGA2011-3, LGA2066, LGA1851, AM4, AM5");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AIO_SupportedSockets",
                value: "LGA1851, LGA1700, LGA1200, LGA1156, LGA1155, LGA1151, LGA1150, LGA2066, LGA2011, AM5, AM4, AM3+, AM3, AM2+, AM2, FM2+, FM2, FM1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "SupportedSockets",
                value: "LGA1851, LGA1700, AM4, AM5");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "SupportedSockets",
                value: "sTR4, SP3, sTRX4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "SupportedSockets",
                value: "LGA1851, LGA1700, LGA1200, LGA1156, LGA1155, LGA1151, LGA1150, LGA2011, LGA2066, AM4, AM5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "AIO_SupportedSockets",
                value: "LGA1200, AM4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "AIO_SupportedSockets",
                value: "LGA1200, AM4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "AIO_SupportedSockets",
                value: "LGA1200, AM4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "SupportedSockets",
                value: "LGA1700, AM4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "SupportedSockets",
                value: "sTR4");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "SupportedSockets",
                value: "LGA1700, AM4/5");
        }
    }
}
