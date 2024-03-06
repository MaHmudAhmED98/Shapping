using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shapping.Migrations
{
    /// <inheritdoc />
    public partial class updatemarchant2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marchant_AspNetUsers_AppUserId",
                table: "Marchant");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchant_City_CityId",
                table: "Marchant");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchant_Governorates_GovernorateId",
                table: "Marchant");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Marchant_MerchantId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_Marchant_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marchant",
                table: "Marchant");

            migrationBuilder.RenameTable(
                name: "Marchant",
                newName: "Marchants");

            migrationBuilder.RenameIndex(
                name: "IX_Marchant_GovernorateId",
                table: "Marchants",
                newName: "IX_Marchants_GovernorateId");

            migrationBuilder.RenameIndex(
                name: "IX_Marchant_CityId",
                table: "Marchants",
                newName: "IX_Marchants_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Marchant_AppUserId",
                table: "Marchants",
                newName: "IX_Marchants_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marchants",
                table: "Marchants",
                column: "MarchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marchants_AspNetUsers_AppUserId",
                table: "Marchants",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marchants_City_CityId",
                table: "Marchants",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marchants_Governorates_GovernorateId",
                table: "Marchants",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Marchants_MerchantId",
                table: "Order",
                column: "MerchantId",
                principalTable: "Marchants",
                principalColumn: "MarchantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId",
                principalTable: "Marchants",
                principalColumn: "MarchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marchants_AspNetUsers_AppUserId",
                table: "Marchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchants_City_CityId",
                table: "Marchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Marchants_Governorates_GovernorateId",
                table: "Marchants");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Marchants_MerchantId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marchants",
                table: "Marchants");

            migrationBuilder.RenameTable(
                name: "Marchants",
                newName: "Marchant");

            migrationBuilder.RenameIndex(
                name: "IX_Marchants_GovernorateId",
                table: "Marchant",
                newName: "IX_Marchant_GovernorateId");

            migrationBuilder.RenameIndex(
                name: "IX_Marchants_CityId",
                table: "Marchant",
                newName: "IX_Marchant_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Marchants_AppUserId",
                table: "Marchant",
                newName: "IX_Marchant_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marchant",
                table: "Marchant",
                column: "MarchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marchant_AspNetUsers_AppUserId",
                table: "Marchant",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Marchant_City_CityId",
                table: "Marchant",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marchant_Governorates_GovernorateId",
                table: "Marchant",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Marchant_MerchantId",
                table: "Order",
                column: "MerchantId",
                principalTable: "Marchant",
                principalColumn: "MarchantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_Marchant_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId",
                principalTable: "Marchant",
                principalColumn: "MarchantId");
        }
    }
}
