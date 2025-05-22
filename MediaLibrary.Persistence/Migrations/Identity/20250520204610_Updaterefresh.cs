using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaLibrary.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class Updaterefresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9295aa0-4ac9-4a91-8019-8de331857eb0", "a16c7f85-e18c-44f6-9cb6-00798c506237" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3491c30f-b365-4275-91bf-ee0e6f395307", "c61b3828-60c9-438c-af59-5e95c71c00ee" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6857926a-5164-4c23-87ad-cc03187a25fe", "c61b3828-60c9-438c-af59-5e95c71c00ee" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9295aa0-4ac9-4a91-8019-8de331857eb0", "c61b3828-60c9-438c-af59-5e95c71c00ee" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f4403049-671b-45ce-80be-70c945479143", "c61b3828-60c9-438c-af59-5e95c71c00ee" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3491c30f-b365-4275-91bf-ee0e6f395307");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "6857926a-5164-4c23-87ad-cc03187a25fe");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "c9295aa0-4ac9-4a91-8019-8de331857eb0");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "f4403049-671b-45ce-80be-70c945479143");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "a16c7f85-e18c-44f6-9cb6-00798c506237");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "c61b3828-60c9-438c-af59-5e95c71c00ee");

            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByIp",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "79787805-ed59-4805-8964-3e4f5cfb1c9a", null, "SuperAdmin", "SUPERADMIN" },
                    { "85d477a2-b37d-4e9d-838f-928657457150", null, "Moderator", "MODERATOR" },
                    { "bc628d03-4014-48a1-bbd0-4989e4197898", null, "Basic", "BASIC" },
                    { "da03c27c-dae3-46d3-97c7-b9bd8e37622d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "001b8490-1891-4c84-bfb0-50cd29cf88fe", 0, "8bf5b7c4-10cc-4731-b806-13c301f2f9ed", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "2721c8d5-ab97-4e1d-9763-1b5c3fdf695a", false, "basicuser" },
                    { "5e3d284e-7834-477c-9580-6d79d983e50e", 0, "80272a57-c868-452b-a81a-b06defb9fe07", "superadmin@gmail.com", true, "Amit", "Naik", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "4da824c3-1c44-496c-addc-95d6b43b0989", false, "superadmin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "bc628d03-4014-48a1-bbd0-4989e4197898", "001b8490-1891-4c84-bfb0-50cd29cf88fe" },
                    { "79787805-ed59-4805-8964-3e4f5cfb1c9a", "5e3d284e-7834-477c-9580-6d79d983e50e" },
                    { "85d477a2-b37d-4e9d-838f-928657457150", "5e3d284e-7834-477c-9580-6d79d983e50e" },
                    { "bc628d03-4014-48a1-bbd0-4989e4197898", "5e3d284e-7834-477c-9580-6d79d983e50e" },
                    { "da03c27c-dae3-46d3-97c7-b9bd8e37622d", "5e3d284e-7834-477c-9580-6d79d983e50e" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc628d03-4014-48a1-bbd0-4989e4197898", "001b8490-1891-4c84-bfb0-50cd29cf88fe" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "79787805-ed59-4805-8964-3e4f5cfb1c9a", "5e3d284e-7834-477c-9580-6d79d983e50e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "85d477a2-b37d-4e9d-838f-928657457150", "5e3d284e-7834-477c-9580-6d79d983e50e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bc628d03-4014-48a1-bbd0-4989e4197898", "5e3d284e-7834-477c-9580-6d79d983e50e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da03c27c-dae3-46d3-97c7-b9bd8e37622d", "5e3d284e-7834-477c-9580-6d79d983e50e" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "79787805-ed59-4805-8964-3e4f5cfb1c9a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "85d477a2-b37d-4e9d-838f-928657457150");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "bc628d03-4014-48a1-bbd0-4989e4197898");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "da03c27c-dae3-46d3-97c7-b9bd8e37622d");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "001b8490-1891-4c84-bfb0-50cd29cf88fe");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "5e3d284e-7834-477c-9580-6d79d983e50e");

            migrationBuilder.AlterColumn<string>(
                name: "RevokedByIp",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReplacedByToken",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByIp",
                schema: "Identity",
                table: "RefreshToken",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3491c30f-b365-4275-91bf-ee0e6f395307", null, "SuperAdmin", "SuperAdmin" },
                    { "6857926a-5164-4c23-87ad-cc03187a25fe", null, "Moderator", "Moderator" },
                    { "c9295aa0-4ac9-4a91-8019-8de331857eb0", null, "Basic", "Basic" },
                    { "f4403049-671b-45ce-80be-70c945479143", null, "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a16c7f85-e18c-44f6-9cb6-00798c506237", 0, "f992e4b2-2fb0-4122-9f62-e03266c8ea53", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "d5e40a6f-53a3-4ada-a02c-cfed814bee89", false, "basicuser" },
                    { "c61b3828-60c9-438c-af59-5e95c71c00ee", 0, "8b4d761f-1525-47d7-9da9-8d01b83d4abe", "superadmin@gmail.com", true, "Amit", "Naik", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "48dbf3e4-c8f8-4ceb-8b9e-ff2a28111790", false, "superadmin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c9295aa0-4ac9-4a91-8019-8de331857eb0", "a16c7f85-e18c-44f6-9cb6-00798c506237" },
                    { "3491c30f-b365-4275-91bf-ee0e6f395307", "c61b3828-60c9-438c-af59-5e95c71c00ee" },
                    { "6857926a-5164-4c23-87ad-cc03187a25fe", "c61b3828-60c9-438c-af59-5e95c71c00ee" },
                    { "c9295aa0-4ac9-4a91-8019-8de331857eb0", "c61b3828-60c9-438c-af59-5e95c71c00ee" },
                    { "f4403049-671b-45ce-80be-70c945479143", "c61b3828-60c9-438c-af59-5e95c71c00ee" }
                });
        }
    }
}
