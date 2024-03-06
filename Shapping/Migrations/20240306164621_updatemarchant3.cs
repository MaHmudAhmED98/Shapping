using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shapping.Migrations
{
    /// <inheritdoc />
    public partial class updatemarchant3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropIndex(
                name: "IX_SpecialPrices_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropColumn(
                name: "MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPrices_MerchentId",
                table: "SpecialPrices",
                column: "MerchentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchentId",
                table: "SpecialPrices",
                column: "MerchentId",
                principalTable: "Marchants",
                principalColumn: "MarchantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchentId",
                table: "SpecialPrices");

            migrationBuilder.DropIndex(
                name: "IX_SpecialPrices_MerchentId",
                table: "SpecialPrices");

            migrationBuilder.AddColumn<int>(
                name: "MerchantMarchantId",
                table: "SpecialPrices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPrices_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_Marchants_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId",
                principalTable: "Marchants",
                principalColumn: "MarchantId");
        }
    }
}
