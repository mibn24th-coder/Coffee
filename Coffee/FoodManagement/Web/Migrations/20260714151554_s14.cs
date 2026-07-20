using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("c7386e4d-1496-4e3c-a462-454a5e554762"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("ea5516da-ee93-4658-ac7a-f5b5f6372cb6"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(4996));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(4987));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 22, 15, 53, 83, DateTimeKind.Local).AddTicks(4917));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("ea5516da-ee93-4658-ac7a-f5b5f6372cb6"));

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("c7386e4d-1496-4e3c-a462-454a5e554762"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3792));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3737));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3730));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 21, 55, 54, 763, DateTimeKind.Local).AddTicks(3669));
        }
    }
}
