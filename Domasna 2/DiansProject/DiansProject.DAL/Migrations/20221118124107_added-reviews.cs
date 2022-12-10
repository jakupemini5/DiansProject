using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiansProject.DAL.Migrations
{
    public partial class addedreviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Geometries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geometries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Access = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amenity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wheelchair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicycleParking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Covered = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertiesId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GeometryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Geometries_GeometryId",
                        column: x => x.GeometryId,
                        principalTable: "Geometries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Features_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OverallRating = table.Column<int>(type: "int", nullable: false),
                    SafetyRating = table.Column<int>(type: "int", nullable: false),
                    ConditionsRating = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_GeometryId",
                table: "Features",
                column: "GeometryId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_PropertiesId",
                table: "Features",
                column: "PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_FeatureId",
                table: "Reviews",
                column: "FeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Geometries");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
