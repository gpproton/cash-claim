using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CashClaim.Service.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "audit_histories",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    row_id = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    table_name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    changed = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                    kind = table.Column<int>(type: "INTEGER", nullable: false),
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_audit_histories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    swift_code = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currency_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    symbol = table.Column<string>(type: "TEXT", maxLength: 1, nullable: true),
                    code = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currency_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "domain_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_domain_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "server",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    service_name = table.Column<string>(type: "TEXT", nullable: false),
                    admin_email = table.Column<string>(type: "TEXT", nullable: false),
                    maintenance_mode = table.Column<bool>(type: "INTEGER", nullable: false),
                    maintenance_text = table.Column<string>(type: "TEXT", nullable: false),
                    currency_id = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server", x => x.id);
                    table.ForeignKey(
                        name: "fk_server_currency_entity_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency_entity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    icon = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    notes = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    currency_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    category_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    cancelled_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    reviewed_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    confirmed_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    confirmed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    approved_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    approved_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    rejected_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    rejected_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_claims_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_claims_currency_entity_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency_entity",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    claim_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    short_name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    full_name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    admin_email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    manager_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    claim_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    path = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    extension = table.Column<string>(type: "TEXT", maxLength: 8, nullable: true),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    claim_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_files_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    notes = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    confirmed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                    table.ForeignKey(
                        name: "fk_payments_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    manager_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_teams_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    profile_image = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    permission = table.Column<int>(type: "INTEGER", nullable: false),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    company_managed_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    team_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    team_managed_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    currency_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_currency_entity_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currency_entity",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "transfer_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    company_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transfer_requests", x => x.id);
                    table.ForeignKey(
                        name: "fk_transfer_requests_companies_company_id",
                        column: x => x.company_id,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_transfer_requests_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_bank_account",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    full_name = table.Column<string>(type: "TEXT", nullable: false),
                    bank_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_bank_account", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_bank_account_banks_bank_id",
                        column: x => x.bank_id,
                        principalTable: "banks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_bank_account_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_notification",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    disabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    channels = table.Column<string>(type: "TEXT", nullable: false),
                    types = table.Column<string>(type: "TEXT", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_notification", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_notification_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    owner_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    dark_mode = table.Column<bool>(type: "INTEGER", nullable: false),
                    language = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    modified_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_setting", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_setting_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "banks",
                columns: new[] { "id", "active", "created_at", "deleted_at", "description", "modified_at", "name", "swift_code" },
                values: new object[,]
                {
                    { new Guid("2a6ec7f9-bbab-4027-bfb4-57411248bc3f"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "First Bank", "" },
                    { new Guid("4317e298-28b9-42a9-bc15-f56e89112098"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "United Bank for Africa", "" },
                    { new Guid("5187ce1a-f723-4706-816a-07281c3a1ae1"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Sterling Bank", "" },
                    { new Guid("5e3ba913-95f1-4731-8275-d408bebc188c"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "GT Bank", "" },
                    { new Guid("74873949-43b3-4672-92fb-79ddcd4e04c0"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Keystone Bank Limited", "" },
                    { new Guid("92c74b77-c2e8-466b-9e53-b80880eaee5e"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Fidelity Bank", "" },
                    { new Guid("933d6ee9-0dd8-4af8-9d95-432faf89062f"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Polaris Bank Limited", "" },
                    { new Guid("aa0c6017-6141-4fcb-a6ea-ccca2e956f97"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Wema Bank", "" },
                    { new Guid("bb9691cf-826e-40a3-9eb5-a30926f78206"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Zenith Bank", "" },
                    { new Guid("bd9da65e-0c81-48d9-8584-ed8a3329e5e5"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "First City Monument Bank", "" },
                    { new Guid("d04fb869-65f6-47dc-8210-0c7f729b6c2f"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Access Bank", "" },
                    { new Guid("d66a880d-e655-4c36-89d8-f77b21adb8ea"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Stanbic IBTC Bank", "" },
                    { new Guid("ebdd83be-f9ad-4534-b3c0-7e5a9bff69ef"), false, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Union Bank of Nigeria", "" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("316707ad-a0ba-4217-a416-fdbd15aee814"), false, null, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", "", null, "Internet Service" },
                    { new Guid("5821fcbc-43d4-4f23-953c-f6039775adc9"), false, null, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", "", null, "General Fuelling" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "active", "admin_email", "created_at", "deleted_at", "full_name", "manager_id", "modified_at", "short_name" },
                values: new object[,]
                {
                    { new Guid("251dc29e-1aa6-4a22-8192-b7c7cbbc1f13"), false, "", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "Multi Consumer Product LTD", null, null, "MCPL LTD" },
                    { new Guid("51664a2c-62ad-4d70-a750-aa89755559b6"), false, "", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "X-Claim Instance Management", null, null, "X-Claim" },
                    { new Guid("d933d322-3242-42d7-a7ff-8f7f71bee0e9"), false, "", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "MCPL LTD - BHN Division", null, null, "BHN Logistics" },
                    { new Guid("ff3d0844-bd7b-443d-aea8-ac9f7313aba5"), false, "", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "Dufil Prima Foods Plc", null, null, "Dufil Prima" }
                });

            migrationBuilder.InsertData(
                table: "currency_entity",
                columns: new[] { "id", "active", "code", "created_at", "deleted_at", "description", "modified_at", "name", "rate", "symbol" },
                values: new object[,]
                {
                    { new Guid("4fae4689-744e-4e08-b153-73440914ffc9"), false, "NGN", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Naira", 0m, "₦" },
                    { new Guid("54958782-52c1-4f9d-8ebc-91085cab25d7"), false, "EUR", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Euro", 0m, "€" },
                    { new Guid("556daac8-2b67-4d46-831e-9ff947c992ac"), false, "GBP", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "British Pounds", 0m, "£" },
                    { new Guid("8336192c-1344-45e3-b57a-3f97397b081c"), false, "USD", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "US Dollar", 0m, "$" },
                    { new Guid("8986d0a0-cc73-4c33-adb5-99ede75e953f"), false, "INR", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, "Rupee", 0m, "₹" }
                });

            migrationBuilder.InsertData(
                table: "domain_entity",
                columns: new[] { "id", "active", "address", "created_at", "deleted_at", "description", "modified_at" },
                values: new object[,]
                {
                    { new Guid("9d70235c-8bd9-4230-b8f0-404b51bc9b12"), false, "dufil.com", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null },
                    { new Guid("e29bfb61-1d30-4544-9fb9-5912fd9f2643"), false, "tolaram.com", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null },
                    { new Guid("e8bb9c25-c4d7-4143-89a8-ed6137b58e56"), false, "outlook.com", new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("7f16094d-2d82-4ae0-94f9-b5e1cb91baa1"), false, new Guid("d933d322-3242-42d7-a7ff-8f7f71bee0e9"), new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", "", null, "BHN - Weekly meeting expense" },
                    { new Guid("92cfead5-b3ae-4276-bf70-e501f4900dbc"), false, new Guid("251dc29e-1aa6-4a22-8192-b7c7cbbc1f13"), new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", "", null, "MCPL - Monthly training expense" }
                });

            migrationBuilder.InsertData(
                table: "server",
                columns: new[] { "id", "admin_email", "currency_id", "maintenance_mode", "maintenance_text", "service_name" },
                values: new object[] { new Guid("2bbaabd5-81fe-44da-8ae2-5ad8bdd2d1b9"), "admin@x-claim.dev", new Guid("4fae4689-744e-4e08-b153-73440914ffc9"), false, "In-Progress", "X-Claim" });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "manager_id", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("79a76b99-b6ee-40ca-9460-9bfd300c2382"), false, new Guid("251dc29e-1aa6-4a22-8192-b7c7cbbc1f13"), new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, null, "Logistics Dept" },
                    { new Guid("ec9dfa7e-c74d-43a3-a9c1-8b7a35f1a208"), false, new Guid("d933d322-3242-42d7-a7ff-8f7f71bee0e9"), new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, null, "Account Dept" },
                    { new Guid("f77e1091-2f09-4e52-ab0c-aa445ffd0ca0"), false, new Guid("ff3d0844-bd7b-443d-aea8-ac9f7313aba5"), new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, "", null, null, "Packaging Dept" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "active", "balance", "company_id", "company_managed_id", "created_at", "currency_id", "deleted_at", "email", "first_name", "identifier", "image", "last_name", "modified_at", "permission", "phone", "profile_image", "team_id", "team_managed_id", "token" },
                values: new object[,]
                {
                    { new Guid("b05485b8-c157-4c09-ba0a-68dfdfee4994"), false, 0m, new Guid("d933d322-3242-42d7-a7ff-8f7f71bee0e9"), null, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, null, "john.doe@tolaram.com", "John", "6ptaait2kucefobaou3mqaskzy", null, "Doe", null, 5, "+234012345567", null, new Guid("ec9dfa7e-c74d-43a3-a9c1-8b7a35f1a208"), null, null },
                    { new Guid("ce544f22-295d-4bd8-944a-69cb3ffcc200"), false, 0m, new Guid("251dc29e-1aa6-4a22-8192-b7c7cbbc1f13"), null, new DateTime(2024, 4, 2, 14, 21, 34, 650, DateTimeKind.Local).AddTicks(1241), null, null, "jane.doe@tolaram.com", "Jane", "kkywogut4ecurkkitaifp3u6ei", null, "Doe", null, 5, "+234022424553", null, new Guid("79a76b99-b6ee-40ca-9460-9bfd300c2382"), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_banks_deleted_at",
                table: "banks",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_banks_name",
                table: "banks",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_categories_company_id",
                table: "categories",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_deleted_at",
                table: "categories",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_claims_approved_by_id",
                table: "claims",
                column: "approved_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_category_id",
                table: "claims",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_company_id",
                table: "claims",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_confirmed_by_id",
                table: "claims",
                column: "confirmed_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_currency_id",
                table: "claims",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_deleted_at",
                table: "claims",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_claims_owner_id",
                table: "claims",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_payment_id",
                table: "claims",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_reviewed_by_id",
                table: "claims",
                column: "reviewed_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_claim_id",
                table: "comments",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_deleted_at",
                table: "comments",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_comments_owner_id",
                table: "comments",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_payment_id",
                table: "comments",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_deleted_at",
                table: "companies",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_companies_manager_id",
                table: "companies",
                column: "manager_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currency_entity_code",
                table: "currency_entity",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currency_entity_deleted_at",
                table: "currency_entity",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_currency_entity_name",
                table: "currency_entity",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_events_claim_id",
                table: "events",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_payment_id",
                table: "events",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_claim_id",
                table: "files",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_deleted_at",
                table: "files",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_files_owner_id",
                table: "files",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_payment_id",
                table: "files",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_company_id",
                table: "payments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_created_by_id",
                table: "payments",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_deleted_at",
                table: "payments",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_payments_owner_id",
                table: "payments",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_server_currency_id",
                table: "server",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_company_id",
                table: "teams",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_teams_deleted_at",
                table: "teams",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_teams_manager_id",
                table: "teams",
                column: "manager_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_transfer_requests_company_id",
                table: "transfer_requests",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_transfer_requests_deleted_at",
                table: "transfer_requests",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_transfer_requests_user_id",
                table: "transfer_requests",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_bank_account_bank_id",
                table: "user_bank_account",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_bank_account_deleted_at",
                table: "user_bank_account",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_bank_account_owner_id",
                table: "user_bank_account",
                column: "owner_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_notification_deleted_at",
                table: "user_notification",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_notification_owner_id",
                table: "user_notification",
                column: "owner_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_setting_deleted_at",
                table: "user_setting",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_setting_owner_id",
                table: "user_setting",
                column: "owner_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_company_id",
                table: "users",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_currency_id",
                table: "users",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_deleted_at",
                table: "users",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_identifier",
                table: "users",
                column: "identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_team_id",
                table: "users",
                column: "team_id");

            migrationBuilder.AddForeignKey(
                name: "fk_categories_companies_company_id",
                table: "categories",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_companies_company_id",
                table: "claims",
                column: "company_id",
                principalTable: "companies",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_payments_payment_id",
                table: "claims",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_users_approved_by_id",
                table: "claims",
                column: "approved_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_users_confirmed_by_id",
                table: "claims",
                column: "confirmed_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_users_owner_id",
                table: "claims",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_users_reviewed_by_id",
                table: "claims",
                column: "reviewed_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_payments_payment_id",
                table: "comments",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_owner_id",
                table: "comments",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_companies_users_manager_id",
                table: "companies",
                column: "manager_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "fk_events_payments_payment_id",
                table: "events",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_files_payments_payment_id",
                table: "files",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_files_users_owner_id",
                table: "files",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_users_created_by_id",
                table: "payments",
                column: "created_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_users_owner_id",
                table: "payments",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_teams_users_manager_id",
                table: "teams",
                column: "manager_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_teams_companies_company_id",
                table: "teams");

            migrationBuilder.DropForeignKey(
                name: "fk_users_companies_company_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_users_currency_entity_currency_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_users_manager_id",
                table: "teams");

            migrationBuilder.DropTable(
                name: "audit_histories");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "domain_entity");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "server");

            migrationBuilder.DropTable(
                name: "transfer_requests");

            migrationBuilder.DropTable(
                name: "user_bank_account");

            migrationBuilder.DropTable(
                name: "user_notification");

            migrationBuilder.DropTable(
                name: "user_setting");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "currency_entity");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
