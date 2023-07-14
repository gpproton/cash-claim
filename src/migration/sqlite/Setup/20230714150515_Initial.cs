using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XClaim.Migrate.Sqlite.Setup
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true),
                    user_name = table.Column<string>(type: "TEXT", nullable: true),
                    normalized_user_name = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    normalized_email = table.Column<string>(type: "TEXT", nullable: true),
                    email_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    password_hash = table.Column<string>(type: "TEXT", nullable: true),
                    security_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number = table.Column<string>(type: "TEXT", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    lockout_end = table.Column<long>(type: "INTEGER", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    access_failed_count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "audit_logs",
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
                    table.PrimaryKey("pk_audit_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    swift_code = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_banks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    symbol = table.Column<string>(type: "TEXT", nullable: true),
                    code = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "server",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    service_name = table.Column<string>(type: "TEXT", nullable: true),
                    admin_email = table.Column<string>(type: "TEXT", nullable: true),
                    maintenance_active = table.Column<bool>(type: "INTEGER", nullable: false),
                    maintenance_text = table.Column<string>(type: "TEXT", nullable: true),
                    currency_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server", x => x.id);
                    table.ForeignKey(
                        name: "fk_server_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    icon = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                    currency_id = table.Column<int>(type: "INTEGER", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    category_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    cancelled_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    reviewed_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    reviewed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    confirmed_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    confirmed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    approved_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    approved_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    rejected_by_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    rejected_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                        name: "fk_claims_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    claim_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    content = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true)
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
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    short_name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    full_name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    admin_email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    manager_id = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    claim_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    payment_id = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    confirmed_at = table.Column<DateTime>(type: "TEXT", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    manager_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    company_managed_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    team_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    team_managed_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    currency_id = table.Column<int>(type: "INTEGER", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                        name: "fk_users_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
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
                    company_id = table.Column<int>(type: "INTEGER", nullable: true),
                    completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
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
                        name: "fk_user_bank_account_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_notifications",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    disabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    channels = table.Column<string>(type: "TEXT", nullable: true),
                    types = table.Column<string>(type: "TEXT", nullable: true),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_notifications", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_notifications_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: true),
                    dark_mode = table.Column<bool>(type: "INTEGER", nullable: false),
                    language = table.Column<int>(type: "INTEGER", nullable: false),
                    created_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    created_at = table.Column<long>(type: "INTEGER", nullable: false),
                    updated_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    updated_at = table.Column<long>(type: "INTEGER", nullable: true),
                    deleted_by = table.Column<Guid>(type: "TEXT", nullable: false),
                    deleted_at = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_setting", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_setting_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_accounts_deleted_at",
                table: "accounts",
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
                name: "ix_claims_payment_id",
                table: "claims",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_reviewed_by_id",
                table: "claims",
                column: "reviewed_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_claims_user_id",
                table: "claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_claim_id",
                table: "comments",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_payment_id",
                table: "comments",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_companies_manager_id",
                table: "companies",
                column: "manager_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currencies_code",
                table: "currencies",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_currencies_name",
                table: "currencies",
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
                name: "ix_files_payment_id",
                table: "files",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_user_id",
                table: "files",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_company_id",
                table: "payments",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_deleted_at",
                table: "payments",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_payments_user_id",
                table: "payments",
                column: "user_id");

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
                name: "ix_user_bank_account_user_id",
                table: "user_bank_account",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_notifications_deleted_at",
                table: "user_notifications",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_notifications_user_id",
                table: "user_notifications",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_setting_deleted_at",
                table: "user_setting",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_user_setting_user_id",
                table: "user_setting",
                column: "user_id",
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
                name: "fk_claims_users_reviewed_by_id",
                table: "claims",
                column: "reviewed_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_claims_users_user_id",
                table: "claims",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_payments_payment_id",
                table: "comments",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_user_id",
                table: "comments",
                column: "user_id",
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
                name: "fk_files_users_user_id",
                table: "files",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_users_user_id",
                table: "payments",
                column: "user_id",
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
                name: "fk_users_currencies_currency_id",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_users_manager_id",
                table: "teams");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "audit_logs");

            migrationBuilder.DropTable(
                name: "comments");

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
                name: "user_notifications");

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
                name: "currencies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
