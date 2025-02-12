using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionSeguridad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("12276bb0-ae4d-4d70-a412-99b132a859b3"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("5e89472d-e17f-4de3-b886-f8f662346297"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("64eaecce-b0c1-42ca-8b10-bb591e62357f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("7fec7e22-573a-4d52-a6d5-ecbf33c56bd9"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("a9fbb2f7-a852-4747-916a-343439ba1083"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c5ec77c1-7060-4cf4-90cc-084332783460"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c8568abf-282e-47bc-8962-d6fec83d3ba9"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("e48c4d19-3e22-4fef-9b05-30b547096fee"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("f18713dc-2517-4aa3-8207-2ae4c926fe9b"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("01b20b2f-1f47-46dc-b3c3-2d192c95e637"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("5a135fbc-08cd-4936-98cb-893a2d687483"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("67faafb7-5194-40b8-b7cd-50ae4716904f"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("6f883bb4-d93e-40c3-8594-ff9afbdb9432"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("7c620a3f-0a0d-4c0f-bd39-7ae5cc4a001b"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("9498e72b-7a21-46f0-8190-560afedd1124"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("b0dcedbd-852a-4ed4-8439-12abc20f257c"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("b512dc19-b45c-40a4-9683-fb6421e08694"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("c030bd34-8676-4c95-98a1-fb3e9f50a412"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("f04df07d-78bb-464a-b02e-9f8488b9441b"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("0b5a2108-6f61-4dae-8477-08f53d7af540"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a0f6064d-2f8b-4d02-9a66-882bd020d9f7", null, "CLIENT", "CLIENT" },
                    { "bb7d706b-7de3-4189-8824-d3466b4c4e3b", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("0bf9d1e5-517a-44ab-803a-a3d98f44bc1f"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(8085), "Awesome Soft Tuna" },
                    { new Guid("12b16afd-3444-4145-8817-1f9a227d8024"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7930), "Small Fresh Computer" },
                    { new Guid("3ffb2328-55ec-4dcd-afb0-1aac8deb80bc"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7805), "Awesome Cotton Chips" },
                    { new Guid("48fc7a6c-315c-4a40-83da-27a3ca494448"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7877), "Tasty Rubber Keyboard" },
                    { new Guid("4f1e62ac-bc56-4f46-b41c-1cadce28c912"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(8059), "Ergonomic Concrete Ball" },
                    { new Guid("7074669b-2337-47b8-b7c6-cc819f9362a6"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7956), "Awesome Concrete Ball" },
                    { new Guid("aed1b6f6-53fc-4cfd-b940-21ca9874c773"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7904), "Gorgeous Steel Pizza" },
                    { new Guid("c6a4ae44-c2d6-4684-ad02-512c02aad303"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7839), "Generic Rubber Computer" },
                    { new Guid("ec1a042e-8527-4d3c-b180-a498bf1787ae"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 2, 12, 1, 19, 35, 468, DateTimeKind.Utc).AddTicks(7980), "Tasty Soft Table" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellido", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0e79f256-cdd4-4a08-8a27-46ac40584b1c"), "Pouros", "Forward Research Associate", "Tressie" },
                    { new Guid("1fd5cdbb-bef6-47ce-85f0-c0b079738470"), "Rath", "Internal Accountability Associate", "Heaven" },
                    { new Guid("2d2f9325-4942-44a9-9968-b7c0f813aff9"), "Yost", "Global Factors Orchestrator", "Rosie" },
                    { new Guid("30f5b621-d28c-41c7-80ec-375dea0424e8"), "Mosciski", "District Branding Consultant", "Lilly" },
                    { new Guid("788045bb-e687-45d8-857b-296c1060ba36"), "Adams", "Lead Division Analyst", "Marlen" },
                    { new Guid("85921368-e407-4c05-938f-f631ac810a09"), "Skiles", "Investor Implementation Manager", "Noe" },
                    { new Guid("8988ef22-6f3f-48cb-a281-1637ad9f1c3d"), "Corwin", "District Data Representative", "Alda" },
                    { new Guid("9a33873b-586a-4610-bfa0-0ce5eb6c810b"), "Schinner", "Dynamic Paradigm Assistant", "Tom" },
                    { new Guid("9d18265b-a64d-44b8-9463-ea759c8a9189"), "Leuschke", "Global Intranet Officer", "Joy" },
                    { new Guid("eeade04f-5c85-42a8-9148-ae21ef335490"), "Ebert", "Future Implementation Agent", "Annamarie" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("0f13225f-c4fa-4355-a233-2be084eaa1e9"), "Precio Regular", 10.0m, 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "CURSO_READ", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 2, "POLICIES", "CURSO_UPDATE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 3, "POLICIES", "CURSO_WRITE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 4, "POLICIES", "CURSO_DELETE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 8, "POLICIES", "COMENTARIO_READ", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 9, "POLICIES", "COMENTARIO_DELETE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 10, "POLICIES", "COMENTARIO_CREATE", "bb7d706b-7de3-4189-8824-d3466b4c4e3b" },
                    { 11, "POLICIES", "CURSO_READ", "a0f6064d-2f8b-4d02-9a66-882bd020d9f7" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "a0f6064d-2f8b-4d02-9a66-882bd020d9f7" },
                    { 13, "POLICIES", "COMENTARIO_READ", "a0f6064d-2f8b-4d02-9a66-882bd020d9f7" },
                    { 14, "POLICIES", "COMENTARIO_CREATE", "a0f6064d-2f8b-4d02-9a66-882bd020d9f7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("0bf9d1e5-517a-44ab-803a-a3d98f44bc1f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("12b16afd-3444-4145-8817-1f9a227d8024"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("3ffb2328-55ec-4dcd-afb0-1aac8deb80bc"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("48fc7a6c-315c-4a40-83da-27a3ca494448"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("4f1e62ac-bc56-4f46-b41c-1cadce28c912"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("7074669b-2337-47b8-b7c6-cc819f9362a6"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("aed1b6f6-53fc-4cfd-b940-21ca9874c773"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c6a4ae44-c2d6-4684-ad02-512c02aad303"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("ec1a042e-8527-4d3c-b180-a498bf1787ae"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("0e79f256-cdd4-4a08-8a27-46ac40584b1c"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("1fd5cdbb-bef6-47ce-85f0-c0b079738470"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("2d2f9325-4942-44a9-9968-b7c0f813aff9"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("30f5b621-d28c-41c7-80ec-375dea0424e8"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("788045bb-e687-45d8-857b-296c1060ba36"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("85921368-e407-4c05-938f-f631ac810a09"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("8988ef22-6f3f-48cb-a281-1637ad9f1c3d"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("9a33873b-586a-4610-bfa0-0ce5eb6c810b"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("9d18265b-a64d-44b8-9463-ea759c8a9189"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("eeade04f-5c85-42a8-9148-ae21ef335490"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("0f13225f-c4fa-4355-a233-2be084eaa1e9"));

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("12276bb0-ae4d-4d70-a412-99b132a859b3"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6829), "Incredible Rubber Pizza" },
                    { new Guid("5e89472d-e17f-4de3-b886-f8f662346297"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6805), "Unbranded Steel Towels" },
                    { new Guid("64eaecce-b0c1-42ca-8b10-bb591e62357f"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6933), "Ergonomic Plastic Fish" },
                    { new Guid("7fec7e22-573a-4d52-a6d5-ecbf33c56bd9"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6786), "Awesome Wooden Bacon" },
                    { new Guid("a9fbb2f7-a852-4747-916a-343439ba1083"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6676), "Awesome Soft Car" },
                    { new Guid("c5ec77c1-7060-4cf4-90cc-084332783460"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6739), "Unbranded Soft Chips" },
                    { new Guid("c8568abf-282e-47bc-8962-d6fec83d3ba9"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6712), "Awesome Granite Towels" },
                    { new Guid("e48c4d19-3e22-4fef-9b05-30b547096fee"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6910), "Practical Rubber Shirt" },
                    { new Guid("f18713dc-2517-4aa3-8207-2ae4c926fe9b"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2025, 2, 11, 2, 16, 18, 427, DateTimeKind.Utc).AddTicks(6763), "Handmade Metal Ball" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellido", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("01b20b2f-1f47-46dc-b3c3-2d192c95e637"), "Leffler", "Senior Tactics Assistant", "Novella" },
                    { new Guid("5a135fbc-08cd-4936-98cb-893a2d687483"), "Waelchi", "Principal Metrics Supervisor", "Uriel" },
                    { new Guid("67faafb7-5194-40b8-b7cd-50ae4716904f"), "Howe", "Chief Interactions Associate", "Rosalyn" },
                    { new Guid("6f883bb4-d93e-40c3-8594-ff9afbdb9432"), "Stoltenberg", "Dynamic Implementation Liaison", "Alexa" },
                    { new Guid("7c620a3f-0a0d-4c0f-bd39-7ae5cc4a001b"), "Ward", "International Usability Agent", "Forest" },
                    { new Guid("9498e72b-7a21-46f0-8190-560afedd1124"), "Lebsack", "Product Usability Liaison", "Davin" },
                    { new Guid("b0dcedbd-852a-4ed4-8439-12abc20f257c"), "Labadie", "Customer Solutions Liaison", "Albina" },
                    { new Guid("b512dc19-b45c-40a4-9683-fb6421e08694"), "Connelly", "Dynamic Configuration Director", "Josie" },
                    { new Guid("c030bd34-8676-4c95-98a1-fb3e9f50a412"), "Jones", "International Security Assistant", "Paige" },
                    { new Guid("f04df07d-78bb-464a-b02e-9f8488b9441b"), "Beier", "Corporate Operations Producer", "Lolita" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("0b5a2108-6f61-4dae-8477-08f53d7af540"), "Precio Regular", 10.0m, 8.0m });
        }
    }
}
