﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendApartmentReservation.Migrations
{
    public partial class FullCarRent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarAddress",
                table: "CarReservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentEndTime",
                table: "CarReservations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RentStartTime",
                table: "CarReservations",
                nullable: true);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarAddress",
                table: "CarReservations");

            migrationBuilder.DropColumn(
                name: "RentEndTime",
                table: "CarReservations");

            migrationBuilder.DropColumn(
                name: "RentStartTime",
                table: "CarReservations");
        }
    }
}
