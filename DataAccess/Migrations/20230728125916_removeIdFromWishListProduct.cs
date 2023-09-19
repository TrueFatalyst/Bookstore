using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeIdFromWishListProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_AspNetUsers_UserId",
                table: "WishListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts");

            migrationBuilder.DropIndex(
                name: "IX_WishListProducts_UserId",
                table: "WishListProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WishListProducts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WishListProducts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "WishListProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "WishListProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts",
                columns: new[] { "UserId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_WishListProducts_ApplicationUserId",
                table: "WishListProducts",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_AspNetUsers_ApplicationUserId",
                table: "WishListProducts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishListProducts_AspNetUsers_ApplicationUserId",
                table: "WishListProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts");

            migrationBuilder.DropIndex(
                name: "IX_WishListProducts_ApplicationUserId",
                table: "WishListProducts");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "WishListProducts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "WishListProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WishListProducts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WishListProducts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WishListProducts",
                table: "WishListProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WishListProducts_UserId",
                table: "WishListProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishListProducts_AspNetUsers_UserId",
                table: "WishListProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
