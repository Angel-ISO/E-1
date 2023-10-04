using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameRol = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descRol = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id_Rol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameUser = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersRols",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRols", x => new { x.UserId, x.RolId });
                    table.ForeignKey(
                        name: "FK_UsersRols_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id_Rol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRols_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Id_Rol", "descRol", "NameRol" },
                values: new object[,]
                {
                    { 1, "Rol de administrador", "Admin" },
                    { 2, "Gestor de administracion", "Gerente" },
                    { 3, "Asalariado de la empresa", "Empleado" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_User", "Email", "NameUser", "Password" },
                values: new object[,]
                {
                    { 1, "angel@gmail.com", "Angel", "1234" },
                    { 2, "sofia@gmail.com", "sofia", "1234" },
                    { 3, "lucia@gmail.com", "lucia", "1234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRols_RolId",
                table: "UsersRols",
                column: "RolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRols");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
