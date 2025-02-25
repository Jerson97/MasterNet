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
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    PrecioActual = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alumno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Puntaje = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calificaciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "curso_instructores",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstructorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso_instructores", x => new { x.InstructorId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_curso_instructores_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_curso_instructores_instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_precios",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_precios", x => new { x.PrecioId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_precios_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_precios_precios_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2ed49c6f-2cdf-4cd3-a4f9-cbfe80fc557c", null, "CLIENT", "CLIENT" },
                    { "66dda938-f00f-4111-957a-c540968dd6f5", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1959d6b2-5fde-44cb-b83d-97c3f55cd2db"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8733), "Practical Concrete Chicken" },
                    { new Guid("35e6209a-cadc-4cfa-a8e0-1b66318c6d42"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8757), "Rustic Plastic Keyboard" },
                    { new Guid("37ae1f95-c567-42a8-875a-2e898f33da07"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8945), "Tasty Cotton Sausages" },
                    { new Guid("5141afef-9c98-4a5f-aa92-55c717779256"), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8779), "Small Frozen Hat" },
                    { new Guid("5c0ce28e-fa9d-48e7-b62e-a4f49898a986"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8922), "Refined Fresh Table" },
                    { new Guid("6fd25941-7ff8-40d4-aac1-7a89e5ee9afa"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8887), "Small Granite Table" },
                    { new Guid("ae5e5fb8-86af-43bb-a11d-fd28406e256d"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8697), "Tasty Frozen Tuna" },
                    { new Guid("cb9fecaa-a60f-4922-8ecc-d8b4a47e4cf7"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8802), "Fantastic Granite Mouse" },
                    { new Guid("cd88d4c8-78e8-495d-8ae7-a6d9e5d44cd3"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2025, 2, 24, 21, 30, 28, 124, DateTimeKind.Utc).AddTicks(8824), "Small Granite Ball" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellido", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("58f65fd6-f78e-4939-9b2d-65b7962bfe16"), "Rice", "Global Metrics Director", "Effie" },
                    { new Guid("6481ca25-de34-442e-954d-b4a782ca1bc4"), "Trantow", "Senior Data Producer", "Leslie" },
                    { new Guid("75f87857-9772-4957-b60d-c2040d7f0b59"), "Lind", "Dynamic Mobility Orchestrator", "Ayden" },
                    { new Guid("7bf0daea-2126-4697-8272-666ee06f5adf"), "Lemke", "Internal Intranet Manager", "Curt" },
                    { new Guid("bd65ab82-b322-4bf7-bfc8-589ff6c230f6"), "Goldner", "Lead Response Facilitator", "Tierra" },
                    { new Guid("beb7c978-f98c-4819-82ea-dfe3bf137d56"), "Hodkiewicz", "Principal Interactions Liaison", "Oliver" },
                    { new Guid("bf0e190e-2ade-4b31-aaae-a062c292669b"), "Torp", "District Program Liaison", "Kennedi" },
                    { new Guid("c3b0b242-071f-49f3-aaad-1525eb85d1f1"), "Raynor", "Direct Implementation Developer", "Pauline" },
                    { new Guid("d3912c12-be3b-437c-954c-a14974fe2ae3"), "Fay", "Regional Web Technician", "Dulce" },
                    { new Guid("d803ed7b-5fec-4be2-b2f1-80cb2857720b"), "Moen", "Direct Division Administrator", "Larue" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("d1653429-216b-45b9-a76d-1a1a8c57c9a4"), "Precio Regular", 10.0m, 8.0m });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "CURSO_READ", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 2, "POLICIES", "CURSO_UPDATE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 3, "POLICIES", "CURSO_WRITE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 4, "POLICIES", "CURSO_DELETE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 5, "POLICIES", "INSTRUCTOR_CREATE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 6, "POLICIES", "INSTRUCTOR_READ", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 7, "POLICIES", "INSTRUCTOR_UPDATE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 8, "POLICIES", "COMENTARIO_READ", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 9, "POLICIES", "COMENTARIO_DELETE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 10, "POLICIES", "COMENTARIO_CREATE", "66dda938-f00f-4111-957a-c540968dd6f5" },
                    { 11, "POLICIES", "CURSO_READ", "2ed49c6f-2cdf-4cd3-a4f9-cbfe80fc557c" },
                    { 12, "POLICIES", "INSTRUCTOR_READ", "2ed49c6f-2cdf-4cd3-a4f9-cbfe80fc557c" },
                    { 13, "POLICIES", "COMENTARIO_READ", "2ed49c6f-2cdf-4cd3-a4f9-cbfe80fc557c" },
                    { 14, "POLICIES", "COMENTARIO_CREATE", "2ed49c6f-2cdf-4cd3-a4f9-cbfe80fc557c" }
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

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_CursoId",
                table: "calificaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_curso_instructores_CursoId",
                table: "curso_instructores",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_precios_CursoId",
                table: "cursos_precios",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_CursoId",
                table: "imagenes",
                column: "CursoId");
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
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "curso_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precios");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
