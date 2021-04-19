using Microsoft.EntityFrameworkCore.Migrations;

namespace MMTApplication.Migrations
{
    public partial class spGetProductsByCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Category",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Category", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Product",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Product", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ProductCategory",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<long>(type: "bigint", nullable: false),
            //        CategoryId = table.Column<long>(type: "bigint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__ProductC__159C556DF8BA4BF2", x => new { x.ProductId, x.CategoryId });
            //        table.ForeignKey(
            //            name: "FK__ProductCa__Categ__3B75D760",
            //            column: x => x.CategoryId,
            //            principalTable: "Category",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__ProductCa__Produ__3A81B327",
            //            column: x => x.ProductId,
            //            principalTable: "Product",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductCategory_CategoryId",
            //    table: "ProductCategory",
            //    column: "CategoryId");

            var sp = @"create PROCEDURE GetProdutsByCategory 
                          @CatId int
                        AS
                        Begin
                            select *
                              from product p
                              inner join ProductCategory pc on pc.ProductId = p.id
                              where pc.CategoryId  = @CatId
                        End";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProductCategory");

            //migrationBuilder.DropTable(
            //    name: "Category");

            //migrationBuilder.DropTable(
            //    name: "Product");
        }
    }
}
