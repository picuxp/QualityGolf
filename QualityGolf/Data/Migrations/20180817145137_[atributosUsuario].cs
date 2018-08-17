using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QualityGolf.Data.Migrations
{
    public partial class atributosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "CantidadClasesMes",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ClasesPendiente",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cuit",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dni",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaNacimiento",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Handicap",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nivel",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartingDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoPlan",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoSuscripcion",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VigenciaDesde",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VigenciaHasta",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CantidadClasesMes",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClasesPendiente",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Cuit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Dni",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Handicap",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StartingDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoPlan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoSuscripcion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VigenciaDesde",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VigenciaHasta",
                table: "AspNetUsers");
        }
    }
}
