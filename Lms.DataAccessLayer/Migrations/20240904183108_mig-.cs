using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId1",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_AuthorId",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthors_AuthorId1",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6140), new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6142) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6144), new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6145) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6147), new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6147) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6149), new DateTime(2024, 9, 4, 18, 31, 7, 571, DateTimeKind.Utc).AddTicks(6149) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 9, 4, 18, 31, 7, 567, DateTimeKind.Utc).AddTicks(9850), new DateTime(2024, 9, 4, 18, 31, 7, 567, DateTimeKind.Utc).AddTicks(9852) });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                schema: "app",
                table: "BookAuthors",
                column: "AuthorId",
                principalSchema: "app",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                schema: "app",
                table: "BookAuthors",
                column: "BookId",
                principalSchema: "app",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                schema: "app",
                table: "BookAuthors");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId1",
                schema: "app",
                table: "BookAuthors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6089), new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6092) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6096), new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6096) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6098), new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6099) });

            migrationBuilder.UpdateData(
                schema: "library",
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6100), new DateTime(2024, 8, 29, 18, 10, 26, 389, DateTimeKind.Utc).AddTicks(6101) });

            migrationBuilder.UpdateData(
                schema: "account",
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 8, 29, 18, 10, 26, 380, DateTimeKind.Utc).AddTicks(8441), new DateTime(2024, 8, 29, 18, 10, 26, 380, DateTimeKind.Utc).AddTicks(8444) });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_AuthorId1",
                schema: "app",
                table: "BookAuthors",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId1",
                schema: "app",
                table: "BookAuthors",
                column: "AuthorId1",
                principalSchema: "app",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_AuthorId",
                schema: "app",
                table: "BookAuthors",
                column: "AuthorId",
                principalSchema: "app",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
