using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace porTIEVserver.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PT_BankBranchs",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BankRef = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    InchargeRef = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_BankBranchs", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Banks",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Banks", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Cities",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code2 = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Code3 = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    NameTrk = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NameEng = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    PhoneAreaCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Cities", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Countries",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code2 = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    Code3 = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    ShortNameTrk = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ShortNameEng = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    OfficialNameTrk = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    OfficialNameEng = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    PhoneAreaCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CustomAreaCode = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Countries", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Firms",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirmType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FullAddress = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CurrencyType = table.Column<int>(type: "int", nullable: false),
                    DbServ = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DbName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DbUser = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DbPass = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Firms", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Menus",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AppUrl = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Menus", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Rites",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserRef = table.Column<int>(type: "int", nullable: false),
                    FirmRef = table.Column<int>(type: "int", nullable: false),
                    RoleRef = table.Column<int>(type: "int", nullable: false),
                    MenuRef = table.Column<int>(type: "int", nullable: false),
                    BttnRef = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Rites", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_Roles",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_Roles", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "PT_StkUnitSets",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_StkUnitSets", x => x.Ref);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PT_StkUnits",
                columns: table => new
                {
                    Ref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitType = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    StkUnitSetRef = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedUser = table.Column<int>(type: "int", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_StkUnits", x => x.Ref);
                    table.ForeignKey(
                        name: "FK_PT_StkUnits_PT_StkUnitSets_StkUnitSetRef",
                        column: x => x.StkUnitSetRef,
                        principalTable: "PT_StkUnitSets",
                        principalColumn: "Ref");
                });

            migrationBuilder.InsertData(
                table: "PT_Cities",
                columns: new[] { "Ref", "Active", "Code2", "Code3", "CountryCode", "CreatedDate", "CreatedUser", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "NameEng", "NameTrk", "PhoneAreaCode" },
                values: new object[,]
                {
                    { 101, true, "01", "ADA", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8433), 1, false, null, -1, "Adana       ", "Adana     ", "322" },
                    { 102, true, "02", "ADI", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8437), 1, false, null, -1, "Adıyaman    ", "Adıyaman  ", "416" },
                    { 103, true, "03", "AFY", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8440), 1, false, null, -1, "Afyon       ", "Afyon     ", "272" },
                    { 104, true, "04", "AGR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8443), 1, false, null, -1, "Ağrı        ", "Ağrı      ", "472" },
                    { 105, true, "05", "AMA", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8446), 1, false, null, -1, "Amasya      ", "Amasya    ", "358" },
                    { 106, true, "06", "ANK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8448), 1, false, null, -1, "Ankara      ", "Ankara    ", "312" },
                    { 107, true, "07", "ANT", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8450), 1, false, null, -1, "Antalya     ", "Antalya   ", "242" },
                    { 108, true, "08", "ART", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8454), 1, false, null, -1, "Artvin      ", "Artvin    ", "466" },
                    { 109, true, "09", "AYD", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8456), 1, false, null, -1, "Aydın       ", "Aydın     ", "256" },
                    { 110, true, "10", "BAL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8458), 1, false, null, -1, "Balıkesir   ", "Balıkesir ", "266" },
                    { 111, true, "11", "BIL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8464), 1, false, null, -1, "Bilecik     ", "Bilecik   ", "228" },
                    { 112, true, "12", "BIN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8466), 1, false, null, -1, "Bingöl      ", "Bingöl    ", "426" },
                    { 113, true, "13", "BIT", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8468), 1, false, null, -1, "Bitlis      ", "Bitlis    ", "434" },
                    { 114, true, "14", "BOL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8469), 1, false, null, -1, "Bolu        ", "Bolu      ", "374" },
                    { 115, true, "15", "BRD", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8472), 1, false, null, -1, "Burdur      ", "Burdur    ", "248" },
                    { 116, true, "16", "BRS", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8474), 1, false, null, -1, "Bursa       ", "Bursa     ", "224" },
                    { 117, true, "17", "CAN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8477), 1, false, null, -1, "Çanakkale   ", "Çanakkale ", "286" },
                    { 118, true, "18", "CNR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8479), 1, false, null, -1, "Çankırı     ", "Çankırı   ", "376" },
                    { 119, true, "19", "COR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8481), 1, false, null, -1, "Çorum       ", "Çorum     ", "364" },
                    { 120, true, "20", "DEN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8483), 1, false, null, -1, "Denizli     ", "Denizli   ", "258" },
                    { 121, true, "21", "DIY", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8485), 1, false, null, -1, "Diyarbakır  ", "Diyarbakır", "412" },
                    { 122, true, "22", "EDI", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8489), 1, false, null, -1, "Edirne      ", "Edirne    ", "284" },
                    { 123, true, "23", "ELA", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8490), 1, false, null, -1, "Elazığ      ", "Elazığ    ", "424" },
                    { 124, true, "24", "ERC", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8492), 1, false, null, -1, "Erzincan    ", "Erzincan  ", "446" },
                    { 125, true, "25", "ERZ", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8493), 1, false, null, -1, "Erzurum     ", "Erzurum   ", "442" },
                    { 126, true, "26", "ESK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8495), 1, false, null, -1, "Eskişehir   ", "Eskişehir ", "222" },
                    { 127, true, "27", "GAZ", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8503), 1, false, null, -1, "Gaziantep   ", "Gaziantep ", "342" },
                    { 128, true, "28", "GIR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8505), 1, false, null, -1, "Giresun     ", "Giresun   ", "454" },
                    { 129, true, "29", "GUM", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8506), 1, false, null, -1, "Gümüşhane   ", "Gümüşhane ", "456" },
                    { 130, true, "30", "HAK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8508), 1, false, null, -1, "Hakkari     ", "Hakkari   ", "438" },
                    { 131, true, "31", "HAT", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8510), 1, false, null, -1, "Hatay       ", "Hatay     ", "326" },
                    { 132, true, "32", "ISP", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(618), 1, false, null, -1, "Isparta     ", "Isparta   ", "246" },
                    { 133, true, "33", "MER", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(654), 1, false, null, -1, "Mersin      ", "Mersin    ", "324" },
                    { 134, true, "34", "IST", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(624), 1, false, null, -1, "İstanbul    ", "İstanbul  ", "212" },
                    { 135, true, "35", "IZM", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(625), 1, false, null, -1, "İzmir       ", "İzmir     ", "232" },
                    { 136, true, "36", "KRS", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(629), 1, false, null, -1, "Kars        ", "Kars      ", "474" },
                    { 137, true, "37", "KAS", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(634), 1, false, null, -1, "Kastamonu   ", "Kastamonu ", "366" },
                    { 138, true, "38", "KAY", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(636), 1, false, null, -1, "Kayseri     ", "Kayseri   ", "352" },
                    { 139, true, "39", "KRK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(644), 1, false, null, -1, "Kırklareli  ", "Kırklareli", "288" },
                    { 140, true, "40", "KSH", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(646), 1, false, null, -1, "Kırşehir    ", "Kırşehir  ", "386" },
                    { 141, true, "41", "KOC", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(641), 1, false, null, -1, "Kocaeli     ", "Kocaeli   ", "262" },
                    { 142, true, "42", "KON", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(643), 1, false, null, -1, "Konya       ", "Konya     ", "332" },
                    { 143, true, "43", "KUT", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(647), 1, false, null, -1, "Kütahya     ", "Kütahya   ", "274" },
                    { 144, true, "44", "MAL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(649), 1, false, null, -1, "Malatya     ", "Malatya   ", "422" },
                    { 145, true, "45", "MAN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(651), 1, false, null, -1, "Manisa      ", "Manisa    ", "236" },
                    { 146, true, "46", "KAH", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(627), 1, false, null, -1, "K.Maraş     ", "K.Maraş   ", "344" },
                    { 147, true, "47", "MAR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(652), 1, false, null, -1, "Mardin      ", "Mardin    ", "482" },
                    { 148, true, "48", "MUG", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(656), 1, false, null, -1, "Muğla       ", "Muğla     ", "252" },
                    { 149, true, "49", "MUS", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(658), 1, false, null, -1, "Muş         ", "Muş       ", "436" },
                    { 150, true, "50", "NEV", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(660), 1, false, null, -1, "Nevşehir    ", "Nevşehir  ", "384" },
                    { 151, true, "51", "NIG", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(661), 1, false, null, -1, "Niğde       ", "Niğde     ", "388" },
                    { 152, true, "52", "ORD", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(663), 1, false, null, -1, "Ordu        ", "Ordu      ", "452" },
                    { 153, true, "53", "RIZ", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(666), 1, false, null, -1, "Rize        ", "Rize      ", "464" },
                    { 154, true, "54", "SAK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(668), 1, false, null, -1, "Sakarya     ", "Sakarya   ", "264" },
                    { 155, true, "55", "SAM", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(669), 1, false, null, -1, "Samsun      ", "Samsun    ", "362" },
                    { 156, true, "56", "SII", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(671), 1, false, null, -1, "Siirt       ", "Siirt     ", "484" },
                    { 157, true, "57", "SIN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(673), 1, false, null, -1, "Sinop       ", "Sinop     ", "368" },
                    { 158, true, "58", "SIV", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(674), 1, false, null, -1, "Sivas       ", "Sivas     ", "346" },
                    { 159, true, "59", "TEK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(680), 1, false, null, -1, "Tekirdağ    ", "Tekirdağ  ", "282" },
                    { 160, true, "60", "TOK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(682), 1, false, null, -1, "Tokat       ", "Tokat     ", "356" },
                    { 161, true, "61", "TRA", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(683), 1, false, null, -1, "Trabzon     ", "Trabzon   ", "462" },
                    { 162, true, "62", "TUN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(685), 1, false, null, -1, "Tunceli     ", "Tunceli   ", "428" },
                    { 163, true, "63", "SUR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(676), 1, false, null, -1, "Şanlıurfa   ", "Şanlıurfa ", "414" },
                    { 164, true, "64", "USK", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(687), 1, false, null, -1, "Uşak        ", "Uşak      ", "276" },
                    { 165, true, "65", "VAN", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(688), 1, false, null, -1, "Van         ", "Van       ", "432" },
                    { 166, true, "66", "YOZ", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(692), 1, false, null, -1, "Yozgat      ", "Yozgat    ", "354" },
                    { 167, true, "67", "ZON", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(693), 1, false, null, -1, "Zonguldak   ", "Zonguldak ", "372" },
                    { 168, true, "68", "AKS", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8444), 1, false, null, -1, "Aksaray     ", "Aksaray   ", "382" },
                    { 169, true, "69", "BAY", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8463), 1, false, null, -1, "Bayburt     ", "Bayburt   ", "458" },
                    { 170, true, "70", "KRM", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(631), 1, false, null, -1, "Karaman     ", "Karaman   ", "338" },
                    { 171, true, "71", "KKL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(638), 1, false, null, -1, "Kırıkkale   ", "Kırıkkale ", "318" },
                    { 172, true, "72", "BAT", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8461), 1, false, null, -1, "Batman      ", "Batman    ", "488" },
                    { 173, true, "73", "SIR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(679), 1, false, null, -1, "Şırnak      ", "Şırnak    ", "486" },
                    { 174, true, "74", "BAR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8460), 1, false, null, -1, "Bartın      ", "Bartın    ", "378" },
                    { 175, true, "75", "ARD", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8452), 1, false, null, -1, "Ardahan     ", "Ardahan   ", "478" },
                    { 176, true, "76", "IGD", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8511), 1, false, null, -1, "Iğdır       ", "Iğdır     ", "476" },
                    { 177, true, "77", "YAL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(690), 1, false, null, -1, "Yalova      ", "Yalova    ", "226" },
                    { 178, true, "78", "KRB", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(632), 1, false, null, -1, "Karabük     ", "Karabük   ", "370" },
                    { 179, true, "79", "KIL", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(639), 1, false, null, -1, "Kilis       ", "Kilis     ", "348" },
                    { 180, true, "80", "OSM", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(665), 1, false, null, -1, "Osmaniye    ", "Osmaniye  ", "328" },
                    { 181, true, "81", "DUZ", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8487), 1, false, null, -1, "Düzce       ", "Düzce     ", "380" }
                });

            migrationBuilder.InsertData(
                table: "PT_Countries",
                columns: new[] { "Ref", "Active", "Code2", "Code3", "CreatedDate", "CreatedUser", "CurrencyCode", "CustomAreaCode", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "OfficialNameEng", "OfficialNameTrk", "PhoneAreaCode", "ShortNameEng", "ShortNameTrk" },
                values: new object[,]
                {
                    { 101, true, "TR", "TUR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8393), 1, "TL", "52", false, null, -1, "Republic of Türkiye", "Türkiye Cumhuriyeti", "90", "Türkiye", "Türkiye" },
                    { 102, true, "US", "USA", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(8398), 1, "USD", "400", false, null, -1, "United States of America", "Amerika Birleşik Devletleri", "1", "U.S.A.", "A.B.D." }
                });

            migrationBuilder.InsertData(
                table: "PT_Firms",
                columns: new[] { "Ref", "Active", "CityCode", "Code", "CountryCode", "CreatedDate", "CreatedUser", "CurrencyType", "DbName", "DbPass", "DbServ", "DbUser", "Desc", "FirmType", "FullAddress", "ImgUrl", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "Name", "TaxNumber", "TaxOffice" },
                values: new object[] { 1, true, "34", "DEMO", "TR", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3083), 1, 1, "ideanos3_IdeaNostraMainDB", "IdAdmn_Usr@2021!!", "mssql04.trwww.com", "IdeaAdminUser", "Demo Anonim Şirketi", 3, "", "Atam.jpg", false, null, -1, "Demo A.Ş.", "1111111111", "" });

            migrationBuilder.InsertData(
                table: "PT_Menus",
                columns: new[] { "Ref", "Active", "AppUrl", "Code", "CreatedDate", "CreatedUser", "Icon", "ImgUrl", "IsAdmin", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "Name" },
                values: new object[,]
                {
                    { 1001, true, "/", "1001", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3285), 1, "fa-solid fa-home", "fa-home.jpg", true, false, null, -1, "Ana Sayfa" },
                    { 1100, true, "/admin", "1100", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3288), 1, "", "", true, false, null, -1, "Admin İşlemleri" },
                    { 1110, true, "/admin/users", "1110", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3290), 1, "fa-solid fa-user", "fa-user.jpg", true, false, null, -1, "Kullanıcılar" },
                    { 1120, true, "/admin/firms", "1120", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3292), 1, "fa-solid fa-city", "fa-city.jpg", true, false, null, -1, "Firmalar" },
                    { 1130, true, "/admin/roles", "1130", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3294), 1, "fa-solid fa-user-group", "fa-user-group.jpg", true, false, null, -1, "Roller" },
                    { 1140, true, "/admin/menus", "1140", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3296), 1, "fa-solid fa-person-circle-check", "fa-person-circle-check.jpg", true, false, null, -1, "Menuler" },
                    { 1200, true, "/gnrldefines", "1200", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3298), 1, "", "", true, false, null, -1, "Genel Tanımlar" },
                    { 1210, true, "/gnrldefines/stkunits", "1210", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3299), 1, "fa-solid fa-users", "fa-users.jpg", true, false, null, -1, "Stok Birimleri" },
                    { 1220, true, "/gnrldefines/stkunitsets", "1220", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3302), 1, "fa-solid fa-boxes-stacked", "fa-boxes-stacked.jpg", true, false, null, -1, "Stok Birim Setleri" },
                    { 1230, true, "/gnrldefines/countrys", "1230", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3304), 1, "fa-solid fa-map", "fa-map.jpg", true, false, null, -1, "Ülkeler" },
                    { 1240, true, "/gnrldefines/citys", "1240", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3305), 1, "fa-solid fa-city", "fa-city.jpg", true, false, null, -1, "Şehirler" },
                    { 1250, true, "/gnrldefines/banks", "1250", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3307), 1, "fa-solid fa-tags", "fa-tags.jpg", true, false, null, -1, "Bankalar" },
                    { 1260, true, "/gnrldefines/bankbranchs", "1260", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3309), 1, "fa-solid fa-users", "fa-users.jpg", true, false, null, -1, "Banka Şubeleri" },
                    { 1300, true, "/firmdefines", "1300", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3310), 1, "", "", false, false, null, -1, "Firma Tanımları" },
                    { 1310, true, "/firmdefines/personnels", "1310", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3312), 1, "fa-solid fa-tags", "fa-tags.jpg", false, false, null, -1, "Personeller" },
                    { 1320, true, "/firmdefines/cashiers", "1320", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3314), 1, "fa-solid fa-cash-register", "fa-cash-register.jpg", false, false, null, -1, "Kasalar" },
                    { 1330, true, "/firmdefines/bankaccounts", "1330", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3315), 1, "fa-solid fa-building-columns", "fa-building-columns.jpg", false, false, null, -1, "Banka Hesapları" },
                    { 1340, true, "/firmdefines/customers", "1340", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3317), 1, "fa-solid fa-users", "fa-users.jpg", false, false, null, -1, "Cariler" },
                    { 1350, true, "/firmdefines/products", "1350", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5238), 1, "fa-solid fa-boxes-stacked", "fa-boxes-stacked.jpg", false, false, null, -1, "Stoklar" },
                    { 1360, true, "/firmdefines/prices", "1360", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5243), 1, "fa-solid fa-tags", "fa-tags.jpg", false, false, null, -1, "Fiyatlar" },
                    { 1400, true, "/eTrainings", "1400", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5245), 1, "", "", false, false, null, -1, "Kurs İşlemleri" },
                    { 1410, true, "/eTrainings/classrooms", "1410", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5246), 1, "fa-solid fa-users", "fa-users.jpg", false, false, null, -1, "Sınıflar" },
                    { 1420, true, "/eTrainings/courses", "1420", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5248), 1, "fa-solid fa-truck-fast", "fa-truck-fast.jpg", false, false, null, -1, "Kurslar" },
                    { 1430, true, "/eTrainings/participants", "1430", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5250), 1, "fa-solid fa-box-archive", "fa-box-archive.jpg", false, false, null, -1, "Katılımcılar" },
                    { 1440, true, "/eTrainings/partners", "1440", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5252), 1, "fa-solid fa-wallet", "fa-wallet.jpg", false, false, null, -1, "Ortak Firmalar" },
                    { 1450, true, "/eTrainings/statues", "1450", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5254), 1, "fa-solid fa-upload", "fa-upload.jpg", false, false, null, -1, "Durum Kodları" },
                    { 1460, true, "/eTrainings/reports", "1460", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5256), 1, "fa-solid fa-print", "fa-print.jpg", false, false, null, -1, "Raporlar" },
                    { 1500, true, "/crm", "1500", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5257), 1, "", "", false, false, null, -1, "Satış Öncesi" },
                    { 1510, true, "/crm/leads", "1510", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5259), 1, "fa-solid fa-candidate", "fa-candidate.jpg", false, false, null, -1, "Adaylar" },
                    { 1520, true, "/crm/contacts", "1520", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5261), 1, "fa-solid fa-contact", "fa-contact.jpg", false, false, null, -1, "Kişiler" },
                    { 1530, true, "/crm/crmactions", "1530", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5263), 1, "fa-solid fa-handshake-angle", "fa-handshake-angle.jpg", false, false, null, -1, "Faaliyetler" },
                    { 1540, true, "/crm/crmactions", "1540", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5264), 1, "fa-solid fa-handshake-angle", "fa-handshake-angle.jpg", false, false, null, -1, "Teklifler" },
                    { 1600, true, "/sales", "1600", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5266), 1, "", "", false, false, null, -1, "Satış İşlemleri" },
                    { 1610, true, "/sales/orders", "1610", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5268), 1, "fa-solid fa-folder-open", "fa-folder-open.jpg", false, false, null, -1, "Siparişler" },
                    { 1620, true, "/sales/despatches", "1620", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5269), 1, "fa-solid fa-truck-arrow-right", "fa-truck-arrow-right.jpg", false, false, null, -1, "Sipariş Sevk" },
                    { 1630, true, "/sales/picking ", "1630", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5272), 1, "fa-solid fa-basket-shopping", "fa-basket-shopping.jpg", false, false, null, -1, "Toplu Mal Ayırma" },
                    { 1640, true, "/sales/delivery", "1640", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5274), 1, "fa-solid fa-user", "fa-user.jpg", false, false, null, -1, "Mal Teslim" },
                    { 1700, true, "/purchase", "1700", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5275), 1, "", "", false, false, null, -1, "Satın alma İşlemleri" },
                    { 1710, true, "/purchase/orders", "1710", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5277), 1, "fa-solid fa-folder-open", "fa-folder-open.jpg", false, false, null, -1, "Siparişler" },
                    { 1720, true, "/purchase/despatches", "1720", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5279), 1, "fa-solid fa-truck-arrow-left", "fa-truck-arrow-left.jpg", false, false, null, -1, "Mal Kabul" },
                    { 1730, true, "/purchase/quality ", "1730", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5280), 1, "fa-solid fa-thumbs-up", "fa-thumbs-up.jpg", false, false, null, -1, "Kalite kontrol" },
                    { 1740, true, "/purchase/approval", "1740", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5282), 1, "fa-solid fa-handshake-simple", "fa-handshake-simple.jpg", false, false, null, -1, "Kesin Kabul/Red" },
                    { 1800, true, "/postsales", "1800", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5284), 1, "", "", false, false, null, -1, "Satış Sonrası" },
                    { 1810, true, "/postsales/contracts", "1810", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5285), 1, "fa-solid fa-file-signature", "fa-file-signature.jpg", false, false, null, -1, "Sozlesmeler" },
                    { 1820, true, "/postsales/maintains", "1820", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5287), 1, "fa-solid fa-screwdriver-wrench", "fa-screwdriver-wrench.jpg", false, false, null, -1, "Bakımlar" },
                    { 1830, true, "/postsales/tasks", "1830", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5289), 1, "fa-solid fa-list-check", "fa-list-check.jpg", false, false, null, -1, "Görevler" },
                    { 1900, true, "/warehouse", "1900", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5290), 1, "fa-solid fa-warehouse", "fa-warehouse.jpg", false, false, null, -1, "Ambar İşlemleri" },
                    { 1910, true, "/warehouse/transfers", "1910", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5292), 1, "fa-solid fa-cubes-stacked", "fa-cubes-stacked.jpg", false, false, null, -1, "Ambar Transfer" },
                    { 1920, true, "/warehouse/despatches", "1920", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5293), 1, "fa-solid fa-people-carry-box", "fa-people-carry-box.jpg", false, false, null, -1, "Adres/Raf Değiştirme" },
                    { 2000, true, "/inventory", "2000", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5296), 1, "", "", false, false, null, -1, "Sayım İşlemleri" },
                    { 2010, true, "/inventory/fiches", "2010", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5297), 1, "fa-solid fa-square-root-variable", "fa-square-root-variable.jpg", false, false, null, -1, "Sayımlar" },
                    { 2020, true, "/inventory/combining ", "2020", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5299), 1, "fa-solid fa-square-root-variable", "fa-square-root-variable.jpg", false, false, null, -1, "Sayım Birleştirme" },
                    { 2030, true, "/inventory/comparing", "2030", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5301), 1, "fa-solid fa-square-root-variable", "fa-square-root-variable.jpg", false, false, null, -1, "Sayım Karşılaştırma" },
                    { 2040, true, "/inventory/finalization", "2040", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5302), 1, "fa-solid fa-square-root-variable", "fa-square-root-variable.jpg", false, false, null, -1, "Sayım Kesinleştirme" },
                    { 2100, true, "/production", "2100", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5304), 1, "", "", false, false, null, -1, "Üretim İşlemleri" },
                    { 2110, true, "/production/prodorders", "2110", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5306), 1, "fa-solid fa-gear", "fa-gear.jpg", false, false, null, -1, "Üretim Emri Başla/Bitir" },
                    { 2120, true, "/production/consumes", "2120", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5307), 1, "fa-solid fa-user", "fa-user.jpg", false, false, null, -1, "Üretimde Harcananlar" },
                    { 2130, true, "/production/prodentry", "2130", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5309), 1, "fa-solid fa-cubes", "fa-cubes.jpg", false, false, null, -1, "Üretilen Mallar" },
                    { 2140, true, "/production/approval", "2140", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5310), 1, "fa-solid fa-dumpster", "fa-dumpster.jpg", false, false, null, -1, "Hurdaya Ayırma" },
                    { 2300, true, "/personnel", "2300", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5312), 1, "", "", false, false, null, -1, "Personel İşlemleri" },
                    { 2310, true, "/personnel/advances", "2310", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5314), 1, "fa-solid fa-gear", "fa-gear.jpg", false, false, null, -1, "Avans Talepleri" },
                    { 2320, true, "/personnel/requests", "2320", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5315), 1, "fa-solid fa-user", "fa-user.jpg", false, false, null, -1, "İzin Talepleri" },
                    { 2330, true, "/personnel/expenses", "2330", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5318), 1, "fa-solid fa-cubes", "fa-cubes.jpg", false, false, null, -1, "Masraf Girişleri" },
                    { 2340, true, "/personnel/checking", "2340", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5320), 1, "fa-solid fa-dumpster", "fa-dumpster.jpg", false, false, null, -1, "Yoklama" },
                    { 2400, true, "/eCargos", "2400", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5321), 1, "", "", false, false, null, -1, "Kargo İşlemleri" },
                    { 2410, true, "/eCargo/customers", "2410", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5323), 1, "fa-solid fa-users", "fa-users.jpg", false, false, null, -1, "Müşteriler" },
                    { 2420, true, "/eCargo/carriers", "2420", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5324), 1, "fa-solid fa-truck-fast", "fa-truck-fast.jpg", false, false, null, -1, "Taşıyıcılar" },
                    { 2430, true, "/eCargo/cargomains", "2430", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5326), 1, "fa-solid fa-box-archive", "fa-box-archive.jpg", false, false, null, -1, "Kargolar" },
                    { 2440, true, "/eCargo/collects", "2440", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5328), 1, "fa-solid fa-wallet", "fa-wallet.jpg", false, false, null, -1, "Tahsilatlar" },
                    { 2450, true, "/eCargo/payments", "2450", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5329), 1, "fa-solid fa-upload", "fa-upload.jpg", false, false, null, -1, "Ödemeler" },
                    { 2460, true, "/eCargo/reports", "2460", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(5331), 1, "fa-solid fa-print", "fa-print.jpg", false, false, null, -1, "Raporlar" }
                });

            migrationBuilder.InsertData(
                table: "PT_Rites",
                columns: new[] { "Ref", "AppUserRef", "BttnRef", "FirmRef", "MenuRef", "RoleRef" },
                values: new object[,]
                {
                    { 101, 1, 63, 1, 1001, 1 },
                    { 102, 1, 63, 1, 1100, 1 },
                    { 103, 1, 63, 1, 1110, 1 },
                    { 104, 1, 63, 1, 1120, 1 },
                    { 105, 1, 63, 1, 1130, 1 },
                    { 106, 1, 63, 1, 1140, 1 },
                    { 107, 1, 63, 1, 1200, 1 },
                    { 108, 1, 63, 1, 1210, 1 },
                    { 109, 1, 63, 1, 1220, 1 },
                    { 110, 1, 63, 1, 1230, 1 },
                    { 111, 1, 63, 1, 1240, 1 },
                    { 112, 1, 63, 1, 1250, 1 },
                    { 113, 1, 63, 1, 1260, 1 },
                    { 114, 1, 63, 1, 1300, 1 },
                    { 115, 1, 63, 1, 1310, 1 },
                    { 116, 1, 63, 1, 1320, 1 },
                    { 117, 1, 63, 1, 1330, 1 },
                    { 118, 1, 63, 1, 1340, 1 },
                    { 119, 1, 63, 1, 1350, 1 },
                    { 120, 1, 63, 1, 1360, 1 },
                    { 121, 1, 63, 1, 1400, 1 },
                    { 122, 1, 63, 1, 1410, 1 },
                    { 123, 1, 63, 1, 1420, 1 },
                    { 124, 1, 63, 1, 1430, 1 },
                    { 125, 1, 63, 1, 1440, 1 },
                    { 126, 1, 63, 1, 1450, 1 },
                    { 127, 1, 63, 1, 1460, 1 },
                    { 128, 1, 63, 1, 1500, 1 },
                    { 129, 1, 63, 1, 1510, 1 },
                    { 130, 1, 63, 1, 1520, 1 },
                    { 131, 1, 63, 1, 1530, 1 },
                    { 132, 1, 63, 1, 1540, 1 },
                    { 133, 1, 63, 1, 1600, 1 },
                    { 134, 1, 63, 1, 1610, 1 },
                    { 135, 1, 63, 1, 1620, 1 },
                    { 136, 1, 63, 1, 1630, 1 },
                    { 137, 1, 63, 1, 1640, 1 },
                    { 138, 1, 63, 1, 1700, 1 },
                    { 139, 1, 63, 1, 1710, 1 },
                    { 140, 1, 63, 1, 1720, 1 },
                    { 141, 1, 63, 1, 1730, 1 },
                    { 142, 1, 63, 1, 1740, 1 },
                    { 143, 1, 63, 1, 1800, 1 },
                    { 144, 1, 63, 1, 1810, 1 },
                    { 145, 1, 63, 1, 1820, 1 },
                    { 146, 1, 63, 1, 1830, 1 },
                    { 147, 1, 63, 1, 1900, 1 },
                    { 148, 1, 63, 1, 1910, 1 },
                    { 149, 1, 63, 1, 1920, 1 },
                    { 150, 1, 63, 1, 2000, 1 },
                    { 151, 1, 63, 1, 2010, 1 },
                    { 152, 1, 63, 1, 2020, 1 },
                    { 153, 1, 63, 1, 2030, 1 },
                    { 154, 1, 63, 1, 2040, 1 },
                    { 155, 1, 63, 1, 2100, 1 },
                    { 156, 1, 63, 1, 2110, 1 },
                    { 157, 1, 63, 1, 2120, 1 },
                    { 158, 1, 63, 1, 2130, 1 },
                    { 159, 1, 63, 1, 2140, 1 },
                    { 160, 1, 63, 1, 2300, 1 },
                    { 161, 1, 63, 1, 2310, 1 },
                    { 162, 1, 63, 1, 2320, 1 },
                    { 163, 1, 63, 1, 2330, 1 },
                    { 164, 1, 63, 1, 2340, 1 },
                    { 165, 1, 63, 1, 2400, 1 },
                    { 166, 1, 63, 1, 2410, 1 },
                    { 167, 1, 63, 1, 2420, 1 },
                    { 168, 1, 63, 1, 2430, 1 },
                    { 169, 1, 63, 1, 2440, 1 },
                    { 170, 1, 63, 1, 2450, 1 },
                    { 171, 1, 63, 1, 2460, 1 },
                    { 201, 2, 23, 1, 1001, 1 },
                    { 202, 2, 5, 1, 1100, 1 },
                    { 203, 2, 5, 1, 1110, 1 },
                    { 204, 2, 5, 1, 1120, 1 },
                    { 205, 2, 5, 1, 1130, 1 },
                    { 206, 2, 5, 1, 1140, 1 },
                    { 207, 2, 19, 1, 1200, 1 },
                    { 208, 2, 19, 1, 1210, 1 },
                    { 209, 2, 19, 1, 1220, 1 },
                    { 210, 2, 19, 1, 1230, 1 },
                    { 211, 2, 19, 1, 1240, 1 },
                    { 212, 2, 19, 1, 1250, 1 },
                    { 213, 2, 19, 1, 1260, 1 },
                    { 214, 2, 23, 1, 1300, 1 },
                    { 215, 2, 23, 1, 1310, 1 },
                    { 216, 2, 23, 1, 1320, 1 },
                    { 217, 2, 23, 1, 1330, 1 },
                    { 218, 2, 23, 1, 1340, 1 },
                    { 219, 2, 23, 1, 1350, 1 },
                    { 220, 2, 23, 1, 1360, 1 },
                    { 221, 2, 23, 1, 1400, 1 },
                    { 222, 2, 23, 1, 1410, 1 },
                    { 223, 2, 23, 1, 1420, 1 },
                    { 224, 2, 23, 1, 1430, 1 },
                    { 225, 2, 23, 1, 1440, 1 },
                    { 226, 2, 23, 1, 1450, 1 },
                    { 227, 2, 23, 1, 1460, 1 },
                    { 228, 2, 23, 1, 1500, 1 },
                    { 229, 2, 23, 1, 1510, 1 },
                    { 230, 2, 23, 1, 1520, 1 },
                    { 231, 2, 23, 1, 1530, 1 },
                    { 232, 2, 23, 1, 1540, 1 },
                    { 233, 2, 23, 1, 1600, 1 },
                    { 234, 2, 23, 1, 1610, 1 },
                    { 235, 2, 23, 1, 1620, 1 },
                    { 236, 2, 23, 1, 1630, 1 },
                    { 237, 2, 23, 1, 1640, 1 },
                    { 238, 2, 23, 1, 1700, 1 },
                    { 239, 2, 23, 1, 1710, 1 },
                    { 240, 2, 23, 1, 1720, 1 },
                    { 241, 2, 23, 1, 1730, 1 },
                    { 242, 2, 23, 1, 1740, 1 },
                    { 243, 2, 23, 1, 1800, 1 },
                    { 244, 2, 23, 1, 1810, 1 },
                    { 245, 2, 23, 1, 1820, 1 },
                    { 246, 2, 23, 1, 1830, 1 },
                    { 247, 2, 23, 1, 1900, 1 },
                    { 248, 2, 23, 1, 1910, 1 },
                    { 249, 2, 23, 1, 1920, 1 },
                    { 250, 2, 23, 1, 2000, 1 },
                    { 251, 2, 23, 1, 2010, 1 },
                    { 252, 2, 23, 1, 2020, 1 },
                    { 253, 2, 23, 1, 2030, 1 },
                    { 254, 2, 23, 1, 2040, 1 },
                    { 255, 2, 23, 1, 2100, 1 },
                    { 256, 2, 23, 1, 2110, 1 },
                    { 257, 2, 23, 1, 2120, 1 },
                    { 258, 2, 23, 1, 2130, 1 },
                    { 259, 2, 23, 1, 2140, 1 },
                    { 260, 2, 23, 1, 2300, 1 },
                    { 261, 2, 23, 1, 2310, 1 },
                    { 262, 2, 23, 1, 2320, 1 },
                    { 263, 2, 23, 1, 2330, 1 },
                    { 264, 2, 23, 1, 2340, 1 },
                    { 265, 2, 23, 1, 2400, 1 },
                    { 266, 2, 23, 1, 2410, 1 },
                    { 267, 2, 23, 1, 2420, 1 },
                    { 268, 2, 23, 1, 2430, 1 },
                    { 269, 2, 23, 1, 2440, 1 },
                    { 270, 2, 23, 1, 2450, 1 },
                    { 271, 2, 23, 1, 2460, 1 }
                });

            migrationBuilder.InsertData(
                table: "PT_Roles",
                columns: new[] { "Ref", "Active", "Code", "CreatedDate", "CreatedUser", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "Name" },
                values: new object[,]
                {
                    { 1, true, "ADM", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3254), 1, false, null, -1, "Yönetici" },
                    { 2, true, "CRG", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3256), 1, false, null, -1, "Kargo" },
                    { 3, true, "CRM", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3258), 1, false, null, -1, "Satış Öncesi" },
                    { 4, true, "SLS", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3259), 1, false, null, -1, "Satış" },
                    { 5, true, "TRN", new DateTime(2025, 2, 26, 18, 46, 46, 676, DateTimeKind.Utc).AddTicks(3261), 1, false, null, -1, "Eğitim" }
                });

            migrationBuilder.InsertData(
                table: "PT_StkUnitSets",
                columns: new[] { "Ref", "Active", "Code", "CreatedDate", "CreatedUser", "Desc", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "Name" },
                values: new object[,]
                {
                    { 101, true, "AD-PK-KL-PL", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(3916), 1, "", false, null, -1, "Adet-Paket-Koli-Palet" },
                    { 102, true, "GR-KG-TN", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(3920), 1, "", false, null, -1, "Gram-Kilogram-Ton" },
                    { 103, true, "ML-LT", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(3922), 1, "", false, null, -1, "Mililitre-Litre" }
                });

            migrationBuilder.InsertData(
                table: "PT_StkUnits",
                columns: new[] { "Ref", "Active", "Code", "CreatedDate", "CreatedUser", "IsDeleted", "LastUpdatedDate", "LastUpdatedUser", "Name", "StkUnitSetRef", "UnitType" },
                values: new object[,]
                {
                    { 101, true, "AD", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(790), 1, false, null, -1, "Adet", null, 1 },
                    { 102, true, "PK", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(792), 1, false, null, -1, "Paket", null, 1 },
                    { 103, true, "KL", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(794), 1, false, null, -1, "Koli", null, 1 },
                    { 104, true, "PL", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(796), 1, false, null, -1, "Palet", null, 1 },
                    { 105, true, "GR", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(797), 1, false, null, -1, "Gram", null, 2 },
                    { 106, true, "KG", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(799), 1, false, null, -1, "Kilogram", null, 2 },
                    { 107, true, "TN", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(800), 1, false, null, -1, "Ton", null, 2 },
                    { 108, true, "ML", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(801), 1, false, null, -1, "MiliLitre", null, 3 },
                    { 109, true, "LT", new DateTime(2025, 2, 26, 18, 46, 46, 677, DateTimeKind.Utc).AddTicks(804), 1, false, null, -1, "Litre", null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PT_BankBranchs_Code",
                table: "PT_BankBranchs",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Banks_Code",
                table: "PT_Banks",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Cities_Code2",
                table: "PT_Cities",
                column: "Code2");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Cities_Code3",
                table: "PT_Cities",
                column: "Code3");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Countries_Code2",
                table: "PT_Countries",
                column: "Code2");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Countries_Code3",
                table: "PT_Countries",
                column: "Code3");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Countries_ShortNameEng",
                table: "PT_Countries",
                column: "ShortNameEng");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Countries_ShortNameTrk",
                table: "PT_Countries",
                column: "ShortNameTrk");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Firms_Code",
                table: "PT_Firms",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Menus_Code",
                table: "PT_Menus",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_Rites_AppUserRef_FirmRef_RoleRef_MenuRef_BttnRef",
                table: "PT_Rites",
                columns: new[] { "AppUserRef", "FirmRef", "RoleRef", "MenuRef", "BttnRef" });

            migrationBuilder.CreateIndex(
                name: "IX_PT_Roles_Code",
                table: "PT_Roles",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_StkUnits_Code",
                table: "PT_StkUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PT_StkUnits_StkUnitSetRef",
                table: "PT_StkUnits",
                column: "StkUnitSetRef");

            migrationBuilder.CreateIndex(
                name: "IX_PT_StkUnitSets_Code",
                table: "PT_StkUnitSets",
                column: "Code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PT_BankBranchs");

            migrationBuilder.DropTable(
                name: "PT_Banks");

            migrationBuilder.DropTable(
                name: "PT_Cities");

            migrationBuilder.DropTable(
                name: "PT_Countries");

            migrationBuilder.DropTable(
                name: "PT_Firms");

            migrationBuilder.DropTable(
                name: "PT_Menus");

            migrationBuilder.DropTable(
                name: "PT_Rites");

            migrationBuilder.DropTable(
                name: "PT_Roles");

            migrationBuilder.DropTable(
                name: "PT_StkUnits");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PT_StkUnitSets");
        }
    }
}
