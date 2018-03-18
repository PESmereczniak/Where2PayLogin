using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Where2PayLogin.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UsersBillerInfo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersBillerInfo_BillerID",
                table: "UsersBillerInfo",
                column: "BillerID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersBillerInfo_UserId1",
                table: "UsersBillerInfo",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBillerInfo_Billers_BillerID",
                table: "UsersBillerInfo",
                column: "BillerID",
                principalTable: "Billers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBillerInfo_AspNetUsers_UserId1",
                table: "UsersBillerInfo",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBillerInfo_Billers_BillerID",
                table: "UsersBillerInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersBillerInfo_AspNetUsers_UserId1",
                table: "UsersBillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersBillerInfo_BillerID",
                table: "UsersBillerInfo");

            migrationBuilder.DropIndex(
                name: "IX_UsersBillerInfo_UserId1",
                table: "UsersBillerInfo");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UsersBillerInfo");
        }
    }
}
