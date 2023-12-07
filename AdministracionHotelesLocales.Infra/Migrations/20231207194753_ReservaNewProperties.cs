using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdministracionHotelesLocales.Infra.Migrations
{
    public partial class ReservaNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaSalida",
                schema: "AdministracionHotelesLocales",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaSalida",
                schema: "AdministracionHotelesLocales",
                table: "Reservas");
        }
    }
}
