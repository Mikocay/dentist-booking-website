using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace swp391_debo_be.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment_Method",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Provider_ID = table.Column<int>(type: "int", nullable: true),
                    Public_Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Private_Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Payment_Info = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ipn_Listener_Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment___3214EC27A63F48AB", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__D80AB49B9D6A0592", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Treatment_Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Treatmen__3214EC270769FCB0", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirthday = table.Column<DateTime>(name: "Date Of Birthday", type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3214EC2717C4EBC6", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.Role,
                        principalTable: "Role",
                        principalColumn: "Role_ID");
                });

            migrationBuilder.CreateTable(
                name: "Clinic_Branch",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Mng_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Admin_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clinic_B__3214EC2754B82300", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clinic_Branch_Admin_ID",
                        column: x => x.Admin_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Clinic_Treatment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: true),
                    Admin_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clinic_T__3214EC27D3BB3E55", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clinic_Treatment_Admin_ID",
                        column: x => x.Admin_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Clinic_Treatment_Category",
                        column: x => x.Category,
                        principalTable: "Treatment_Category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cus_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Method_ID = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__3214EC2741530AD8", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Cus_ID",
                        column: x => x.Cus_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Payment_Method_ID",
                        column: x => x.Method_ID,
                        principalTable: "Payment_Method",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Br_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Manager__3214EC27A5342A08", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Manager_Br_ID_Clinic_Branch_ID",
                        column: x => x.Br_ID,
                        principalTable: "Clinic_Branch",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Cus_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Treat_ID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feedback__3214EC2719078489", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Feedback_Cus_ID",
                        column: x => x.Cus_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Feedback_Treat_ID",
                        column: x => x.Treat_ID,
                        principalTable: "Clinic_Treatment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mng_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC27B38DD1FA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Mng_ID",
                        column: x => x.Mng_ID,
                        principalTable: "Manager",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Payment_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cus_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Den_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Creator_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Is_Created_By_Staff = table.Column<bool>(type: "bit", nullable: true),
                    Created_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Med_Rec = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Booking__3214EC27E7A736E0", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Booking_Creator_ID",
                        column: x => x.Creator_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Booking_Cus_ID",
                        column: x => x.Cus_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Booking_Den_ID",
                        column: x => x.Den_ID,
                        principalTable: "Employee",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Booking_Payment_ID",
                        column: x => x.Payment_ID,
                        principalTable: "Payment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Customer_Record",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Cus_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Dent_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3214EC279115F950", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Customer_Record_Cus_ID",
                        column: x => x.Cus_ID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Customer_Record_Dent_ID",
                        column: x => x.Dent_ID,
                        principalTable: "Employee",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Dentist_Major",
                columns: table => new
                {
                    Dent_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Treat_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dentist___7EA26274A7A5F0FE", x => new { x.Dent_ID, x.Treat_ID });
                    table.ForeignKey(
                        name: "FK_Dentist_Major_Dent_ID",
                        column: x => x.Dent_ID,
                        principalTable: "Employee",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dentist_Major_Treat_ID",
                        column: x => x.Treat_ID,
                        principalTable: "Clinic_Treatment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Treat_ID = table.Column<int>(type: "int", nullable: true),
                    Temp_Dent = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Book_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cus_Rec_ID = table.Column<int>(type: "int", nullable: true),
                    Est_Duration = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Appointm__3214EC2741C62A16", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Book_ID",
                        column: x => x.Book_ID,
                        principalTable: "Booking",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Appointment_Temp_Dent",
                        column: x => x.Temp_Dent,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Appointment_Treat_ID",
                        column: x => x.Treat_ID,
                        principalTable: "Clinic_Treatment",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Appointme__Cus_R__52593CB8",
                        column: x => x.Cus_Rec_ID,
                        principalTable: "Customer_Record",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Book_ID",
                table: "Appointment",
                column: "Book_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Cus_Rec_ID",
                table: "Appointment",
                column: "Cus_Rec_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Temp_Dent",
                table: "Appointment",
                column: "Temp_Dent");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Treat_ID",
                table: "Appointment",
                column: "Treat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Creator_ID",
                table: "Booking",
                column: "Creator_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Cus_ID",
                table: "Booking",
                column: "Cus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Den_ID",
                table: "Booking",
                column: "Den_ID");

            migrationBuilder.CreateIndex(
                name: "UQ__Booking__DA6C7FE003D3E611",
                table: "Booking",
                column: "Payment_ID",
                unique: true,
                filter: "[Payment_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Branch_Admin_ID",
                table: "Clinic_Branch",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Treatment_Admin_ID",
                table: "Clinic_Treatment",
                column: "Admin_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Clinic_Treatment_Category",
                table: "Clinic_Treatment",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Record_Cus_ID",
                table: "Customer_Record",
                column: "Cus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Record_Dent_ID",
                table: "Customer_Record",
                column: "Dent_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Dentist_Major_Treat_ID",
                table: "Dentist_Major",
                column: "Treat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Mng_ID",
                table: "Employee",
                column: "Mng_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Cus_ID",
                table: "Feedback",
                column: "Cus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_Treat_ID",
                table: "Feedback",
                column: "Treat_ID");

            migrationBuilder.CreateIndex(
                name: "UQ_Manager_Br_ID",
                table: "Manager",
                column: "Br_ID",
                unique: true,
                filter: "[Br_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Cus_ID",
                table: "Payment",
                column: "Cus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Method_ID",
                table: "Payment",
                column: "Method_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Role",
                table: "User",
                column: "Role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Dentist_Major");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Customer_Record");

            migrationBuilder.DropTable(
                name: "Clinic_Treatment");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Treatment_Category");

            migrationBuilder.DropTable(
                name: "Payment_Method");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Clinic_Branch");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
