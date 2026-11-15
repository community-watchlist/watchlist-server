using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_name = table.Column<string>(type: "varchar(64)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    code = table.Column<string>(type: "varchar(10)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<string>(type: "varchar(16)", nullable: false),
                    provider = table.Column<string>(type: "varchar(32)", nullable: false),
                    external_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    original_title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "varchar(2047)", nullable: true),
                    title_release_status = table.Column<string>(type: "varchar(32)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fetched_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    attributes = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_titles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genre_translations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    genre_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_code = table.Column<string>(type: "varchar(10)", nullable: false),
                    translated_name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genre_translations", x => x.id);
                    table.ForeignKey(
                        name: "fk_genre_translation_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_genre_translation_language_code",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    clerk_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    role = table.Column<string>(type: "varchar(32)", nullable: false),
                    username = table.Column<string>(type: "varchar(32)", nullable: false),
                    display_name = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    bio = table.Column<string>(type: "varchar(255)", nullable: true),
                    language_code = table.Column<string>(type: "varchar(10)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    last_seen_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    attributes = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_language_code",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    provider = table.Column<string>(type: "varchar(32)", nullable: false),
                    external_id = table.Column<string>(type: "varchar(64)", nullable: false),
                    original_title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "varchar(2047)", nullable: true),
                    position = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fetched_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    attributes = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_episodes", x => x.id);
                    table.ForeignKey(
                        name: "fk_episodes_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "title_genres",
                columns: table => new
                {
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    genre_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_title_genres", x => new { x.title_id, x.genre_id });
                    table.ForeignKey(
                        name: "fk_title_genre_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_title_genre_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "title_posters",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_file_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    file_url = table.Column<string>(type: "varchar(2048)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_title_posters", x => x.id);
                    table.ForeignKey(
                        name: "fk_title_poster_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "title_properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    score_average = table.Column<float>(type: "real", nullable: true),
                    score_count = table.Column<int>(type: "integer", nullable: false),
                    views = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_title_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_title_properties_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "title_translations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_code = table.Column<string>(type: "varchar(10)", nullable: false),
                    translated_title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "varchar(2047)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_title_translations", x => x.id);
                    table.ForeignKey(
                        name: "fk_title_translation_language_code",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_title_translation_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_banners",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_file_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    file_url = table.Column<string>(type: "varchar(2048)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_banners", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_banners_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_pictures",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_file_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    file_url = table.Column<string>(type: "varchar(2048)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_pictures", x => x.id);
                    table.ForeignKey(
                        name: "fk_user_pictures_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_score_titles",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_score_titles", x => new { x.user_id, x.title_id });
                    table.ForeignKey(
                        name: "fk_user_score_titles_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_score_titles_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_public = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watchlists", x => x.id);
                    table.ForeignKey(
                        name: "fk_watchlist_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episode_properties",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    episode_id = table.Column<Guid>(type: "uuid", nullable: false),
                    slug = table.Column<string>(type: "varchar(255)", nullable: false),
                    score_average = table.Column<float>(type: "real", nullable: true),
                    score_count = table.Column<int>(type: "integer", nullable: false),
                    views = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_episode_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_episode_properties_episode_id",
                        column: x => x.episode_id,
                        principalTable: "episodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episode_translations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    episode_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_code = table.Column<string>(type: "varchar(10)", nullable: false),
                    translated_title = table.Column<string>(type: "varchar(255)", nullable: false),
                    overview = table.Column<string>(type: "varchar(2047)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_episode_translations", x => x.id);
                    table.ForeignKey(
                        name: "fk_episode_translation_episode_id",
                        column: x => x.episode_id,
                        principalTable: "episodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_episode_translation_language_code",
                        column: x => x.language_code,
                        principalTable: "languages",
                        principalColumn: "code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_score_episodes",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    episode_id = table.Column<Guid>(type: "uuid", nullable: false),
                    score = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_score_episodes", x => new { x.user_id, x.episode_id });
                    table.ForeignKey(
                        name: "fk_user_score_episodes_episode_id",
                        column: x => x.episode_id,
                        principalTable: "episodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_score_episodes_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watchlist_banners",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    watchlist_id = table.Column<Guid>(type: "uuid", nullable: false),
                    original_file_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    file_url = table.Column<string>(type: "varchar(2048)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watchlist_banners", x => x.id);
                    table.ForeignKey(
                        name: "fk_watchlist_banners_watchlist_id",
                        column: x => x.watchlist_id,
                        principalTable: "watchlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "watchlist_items",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    watchlist_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "varchar(32)", nullable: false),
                    progress = table.Column<int>(type: "integer", nullable: false),
                    tags = table.Column<string>(type: "varchar(255)", nullable: true),
                    notes = table.Column<string>(type: "varchar(1000)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "timezone('utc', now())"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    attributes = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_watchlist_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_watchlist_items_title_id",
                        column: x => x.title_id,
                        principalTable: "titles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_watchlist_items_watchlist_id",
                        column: x => x.watchlist_id,
                        principalTable: "watchlists",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_episode_properties_episode_id",
                table: "episode_properties",
                column: "episode_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_episode_properties_slug",
                table: "episode_properties",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_episode_translations_episode_id_language_code",
                table: "episode_translations",
                columns: new[] { "episode_id", "language_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_episode_translations_language_code",
                table: "episode_translations",
                column: "language_code");

            migrationBuilder.CreateIndex(
                name: "ix_episodes_provider_external_id",
                table: "episodes",
                columns: new[] { "provider", "external_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_episodes_title_id",
                table: "episodes",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "ix_genre_translations_genre_id_language_code",
                table: "genre_translations",
                columns: new[] { "genre_id", "language_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_genre_translations_language_code",
                table: "genre_translations",
                column: "language_code");

            migrationBuilder.CreateIndex(
                name: "ix_genres_original_name",
                table: "genres",
                column: "original_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_title_genres_genre_id",
                table: "title_genres",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_title_posters_title_id",
                table: "title_posters",
                column: "title_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_title_properties_slug",
                table: "title_properties",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_title_properties_title_id",
                table: "title_properties",
                column: "title_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_title_translations_language_code",
                table: "title_translations",
                column: "language_code");

            migrationBuilder.CreateIndex(
                name: "ix_title_translations_title_id_language_code",
                table: "title_translations",
                columns: new[] { "title_id", "language_code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_titles_provider_external_id",
                table: "titles",
                columns: new[] { "provider", "external_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_banners_user_id",
                table: "user_banners",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_pictures_user_id",
                table: "user_pictures",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_score_episodes_episode_id",
                table: "user_score_episodes",
                column: "episode_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_score_titles_title_id",
                table: "user_score_titles",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_clerk_id",
                table: "users",
                column: "clerk_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_users_language_code",
                table: "users",
                column: "language_code");

            migrationBuilder.CreateIndex(
                name: "ix_users_username",
                table: "users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_watchlist_banners_watchlist_id",
                table: "watchlist_banners",
                column: "watchlist_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_watchlist_items_title_id",
                table: "watchlist_items",
                column: "title_id");

            migrationBuilder.CreateIndex(
                name: "ix_watchlist_items_watchlist_id_title_id",
                table: "watchlist_items",
                columns: new[] { "watchlist_id", "title_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_watchlists_user_id",
                table: "watchlists",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "episode_properties");

            migrationBuilder.DropTable(
                name: "episode_translations");

            migrationBuilder.DropTable(
                name: "genre_translations");

            migrationBuilder.DropTable(
                name: "title_genres");

            migrationBuilder.DropTable(
                name: "title_posters");

            migrationBuilder.DropTable(
                name: "title_properties");

            migrationBuilder.DropTable(
                name: "title_translations");

            migrationBuilder.DropTable(
                name: "user_banners");

            migrationBuilder.DropTable(
                name: "user_pictures");

            migrationBuilder.DropTable(
                name: "user_score_episodes");

            migrationBuilder.DropTable(
                name: "user_score_titles");

            migrationBuilder.DropTable(
                name: "watchlist_banners");

            migrationBuilder.DropTable(
                name: "watchlist_items");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "titles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
