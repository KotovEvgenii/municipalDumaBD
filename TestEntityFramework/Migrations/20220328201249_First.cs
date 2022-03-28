using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestEntityFramework.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "f_comission",
                columns: table => new
                {
                    f_comission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_f_comission", x => x.f_comission);
                });

            migrationBuilder.CreateTable(
                name: "f_person",
                columns: table => new
                {
                    f_person = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_f_person", x => x.f_person);
                });

            migrationBuilder.CreateTable(
                name: "f_meeting",
                columns: table => new
                {
                    f_meeting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_comission = table.Column<int>(type: "int", nullable: false),
                    date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    place = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_f_meeting", x => x.f_meeting);
                    table.ForeignKey(
                        name: "fk_f_meet_f_comission",
                        column: x => x.f_comission,
                        principalTable: "f_comission",
                        principalColumn: "f_comission",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "l_comission_person",
                columns: table => new
                {
                    l_comission_person = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_comission = table.Column<int>(type: "int", nullable: false),
                    f_person = table.Column<int>(type: "int", nullable: false),
                    stat = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    stat_main = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    date_begin = table.Column<DateTime>(type: "datetime", nullable: true),
                    date_end = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_l_comission_person", x => x.l_comission_person);
                    table.ForeignKey(
                        name: "fk_lcp_f_comission",
                        column: x => x.f_comission,
                        principalTable: "f_comission",
                        principalColumn: "f_comission",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_lcp_f_person",
                        column: x => x.f_person,
                        principalTable: "f_person",
                        principalColumn: "f_person",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "l_meeting_work",
                columns: table => new
                {
                    l_meeting_work = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    f_meeting = table.Column<int>(type: "int", nullable: false),
                    f_person = table.Column<int>(type: "int", nullable: false),
                    isAbsent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_l_meeting_work", x => x.l_meeting_work);
                    table.ForeignKey(
                        name: "fk_l_meet_work_f_meeting",
                        column: x => x.f_meeting,
                        principalTable: "f_meeting",
                        principalColumn: "f_meeting",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_l_meet_work_f_person",
                        column: x => x.f_person,
                        principalTable: "f_person",
                        principalColumn: "f_person",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_f_meeting_f_comission",
                table: "f_meeting",
                column: "f_comission");

            migrationBuilder.CreateIndex(
                name: "IX_l_comission_person_f_comission",
                table: "l_comission_person",
                column: "f_comission");

            migrationBuilder.CreateIndex(
                name: "IX_l_comission_person_f_person",
                table: "l_comission_person",
                column: "f_person");

            migrationBuilder.CreateIndex(
                name: "IX_l_meeting_work_f_meeting",
                table: "l_meeting_work",
                column: "f_meeting");

            migrationBuilder.CreateIndex(
                name: "IX_l_meeting_work_f_person",
                table: "l_meeting_work",
                column: "f_person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "l_comission_person");

            migrationBuilder.DropTable(
                name: "l_meeting_work");

            migrationBuilder.DropTable(
                name: "f_meeting");

            migrationBuilder.DropTable(
                name: "f_person");

            migrationBuilder.DropTable(
                name: "f_comission");
        }
    }
}
