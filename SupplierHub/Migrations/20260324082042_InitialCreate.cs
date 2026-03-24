using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplierHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsnItems_PLines_PoLineID",
                table: "AsnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GrnItemRefs_PLines_PoLineID",
                table: "GrnItemRefs");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_PLines_PoLineID",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PLines_Items_ItemID",
                table: "PLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PLines_PurchaseOrders_PoID",
                table: "PLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Userroles_Roles_RoleID",
                table: "Userroles");

            migrationBuilder.DropForeignKey(
                name: "FK_Userroles_Users_UserID",
                table: "Userroles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userroles",
                table: "Userroles");

            migrationBuilder.DropIndex(
                name: "IX_Userroles_RoleID",
                table: "Userroles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PLines",
                table: "PLines");

            migrationBuilder.RenameTable(
                name: "Userroles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "PLines",
                newName: "PoLine");

            migrationBuilder.RenameIndex(
                name: "IX_PLines_PoID",
                table: "PoLine",
                newName: "IX_PoLine_PoID");

            migrationBuilder.RenameIndex(
                name: "IX_PLines_ItemID",
                table: "PoLine",
                newName: "IX_PoLine_ItemID");

            migrationBuilder.AddColumn<string>(
                name: "UserRoles",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "OPEN",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Open");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PoRevisions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "ACTIVE",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Active");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PoAcks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "ACTIVE",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Active");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ErpExportRefs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "QUEUED",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Queued");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PoLine",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "ACTIVE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoLine",
                table: "PoLine",
                column: "PoLineID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID_RoleID",
                table: "UserRoles",
                columns: new[] { "UserID", "RoleID" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AsnItems_PoLine_PoLineID",
                table: "AsnItems",
                column: "PoLineID",
                principalTable: "PoLine",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrnItemRefs_PoLine_PoLineID",
                table: "GrnItemRefs",
                column: "PoLineID",
                principalTable: "PoLine",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_PoLine_PoLineID",
                table: "InvoiceLines",
                column: "PoLineID",
                principalTable: "PoLine",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoLine_Items_ItemID",
                table: "PoLine",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PoLine_PurchaseOrders_PoID",
                table: "PoLine",
                column: "PoID",
                principalTable: "PurchaseOrders",
                principalColumn: "PoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleID",
                table: "UserRoles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserID",
                table: "UserRoles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AsnItems_PoLine_PoLineID",
                table: "AsnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_GrnItemRefs_PoLine_PoLineID",
                table: "GrnItemRefs");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceLines_PoLine_PoLineID",
                table: "InvoiceLines");

            migrationBuilder.DropForeignKey(
                name: "FK_PoLine_Items_ItemID",
                table: "PoLine");

            migrationBuilder.DropForeignKey(
                name: "FK_PoLine_PurchaseOrders_PoID",
                table: "PoLine");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleID",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserID",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserRoles_UserID_RoleID",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoLine",
                table: "PoLine");

            migrationBuilder.DropColumn(
                name: "UserRoles",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "Userroles");

            migrationBuilder.RenameTable(
                name: "PoLine",
                newName: "PLines");

            migrationBuilder.RenameIndex(
                name: "IX_PoLine_PoID",
                table: "PLines",
                newName: "IX_PLines_PoID");

            migrationBuilder.RenameIndex(
                name: "IX_PoLine_ItemID",
                table: "PLines",
                newName: "IX_PLines_ItemID");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PurchaseOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Open",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "OPEN");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PoRevisions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "ACTIVE");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PoAcks",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "ACTIVE");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ErpExportRefs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "Queued",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "QUEUED");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PLines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "ACTIVE",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldDefaultValue: "Active");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userroles",
                table: "Userroles",
                columns: new[] { "UserID", "RoleID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PLines",
                table: "PLines",
                column: "PoLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Userroles_RoleID",
                table: "Userroles",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_AsnItems_PLines_PoLineID",
                table: "AsnItems",
                column: "PoLineID",
                principalTable: "PLines",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GrnItemRefs_PLines_PoLineID",
                table: "GrnItemRefs",
                column: "PoLineID",
                principalTable: "PLines",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceLines_PLines_PoLineID",
                table: "InvoiceLines",
                column: "PoLineID",
                principalTable: "PLines",
                principalColumn: "PoLineID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PLines_Items_ItemID",
                table: "PLines",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PLines_PurchaseOrders_PoID",
                table: "PLines",
                column: "PoID",
                principalTable: "PurchaseOrders",
                principalColumn: "PoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Userroles_Roles_RoleID",
                table: "Userroles",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Userroles_Users_UserID",
                table: "Userroles",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
