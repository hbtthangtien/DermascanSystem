using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SkinZones",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1703), null, "Trán", null, null },
                    { 2L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1717), null, "Má trái", null, null },
                    { 3L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1719), null, "Má phải", null, null },
                    { 4L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1720), null, "Cằm", null, null },
                    { 5L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1721), null, "Mũi", null, null },
                    { 6L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1724), null, "Vùng mắt", null, null },
                    { 7L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1725), null, "Cổ", null, null },
                    { 8L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1726), null, "Xương hàm", null, null },
                    { 9L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1728), null, "Môi trên", null, null },
                    { 10L, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1730), null, "Toàn bộ mặt", null, null }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionPlans",
                columns: new[] { "Id", "BillingCycle", "CreatedAt", "DeletedAt", "Description", "FreeUsageLimitPerWeek", "GracePeriodDays", "Name", "Price", "ResultRetentionDays", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 0, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1784), null, "Dùng thử phân tích da mặt trong 3 ngày, không lưu trữ kết quả, có quảng cáo.", 1, 0, "Gói miễn phí", 0m, 0, null, null },
                    { 2L, 0, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1790), null, "Dùng thử 15 ngày, không lưu kết quả, có quảng cáo, kèm món quà nhỏ tri ân khách hàng.", 2, 0, "Gói cơ bản", 19000m, 0, null, null },
                    { 3L, 1, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1794), null, "Phân tích da mặt trong 1 tháng, có lưu kết quả, bỏ quảng cáo, giảm giá 10% cho khách hàng lần đầu.", 5, 3, "Gói Premium", 59000m, 30, null, null },
                    { 4L, 2, new DateTime(2025, 6, 4, 15, 11, 29, 45, DateTimeKind.Local).AddTicks(1796), null, "Phân tích da mặt trong 3 tháng, có lưu kết quả, nhắc nhở điểm danh, bỏ quảng cáo, giảm giá 15%, tặng quà (nước tẩy trang/sữa rửa mặt).", 7, 5, "Gói Pro", 299000m, 90, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "SkinZones",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "SubscriptionPlans",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
