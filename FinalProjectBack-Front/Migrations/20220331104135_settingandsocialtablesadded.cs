using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProjectBack_Front.Migrations
{
    public partial class settingandsocialtablesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FooterSocials",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialIcon = table.Column<string>(nullable: false),
                    SocialUrl = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterSocials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuIcon = table.Column<string>(nullable: false),
                    CloseIcon = table.Column<string>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    SearchIcon = table.Column<string>(nullable: false),
                    UserIcon = table.Column<string>(nullable: false),
                    WhishlistIcon = table.Column<string>(nullable: false),
                    BasketIcon = table.Column<string>(nullable: false),
                    HandpickedImage = table.Column<string>(nullable: true),
                    HandpickedSale = table.Column<string>(maxLength: 20, nullable: false),
                    HandpickedSaleTitle = table.Column<string>(maxLength: 10, nullable: false),
                    NewArrivalImage = table.Column<string>(nullable: true),
                    FunImage = table.Column<string>(nullable: true),
                    UpliftedImage = table.Column<string>(nullable: true),
                    SubscribeTitle = table.Column<string>(maxLength: 50, nullable: false),
                    SubscribeImage = table.Column<string>(nullable: true),
                    FooterAddress = table.Column<string>(maxLength: 30, nullable: false),
                    FooterAdressIcon = table.Column<string>(nullable: false),
                    FooterEmail = table.Column<string>(maxLength: 50, nullable: false),
                    FooterEmailIcon = table.Column<string>(nullable: false),
                    FooterNumberIcon = table.Column<string>(nullable: false),
                    FooterNumber = table.Column<string>(maxLength: 30, nullable: false),
                    FooterPaymentImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FooterSocials");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
