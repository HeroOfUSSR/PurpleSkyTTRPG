using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleSkyTTRPG.DataAccess.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    System = table.Column<int>(type: "integer", nullable: false),
                    CharacterName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CharData = table.Column<string>(type: "text", nullable: false, defaultValue: "{}"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    ProfileJson = table.Column<string>(type: "text", nullable: false, defaultValue: "{}"),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    System = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    ItemTag = table.Column<int>(type: "integer", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    System = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSpells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    System = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSpells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GmId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    System = table.Column<int>(type: "integer", nullable: false),
                    InviteCode = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lobbies_Profiles_GmId",
                        column: x => x.GmId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LobbyCharacters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LobbyId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyCharacters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LobbyCharacters_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LobbyCharacters_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LobbyInventories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LobbyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContributorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    LobbyEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProfileEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyInventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LobbyInventories_Lobbies_LobbyEntityId",
                        column: x => x.LobbyEntityId,
                        principalTable: "Lobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LobbyInventories_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LobbyInventories_Profiles_ContributorId",
                        column: x => x.ContributorId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LobbyInventories_Profiles_ProfileEntityId",
                        column: x => x.ProfileEntityId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LobbyProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LobbyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LobbyProfiles_Lobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "Lobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LobbyProfiles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LobbyCharacterNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LobbyCharacterId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    NoteVisibility = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LobbyCharacterNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LobbyCharacterNotes_LobbyCharacters_LobbyCharacterId",
                        column: x => x.LobbyCharacterId,
                        principalTable: "LobbyCharacters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteVisibilities",
                columns: table => new
                {
                    LobbyCharacterNoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: false),
                    LobbyProfileEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteVisibilities", x => new { x.LobbyCharacterNoteId, x.ProfileId });
                    table.ForeignKey(
                        name: "FK_NoteVisibilities_LobbyCharacterNotes_LobbyCharacterNoteId",
                        column: x => x.LobbyCharacterNoteId,
                        principalTable: "LobbyCharacterNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteVisibilities_LobbyProfiles_LobbyProfileEntityId",
                        column: x => x.LobbyProfileEntityId,
                        principalTable: "LobbyProfiles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NoteVisibilities_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_GmId",
                table: "Lobbies",
                column: "GmId");

            migrationBuilder.CreateIndex(
                name: "IX_Lobbies_InviteCode",
                table: "Lobbies",
                column: "InviteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LobbyCharacterNotes_LobbyCharacterId",
                table: "LobbyCharacterNotes",
                column: "LobbyCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyCharacters_CharacterId",
                table: "LobbyCharacters",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyCharacters_LobbyId",
                table: "LobbyCharacters",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyInventories_ContributorId",
                table: "LobbyInventories",
                column: "ContributorId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyInventories_LobbyEntityId",
                table: "LobbyInventories",
                column: "LobbyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyInventories_LobbyId",
                table: "LobbyInventories",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyInventories_ProfileEntityId",
                table: "LobbyInventories",
                column: "ProfileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyProfiles_LobbyId",
                table: "LobbyProfiles",
                column: "LobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_LobbyProfiles_ProfileId",
                table: "LobbyProfiles",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteVisibilities_LobbyProfileEntityId",
                table: "NoteVisibilities",
                column: "LobbyProfileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteVisibilities_ProfileId",
                table: "NoteVisibilities",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_Login",
                table: "Profiles",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SystemItems_System",
                table: "SystemItems",
                column: "System");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSkills_System",
                table: "SystemSkills",
                column: "System");

            migrationBuilder.CreateIndex(
                name: "IX_SystemSpells_System",
                table: "SystemSpells",
                column: "System");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LobbyInventories");

            migrationBuilder.DropTable(
                name: "NoteVisibilities");

            migrationBuilder.DropTable(
                name: "SystemItems");

            migrationBuilder.DropTable(
                name: "SystemSkills");

            migrationBuilder.DropTable(
                name: "SystemSpells");

            migrationBuilder.DropTable(
                name: "LobbyCharacterNotes");

            migrationBuilder.DropTable(
                name: "LobbyProfiles");

            migrationBuilder.DropTable(
                name: "LobbyCharacters");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Lobbies");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
