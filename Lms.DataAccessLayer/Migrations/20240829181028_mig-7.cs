using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lms.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Books_BookId",
                schema: "libraries",
                table: "UploadedFiles");


            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Books_BookId",
                schema: "libraries",
                table: "UploadedFiles",
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
                name: "FK_UploadedFiles_Books_BookId",
                schema: "libraries",
                table: "UploadedFiles");

           

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Books_BookId",
                schema: "libraries",
                table: "UploadedFiles",
                column: "BookId",
                principalSchema: "app",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
