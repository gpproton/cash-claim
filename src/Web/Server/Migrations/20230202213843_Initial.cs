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
                    swiftcode = table.Column<string>(name: "swift_code", type: "TEXT", nullable: false),
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
                    symbol = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    code = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    rate = table.Column<decimal>(type: "TEXT", nullable: false),
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
                name: "domain_entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    address = table.Column<string>(type: "TEXT", nullable: false),
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
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
                    servicename = table.Column<string>(name: "service_name", type: "TEXT", nullable: false),
                    adminemail = table.Column<string>(name: "admin_email", type: "TEXT", nullable: false),
                    maintenancemode = table.Column<bool>(name: "maintenance_mode", type: "INTEGER", nullable: false),
                    maintenancetext = table.Column<string>(name: "maintenance_text", type: "TEXT", nullable: false),
                    currencyid = table.Column<Guid>(name: "currency_id", type: "TEXT", nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_server", x => x.id);
                    table.ForeignKey(
                        name: "fk_server_currency_entity_currency_id",
                        column: x => x.currencyid,
                        principalTable: "currency_entity",
                        principalColumn: "id");
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
                    priority = table.Column<int>(type: "INTEGER", nullable: false),
                    paymentid = table.Column<Guid>(name: "payment_id", type: "TEXT", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "TEXT", nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
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
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
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
                    confirmedat = table.Column<DateTime>(name: "confirmed_at", type: "TEXT", nullable: true),
                    confirmedbyid = table.Column<Guid>(name: "confirmed_by_id", type: "TEXT", nullable: true),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
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
                    active = table.Column<bool>(type: "INTEGER", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
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
                    identifier = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    profileimage = table.Column<string>(name: "profile_image", type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "TEXT", maxLength: 128, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "TEXT", maxLength: 128, nullable: false),
                    balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    permission = table.Column<int>(type: "INTEGER", nullable: false),
                    companyid = table.Column<Guid>(name: "company_id", type: "TEXT", nullable: true),
                    companymanagedid = table.Column<Guid>(name: "company_managed_id", type: "TEXT", nullable: true),
                    teamid = table.Column<Guid>(name: "team_id", type: "TEXT", nullable: true),
                    teammanagedid = table.Column<Guid>(name: "team_managed_id", type: "TEXT", nullable: true),
                    currencyid = table.Column<Guid>(name: "currency_id", type: "TEXT", nullable: true),
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
                        name: "fk_users_currency_entity_currency_id",
                        column: x => x.currencyid,
                        principalTable: "currency_entity",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_users_teams_team_id",
                        column: x => x.teamid,
                        principalTable: "teams",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_bank_account",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    fullname = table.Column<string>(name: "full_name", type: "TEXT", nullable: false),
                    bankid = table.Column<Guid>(name: "bank_id", type: "TEXT", nullable: true),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
                    number = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_bank_account", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_bank_account_banks_bank_id",
                        column: x => x.bankid,
                        principalTable: "banks",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_user_bank_account_users_owner_id",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_notification",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
                    disabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    channels = table.Column<string>(type: "TEXT", nullable: false),
                    types = table.Column<string>(type: "TEXT", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_notification", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_notification_users_owner_id",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "user_setting",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ownerid = table.Column<Guid>(name: "owner_id", type: "TEXT", nullable: true),
                    darkmode = table.Column<bool>(name: "dark_mode", type: "INTEGER", nullable: false),
                    language = table.Column<int>(type: "INTEGER", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "TEXT", nullable: false),
                    modifiedat = table.Column<DateTime>(name: "modified_at", type: "TEXT", nullable: true),
                    deletedat = table.Column<DateTime>(name: "deleted_at", type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_setting", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_setting_users_owner_id",
                        column: x => x.ownerid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "banks",
                columns: new[] { "id", "active", "created_at", "deleted_at", "description", "modified_at", "name", "swift_code" },
                values: new object[,]
                {
                    { new Guid("01cb6bc8-b3a7-4a9f-8c25-37885fbd1ada"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Polaris Bank Limited", "" },
                    { new Guid("1771e448-891d-43c4-a0aa-3784803e9af1"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Zenith Bank", "" },
                    { new Guid("195fc39b-4791-41b7-9d9e-d9c31dcbe884"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "First City Monument Bank", "" },
                    { new Guid("2e6fa8fd-49ca-450d-a85d-54df1055816e"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Keystone Bank Limited", "" },
                    { new Guid("3ce65741-39ef-4ca8-bc85-4afee4800a07"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Access Bank", "" },
                    { new Guid("4a12f06b-352d-4786-899f-52ea979cc65c"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Fidelity Bank", "" },
                    { new Guid("8b98faad-c950-4adc-ac13-4577c3e7d616"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "United Bank for Africa", "" },
                    { new Guid("8f2fdbbc-c992-4f57-86bf-167633c491fb"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Wema Bank", "" },
                    { new Guid("ac444cc9-93c2-4b90-b7a4-cb759fe9bb1a"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Sterling Bank", "" },
                    { new Guid("bcb4a992-7936-4126-9bba-602b0f0f979f"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Stanbic IBTC Bank", "" },
                    { new Guid("dbb5aa84-e727-4b03-b18f-80315d2a18b4"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "First Bank", "" },
                    { new Guid("dcb125d2-1d42-4b01-bc2c-a7863e708a47"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "GT Bank", "" },
                    { new Guid("de625d37-6628-47d3-8656-6d457ca1b151"), false, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Union Bank of Nigeria", "" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("8286de04-35da-48fa-9fd3-9a90910c54aa"), false, null, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", "", null, "Internet Service" },
                    { new Guid("8db67707-4665-43b0-b26f-cfca391aa4b0"), false, null, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", "", null, "General Fuelling" }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "id", "active", "admin_email", "created_at", "deleted_at", "full_name", "manager_id", "modified_at", "short_name" },
                values: new object[,]
                {
                    { new Guid("15539941-c7e7-45d4-b86e-05b5991f6215"), false, "", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "Multi Consumer Product LTD", null, null, "MCPL LTD" },
                    { new Guid("3de60ed7-4c83-43d9-ac34-21c18e849b8f"), false, "", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "MCPL LTD - BHN Division", null, null, "BHN Logistics" },
                    { new Guid("84cccd2f-2369-4337-bb89-7495146d8411"), false, "", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "X-Claim Instance Management", null, null, "X-Claim" },
                    { new Guid("9f4598fe-bd5d-4e3b-8588-d293df693ba9"), false, "", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "Dufil Prima Foods Plc", null, null, "Dufil Prima" }
                });

            migrationBuilder.InsertData(
                table: "currency_entity",
                columns: new[] { "id", "active", "code", "created_at", "deleted_at", "description", "modified_at", "name", "rate", "symbol" },
                values: new object[,]
                {
                    { new Guid("4b2bb3b9-2e37-4942-a499-2c852e5db1c7"), false, "USD", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "US Dollar", 0m, "$" },
                    { new Guid("62184e4d-9397-459c-9623-1bb02a44419b"), false, "NGN", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Naira", 0m, "₦" },
                    { new Guid("85ad4afd-5c60-44ae-b809-170fdaac6b09"), false, "INR", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Rupee", 0m, "₹" },
                    { new Guid("88dddfe8-d318-4868-9bf5-8f267376e3a9"), false, "EUR", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "Euro", 0m, "€" },
                    { new Guid("a9161b94-6223-4929-b4ef-bbcd82ba6719"), false, "GBP", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, "British Pounds", 0m, "£" }
                });

            migrationBuilder.InsertData(
                table: "domain_entity",
                columns: new[] { "id", "active", "address", "created_at", "deleted_at", "description", "modified_at" },
                values: new object[,]
                {
                    { new Guid("320655ca-4002-4539-8eab-3ee2dcac1804"), false, "dufil.com", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null },
                    { new Guid("989e690e-7895-4dbf-93c6-fbb2cca3e632"), false, "outlook.com", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null },
                    { new Guid("e3bfd149-0a86-43f4-9021-81a3d6fea9a2"), false, "tolaram.com", new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "icon", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("4197d752-02d5-450a-9d3c-6fa44489d97d"), false, new Guid("3de60ed7-4c83-43d9-ac34-21c18e849b8f"), new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", "", null, "BHN - Weekly meeting expense" },
                    { new Guid("64c7b903-12e5-4168-96fd-026a1a67f73f"), false, new Guid("15539941-c7e7-45d4-b86e-05b5991f6215"), new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", "", null, "MCPL - Monthly training expense" }
                });

            migrationBuilder.InsertData(
                table: "server",
                columns: new[] { "id", "admin_email", "created_at", "currency_id", "deleted_at", "maintenance_mode", "maintenance_text", "modified_at", "service_name" },
                values: new object[] { new Guid("ca00807b-625a-48e4-9269-3cbbd890226d"), "admin@x-claim.dev", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("62184e4d-9397-459c-9623-1bb02a44419b"), null, false, "In-Progress", null, "X-Claim" });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "active", "company_id", "created_at", "deleted_at", "description", "manager_id", "modified_at", "name" },
                values: new object[,]
                {
                    { new Guid("0a063653-f0f0-468f-aec8-85bdcfd22c21"), false, new Guid("3de60ed7-4c83-43d9-ac34-21c18e849b8f"), new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, null, "Account Dept" },
                    { new Guid("47720f67-9f3d-4cce-b34c-8dc6aa26ddc6"), false, new Guid("15539941-c7e7-45d4-b86e-05b5991f6215"), new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, null, "Logistics Dept" },
                    { new Guid("8f08bd2f-148b-410a-8a15-1c826c5a7ede"), false, new Guid("9f4598fe-bd5d-4e3b-8588-d293df693ba9"), new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, "", null, null, "Packaging Dept" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "active", "balance", "company_id", "company_managed_id", "created_at", "currency_id", "deleted_at", "email", "first_name", "identifier", "image", "last_name", "modified_at", "permission", "phone", "profile_image", "team_id", "team_managed_id", "token" },
                values: new object[,]
                {
                    { new Guid("88e90686-fc3e-4063-819c-1cd585dd49a3"), false, 0m, new Guid("3de60ed7-4c83-43d9-ac34-21c18e849b8f"), null, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, null, "john.doe@tolaram.com", "John", "rtebe6r6mhpubcu7iitygg7woa", null, "Doe", null, 5, "+234012345567", null, new Guid("0a063653-f0f0-468f-aec8-85bdcfd22c21"), null, null },
                    { new Guid("cc8e58ef-9920-4090-a972-a027ed3f48e2"), false, 0m, new Guid("15539941-c7e7-45d4-b86e-05b5991f6215"), null, new DateTime(2023, 2, 2, 22, 38, 43, 510, DateTimeKind.Local).AddTicks(5798), null, null, "jane.doe@tolaram.com", "Jane", "syrbh5p7fuxuljf66irs5bhahi", null, "Doe", null, 5, "+234022424553", null, new Guid("47720f67-9f3d-4cce-b34c-8dc6aa26ddc6"), null, null }
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
                name: "ix_payments_confirmed_by_id",
                table: "payments",
                column: "confirmed_by_id");

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
                name: "ix_server_deleted_at",
                table: "server",
                column: "deleted_at");

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
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_payments_users_confirmed_by_id",
                table: "payments",
                column: "confirmed_by_id",
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
                name: "fk_teams_users_manager_id",
                table: "teams");

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
                name: "users");

            migrationBuilder.DropTable(
                name: "currency_entity");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
