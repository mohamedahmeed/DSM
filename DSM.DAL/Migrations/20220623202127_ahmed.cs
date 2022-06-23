using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DSM.DAL.Migrations
{
    public partial class ahmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_screens_branches_BranchId",
                table: "screens");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "screens",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_screens_branches_BranchId",
                table: "screens",
                column: "BranchId",
                principalTable: "branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_screens_branches_BranchId",
                table: "screens");

            migrationBuilder.AlterColumn<Guid>(
                name: "BranchId",
                table: "screens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_screens_branches_BranchId",
                table: "screens",
                column: "BranchId",
                principalTable: "branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
