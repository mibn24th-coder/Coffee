using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("ea5516da-ee93-4658-ac7a-f5b5f6372cb6"));


            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsPercent = table.Column<bool>(type: "bit", nullable: false),
                    MinOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("c414ca00-bba2-473f-ac73-1d4102840ad8"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9777));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9787));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9773));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9780));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 17, 11, 19, 42, 72, DateTimeKind.Local).AddTicks(9719));

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("c414ca00-bba2-473f-ac73-1d4102840ad8"));


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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
