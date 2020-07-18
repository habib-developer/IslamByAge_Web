using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IslamByAge.Infrastructure.Data.Migrations
{
    public partial class trackableandtopiccategoryfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Topics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Topics",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Topics",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Categories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Categories_CategoryId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_CategoryId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Categories");
        }
    }
}
