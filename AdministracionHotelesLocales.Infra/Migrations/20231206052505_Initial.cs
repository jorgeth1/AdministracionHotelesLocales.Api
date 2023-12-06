using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionHotelesLocales.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "AdministracionHotelesLocales");

            migrationBuilder.CreateTable(
                name: "Agencias",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hoteles",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estrellas = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoteles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Viajeros",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajeros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgenciasHoteles",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciasHoteles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgenciasHoteles_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Agencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgenciasHoteles_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    CostoBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Impuestos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Habitaciones_Hoteles_HotelId",
                        column: x => x.HotelId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Hoteles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HabitacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViajeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactoEmergenciaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Habitaciones_HabitacionId",
                        column: x => x.HabitacionId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Habitaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Viajeros_ViajeroId",
                        column: x => x.ViajeroId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Viajeros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactosEmergencia",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactosEmergencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactosEmergencia_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                schema: "AdministracionHotelesLocales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Huespedes_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalSchema: "AdministracionHotelesLocales",
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgenciasHoteles_AgenciaId",
                schema: "AdministracionHotelesLocales",
                table: "AgenciasHoteles",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_AgenciasHoteles_HotelId",
                schema: "AdministracionHotelesLocales",
                table: "AgenciasHoteles",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactosEmergencia_ReservaId",
                schema: "AdministracionHotelesLocales",
                table: "ContactosEmergencia",
                column: "ReservaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_HotelId",
                schema: "AdministracionHotelesLocales",
                table: "Habitaciones",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Huespedes_ReservaId",
                schema: "AdministracionHotelesLocales",
                table: "Huespedes",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_HabitacionId",
                schema: "AdministracionHotelesLocales",
                table: "Reservas",
                column: "HabitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ViajeroId",
                schema: "AdministracionHotelesLocales",
                table: "Reservas",
                column: "ViajeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgenciasHoteles",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "ContactosEmergencia",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Huespedes",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Agencias",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Reservas",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Habitaciones",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Viajeros",
                schema: "AdministracionHotelesLocales");

            migrationBuilder.DropTable(
                name: "Hoteles",
                schema: "AdministracionHotelesLocales");
        }
    }
}
