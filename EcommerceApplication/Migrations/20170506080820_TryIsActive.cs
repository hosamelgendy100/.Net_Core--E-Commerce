using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceApplication.Migrations
{
    public partial class TryIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Customer",
                newName: "UserName");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Customer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Customer",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CartItemId",
                table: "CartItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CartItemId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Customer",
                newName: "EmailAddress");
        }
    }
}
