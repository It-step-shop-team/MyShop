using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7247), "Electronics", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7503) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7746), "Clothing", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7746) },
                    { new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7750), "Books", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7750) },
                    { new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7753), "Home & Kitchen", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7754) },
                    { new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7756), "Sports & Outdoors", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7756) },
                    { new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7760), "Beauty & Health", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7760) },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7775), "Toys & Games", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7775) },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7777), "Automotive", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7778) },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7780), "Pet Supplies", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7781) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7783), "Office & Stationery", new DateTime(2025, 9, 10, 18, 40, 37, 59, DateTimeKind.Utc).AddTicks(7783) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("aaaaaa10-aaaa-aaaa-aaaa-aaaaaaaaaaa0"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4678), "Limited Stock", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4678) },
                    { new Guid("aaaaaa11-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4680), "Trending", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4681) },
                    { new Guid("aaaaaa12-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4683), "Gift", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4684) },
                    { new Guid("aaaaaa13-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4688), "Seasonal", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4688) },
                    { new Guid("aaaaaa14-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4691), "Exclusive", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4691) },
                    { new Guid("aaaaaa15-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4694), "Bundle", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4694) },
                    { new Guid("aaaaaa16-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4696), "Limited Time Offer", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4697) },
                    { new Guid("aaaaaa17-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4699), "Preorder", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4699) },
                    { new Guid("aaaaaa18-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4701), "Popular Choice", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4701) },
                    { new Guid("aaaaaa19-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4713), "Hot Deal", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4713) },
                    { new Guid("aaaaaa20-aaaa-aaaa-aaaa-aaaaaaaaaaa0"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4715), "Back in Stock", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4716) },
                    { new Guid("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4590), "New", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4591) },
                    { new Guid("aaaaaaa2-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4602), "Sale", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4602) },
                    { new Guid("aaaaaaa3-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4605), "Popular", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4636) },
                    { new Guid("aaaaaaa4-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4640), "Limited Edition", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4640) },
                    { new Guid("aaaaaaa5-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4663), "Free Shipping", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4663) },
                    { new Guid("aaaaaaa6-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4665), "Eco-Friendly", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4666) },
                    { new Guid("aaaaaaa7-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4669), "Handmade", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4669) },
                    { new Guid("aaaaaaa8-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4671), "Best Seller", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4672) },
                    { new Guid("aaaaaaa9-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4674), "On Discount", new DateTime(2025, 9, 10, 18, 40, 37, 60, DateTimeKind.Utc).AddTicks(4675) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
