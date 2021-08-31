using Microsoft.EntityFrameworkCore.Migrations;

namespace USelection.Web.Migrations
{
    public partial class migi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exception",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poruka = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exception", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IzbornaJedinica",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzbornaJedinica", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kandidat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeIPrezime = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    SifraKandidata = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kandidat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IzbornaJedinicaKandidat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzbornaJedinicaID = table.Column<int>(type: "int", nullable: true),
                    KandidatID = table.Column<int>(type: "int", nullable: true),
                    BrojOsvojenihGlasova = table.Column<int>(type: "int", nullable: true),
                    OverrideFile = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzbornaJedinicaKandidat", x => x.ID);
                    table.ForeignKey(
                        name: "FK__IzbornaJe__Izbor__2A4B4B5E",
                        column: x => x.IzbornaJedinicaID,
                        principalTable: "IzbornaJedinica",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__IzbornaJe__Kandi__2B3F6F97",
                        column: x => x.KandidatID,
                        principalTable: "Kandidat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IzbornaJedinica",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "New York" },
                    { 2, "Washington" },
                    { 3, "Texas" }
                });

            migrationBuilder.InsertData(
                table: "Kandidat",
                columns: new[] { "ID", "ImeIPrezime", "SifraKandidata" },
                values: new object[,]
                {
                    { 1, "Donald Trump", "DT" },
                    { 2, "Hillary Clinton", "HC" },
                    { 3, "Joe Biden", "JB" }
                });

            migrationBuilder.InsertData(
                table: "IzbornaJedinicaKandidat",
                columns: new[] { "ID", "BrojOsvojenihGlasova", "IzbornaJedinicaID", "KandidatID", "OverrideFile" },
                values: new object[,]
                {
                    { 1, 1233, 1, 1, false },
                    { 4, 1033, 2, 1, false },
                    { 7, 533, 3, 1, false },
                    { 2, 733, 1, 2, false },
                    { 5, 1733, 2, 2, false },
                    { 8, 733, 3, 2, false },
                    { 3, 1003, 1, 3, false },
                    { 6, 903, 2, 3, false },
                    { 9, 700, 3, 3, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzbornaJedinicaKandidat_IzbornaJedinicaID",
                table: "IzbornaJedinicaKandidat",
                column: "IzbornaJedinicaID");

            migrationBuilder.CreateIndex(
                name: "IX_IzbornaJedinicaKandidat_KandidatID",
                table: "IzbornaJedinicaKandidat",
                column: "KandidatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exception");

            migrationBuilder.DropTable(
                name: "IzbornaJedinicaKandidat");

            migrationBuilder.DropTable(
                name: "IzbornaJedinica");

            migrationBuilder.DropTable(
                name: "Kandidat");
        }
    }
}
