﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Binner.Data.Migrations.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class PostMigrateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "StoredFiles",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "ProjectPcbAssignments",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "PartTypes",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "Parts",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<long>(
                name: "Ip",
                schema: "dbo",
                table: "OAuthRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "OAuthCredentials",
                type: "TEXT",
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddColumn<long>(
                name: "Ip",
                schema: "dbo",
                table: "OAuthCredentials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    DateLockedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    DateEmailConfirmedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsEmailSubscribed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    EmailConfirmationToken = table.Column<string>(type: "TEXT", nullable: true),
                    ProfileImage = table.Column<byte[]>(type: "BLOB", nullable: true),
                    DateLastLoginUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateLastActiveUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ReCaptchaScore = table.Column<double>(type: "REAL", nullable: true),
                    Ip = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L),
                    EmailConfirmedIp = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L),
                    LastSetPasswordIp = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserIntegrationConfigurations",
                schema: "dbo",
                columns: table => new
                {
                    UserIntegrationConfigurationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    SwarmEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    SwarmApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    SwarmApiUrl = table.Column<string>(type: "TEXT", nullable: true),
                    SwarmTimeout = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    DigiKeyEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    DigiKeyClientId = table.Column<string>(type: "TEXT", nullable: true),
                    DigiKeyClientSecret = table.Column<string>(type: "TEXT", nullable: true),
                    DigiKeyOAuthPostbackUrl = table.Column<string>(type: "TEXT", nullable: true),
                    DigiKeyApiUrl = table.Column<string>(type: "TEXT", nullable: true),
                    MouserEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    MouserSearchApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    MouserOrderApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    MouserCartApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    MouserApiUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ArrowEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    ArrowUsername = table.Column<string>(type: "TEXT", nullable: true),
                    ArrowApiKey = table.Column<string>(type: "TEXT", nullable: true),
                    ArrowApiUrl = table.Column<string>(type: "TEXT", nullable: false),
                    OctopartEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    OctopartClientId = table.Column<string>(type: "TEXT", nullable: true),
                    OctopartClientSecret = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserIntegrationConfigurations", x => x.UserIntegrationConfigurationId);
                    table.ForeignKey(
                        name: "FK_UserIntegrationConfigurations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginHistory",
                schema: "dbo",
                columns: table => new
                {
                    UserLoginHistoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: true),
                    IsSuccessful = table.Column<bool>(type: "INTEGER", nullable: false),
                    CanLogin = table.Column<bool>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    ReCaptchaScore = table.Column<double>(type: "REAL", nullable: true),
                    Ip = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginHistory", x => x.UserLoginHistoryId);
                    table.ForeignKey(
                        name: "FK_UserLoginHistory_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrinterConfigurations",
                schema: "dbo",
                columns: table => new
                {
                    UserPrinterConfigurationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    RemoteAddressUrl = table.Column<string>(type: "TEXT", nullable: true),
                    PrinterName = table.Column<string>(type: "TEXT", nullable: false),
                    PartLabelName = table.Column<string>(type: "TEXT", nullable: false),
                    PartLabelSource = table.Column<int>(type: "INTEGER", nullable: false),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrinterConfigurations", x => x.UserPrinterConfigurationId);
                    table.ForeignKey(
                        name: "FK_UserPrinterConfigurations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserTokenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    TokenTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    ReplacedByToken = table.Column<string>(type: "TEXT", nullable: true),
                    DateExpiredUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateRevokedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    Ip = table.Column<long>(type: "INTEGER", nullable: false, defaultValue: 0L),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserTokenId);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrinterTemplateConfigurations",
                schema: "dbo",
                columns: table => new
                {
                    UserPrinterTemplateConfigurationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserPrinterConfigurationId = table.Column<int>(type: "INTEGER", nullable: false),
                    Line = table.Column<int>(type: "INTEGER", nullable: false),
                    Label = table.Column<int>(type: "INTEGER", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    FontName = table.Column<string>(type: "TEXT", nullable: false),
                    AutoSize = table.Column<bool>(type: "INTEGER", nullable: false),
                    UpperCase = table.Column<bool>(type: "INTEGER", nullable: false),
                    LowerCase = table.Column<bool>(type: "INTEGER", nullable: false),
                    FontSize = table.Column<int>(type: "INTEGER", nullable: false),
                    Barcode = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rotate = table.Column<int>(type: "INTEGER", nullable: false),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    MarginTop = table.Column<int>(type: "INTEGER", nullable: false),
                    MarginBottom = table.Column<int>(type: "INTEGER", nullable: false),
                    MarginLeft = table.Column<int>(type: "INTEGER", nullable: false),
                    MarginRight = table.Column<int>(type: "INTEGER", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()"),
                    DateModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrinterTemplateConfigurations", x => x.UserPrinterTemplateConfigurationId);
                    table.ForeignKey(
                        name: "FK_UserPrinterTemplateConfigurations_UserPrinterConfigurations_UserPrinterConfigurationId",
                        column: x => x.UserPrinterConfigurationId,
                        principalSchema: "dbo",
                        principalTable: "UserPrinterConfigurations",
                        principalColumn: "UserPrinterConfigurationId");
                    table.ForeignKey(
                        name: "FK_UserPrinterTemplateConfigurations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoredFiles_UserId",
                schema: "dbo",
                table: "StoredFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                schema: "dbo",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPcbAssignments_UserId",
                schema: "dbo",
                table: "ProjectPcbAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPartAssignments_UserId",
                schema: "dbo",
                table: "ProjectPartAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PcbStoredFileAssignments_UserId",
                schema: "dbo",
                table: "PcbStoredFileAssignments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pcbs_UserId",
                schema: "dbo",
                table: "Pcbs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartTypes_UserId",
                schema: "dbo",
                table: "PartTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartSuppliers_UserId",
                schema: "dbo",
                table: "PartSuppliers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_UserId",
                schema: "dbo",
                table: "Parts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OAuthRequests_UserId",
                schema: "dbo",
                table: "OAuthRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OAuthCredentials_UserId",
                schema: "dbo",
                table: "OAuthCredentials",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserIntegrationConfigurations_UserId",
                schema: "dbo",
                table: "UserIntegrationConfigurations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginHistory_UserId",
                schema: "dbo",
                table: "UserLoginHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinterConfigurations_UserId",
                schema: "dbo",
                table: "UserPrinterConfigurations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinterTemplateConfigurations_UserId",
                schema: "dbo",
                table: "UserPrinterTemplateConfigurations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrinterTemplateConfigurations_UserPrinterConfigurationId",
                schema: "dbo",
                table: "UserPrinterTemplateConfigurations",
                column: "UserPrinterConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmailAddress",
                schema: "dbo",
                table: "Users",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                schema: "dbo",
                table: "Users",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "dbo",
                table: "Users",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                schema: "dbo",
                table: "UserTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OAuthCredentials_Users_UserId",
                schema: "dbo",
                table: "OAuthCredentials",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OAuthRequests_Users_UserId",
                schema: "dbo",
                table: "OAuthRequests",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Users_UserId",
                schema: "dbo",
                table: "Parts",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartSuppliers_Users_UserId",
                schema: "dbo",
                table: "PartSuppliers",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartTypes_Users_UserId",
                schema: "dbo",
                table: "PartTypes",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pcbs_Users_UserId",
                schema: "dbo",
                table: "Pcbs",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PcbStoredFileAssignments_Users_UserId",
                schema: "dbo",
                table: "PcbStoredFileAssignments",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPartAssignments_Users_UserId",
                schema: "dbo",
                table: "ProjectPartAssignments",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectPcbAssignments_Users_UserId",
                schema: "dbo",
                table: "ProjectPcbAssignments",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                schema: "dbo",
                table: "Projects",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StoredFiles_Users_UserId",
                schema: "dbo",
                table: "StoredFiles",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OAuthCredentials_Users_UserId",
                schema: "dbo",
                table: "OAuthCredentials");

            migrationBuilder.DropForeignKey(
                name: "FK_OAuthRequests_Users_UserId",
                schema: "dbo",
                table: "OAuthRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Users_UserId",
                schema: "dbo",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_PartSuppliers_Users_UserId",
                schema: "dbo",
                table: "PartSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_PartTypes_Users_UserId",
                schema: "dbo",
                table: "PartTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pcbs_Users_UserId",
                schema: "dbo",
                table: "Pcbs");

            migrationBuilder.DropForeignKey(
                name: "FK_PcbStoredFileAssignments_Users_UserId",
                schema: "dbo",
                table: "PcbStoredFileAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPartAssignments_Users_UserId",
                schema: "dbo",
                table: "ProjectPartAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectPcbAssignments_Users_UserId",
                schema: "dbo",
                table: "ProjectPcbAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                schema: "dbo",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_StoredFiles_Users_UserId",
                schema: "dbo",
                table: "StoredFiles");

            migrationBuilder.DropTable(
                name: "UserIntegrationConfigurations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLoginHistory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPrinterTemplateConfigurations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserPrinterConfigurations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_StoredFiles_UserId",
                schema: "dbo",
                table: "StoredFiles");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                schema: "dbo",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPcbAssignments_UserId",
                schema: "dbo",
                table: "ProjectPcbAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ProjectPartAssignments_UserId",
                schema: "dbo",
                table: "ProjectPartAssignments");

            migrationBuilder.DropIndex(
                name: "IX_PcbStoredFileAssignments_UserId",
                schema: "dbo",
                table: "PcbStoredFileAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Pcbs_UserId",
                schema: "dbo",
                table: "Pcbs");

            migrationBuilder.DropIndex(
                name: "IX_PartTypes_UserId",
                schema: "dbo",
                table: "PartTypes");

            migrationBuilder.DropIndex(
                name: "IX_PartSuppliers_UserId",
                schema: "dbo",
                table: "PartSuppliers");

            migrationBuilder.DropIndex(
                name: "IX_Parts_UserId",
                schema: "dbo",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_OAuthRequests_UserId",
                schema: "dbo",
                table: "OAuthRequests");

            migrationBuilder.DropIndex(
                name: "IX_OAuthCredentials_UserId",
                schema: "dbo",
                table: "OAuthCredentials");

            migrationBuilder.DropColumn(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "StoredFiles");

            migrationBuilder.DropColumn(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "ProjectPcbAssignments");

            migrationBuilder.DropColumn(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "PartTypes");

            migrationBuilder.DropColumn(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "Parts");

            migrationBuilder.DropColumn(
                name: "Ip",
                schema: "dbo",
                table: "OAuthRequests");

            migrationBuilder.DropColumn(
                name: "DateModifiedUtc",
                schema: "dbo",
                table: "OAuthCredentials");

            migrationBuilder.DropColumn(
                name: "Ip",
                schema: "dbo",
                table: "OAuthCredentials");
        }
    }
}
