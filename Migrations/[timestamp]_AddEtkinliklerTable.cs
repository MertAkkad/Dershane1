using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Dershane.Migrations
{
    public partial class AddEtkinliklerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Etkinlik_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etkinlik_Baslik = table.Column<string>(maxLength: 200, nullable: false),
                    Etkinlik_Icerik = table.Column<string>(nullable: false),
                    Etkinlik_Tarih = table.Column<DateTime>(nullable: false),
                    Gorsel_Data = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Etkinlik_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etkinlikler");
        }
    }
} 