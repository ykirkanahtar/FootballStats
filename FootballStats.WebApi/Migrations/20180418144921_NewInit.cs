using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FootballStats.WebApi.Migrations
{
    public partial class NewInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    custom_claim = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_claims", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_applications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    client_application_name = table.Column<string>(maxLength: 20, nullable: false),
                    client_application_code = table.Column<string>(maxLength: 6, nullable: false),
                    client_application_password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_applications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    surname = table.Column<string>(maxLength: 25, nullable: false),
                    birth_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_name = table.Column<string>(maxLength: 25, nullable: false),
                    description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 25, nullable: false),
                    color = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_name = table.Column<string>(maxLength: 25, nullable: false),
                    password = table.Column<string>(maxLength: 256, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    email_confirmed = table.Column<bool>(nullable: false),
                    email_confirm_code = table.Column<string>(maxLength: 6, nullable: false, defaultValue: "993923"),
                    access_failed_count = table.Column<int>(nullable: false, defaultValue: 0),
                    lockout = table.Column<bool>(nullable: false),
                    lockout_end_date_time = table.Column<DateTime>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "client_application_utils",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    client_application_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client_application_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_client_application_utils_client_applications_client_applica~",
                        column: x => x.client_application_id,
                        principalTable: "client_applications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_role_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "role_entity_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_role_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_role_entity_claims_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "matches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    match_date = table.Column<DateTime>(nullable: false),
                    order = table.Column<int>(nullable: false),
                    duration_in_minutes = table.Column<int>(nullable: false),
                    home_team_id = table.Column<int>(nullable: false),
                    away_team_id = table.Column<int>(nullable: false),
                    video_link = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_matches", x => x.id);
                    table.ForeignKey(
                        name: "fk_matches_teams_away_team_id",
                        column: x => x.away_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_matches_teams_home_team_id",
                        column: x => x.home_team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    claim_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_claims_claims_claim_id",
                        column: x => x.claim_id,
                        principalTable: "claims",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_entity_claims",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    entity = table.Column<string>(maxLength: 50, nullable: false),
                    can_select = table.Column<bool>(nullable: false),
                    can_create = table.Column<bool>(nullable: false),
                    can_update = table.Column<bool>(nullable: false),
                    can_delete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_entity_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_entity_claims_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    user_id = table.Column<int>(nullable: false),
                    role_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_roles_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_user_roles_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_utils",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    special_value = table.Column<string>(maxLength: 100, nullable: false),
                    user_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_utils", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_utils_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stats",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    create_date_time = table.Column<DateTime>(nullable: false),
                    update_date_time = table.Column<DateTime>(nullable: true),
                    delete_date_time = table.Column<DateTime>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    match_id = table.Column<int>(nullable: false),
                    team_id = table.Column<int>(nullable: false),
                    player_id = table.Column<int>(nullable: false),
                    goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    own_goal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    penalty_score = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    missed_penalty = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    assist = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stats", x => x.id);
                    table.ForeignKey(
                        name: "fk_stats_matches_match_id",
                        column: x => x.match_id,
                        principalTable: "matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stats_players_player_id",
                        column: x => x.player_id,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_stats_teams_team_id",
                        column: x => x.team_id,
                        principalTable: "teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "client_applications",
                columns: new[] { "id", "client_application_code", "client_application_name", "client_application_password", "create_date_time", "delete_date_time", "status", "update_date_time" },
                values: new object[] { 1, "web", "web", "MEEW64IB6P6QJraD945T4m+C0Nb4sf8x6bwhYLzaxPU=", new DateTime(2018, 4, 18, 17, 49, 20, 893, DateTimeKind.Local), null, 1, null });

            migrationBuilder.InsertData(
                table: "players",
                columns: new[] { "id", "birth_date", "create_date_time", "delete_date_time", "name", "status", "surname", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(1982, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Yunus Emre", 1, "Kırkanahtar", null },
                    { 2, new DateTime(1974, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Mithat", 1, "Gerede", null },
                    { 3, new DateTime(1988, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Aytaç", 1, "Tongel", null },
                    { 4, new DateTime(1989, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Hakan", 1, "Çavdar", null },
                    { 5, new DateTime(1989, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Cihat", 1, "Manav", null },
                    { 6, new DateTime(1983, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Görkem", 1, "Güngör", null },
                    { 7, new DateTime(1988, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Emir", 1, "Cevahiroğlu", null },
                    { 8, new DateTime(1991, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, "Sabri", 1, "Öksüz", null }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "description", "role_name", "status", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 4, 18, 17, 49, 20, 894, DateTimeKind.Local), null, "Administration Role", "Administrator", 1, null },
                    { 2, new DateTime(2018, 4, 18, 17, 49, 20, 894, DateTimeKind.Local), null, "Default User Role", "NormalUser", 1, null },
                    { 3, new DateTime(2018, 4, 18, 17, 49, 20, 894, DateTimeKind.Local), null, "User for data writer like stats", "DataWriter", 1, null }
                });

            migrationBuilder.InsertData(
                table: "teams",
                columns: new[] { "id", "color", "create_date_time", "delete_date_time", "name", "status", "update_date_time" },
                values: new object[,]
                {
                    { 1, "Red-White-Blue", new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Atletico New Village FC", 1, null },
                    { 2, "Yellow-Black", new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Dortmund New Village FC", 1, null }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "access_failed_count", "create_date_time", "delete_date_time", "email", "email_confirm_code", "email_confirmed", "lockout", "lockout_end_date_time", "password", "status", "update_date_time", "user_name" },
                values: new object[] { 1, 0, new DateTime(2018, 4, 18, 17, 49, 20, 891, DateTimeKind.Local), null, "admin@admin.org", "9988", false, false, null, "aTyxEm41cX0hP8tkocP3OHyF64srB399R0u7BxNnaZQ=", 1, null, "admin" });

            migrationBuilder.InsertData(
                table: "client_application_utils",
                columns: new[] { "id", "client_application_id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time" },
                values: new object[] { 1, 1, new DateTime(2018, 4, 18, 17, 49, 20, 893, DateTimeKind.Local), null, "4JtyaPZVGpJ4P20HnyMPZA==", 1, null });

            migrationBuilder.InsertData(
                table: "matches",
                columns: new[] { "id", "away_team_id", "create_date_time", "delete_date_time", "duration_in_minutes", "home_team_id", "match_date", "order", "status", "update_date_time", "video_link" },
                values: new object[] { 1, 2, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, 60, 1, new DateTime(2018, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, "http://sosyalhalisaha.com/mac-detay/1452182" });

            migrationBuilder.InsertData(
                table: "role_entity_claims",
                columns: new[] { "id", "can_create", "can_delete", "can_select", "can_update", "create_date_time", "delete_date_time", "entity", "role_id", "status", "update_date_time" },
                values: new object[,]
                {
                    { 2, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "ClientApplicationUtil", 1, 1, null },
                    { 19, true, false, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Stat", 3, 1, null },
                    { 18, true, false, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Player", 3, 1, null },
                    { 17, true, false, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Team", 3, 1, null },
                    { 16, true, false, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Match", 3, 1, null },
                    { 15, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Team", 1, 1, null },
                    { 14, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Stat", 1, 1, null },
                    { 13, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Player", 1, 1, null },
                    { 1, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 894, DateTimeKind.Local), null, "Claim", 1, 1, null },
                    { 12, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Match", 1, 1, null },
                    { 10, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "RoleEntityClaim", 1, 1, null },
                    { 9, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "RoleClaim", 1, 1, null },
                    { 8, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "User", 1, 1, null },
                    { 7, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "UserUtil", 1, 1, null },
                    { 6, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "UserRole", 1, 1, null },
                    { 5, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "UserEntityClaim", 1, 1, null },
                    { 4, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "UserClaim", 1, 1, null },
                    { 3, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "ClientApplication", 1, 1, null },
                    { 11, true, true, true, true, new DateTime(2018, 4, 18, 17, 49, 20, 895, DateTimeKind.Local), null, "Role", 1, 1, null }
                });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "id", "create_date_time", "delete_date_time", "role_id", "status", "update_date_time", "user_id" },
                values: new object[] { 1, new DateTime(2018, 4, 18, 17, 49, 20, 894, DateTimeKind.Local), null, 1, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "user_utils",
                columns: new[] { "id", "create_date_time", "delete_date_time", "special_value", "status", "update_date_time", "user_id" },
                values: new object[] { 1, new DateTime(2018, 4, 18, 17, 49, 20, 892, DateTimeKind.Local), null, "Jm8i5WuspfBnFUE3ssUYbQ==", 1, null, 1 });

            migrationBuilder.InsertData(
                table: "stats",
                columns: new[] { "id", "assist", "create_date_time", "delete_date_time", "goal", "match_id", "missed_penalty", "own_goal", "penalty_score", "player_id", "status", "team_id", "update_date_time" },
                values: new object[,]
                {
                    { 1, 0m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 8m, 1, 0m, 0m, 0m, 3, 1, 1, null },
                    { 2, 3m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 5m, 1, 0m, 0m, 0m, 6, 1, 1, null },
                    { 3, 5m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 2m, 1, 0m, 0m, 0m, 7, 1, 1, null },
                    { 4, 2m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 1m, 1, 0m, 0m, 0m, 8, 1, 1, null },
                    { 5, 2m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 7m, 1, 0m, 0m, 0m, 2, 1, 2, null },
                    { 6, 2m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 4m, 1, 0m, 0m, 0m, 4, 1, 2, null },
                    { 7, 5m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 2m, 1, 0m, 1m, 0m, 5, 1, 2, null },
                    { 8, 3m, new DateTime(2018, 4, 18, 17, 49, 20, 896, DateTimeKind.Local), null, 2m, 1, 0m, 0m, 0m, 1, 1, 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_client_application_utils_client_application_id",
                table: "client_application_utils",
                column: "client_application_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_matches_away_team_id",
                table: "matches",
                column: "away_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_home_team_id",
                table: "matches",
                column: "home_team_id");

            migrationBuilder.CreateIndex(
                name: "ix_matches_match_date_order",
                table: "matches",
                columns: new[] { "match_date", "order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_claim_id",
                table: "role_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_claims_role_id",
                table: "role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_role_entity_claims_role_id",
                table: "role_entity_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_player_id",
                table: "stats",
                column: "player_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_team_id",
                table: "stats",
                column: "team_id");

            migrationBuilder.CreateIndex(
                name: "ix_stats_match_id_player_id_team_id",
                table: "stats",
                columns: new[] { "match_id", "player_id", "team_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_teams_name",
                table: "teams",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_claim_id",
                table: "user_claims",
                column: "claim_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_claims_user_id",
                table: "user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_entity_claims_user_id",
                table: "user_entity_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_role_id",
                table: "user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_roles_user_id",
                table: "user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_utils_user_id",
                table: "user_utils",
                column: "user_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "client_application_utils");

            migrationBuilder.DropTable(
                name: "role_claims");

            migrationBuilder.DropTable(
                name: "role_entity_claims");

            migrationBuilder.DropTable(
                name: "stats");

            migrationBuilder.DropTable(
                name: "user_claims");

            migrationBuilder.DropTable(
                name: "user_entity_claims");

            migrationBuilder.DropTable(
                name: "user_roles");

            migrationBuilder.DropTable(
                name: "user_utils");

            migrationBuilder.DropTable(
                name: "client_applications");

            migrationBuilder.DropTable(
                name: "matches");

            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropTable(
                name: "claims");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "teams");
        }
    }
}
