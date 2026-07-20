using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("c414ca00-bba2-473f-ac73-1d4102840ad8"));

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReplyMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplyOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsReplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("64c4cf9d-fe70-4459-aeef-bcffe913981a"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(4012));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(4001));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"),
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 10, 40, 17, 921, DateTimeKind.Local).AddTicks(3954));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("64c4cf9d-fe70-4459-aeef-bcffe913981a"));

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
        }
    }
}
