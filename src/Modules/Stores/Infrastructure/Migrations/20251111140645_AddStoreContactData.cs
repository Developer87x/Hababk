using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hababk.Modules.Stores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreContactData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "Store",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    ContactEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ContactPhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.StoreId);
                    table.ForeignKey(
                        name: "FK_Contacts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Store",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "Store");
        }
    }
}
