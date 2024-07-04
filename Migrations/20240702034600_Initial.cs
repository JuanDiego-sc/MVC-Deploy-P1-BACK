using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniCoreEnriqueMerizalde.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id_Empleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_Empleado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id_Empleado);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id_Proyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Proyecto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id_Proyecto);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id_Tarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_EmpleadoV = table.Column<int>(type: "int", nullable: false),
                    Id_ProyectoV = table.Column<int>(type: "int", nullable: false),
                    Descripcion_Tarea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Inicio_Tarea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tiempo_Estimado_Tarea = table.Column<int>(type: "int", nullable: false),
                    Estado_Tarea = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id_Tarea);
                    table.ForeignKey(
                        name: "FK_Tareas_Empleados_Id_EmpleadoV",
                        column: x => x.Id_EmpleadoV,
                        principalTable: "Empleados",
                        principalColumn: "Id_Empleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_Id_ProyectoV",
                        column: x => x.Id_ProyectoV,
                        principalTable: "Proyectos",
                        principalColumn: "Id_Proyecto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Id_EmpleadoV",
                table: "Tareas",
                column: "Id_EmpleadoV");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Id_ProyectoV",
                table: "Tareas",
                column: "Id_ProyectoV");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
