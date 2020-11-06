using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaWorkshop.Infrastructure.Persistence.Migrations
{
    public partial class AuditableEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TodoLists",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TodoLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TodoLists",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "TodoLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TodoItems",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedUtc",
                table: "TodoItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "TodoItems",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedUtc",
                table: "TodoItems",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "TodoLists");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedUtc",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedUtc",
                table: "TodoItems");
        }
    }
}
