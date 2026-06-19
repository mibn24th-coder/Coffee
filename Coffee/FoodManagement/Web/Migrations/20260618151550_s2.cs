using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web.Migrations
{
    /// <inheritdoc />
    public partial class s2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"), new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3765), null, null, "Root", null });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), "Quản trị viên" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"), new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3774), null, null, "Article", new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099") },
                    { new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"), new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3768), null, null, "Authorized", new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099") },
                    { new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"), new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3777), null, null, "Product", new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099") }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "GroupId", "LastLogin", "LoginName", "ModifiedBy", "ModifiedOn", "Name", "Password", "Picture" },
                values: new object[] { new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), null, new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3718), "mibn.24th@sv.dla.edu.vn", new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), null, "bui.mi", null, null, "Bùi Ngọc Thảo Mi", "c4ca4238a0b923820dcc509a6f75849b", "/img/users/thaomi.jpg" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "ParentId" },
                values: new object[] { new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"), new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"), new DateTime(2026, 6, 18, 22, 15, 49, 891, DateTimeKind.Local).AddTicks(3771), null, null, "Nhóm quyền", new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CategoryId", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574"), new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"), "view-groups", "Xem danh sách" },
                    { new Guid("ce1c61ac-219e-40d3-b780-9732052b4375"), new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"), "edit-group", "Cập nhật" }
                });

            migrationBuilder.InsertData(
                table: "Authorized",
                columns: new[] { "Id", "GroupId", "RoleId" },
                values: new object[] { new Guid("860ca080-aa8c-4a0f-9d90-0071068a54c5"), new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"), new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authorized",
                keyColumn: "Id",
                keyValue: new Guid("860ca080-aa8c-4a0f-9d90-0071068a54c5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("348b75cd-56a7-4094-97f1-284ab85c3ab9"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d4f86670-a689-4cc2-90df-0e89ba79276d"));

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "Id",
                keyValue: new Guid("98d64f50-d8ce-4c84-90cc-4131af413f2a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ce1c61ac-219e-40d3-b780-9732052b4375"));

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Id",
                keyValue: new Guid("eb6b4076-ae9a-4d83-9522-f71760bf27b4"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b643e139-b6bf-41d7-a251-ad3bd2ae5574"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fe7f810c-72b9-44cb-ab4b-3faf28cdc443"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4d84c1f5-3daa-439a-93cd-8b60dc29192d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("f3dadf45-7db1-4ec9-89bc-f29eed14d099"));
        }
    }
}
