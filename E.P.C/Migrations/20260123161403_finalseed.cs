using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E.P.C.Migrations
{
    /// <inheritdoc />
    public partial class finalseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AIO_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AIO_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadiatorSize = table.Column<int>(type: "int", nullable: true),
                    PumpSpeed = table.Column<int>(type: "int", nullable: true),
                    FanSize = table.Column<int>(type: "int", nullable: true),
                    FanRPM = table.Column<int>(type: "int", nullable: true),
                    AIO_NoiseLevel = table.Column<int>(type: "int", nullable: true),
                    AIO_SupportedSockets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Threads = table.Column<int>(type: "int", nullable: true),
                    BaseClock = table.Column<double>(type: "float", nullable: true),
                    CPU_BoostClock = table.Column<double>(type: "float", nullable: true),
                    CPU_SocketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntegratedGraphics = table.Column<bool>(type: "bit", nullable: true),
                    CPUFan_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUFan_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUFan_Size = table.Column<int>(type: "int", nullable: true),
                    CPUFan_RPM = table.Column<int>(type: "int", nullable: true),
                    CPUFan_Airflow = table.Column<double>(type: "float", nullable: true),
                    CPUFan_NoiseLevel = table.Column<int>(type: "int", nullable: true),
                    CPUFan_ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedSockets = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Case_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Case_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Case_FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGPULength = table.Column<int>(type: "int", nullable: true),
                    MaxCPUCoolerHeight = table.Column<int>(type: "int", nullable: true),
                    DriveBays = table.Column<int>(type: "int", nullable: true),
                    FanSlots = table.Column<int>(type: "int", nullable: true),
                    Fan_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fan_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: true),
                    RPM = table.Column<int>(type: "int", nullable: true),
                    Airflow = table.Column<int>(type: "int", nullable: true),
                    NoiseLevel = table.Column<int>(type: "int", nullable: true),
                    ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySize = table.Column<int>(type: "int", nullable: true),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreClock = table.Column<int>(type: "int", nullable: true),
                    BoostClock = table.Column<int>(type: "int", nullable: true),
                    TDP = table.Column<int>(type: "int", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ports = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherBoard_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherBoard_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAMSlots = table.Column<int>(type: "int", nullable: true),
                    MaxRAMCapacity = table.Column<int>(type: "int", nullable: true),
                    MotherBoard_FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wattage = table.Column<int>(type: "int", nullable: true),
                    EfficiencyRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modular = table.Column<bool>(type: "bit", nullable: true),
                    Connectors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speed = table.Column<int>(type: "int", nullable: true),
                    sticks = table.Column<int>(type: "int", nullable: true),
                    Storage_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage_Capacity = table.Column<int>(type: "int", nullable: true),
                    Storage_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage_FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    connectionInterface = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsCheckedOut = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedOutAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PriceAtPurchase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AIO_Brand", "Description", "Discriminator", "FanRPM", "FanSize", "ImageUrl", "AIO_Model", "AIO_NoiseLevel", "Price", "PumpSpeed", "RadiatorSize", "AIO_SupportedSockets" },
                values: new object[,]
                {
                    { 1, "Corsair", "Corsair iCUE H100i RGB PRO XT AIO", "AIO", 2400, 120, "https://nanotroniconline.com/wp-content/uploads/2020/09/enfriamiento-liquido-corsair-h100i-elite-capllix-nanotroniconline.png", "iCUE H100i RGB PRO XT", 36, 569.0, 2800, 240, "LGA1200, AM4" },
                    { 2, "NZXT", "NZXT Kraken X63 AIO", "AIO", 2000, 140, "https://www.topmarket.co.il/images/detailed/88/GoRTpzh37R.png", "Kraken X63", 38, 880.0, 2800, 280, "LGA1200, AM4" },
                    { 3, "Cooler Master", "Cooler Master MasterLiquid ML240L V2 RGB AIO", "AIO", 2000, 120, "https://tms.co.il/image/catalog/products/MLW-D24M-A18PC-R2/yZCRgRdRhR.jpg", "MasterLiquid ML240L V2 RGB", 30, 295.0, 2400, 240, "LGA1200, AM4" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Case_Brand", "Description", "Discriminator", "DriveBays", "FanSlots", "Case_FormFactor", "ImageUrl", "MaxCPUCoolerHeight", "MaxGPULength", "Case_Model", "Price" },
                values: new object[,]
                {
                    { 4, "Cooler Master", "Cooler Master MasterBox Q300L Case", "Case", 4, 6, "Micro-ATX", "data:image/jpeg;base64,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", 159, 360, "MasterBox Q300L", 295.0 },
                    { 5, "NZXT", "NZXT H510 ATX Case", "Case", 3, 5, "ATX", "data:image/jpeg;base64,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", 165, 381, "H510", 437.0 },
                    { 6, "Corsair", "Corsair 4000D Airflow ATX Case", "Case", 4, 6, "ATX", "https://computerlounge.co.nz/cdn/shop/files/aa2910ffab2f0f65b7461d4f947e6f42e2ef2f9f_35820_1_grande.jpg?v=1720998019", 170, 360, "4000D Airflow", 246.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CPUFan_Airflow", "CPUFan_Brand", "CPUFan_ConnectorType", "Description", "Discriminator", "ImageUrl", "CPUFan_Model", "CPUFan_NoiseLevel", "Price", "CPUFan_RPM", "CPUFan_Size", "SupportedSockets" },
                values: new object[,]
                {
                    { 7, 48.799999999999997, "Arctic", "3-pin A-RGB", "Arctic Freezer 36 LGA1700+AM4 3-pin A-RGB CPU Fan - black", "CPUFan", "https://www.arctic.de/media/8f/6d/6c/1707835553/Freezer_36_A-RGB_Black_G01.png", "Freezer 36 A-RGB - Black", 45, 190.0, 2000, 159, "LGA1700, AM4" },
                    { 8, 145.16, "Arctic", "4-pin RGB", "Arctic Freezer 50 sTR4 4-pin RGB Cpu Fan", "CPUFan", "https://www.arctic.de/media/26/d8/ab/1598259954/Freezer_50_G00.png", "Freezer 50 TR", 20, 229.0, 1750, 165, "sTR4" },
                    { 9, 102.09999999999999, "Noctua", "4-pin", "Noctua NH-D12L LGA1700+AM4/5 4-pin CPU Fan", "CPUFan", "https://media.ldlc.com/r1600/ld/products/00/05/96/38/LD0005963837.jpg", "NH-D12L", 22, 299.0, 2000, 145, "LGA1700, AM4/5" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BaseClock", "CPU_BoostClock", "CPU_Brand", "Cores", "Description", "Discriminator", "ImageUrl", "IntegratedGraphics", "CPU_Model", "Price", "CPU_SocketType", "Threads" },
                values: new object[,]
                {
                    { 10, 3.3999999999999999, 5.4000000000000004, "Intel", 16, "Intel Core i7-13700K LGA1700 CPU Integrated Graphics", "CPU", "https://tms.co.il/image/catalog/products/C13700KB/Kzi45lJeg9.jpg", true, "Core i7-13700K", 1250.0, "LGA1700", 24 },
                    { 11, 4.7000000000000002, 5.5999999999999996, "AMD", 12, "AMD Ryzen 9 7900X AM5 CPU", "CPU", "https://ksp.co.il/shop/items/512/228616.jpg", false, "Ryzen 9 7900X", 1743.0, "AM5", 24 },
                    { 12, 3.2000000000000002, 5.4000000000000004, "AMD", 64, "AMD Ryzen Threadripper 9980X sTR5 CPU", "CPU", "https://media.ldlc.com/r1600/ld/products/00/06/26/04/LD0006260489_0006260509_0006260512.jpg", false, "Ryzen Threadripper 9980X", 21268.25, "sTR5", 128 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Airflow", "Fan_Brand", "ConnectorType", "Description", "Discriminator", "ImageUrl", "Fan_Model", "NoiseLevel", "Price", "RPM", "Size" },
                values: new object[,]
                {
                    { 13, 77, "Arctic", "4-pin PWM + 3-pin A-RGB", "Arctic P12 Pro 120mm 4-pin PWM + 3-pin A-RGB Fan - black", "Fan", "https://www.arctic.de/media/a2/cd/82/1750770613/P12_Pro_ARGB_black_rainbow_g00_(1).png", "P12 Pro A-RGB 120mm", 25, 59.0, 3000, 120 },
                    { 14, 92, "Lian Li", "4-pin PWM + 3-pin A-RGB", "Lian Li UNI FAN P28 4-pin PWM + 3-pin A-RGB Fan - white", "Fan", "https://lian-li.com/wp-content/uploads/2023/05/p28-00.jpg", "UNI FAN P28", 32, 136.0, 2600, 120 },
                    { 15, 71, "Cooler Master", "3-pin A-RGB", "Cooler Master SickleFlow Edge 120mm 3-pin A-RGB Fan - black", "Fan", "https://a.storyblok.com/f/281110/960x960/c7669a7ee9/sickleflow-edge-3pack-01-01.png/m/960x0/smart", "SickleFlow Edge 120 ARGB", 33, 136.0, 2500, 120 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BoostClock", "GPU_Brand", "CoreClock", "Description", "Discriminator", "ImageUrl", "Interface", "MemorySize", "MemoryType", "GPU_Model", "Ports", "Price", "TDP", "dimensions" },
                values: new object[,]
                {
                    { 16, 2588, "NVIDIA", 2452, "NVIDIA GIGABYTE RTX 5070Ti 16GB GDDR7 GPU", "GPU", "https://tms.co.il/image/catalog/products/N507TGAMINGOC16GD/MFe2EFfVT7.jpg", "PCIe 5.0 x16", 16, "GDDR7", "RTX 5070 Ti", "x3 DP + x1 HDMI", 3990.0, 300, "340x140x70 mm" },
                    { 17, 2500, "AMD", 1929, "AMD Sapphire Radeon RX 7900 XTX 24GB GDDR6 GPU", "GPU", "https://media.ldlc.com/r1600/ld/products/00/06/00/15/LD0006001513.jpg", "PCIe 4.0 x16", 24, "GDDR6", "Radeon RX 7900 XTX", "x2 DP + x1 HDMI + x1 USB-C", 5329.0, 355, "287x110x51 mm" },
                    { 18, 2535, "NVIDIA", 2310, "NVIDIA MSI RTX 4060Ti 8GB GDDR6 GPU", "GPU", "https://m.media-amazon.com/images/I/71hkfByPEiL.jpg", "PCIe 4.0 x8", 8, "GDDR6", "RTX 4060 Ti", "x3 DP + x1 HDMI", 2305.0, 160, "240x111x40 mm" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "MotherBoard_Brand", "Description", "Discriminator", "MotherBoard_FormFactor", "ImageUrl", "MaxRAMCapacity", "MotherBoard_Model", "Price", "RAMSlots", "SocketType" },
                values: new object[,]
                {
                    { 19, "ASUS", "ASUS ROG Strix B550-F Gaming MotherBoard AM4 ATX DDR4", "MotherBoard", "ATX", "https://tms.co.il/image/catalog/products/90MB19V0-M0EAY0/M2VOw178Qc.jpg", 128, "ROG Strix B550-F Gaming", 803.0, 4, "AM4" },
                    { 20, "MSI", "MSI MAG B660M Mortar WiFi DDR4 MotherBoard LGA1700 Micro-ATX", "MotherBoard", "Micro-ATX", "https://media.ldlc.com/r1600/ld/products/00/05/94/22/LD0005942218.jpg", 128, "MAG B660M Mortar WiFi DDR4", 910.0, 4, "LGA1700" },
                    { 21, "Gigabyte", "Gigabyte Z790 AORUS ELITE AX MotherBoard LGA1700 ATX DDR5", "MotherBoard", "ATX", "https://tms.co.il/image/catalog/products/GZ790AORUSELITEAX/lJVeEI0BTp.png", 128, "Z790 AORUS ELITE AX", 1200.0, 4, "LGA1700" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Connectors", "Description", "Discriminator", "EfficiencyRating", "FormFactor", "ImageUrl", "Model", "Modular", "Price", "Wattage" },
                values: new object[,]
                {
                    { 22, "Corsair", "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), 12V-2x6 (12+4 pin), SATA, PATA (4-pin)", "Corsair RM750x ATX 750 Watt 80 Plus Gold Certified Modular PSU", "PSU", "80 Plus Gold", "ATX", "https://media.ldlc.com/r1600/ld/products/00/06/19/18/LD0006191829.jpg", "RM750x", true, 738.0, 750 },
                    { 23, "EVGA", "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), SATA, PATA (4-pin), Floppy Adapter", "EVGA SuperNOVA 650 G5 ATX 650 Watt 80 Plus Gold Certified Modular PSU", "PSU", "80 Plus Gold", "ATX", "https://images.evga.com/products/gallery/png/220-G5-0650-X1_XL_1.png", "SuperNOVA 650 G5", true, 620.0, 650 },
                    { 24, "Seasonic", "24-pin ATX, 8-pin EPS/ATX 12V (4+4 pin), PCIe (6+2 pin), 12V-2x6 (12+4 pin), SATA, PATA (4-pin)", "Seasonic Focus GX-850 ATX 850 Watt 80 Plus Gold Certified Modular PSU", "PSU", "80 Plus Gold", "ATX", "https://datatronic.fi/1137008-large_default/seasonic-focus-gx-virtalahdeyksikko-750-w-20-4-pin-atx-atx-musta-seasonic-focus-gx-750-v4.jpg", "Focus GX-850", true, 770.0, 850 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "RAM_Brand", "Capacity", "Description", "Discriminator", "ImageUrl", "RAM_Model", "Price", "Speed", "Type", "sticks" },
                values: new object[,]
                {
                    { 25, "Corsair", 16, "Corsair Vengeance LPX DDR4 RAM 16GB 2x8GB 3200MHz", "RAM", "https://ksp.co.il/shop/items/512/69741.jpg", "Vengeance LPX", 406.0, 3200, "DDR4", 2 },
                    { 26, "G.Skill", 32, "G.Skill Trident Z RGB DDR5 RAM 32GB 2x16 6000MHz", "RAM", "https://media.ldlc.com/r1600/ld/products/00/06/05/02/LD0006050270.jpg", "Trident Z RGB", 610.0, 6000, "DDR5", 2 },
                    { 27, "Kingston", 128, "Kingston HyperX Fury DDR4 RAM 128GB 4x32GB 3600MHz", "RAM", "https://media.ldlc.com/r1600/ld/products/00/05/42/76/LD0005427627_2_0005709507.jpg", "HyperX Fury", 400.0, 3600, "DDR4", 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Storage_Brand", "Storage_Capacity", "Description", "Discriminator", "Storage_FormFactor", "ImageUrl", "Storage_Model", "Price", "Storage_Type", "connectionInterface" },
                values: new object[,]
                {
                    { 28, "Samsung", 1000, "Samsung 970 EVO Plus 1TB NVMe M.2 Gen 3", "Storage", "M.2 Gen 3.0", "https://computerlounge.co.nz/cdn/shop/files/b7cbb4b89b9aebffd4ffc0f5403298372463901d_32488_3.jpg?v=1720997560&width=1214", "970 EVO Plus", 855.0, "NVMe", "PCIe" },
                    { 29, "Western Digital", 4000, "WD Blue 3D NAND 4TB SSD 2.5\" and M.2 2280", "Storage", "2.5 and M.2 2280", "https://ksp.co.il/shop/items/512/328843.jpg", "Blue 3D NAND", 3447.0, "SSD", "SATA" },
                    { 30, "Seagate", 24000, "Seagate Barracuda 24TB HDD 3.5\" with SATA interface", "Storage", "3.5", "https://www.seagate.com/content/dam/seagate/assets/products/hard-drives/barracuda-3-5-hdd/images/barracuda-24TB-right.png/_jcr_content/renditions/1-1-large-640x640.png", "Barracuda", 2989.0, "HDD", "SATA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
