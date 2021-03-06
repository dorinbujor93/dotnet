﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStore___Project.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    BikeId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    Role = table.Column<byte>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true),
                    FrameType = table.Column<byte>(nullable: false),
                    FrameSize = table.Column<byte>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    BikeOwnerId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_Users_BikeOwnerId",
                        column: x => x.BikeOwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    BikeId = table.Column<int>(nullable: false),
                    AccessoryType = table.Column<byte>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessories_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Road Bike" },
                    { 2, "Mountain Bike" },
                    { 3, "Touring Bike" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "BikeId", "ShopId", "UserId" },
                values: new object[] { 1, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "Mihai Eminescu 23", "Vello Express" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "Gender", "LastName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "mike@mail.com", "Mike", (byte)1, "Ekim", "very_strong_pass", (byte)2, "mike.ekim" },
                    { 2, "sally@mail.com", "Sally", (byte)2, "Harry", "very_strong_pass", (byte)1, "sally.harry" },
                    { 3, "harry@mail.com", "Harry", (byte)1, "Sally", "very_strong_pass", (byte)1, "harry.sally" }
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BikeOwnerId", "CategoryId", "Color", "FrameSize", "FrameType" },
                values: new object[] { 1, 2, 1, "Red", (byte)3, (byte)1 });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BikeOwnerId", "CategoryId", "Color", "FrameSize", "FrameType" },
                values: new object[] { 2, 2, 2, "Yellow", (byte)3, (byte)4 });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BikeOwnerId", "CategoryId", "Color", "FrameSize", "FrameType" },
                values: new object[] { 3, 3, 3, "Gray", (byte)3, (byte)2 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 1, (byte)6, 1, "Shimano", "Altus", 100 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 2, (byte)2, 2, "Kring", "Lighting", 10 });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "AccessoryType", "BikeId", "Brand", "Name", "Weight" },
                values: new object[] { 3, (byte)1, 2, "Smith", "Ringer", 15 });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_BikeId",
                table: "Accessories",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_BikeOwnerId",
                table: "Bikes",
                column: "BikeOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_CategoryId",
                table: "Bikes",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
