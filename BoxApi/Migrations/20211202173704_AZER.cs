using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoxApi.Migrations
{
    public partial class AZER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boxs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Superficie = table.Column<double>(type: "float", nullable: false),
                    Volume = table.Column<double>(type: "float", nullable: false),
                    Profendeur = table.Column<double>(type: "float", nullable: false),
                    Hauteur = table.Column<double>(type: "float", nullable: false),
                    Largeur = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profendeur = table.Column<double>(type: "float", nullable: false),
                    Hauteur = table.Column<double>(type: "float", nullable: false),
                    Largeur = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Boxs_BoxId",
                        column: x => x.BoxId,
                        principalTable: "Boxs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stocks_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stocks_Categories_OStock_StockID",
                        column: x => x.StockID,
                        principalTable: "OStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandeOStock",
                columns: table => new
                {
                    CommandesId = table.Column<int>(type: "int", nullable: false),
                    OStocksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandeOStock", x => new { x.CommandesId, x.OStocksId });
                    table.ForeignKey(
                        name: "FK_CommandeOStock_Commandes_CommandesId",
                        column: x => x.CommandesId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandeOStock_OStock_OStocksId",
                        column: x => x.OStocksId,
                        principalTable: "OStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandeOStock_OStocksId",
                table: "CommandeOStock",
                column: "OStocksId");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_BoxId",
                table: "Commandes",
                column: "BoxId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Categories_CategoryId",
                table: "Stocks_Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_Categories_StockID",
                table: "Stocks_Categories",
                column: "StockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandeOStock");

            migrationBuilder.DropTable(
                name: "Stocks_Categories");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OStock");

            migrationBuilder.DropTable(
                name: "Boxs");
        }
    }
}
