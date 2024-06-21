using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kol2.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ObjectTypeId = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    Height = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objects_ObjectType_ObjectTypeId",
                        column: x => x.ObjectTypeId,
                        principalTable: "ObjectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objects_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Object_Owner",
                columns: table => new
                {
                    ObjectId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object_Owner", x => new { x.ObjectId, x.OwnerId });
                    table.ForeignKey(
                        name: "FK_Object_Owner_Objects_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Objects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Object_Owner_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ObjectType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "exampleType" },
                    { 2, "anotherExampleType" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1, "Jan", "Kowalski", "123456789" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "bw1" },
                    { 2, "bw2" }
                });

            migrationBuilder.InsertData(
                table: "Objects",
                columns: new[] { "Id", "Height", "ObjectTypeId", "WarehouseId", "Width" },
                values: new object[,]
                {
                    { 1, 2.2m, 1, 1, 1.5m },
                    { 2, 2.4m, 2, 1, 3.5m },
                    { 3, 4.6m, 1, 2, 44.0m }
                });

            migrationBuilder.InsertData(
                table: "Object_Owner",
                columns: new[] { "ObjectId", "OwnerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Object_Owner_OwnerId",
                table: "Object_Owner",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_ObjectTypeId",
                table: "Objects",
                column: "ObjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_WarehouseId",
                table: "Objects",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Object_Owner");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "ObjectType");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
