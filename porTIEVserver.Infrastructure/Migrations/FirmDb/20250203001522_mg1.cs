using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace porTIEVserver.Infrastructure.Migrations.FirmDb
{
    /// <inheritdoc />
    public partial class mg1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PT_BankAccounts",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankRef = table.Column<int>(type: "int", nullable: false),
                    BankBranchRef = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<decimal>(type: "money", nullable: false),
                    Credit = table.Column<decimal>(type: "money", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_BankAccounts", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_BizService",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "varchar(max)", nullable: false),
                    TraderServerRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraderClientRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_BizService", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Branch",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Branch", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_CargoActions",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoMainRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoStatus = table.Column<int>(type: "int", nullable: false),
                    ActionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ActionTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_CargoActions", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_CargoDetails",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CargoMainRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoDetailType = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "money", nullable: false),
                    CurrencyType1 = table.Column<int>(type: "int", nullable: false),
                    CurrencyRate1 = table.Column<decimal>(type: "money", nullable: false),
                    Amount1 = table.Column<decimal>(type: "money", nullable: false),
                    Total1 = table.Column<decimal>(type: "money", nullable: false),
                    CurrencyType2 = table.Column<int>(type: "int", nullable: false),
                    CurrencyRate2 = table.Column<decimal>(type: "money", nullable: false),
                    Amount2 = table.Column<decimal>(type: "money", nullable: false),
                    Total2 = table.Column<decimal>(type: "money", nullable: false),
                    CurrencyType3 = table.Column<int>(type: "int", nullable: false),
                    CurrencyRate3 = table.Column<decimal>(type: "money", nullable: false),
                    Amount3 = table.Column<decimal>(type: "money", nullable: false),
                    Total3 = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_CargoDetails", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_CargoMains",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradingType = table.Column<int>(type: "int", nullable: false),
                    FicheDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FicheTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FicheNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoStatus = table.Column<int>(type: "int", nullable: false),
                    TransportType = table.Column<int>(type: "int", nullable: false),
                    EstimateArrivalDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SenderOfficeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderOfficeNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickerOfficeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickerRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayerOfficeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayerRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayerNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarrierNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_CargoMains", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Carriers",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InchargeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "money", nullable: false),
                    Credit = table.Column<decimal>(type: "money", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Carriers", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Cashiers",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "money", nullable: false),
                    Credit = table.Column<decimal>(type: "money", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Cashiers", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Classroom",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Classroom", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Contacts",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InchargeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Contacts", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Course",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Course", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_CrmActions",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrmActionType = table.Column<int>(type: "int", nullable: false),
                    FicheDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FicheTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FicheNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description1 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description2 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description3 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description4 = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description5 = table.Column<string>(type: "varchar(250)", nullable: false),
                    ContactRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_CrmActions", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Customers",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    FirmType = table.Column<int>(type: "int", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InchargeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "money", nullable: false),
                    Credit = table.Column<decimal>(type: "money", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Customers", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Offices",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    InchargeRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Offices", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Partner",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Partner", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Personnels",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<decimal>(type: "money", nullable: false),
                    Credit = table.Column<decimal>(type: "money", nullable: false),
                    Balance = table.Column<decimal>(type: "money", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Personnels", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Presences",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirmRef = table.Column<int>(type: "int", nullable: false),
                    ScanCode = table.Column<string>(type: "varchar(250)", nullable: false),
                    ScanTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Presences", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Products",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeCode2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeCode3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeCode4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeCode5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StkGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Debit = table.Column<double>(type: "float", nullable: false),
                    Credit = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Products", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_ProductStkUnits",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LineNr = table.Column<int>(type: "int", nullable: false),
                    StkUnitRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carpan = table.Column<double>(type: "float", nullable: false),
                    Bolen = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_ProductStkUnits", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Status",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Status", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Tradings",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FicheDate = table.Column<DateOnly>(type: "date", nullable: false),
                    FicheTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    FicheNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradingType = table.Column<int>(type: "int", nullable: false),
                    DebitTraderType = table.Column<int>(type: "int", nullable: false),
                    DebitTraderRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DebitCurrType = table.Column<int>(type: "int", nullable: false),
                    DebitCurrRate = table.Column<decimal>(type: "money", nullable: false),
                    DebitAmount = table.Column<decimal>(type: "money", nullable: false),
                    DebitDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    ContraRef = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreditTraderType = table.Column<int>(type: "int", nullable: false),
                    CreditTraderRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCurrType = table.Column<int>(type: "int", nullable: false),
                    CreditCurrRate = table.Column<decimal>(type: "money", nullable: false),
                    CreditAmount = table.Column<decimal>(type: "money", nullable: false),
                    CreditDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    CarrierRef = table.Column<int>(type: "int", nullable: true),
                    CashierRef = table.Column<int>(type: "int", nullable: true),
                    CustomerRef = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Tradings", x => x.Ref);
                    table.ForeignKey(
                        name: "FK_PT_Tradings_PT_Carriers_CarrierRef",
                        column: x => x.CarrierRef,
                        principalTable: "PT_Carriers",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Tradings_PT_Cashiers_CashierRef",
                        column: x => x.CashierRef,
                        principalTable: "PT_Cashiers",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Tradings_PT_Customers_CustomerRef",
                        column: x => x.CustomerRef,
                        principalTable: "PT_Customers",
                        principalColumn: "Ref");
                });

            migrationBuilder.CreateTable(
                name: "PT_Participant",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainTypeRef = table.Column<int>(type: "int", nullable: true),
                    IsCandidate = table.Column<bool>(type: "bit", nullable: false),
                    TraineRoomRef = table.Column<int>(type: "int", nullable: true),
                    BranchRef = table.Column<int>(type: "int", nullable: true),
                    PartnerRef = table.Column<int>(type: "int", nullable: true),
                    StatusRef = table.Column<int>(type: "int", nullable: true),
                    RegisterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prepaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayMent1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayDate1 = table.Column<DateOnly>(type: "date", nullable: false),
                    Payment2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayDate2 = table.Column<DateOnly>(type: "date", nullable: false),
                    Payment3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayDate3 = table.Column<DateOnly>(type: "date", nullable: false),
                    Notes1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Participant", x => x.Ref);
                    table.ForeignKey(
                        name: "FK_PT_Participant_PT_Branch_BranchRef",
                        column: x => x.BranchRef,
                        principalTable: "PT_Branch",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Participant_PT_Classroom_TraineRoomRef",
                        column: x => x.TraineRoomRef,
                        principalTable: "PT_Classroom",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Participant_PT_Course_TrainTypeRef",
                        column: x => x.TrainTypeRef,
                        principalTable: "PT_Course",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Participant_PT_Partner_PartnerRef",
                        column: x => x.PartnerRef,
                        principalTable: "PT_Partner",
                        principalColumn: "Ref");
                    table.ForeignKey(
                        name: "FK_PT_Participant_PT_Status_StatusRef",
                        column: x => x.StatusRef,
                        principalTable: "PT_Status",
                        principalColumn: "Ref");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PT_BankAccounts_Code",
                table: "PT_BankAccounts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_BizService_Code",
                table: "PT_BizService",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Branch_Code",
                table: "PT_Branch",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_CargoMains_FicheNumber",
                table: "PT_CargoMains",
                column: "FicheNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Carriers_Code",
                table: "PT_Carriers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Cashiers_Code",
                table: "PT_Cashiers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Classroom_Code",
                table: "PT_Classroom",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Contacts_Code",
                table: "PT_Contacts",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Course_Code",
                table: "PT_Course",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_CrmActions_FicheNumber",
                table: "PT_CrmActions",
                column: "FicheNumber");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Customers_Code",
                table: "PT_Customers",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Offices_Code",
                table: "PT_Offices",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_BranchRef",
                table: "PT_Participant",
                column: "BranchRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_Code",
                table: "PT_Participant",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_PartnerRef",
                table: "PT_Participant",
                column: "PartnerRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_StatusRef",
                table: "PT_Participant",
                column: "StatusRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_TraineRoomRef",
                table: "PT_Participant",
                column: "TraineRoomRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Participant_TrainTypeRef",
                table: "PT_Participant",
                column: "TrainTypeRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Partner_Code",
                table: "PT_Partner",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Personnels_Code",
                table: "PT_Personnels",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Products_Code",
                table: "PT_Products",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Status_Code",
                table: "PT_Status",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Tradings_CarrierRef",
                table: "PT_Tradings",
                column: "CarrierRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Tradings_CashierRef",
                table: "PT_Tradings",
                column: "CashierRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Tradings_CustomerRef",
                table: "PT_Tradings",
                column: "CustomerRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Tradings_FicheNumber",
                table: "PT_Tradings",
                column: "FicheNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PT_BankAccounts");

            migrationBuilder.DropTable(
                name: "PT_BizService");

            migrationBuilder.DropTable(
                name: "PT_CargoActions");

            migrationBuilder.DropTable(
                name: "PT_CargoDetails");

            migrationBuilder.DropTable(
                name: "PT_CargoMains");

            migrationBuilder.DropTable(
                name: "PT_Contacts");

            migrationBuilder.DropTable(
                name: "PT_CrmActions");

            migrationBuilder.DropTable(
                name: "PT_Offices");

            migrationBuilder.DropTable(
                name: "PT_Participant");

            migrationBuilder.DropTable(
                name: "PT_Personnels");

            migrationBuilder.DropTable(
                name: "PT_Presences");

            migrationBuilder.DropTable(
                name: "PT_Products");

            migrationBuilder.DropTable(
                name: "PT_ProductStkUnits");

            migrationBuilder.DropTable(
                name: "PT_Tradings");

            migrationBuilder.DropTable(
                name: "PT_Branch");

            migrationBuilder.DropTable(
                name: "PT_Classroom");

            migrationBuilder.DropTable(
                name: "PT_Course");

            migrationBuilder.DropTable(
                name: "PT_Partner");

            migrationBuilder.DropTable(
                name: "PT_Status");

            migrationBuilder.DropTable(
                name: "PT_Carriers");

            migrationBuilder.DropTable(
                name: "PT_Cashiers");

            migrationBuilder.DropTable(
                name: "PT_Customers");
        }
    }
}
