using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTempsProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "IsPromotional", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 7, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 8, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 9, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 10, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 11, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 12, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 13, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 14, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 15, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 16, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 17, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 18, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 19, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 20, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 21, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 22, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 23, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 24, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 25, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 26, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 27, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 28, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 29, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 30, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" },
                    { 31, "Laura Phantom", 3, "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "FOT000000001", "\\images\\product\\0e87ddf3-8be2-4f7a-8aea-0051cbacb484.jpg", false, 25.0, 23.0, 20.0, 22.0, "Leaves and Wonders" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);
        }
    }
}
