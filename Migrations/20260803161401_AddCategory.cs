using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingSubscriptionTrackerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    actived = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionCategories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_SubscriptionCategories_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    date_to_paid = table.Column<DateOnly>(type: "date", nullable: false),
                    id_category = table.Column<long>(type: "bigint", nullable: false),
                    id_user = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_SubscriptionCategories_id_category",
                        column: x => x.id_category,
                        principalTable: "SubscriptionCategories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_id_user",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCategories_id_user",
                table: "SubscriptionCategories",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_id_category",
                table: "Subscriptions",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_id_user",
                table: "Subscriptions",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "SubscriptionCategories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
