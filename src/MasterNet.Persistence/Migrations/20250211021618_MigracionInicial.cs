using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "curso_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precios");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
