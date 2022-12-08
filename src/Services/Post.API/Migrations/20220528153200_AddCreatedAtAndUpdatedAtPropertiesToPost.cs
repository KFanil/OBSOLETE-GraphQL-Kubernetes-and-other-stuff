using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.API.Migrations
{
    public partial class AddCreatedAtAndUpdatedAtPropertiesToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created_At",
                table: "Posts",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Updated_At",
                table: "Posts",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created_At",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Updated_At",
                table: "Posts");
        }
    }
}
