using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hababk.Modules.Stores.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LowerTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Stores_StoreId",
                schema: "Store",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                schema: "Store",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                schema: "Store",
                table: "Contacts");

            migrationBuilder.EnsureSchema(
                name: "store");

            migrationBuilder.RenameTable(
                name: "Stores",
                schema: "Store",
                newName: "stores",
                newSchema: "store");

            migrationBuilder.RenameTable(
                name: "Contacts",
                schema: "Store",
                newName: "contacts",
                newSchema: "store");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "store",
                table: "stores",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "StoreName",
                schema: "store",
                table: "stores",
                newName: "storename");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "store",
                table: "stores",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ContactPhoneNumber",
                schema: "store",
                table: "contacts",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                schema: "store",
                table: "contacts",
                newName: "email");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "store",
                table: "stores",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "id",
                schema: "store",
                table: "stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contacts",
                schema: "store",
                table: "contacts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_stores_StoreId",
                schema: "store",
                table: "contacts",
                column: "StoreId",
                principalSchema: "store",
                principalTable: "stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contacts_stores_StoreId",
                schema: "store",
                table: "contacts");

            migrationBuilder.DropPrimaryKey(
                name: "id",
                schema: "store",
                table: "stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contacts",
                schema: "store",
                table: "contacts");

            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.RenameTable(
                name: "stores",
                schema: "store",
                newName: "Stores",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "contacts",
                schema: "store",
                newName: "Contacts",
                newSchema: "Store");

            migrationBuilder.RenameColumn(
                name: "userId",
                schema: "Store",
                table: "Stores",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "storename",
                schema: "Store",
                table: "Stores",
                newName: "StoreName");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "Store",
                table: "Stores",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "phonenumber",
                schema: "Store",
                table: "Contacts",
                newName: "ContactPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "email",
                schema: "Store",
                table: "Contacts",
                newName: "ContactEmail");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Store",
                table: "Stores",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                schema: "Store",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                schema: "Store",
                table: "Contacts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Stores_StoreId",
                schema: "Store",
                table: "Contacts",
                column: "StoreId",
                principalSchema: "Store",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
