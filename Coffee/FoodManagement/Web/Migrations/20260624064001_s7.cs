using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("afa6c2fa-cd71-493a-a0ef-5a9216a40341"));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Order",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("e63be076-d089-447b-807e-efc803fb58cc"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9096));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9086));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 40, 0, 476, DateTimeKind.Local).AddTicks(9031));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("e63be076-d089-447b-807e-efc803fb58cc"));

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("afa6c2fa-cd71-493a-a0ef-5a9216a40341"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 308, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 307, DateTimeKind.Local).AddTicks(9965));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 308, DateTimeKind.Local).AddTicks(17));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 307, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 307, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 6, 24, 13, 28, 23, 307, DateTimeKind.Local).AddTicks(9910));
        }
    }
}
