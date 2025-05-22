using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MediaLibrary.Persistence.Migrations.Identity
{
    /// <inheritdoc />
    public partial class ChangeList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17fbfd84-8481-434a-9587-33dc2b2b70db", null, "Moderator", "MODERATOR" },
                    { "3078d0cf-c876-405b-a462-1dda74b1aa2a", null, "Admin", "ADMIN" },
                    { "3cc4c461-5d11-4aa2-a28e-428edef94f58", null, "Basic", "BASIC" },
                    { "3d775370-33c8-4297-a4a2-b1ec1034b25a", null, "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02198c15-1360-43ad-b691-52060b64f6fa", 0, "b208a660-fa40-46ea-af75-af2fc8feb372", "basicuser@gmail.com", true, "Basic", "User", false, null, "BASICUSER@GMAIL.COM", "BASICUSER", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "37637ce6-8848-4be3-aca2-e2ca159fc79e", false, "basicuser" },
                    { "5bd5730b-dd98-4182-929b-35f1fa8de8fd", 0, "6573b420-7f2b-4d6e-ab18-e58d064956a5", "superadmin@gmail.com", true, "Amit", "Naik", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, "5e0cc719-6632-4e3d-927d-29ca05bd0bc6", false, "superadmin" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "3cc4c461-5d11-4aa2-a28e-428edef94f58", "02198c15-1360-43ad-b691-52060b64f6fa" },
                    { "17fbfd84-8481-434a-9587-33dc2b2b70db", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" },
                    { "3078d0cf-c876-405b-a462-1dda74b1aa2a", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" },
                    { "3cc4c461-5d11-4aa2-a28e-428edef94f58", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" },
                    { "3d775370-33c8-4297-a4a2-b1ec1034b25a", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cc4c461-5d11-4aa2-a28e-428edef94f58", "02198c15-1360-43ad-b691-52060b64f6fa" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "17fbfd84-8481-434a-9587-33dc2b2b70db", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3078d0cf-c876-405b-a462-1dda74b1aa2a", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3cc4c461-5d11-4aa2-a28e-428edef94f58", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d775370-33c8-4297-a4a2-b1ec1034b25a", "5bd5730b-dd98-4182-929b-35f1fa8de8fd" });

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "17fbfd84-8481-434a-9587-33dc2b2b70db");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3078d0cf-c876-405b-a462-1dda74b1aa2a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3cc4c461-5d11-4aa2-a28e-428edef94f58");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Role",
                keyColumn: "Id",
                keyValue: "3d775370-33c8-4297-a4a2-b1ec1034b25a");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "02198c15-1360-43ad-b691-52060b64f6fa");

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: "5bd5730b-dd98-4182-929b-35f1fa8de8fd");

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
    }
}
