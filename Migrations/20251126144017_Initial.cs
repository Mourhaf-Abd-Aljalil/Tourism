using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTourism.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attraction",
                columns: table => new
                {
                    Attraction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attraction_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("AttractionId", x => x.Attraction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trip", x => x.TripID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User_Type = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    ActivityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity_Name = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Trip_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ActivityID", x => x.ActivityID);
                    table.ForeignKey(
                        name: "FK__Activity__Trip_ID",
                        column: x => x.Trip_ID,
                        principalTable: "Trip",
                        principalColumn: "TripID");
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK__Offers__Trip_Id",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "TripID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Review_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trip_Id = table.Column<int>(type: "int", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ReviewDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK__Review__Trip_Id",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "TripID");
                });

            migrationBuilder.CreateTable(
                name: "Trip_Attraction",
                columns: table => new
                {
                    Trip_Attraction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attraction_Id = table.Column<int>(type: "int", nullable: true),
                    Trip_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trip_Att", x => x.Trip_Attraction_Id);
                    table.ForeignKey(
                        name: "FK__Trip_Attr__Attra",
                        column: x => x.Attraction_Id,
                        principalTable: "Attraction",
                        principalColumn: "Attraction_Id");
                    table.ForeignKey(
                        name: "FK__Trip_Attr__Trip",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "TripID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    Trip_Id = table.Column<int>(type: "int", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CostBooking = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Booking", x => x.Booking_Id);
                    table.ForeignKey(
                        name: "FK__Booking__Trip_Id",
                        column: x => x.Trip_Id,
                        principalTable: "Trip",
                        principalColumn: "TripID");
                    table.ForeignKey(
                        name: "FK__Booking__User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "User_Id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Payment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Id = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment", x => x.Payment_Id);
                    table.ForeignKey(
                        name: "FK__Payment__Booking",
                        column: x => x.Booking_Id,
                        principalTable: "Booking",
                        principalColumn: "Booking_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Trip_ID",
                table: "Activity",
                column: "Trip_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Trip_Id",
                table: "Booking",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_User_Id",
                table: "Booking",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TripId",
                table: "Offers",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Booking_Id",
                table: "Payment",
                column: "Booking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_Trip_Id",
                table: "Review",
                column: "Trip_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_Attraction_Attraction_Id",
                table: "Trip_Attraction",
                column: "Attraction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_Attraction_Trip_Id",
                table: "Trip_Attraction",
                column: "Trip_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Trip_Attraction");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Attraction");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
