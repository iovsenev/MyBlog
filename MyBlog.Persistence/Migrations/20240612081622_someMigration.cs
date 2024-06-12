using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBlog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class someMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "+79998887766");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_email",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "phone_number",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "+79998887766",
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
