using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class update_resultJson_ableNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResultJSON",
                table: "SkinAnalysis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6634));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6653));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6654));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6674));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6675));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6676));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6678));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6744));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6751));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6756));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 29, 27, 819, DateTimeKind.Local).AddTicks(6760));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ResultJSON",
                table: "SkinAnalysis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9849));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9869));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9873));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9874));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9878));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9880));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9881));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9883));

            migrationBuilder.UpdateData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9886));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9955));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9962));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 8, 15, 24, 6, 571, DateTimeKind.Local).AddTicks(9970));
        }
    }
}
