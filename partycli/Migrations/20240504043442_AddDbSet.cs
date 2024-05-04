using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace partycli.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocationModel_CountryModel_CountryId",
                table: "LocationModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LocationModel_Servers_ServerId",
                table: "LocationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LocationModel",
                table: "LocationModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CountryModel",
                table: "CountryModel");

            migrationBuilder.RenameTable(
                name: "LocationModel",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "CountryModel",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_LocationModel_ServerId",
                table: "Locations",
                newName: "IX_Locations_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_LocationModel_CountryId",
                table: "Locations",
                newName: "IX_Locations_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Servers_ServerId",
                table: "Locations",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Servers_ServerId",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "LocationModel");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "CountryModel");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_ServerId",
                table: "LocationModel",
                newName: "IX_LocationModel_ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountryId",
                table: "LocationModel",
                newName: "IX_LocationModel_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LocationModel",
                table: "LocationModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountryModel",
                table: "CountryModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LocationModel_CountryModel_CountryId",
                table: "LocationModel",
                column: "CountryId",
                principalTable: "CountryModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationModel_Servers_ServerId",
                table: "LocationModel",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
