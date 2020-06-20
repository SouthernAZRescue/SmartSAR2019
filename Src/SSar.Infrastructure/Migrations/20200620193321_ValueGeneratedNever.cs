using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SSar.Infrastructure.Migrations
{
    public partial class ValueGeneratedNever : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("097553b3-aa2b-4a9a-92b4-bc40c645c1ab"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("54e2e99c-9fe0-4895-a787-586b50ab8582"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("685a7efb-c6d1-4578-97ca-c0fd09e0c44d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a114f89e-da47-48cf-ac95-f787cfa60867"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d462a06b-c0e3-4c1e-a9bf-32bc2178e737"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e57f9f62-b1b8-4ceb-b9d1-6eb28a2ee33a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("cf5ff70a-14aa-4f08-83e5-8e8dcb1aa1d3"), "new", "Super Admin", "SUPER ADMIN" },
                    { new Guid("e94d1c62-74e0-4230-86f2-e7c03101fd6d"), "new", "App Security Admin", "APP SECURITY ADMIN" },
                    { new Guid("dc4c6d5a-1b37-46ac-97c7-c587fccc49ee"), "new", "Member Data Admin", "MEMBER RECORDS ADMIN" },
                    { new Guid("088c868e-83d3-4007-b9fb-8da81b0de21e"), "new", "Organization Member", "ORGANIZATION MEMBER" },
                    { new Guid("2c7d47f0-9ae8-497a-8204-d8782d4602a2"), "new", "Affiliate User", "AFFILIATE USER" },
                    { new Guid("d2cb3c02-b028-4f3f-817c-2aa8561813c1"), "new", "Guest User", "GUEST USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("088c868e-83d3-4007-b9fb-8da81b0de21e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2c7d47f0-9ae8-497a-8204-d8782d4602a2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("cf5ff70a-14aa-4f08-83e5-8e8dcb1aa1d3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d2cb3c02-b028-4f3f-817c-2aa8561813c1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("dc4c6d5a-1b37-46ac-97c7-c587fccc49ee"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e94d1c62-74e0-4230-86f2-e7c03101fd6d"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("685a7efb-c6d1-4578-97ca-c0fd09e0c44d"), "new", "Super Admin", "SUPER ADMIN" },
                    { new Guid("a114f89e-da47-48cf-ac95-f787cfa60867"), "new", "App Security Admin", "APP SECURITY ADMIN" },
                    { new Guid("e57f9f62-b1b8-4ceb-b9d1-6eb28a2ee33a"), "new", "Member Data Admin", "MEMBER RECORDS ADMIN" },
                    { new Guid("d462a06b-c0e3-4c1e-a9bf-32bc2178e737"), "new", "Organization Member", "ORGANIZATION MEMBER" },
                    { new Guid("54e2e99c-9fe0-4895-a787-586b50ab8582"), "new", "Affiliate User", "AFFILIATE USER" },
                    { new Guid("097553b3-aa2b-4a9a-92b4-bc40c645c1ab"), "new", "Guest User", "GUEST USER" }
                });
        }
    }
}
