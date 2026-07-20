using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("a5c5295c-312c-4c44-8135-5c0e9241702a"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("0b6ebcb3-e19d-424b-98e2-82cd18ce19c5"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9733));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9727));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9724));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9730));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 13, 14, 51, 7, 42, DateTimeKind.Local).AddTicks(9676));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("0b6ebcb3-e19d-424b-98e2-82cd18ce19c5"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Order");

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("a5c5295c-312c-4c44-8135-5c0e9241702a"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6294));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6307));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6224));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6299));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 12, 23, 4, 58, 285, DateTimeKind.Local).AddTicks(6147));
        }
    }
}
