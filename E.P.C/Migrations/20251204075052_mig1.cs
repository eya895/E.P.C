using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E.P.C.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    BaseClock = table.Column<float>(type: "real", nullable: true),
                    CPU_BoostClock = table.Column<float>(type: "real", nullable: true),
                    CPU_SocketType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUFan_Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUFan_Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUFan_Size = table.Column<int>(type: "int", nullable: true),
                    CPUFan_RPM = table.Column<int>(type: "int", nullable: true),
                    CPUFan_Airflow = table.Column<int>(type: "int", nullable: true),
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
                    GPU_Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
