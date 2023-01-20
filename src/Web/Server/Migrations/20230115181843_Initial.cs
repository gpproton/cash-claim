using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace XClaim.Web.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
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
                    symbol = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currency_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bank_accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "TEXT", nullable: false),
                    bankid = table.Column<Guid>(name: "bank_id", type: "TEXT", nullable: false),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
                    number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_bank_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_bank_accounts_banks_bank_id",
                        column: x => x.bankid,
                        principalTable: "banks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    icon = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
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
                    paymentid = table.Column<Guid>(name: "payment_id", type: "TEXT", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "TEXT", nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: false),
                    reviewedbyid = table.Column<Guid>(name: "reviewed_by_id", type: "TEXT", nullable: true),
                    reviewedat = table.Column<DateTime>(name: "reviewed_at", type: "TEXT", nullable: true),
                    confirmedbyid = table.Column<Guid>(name: "confirmed_by_id", type: "TEXT", nullable: true),
                    confirmedat = table.Column<DateTime>(name: "confirmed_at", type: "TEXT", nullable: true),
                    approvedbyid = table.Column<Guid>(name: "approved_by_id", type: "TEXT", nullable: true),
                    approvedat = table.Column<DateTime>(name: "approved_at", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_claims_categories_category_id",
                        column: x => x.categoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    claimid = table.Column<Guid>(name: "claim_id", type: "TEXT", nullable: true),
                    paymentid = table.Column<Guid>(name: "payment_id", type: "TEXT", nullable: true),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: false),
                    content = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_comments_claims_claim_id",
                        column: x => x.claimid,
                        principalTable: "claims",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    shortname = table.Column<string>(name: "short_name", type: "TEXT", maxLength: 64, nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "TEXT", maxLength: 128, nullable: false),
                    adminemail = table.Column<string>(name: "admin_email", type: "TEXT", maxLength: 256, nullable: false),
                    managerid = table.Column<Guid>(name: "manager_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "domain_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    companyentityid = table.Column<Guid>(name: "company_entity_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_domain_entity", x => x.id);
                    table.ForeignKey(
                        name: "fk_domain_entity_companies_company_entity_id",
                        column: x => x.companyentityid,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    claimid = table.Column<Guid>(name: "claim_id", type: "TEXT", nullable: true),
                    paymentid = table.Column<Guid>(name: "payment_id", type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_events", x => x.id);
                    table.ForeignKey(
                        name: "fk_events_claims_claim_id",
                        column: x => x.claimid,
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
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
                    claimentityid = table.Column<Guid>(name: "claim_entity_id", type: "TEXT", nullable: true),
                    paymententityid = table.Column<Guid>(name: "payment_entity_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_files", x => x.id);
                    table.ForeignKey(
                        name: "fk_files_claims_claim_entity_id",
                        column: x => x.claimentityid,
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
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: false),
                    completedat = table.Column<DateTime>(name: "completed_at", type: "TEXT", nullable: true),
                    completedbyid = table.Column<Guid>(name: "completed_by_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_payments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    managerid = table.Column<Guid>(name: "manager_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                    table.ForeignKey(
                        name: "fk_teams_companies_company_id",
                        column: x => x.companyid,
                        principalTable: "companies",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    profileimage = table.Column<string>(name: "profile_image", type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    username = table.Column<string>(name: "user_name", type: "TEXT", maxLength: 128, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "TEXT", maxLength: 128, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "TEXT", maxLength: 128, nullable: false),
                    balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    permission = table.Column<int>(type: "INTEGER", nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    companymanagedid = table.Column<Guid>(name: "company_managed_id", type: "TEXT", nullable: true),
                    managerid = table.Column<Guid>(name: "manager_id", type: "TEXT", nullable: true),
                    teamid = table.Column<Guid>(name: "team_id", type: "TEXT", nullable: true),
                    teammanagedid = table.Column<Guid>(name: "team_managed_id", type: "TEXT", nullable: true),
                    bankaccountid = table.Column<Guid>(name: "bank_account_id", type: "TEXT", nullable: true),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    token = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_companies_company_id",
                        column: x => x.companyid,
                        principalTable: "companies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_teams_team_id",
                        column: x => x.teamid,
                        principalTable: "teams",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_users_manager_id",
                        column: x => x.managerid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "banks",
                columns: new[] { "id", "active", "created_at", "deleted_at", "description", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("2416552e-495b-49de-8a2c-48aa7e55941a"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Zenith Bank" },
                    { new Guid("2b90a7c1-b184-4a81-90d5-064ac5ce04c7"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "GT Bank" },
                    { new Guid("3e54f0c5-70e2-4007-afad-2eece797bd1d"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "United Bank for Africa" },
                    { new Guid("3eaaa9ee-9370-42db-80b5-8b9506f6eb1b"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Polaris Bank Limited" },
                    { new Guid("60dc66e7-10ce-4313-993b-ea528ee3e6b7"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Access Bank" },
                    { new Guid("7b19efc3-7772-4e4c-84c3-b62888b69b2b"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Keystone Bank Limited" },
                    { new Guid("7bdace1e-f7e5-4c4f-b759-4a3dc02cb6c6"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Fidelity Bank" },
                    { new Guid("9591ce72-fa44-4337-a477-dd68e90d86a1"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Wema Bank" },
                    { new Guid("bc55b8e1-2c15-4844-aca8-198392129eea"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Sterling Bank" },
                    { new Guid("beac0a9e-9724-49ff-a75f-411247bf613b"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "First Bank" },
                    { new Guid("cb2af089-4476-4f99-b496-a9b5a09420f6"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "First City Monument Bank" },
                    { new Guid("fb1b15ca-481d-4409-aad1-2638e9d830bc"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Stanbic IBTC Bank" },
                    { new Guid("fd6dfacb-7c41-478f-a346-46142a5f1680"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Union Bank of Nigeria" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("186c18f4-e02c-48f8-b5c4-868fef9e0cf8"), false, null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", "", null, "General Fuelling" },
                    { new Guid("83ab2715-50ce-47d2-90bc-18c0a5581115"), false, null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", "", null, "Internet Service" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "admin_email", "created_at", "deleted_at", "full_name", "manager_id", "modified_at", "short_name" },
                values: new object[,]
                {
                    { new Guid("71927876-903a-4b7a-a5a6-a3bef7321ec3"), "", new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "Multi Consumer Product LTD", null, null, "MCPL LTD" },
                    { new Guid("94d47c0b-fdba-4806-9357-4a2934b05fbd"), "", new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "Dufil Prima Foods Plc", null, null, "Dufil" },
                    { new Guid("c42df454-1b41-470d-9ec8-11b9e4c9f5a4"), "", new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "MCPL LTD - BHN Division", null, null, "BHN LTD" }
                });

            migrationBuilder.InsertData(
                table: "currency_entity",
                columns: new[] { "id", "active", "created_at", "deleted_at", "description", "modified_at", "name", "symbol" },
                values: new object[,]
                {
                    { new Guid("6f514f6d-de6b-46a7-aabe-448a1d1682cb"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Dollar", "$" },
                    { new Guid("d7e33ed0-453d-45a8-aea0-fb989624869f"), false, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", null, "Naira", "₦" }
                });

            migrationBuilder.InsertData(
                table: "domain_entity",
                columns: new[] { "id", "address", "company_entity_id", "created_at", "deleted_at", "modified_at" },
                values: new object[,]
                {
                    { new Guid("3906d110-193c-4029-b1c8-7db06100e7dd"), "dufil.com", null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null },
                    { new Guid("61f19266-2b6f-4ab0-a080-c69637169cde"), "agboolas@outlook.com", null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null },
                    { new Guid("a4c3605d-cc20-4da5-8f8d-32ee6cea14ca"), "tolaram.com", null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("01069213-1141-4fdd-8618-4de210f95c80"), false, new Guid("71927876-903a-4b7a-a5a6-a3bef7321ec3"), new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", "", null, "MCPL - Monthly training expense" },
                    { new Guid("4cad163d-ec4c-468b-bb9b-7c894b8485d2"), false, new Guid("c42df454-1b41-470d-9ec8-11b9e4c9f5a4"), new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "", "", null, "BHN - Weekly meeting expense" }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "company_id", "created_at", "deleted_at", "manager_id", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("567851e6-955f-4f2a-928b-1db6d2b493ad"), new Guid("c42df454-1b41-470d-9ec8-11b9e4c9f5a4"), new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null, null, "Account Dept" },
                    { new Guid("acf60b30-6128-481c-a643-19bc2a2db6ad"), new Guid("94d47c0b-fdba-4806-9357-4a2934b05fbd"), new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null, null, "QA Dept" },
                    { new Guid("b13dd109-9d5a-416b-a3dc-ea7ce734969f"), new Guid("71927876-903a-4b7a-a5a6-a3bef7321ec3"), new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, null, null, "Logistics Dept" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "active", "balance", "bank_account_id", "company_id", "company_managed_id", "created_at", "deleted_at", "email", "first_name", "image", "last_name", "manager_id", "modified_at", "permission", "phone", "profile_image", "team_id", "team_managed_id", "token", "user_name" },
                values: new object[,]
                {
                    { new Guid("28bdb705-e568-49c7-8217-74d44b57461e"), false, 0m, null, new Guid("71927876-903a-4b7a-a5a6-a3bef7321ec3"), null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "jane.doe@test.com", "Jane", null, "Doe", null, null, 1, "+23402", null, new Guid("b13dd109-9d5a-416b-a3dc-ea7ce734969f"), null, null, "jane_doe" },
                    { new Guid("557afd14-d7c3-4015-a0b6-0a745df7e9cd"), false, 0m, null, new Guid("94d47c0b-fdba-4806-9357-4a2934b05fbd"), null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "johnny.test@test.com", "Johnny ", null, "Test", null, null, 1, "+23403", null, new Guid("acf60b30-6128-481c-a643-19bc2a2db6ad"), null, null, "johnny_test" },
                    { new Guid("64a4fd2d-f81a-4b91-ae8f-33e790d9f93a"), false, 0m, null, new Guid("c42df454-1b41-470d-9ec8-11b9e4c9f5a4"), null, new DateTime(2023, 1, 15, 19, 18, 43, 214, DateTimeKind.Local).AddTicks(7158), null, "john.doe@test.com", "John", null, "Doe", null, null, 4, "+23401", null, new Guid("567851e6-955f-4f2a-928b-1db6d2b493ad"), null, null, "john_doe" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_bank_accounts_bank_id",
                table: "bank_accounts",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "ix_bank_accounts_deleted_at",
                table: "bank_accounts",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_bank_accounts_owner_id",
                table: "bank_accounts",
                column: "owner_id",
                unique: true);

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
                name: "ix_currency_entity_name",
                table: "currency_entity",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_domain_entity_company_entity_id",
                table: "domain_entity",
                column: "company_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_domain_entity_deleted_at",
                table: "domain_entity",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_events_claim_id",
                table: "events",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_events_deleted_at",
                table: "events",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_events_payment_id",
                table: "events",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_claim_entity_id",
                table: "files",
                column: "claim_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_deleted_at",
                table: "files",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_files_owner_id",
                table: "files",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_files_payment_entity_id",
                table: "files",
                column: "payment_entity_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_completed_by_id",
                table: "payments",
                column: "completed_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_payments_deleted_at",
                table: "payments",
                column: "deleted_at");

            migrationBuilder.CreateIndex(
                name: "ix_payments_owner_id",
                table: "payments",
                column: "owner_id");

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
                name: "ix_users_company_id",
                table: "users",
                column: "company_id");

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
                name: "ix_users_manager_id",
                table: "users",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_phone",
                table: "users",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_team_id",
                table: "users",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_user_name",
                table: "users",
                column: "user_name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_bank_accounts_users_owner_id1",
                table: "bank_accounts",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

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
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_companies_users_manager_id",
                table: "companies",
                column: "manager_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_events_payments_payment_id",
                table: "events",
                column: "payment_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_files_payments_payment_entity_id",
                table: "files",
                column: "payment_entity_id",
                principalTable: "payments",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_files_users_owner_id",
                table: "files",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_users_completed_by_id",
                table: "payments",
                column: "completed_by_id",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_users_owner_id",
                table: "payments",
                column: "owner_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_teams_users_manager_id",
                table: "teams",
                column: "manager_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_companies_users_manager_id",
                table: "companies");

            migrationBuilder.DropForeignKey(
                name: "fk_teams_users_manager_id",
                table: "teams");

            migrationBuilder.DropTable(
                name: "bank_accounts");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "currency_entity");

            migrationBuilder.DropTable(
                name: "domain_entity");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "files");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
