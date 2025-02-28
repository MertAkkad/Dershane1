using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dershane.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anasayfa_icerik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anasayfa_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anasayfa_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anasayfa_icerik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gorsel_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Banner_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banner_Gorsel_Tipi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dokumanlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dokuman_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dokuman_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dokumanlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duyuru_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duyuru_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duyuru_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Egitimler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EgitimAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EgitimAciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitimler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etkinlikler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etkinlik_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etkinlik_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etkinlik_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinlikler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Haberler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Haber_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haber_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Haber_Tarih = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haberler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hakkimizda_icerik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hakkimizda_Baslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hakkimizda_Icerik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hakkimizda_icerik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kadromuz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kadromuz", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KurumsalBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Logo_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tel_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kurumsal_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KurumsalBilgiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubeKonum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gorsel_Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subeler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anasayfa_icerik");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Dokumanlar");

            migrationBuilder.DropTable(
                name: "Duyurular");

            migrationBuilder.DropTable(
                name: "Egitimler");

            migrationBuilder.DropTable(
                name: "Etkinlikler");

            migrationBuilder.DropTable(
                name: "Haberler");

            migrationBuilder.DropTable(
                name: "Hakkimizda_icerik");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "Kadromuz");

            migrationBuilder.DropTable(
                name: "KurumsalBilgiler");

            migrationBuilder.DropTable(
                name: "Subeler");
        }
    }
}
