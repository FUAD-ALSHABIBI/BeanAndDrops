using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanAndDrops.Migrations
{
    /// <inheritdoc />
    public partial class FF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Category_Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Category_Name = table.Column<string>(type: "longtext", nullable: true),
                    Category_Description = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Category_Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Product_id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Product_Name = table.Column<string>(type: "longtext", nullable: true),
                    Product_Description = table.Column<string>(type: "longtext", nullable: true),
                    Category_Id = table.Column<string>(type: "varchar(255)", nullable: true),
                    Product_Size = table.Column<int>(type: "int", nullable: false),
                    Product_Price = table.Column<int>(type: "int", nullable: false),
                    Product_Count = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "longtext", nullable: true),
                    Product_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Product_id);
                    table.ForeignKey(
                        name: "FK_products_category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "category",
                        principalColumn: "Category_Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_products_Category_Id",
                table: "products",
                column: "Category_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
