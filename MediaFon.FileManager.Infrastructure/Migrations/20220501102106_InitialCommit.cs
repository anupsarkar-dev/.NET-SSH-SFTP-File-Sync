﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediaFon.FileManager.Infrastructure.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastAccessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWriteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWriteTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HasAccessPermission = table.Column<bool>(type: "boolean", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DirectoryName = table.Column<string>(type: "text", nullable: false),
                    DirectoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Extention = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    LastAccessTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWriteTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastAccessTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastWriteTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    HasAccessPermission = table.Column<bool>(type: "boolean", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true, defaultValueSql: "now()"),
                    CreatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Directories_DirectoryId",
                        column: x => x.DirectoryId,
                        principalTable: "Directories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_DirectoryId",
                table: "Files",
                column: "DirectoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Directories");
        }
    }
}
