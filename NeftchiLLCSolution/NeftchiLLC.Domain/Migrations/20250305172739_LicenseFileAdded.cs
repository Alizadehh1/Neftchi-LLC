using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NeftchiLLC.Domain.Migrations
{
    /// <inheritdoc />
    public partial class LicenseFileAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Licenses",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Licenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Licenses",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Licenses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedAt",
                table: "Licenses",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Licenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LicenseFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    LicenseId = table.Column<int>(type: "int", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LicenseFiles_Licenses_LicenseId",
                        column: x => x.LicenseId,
                        principalTable: "Licenses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LicenseFiles_LicenseId",
                table: "LicenseFiles",
                column: "LicenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseFiles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "LastModifiedAt",
                table: "Licenses");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Licenses");
        }
    }
}
