using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shapping.Migrations
{
    /// <inheritdoc />
    public partial class updatemarchant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Governorates_GovernorateId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_MerchantId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_RepresentativeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_AspNetUsers_MerchantId",
                table: "SpecialPrices");

            migrationBuilder.DropIndex(
                name: "IX_SpecialPrices_MerchantId",
                table: "SpecialPrices");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_GovernorateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "SpecialPrices");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GovernorateId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReturnerPercent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "MerchentId",
                table: "SpecialPrices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MerchantMarchantId",
                table: "SpecialPrices",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RepresentativeId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Order",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Marchant",
                columns: table => new
                {
                    MarchantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReturnerPercent = table.Column<double>(type: "float", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GovernorateId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchant", x => x.MarchantId);
                    table.ForeignKey(
                        name: "FK_Marchant_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marchant_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Marchant_Governorates_GovernorateId",
                        column: x => x.GovernorateId,
                        principalTable: "Governorates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Representative",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representative", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Representative_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPrices_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId");

            migrationBuilder.CreateIndex(
                name: "IX_Marchant_AppUserId",
                table: "Marchant",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marchant_CityId",
                table: "Marchant",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Marchant_GovernorateId",
                table: "Marchant",
                column: "GovernorateId");

            migrationBuilder.CreateIndex(
                name: "IX_Representative_AppUserId",
                table: "Representative",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Marchant_MerchantId",
                table: "Order",
                column: "MerchantId",
                principalTable: "Marchant",
                principalColumn: "MarchantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Representative_RepresentativeId",
                table: "Order",
                column: "RepresentativeId",
                principalTable: "Representative",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_Marchant_MerchantMarchantId",
                table: "SpecialPrices",
                column: "MerchantMarchantId",
                principalTable: "Marchant",
                principalColumn: "MarchantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Marchant_MerchantId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Representative_RepresentativeId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialPrices_Marchant_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropTable(
                name: "Marchant");

            migrationBuilder.DropTable(
                name: "Representative");

            migrationBuilder.DropIndex(
                name: "IX_SpecialPrices_MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.DropColumn(
                name: "MerchantMarchantId",
                table: "SpecialPrices");

            migrationBuilder.AlterColumn<string>(
                name: "MerchentId",
                table: "SpecialPrices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MerchantId",
                table: "SpecialPrices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepresentativeId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MerchantId",
                table: "Order",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GovernorateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ReturnerPercent",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPrices_MerchantId",
                table: "SpecialPrices",
                column: "MerchantId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CityId",
                table: "AspNetUsers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GovernorateId",
                table: "AspNetUsers",
                column: "GovernorateId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_City_CityId",
                table: "AspNetUsers",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Governorates_GovernorateId",
                table: "AspNetUsers",
                column: "GovernorateId",
                principalTable: "Governorates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_MerchantId",
                table: "Order",
                column: "MerchantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_RepresentativeId",
                table: "Order",
                column: "RepresentativeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialPrices_AspNetUsers_MerchantId",
                table: "SpecialPrices",
                column: "MerchantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
