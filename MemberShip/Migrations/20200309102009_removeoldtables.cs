using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberShip.Migrations
{
    public partial class removeoldtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderDetails_AppOrders_OrderId",
                table: "AppOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrderDetails_AppProducts_ProductId",
                table: "AppOrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AspNetUsers_CashierId",
                table: "AppOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AppCustomers_CustomerId",
                table: "AppOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppProducts_ParentId",
                table: "AppProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_AppProducts_AppProductCategories_ProductCategoryId",
                table: "AppProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProducts",
                table: "AppProducts");

            migrationBuilder.DropIndex(
                name: "IX_AppProducts_Name",
                table: "AppProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppProductCategories",
                table: "AppProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrders",
                table: "AppOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppOrderDetails",
                table: "AppOrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers");

            migrationBuilder.DropIndex(
                name: "IX_AppCustomers_Name",
                table: "AppCustomers");

            migrationBuilder.RenameTable(
                name: "AppProducts",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "AppProductCategories",
                newName: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "AppOrders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "AppOrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "AppCustomers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_AppProducts_ProductCategoryId",
                table: "Product",
                newName: "IX_Product_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AppProducts_ParentId",
                table: "Product",
                newName: "IX_Product_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrders_CustomerId",
                table: "Order",
                newName: "IX_Order_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrders_CashierId",
                table: "Order",
                newName: "IX_Order_CashierId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrderDetails_ProductId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_AppOrderDetails_OrderId",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Product",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ProductCategory",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Order",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Customer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_CashierId",
                table: "Order",
                column: "CashierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Product_ParentId",
                table: "Product",
                column: "ParentId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product",
                column: "ProductCategoryId",
                principalTable: "ProductCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_CashierId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Product_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Product_ParentId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "AppProductCategories");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "AppProducts");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "AppOrderDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "AppOrders");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "AppCustomers");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductCategoryId",
                table: "AppProducts",
                newName: "IX_AppProducts_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ParentId",
                table: "AppProducts",
                newName: "IX_AppProducts_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ProductId",
                table: "AppOrderDetails",
                newName: "IX_AppOrderDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderId",
                table: "AppOrderDetails",
                newName: "IX_AppOrderDetails_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerId",
                table: "AppOrders",
                newName: "IX_AppOrders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CashierId",
                table: "AppOrders",
                newName: "IX_AppOrders_CashierId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppProductCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppProductCategories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppProducts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "AppProducts",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AppProducts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "AppOrders",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AppCustomers",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AppCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AppCustomers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AppCustomers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProductCategories",
                table: "AppProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppProducts",
                table: "AppProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrderDetails",
                table: "AppOrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppOrders",
                table: "AppOrders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppCustomers",
                table: "AppCustomers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AppProducts_Name",
                table: "AppProducts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AppCustomers_Name",
                table: "AppCustomers",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderDetails_AppOrders_OrderId",
                table: "AppOrderDetails",
                column: "OrderId",
                principalTable: "AppOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrderDetails_AppProducts_ProductId",
                table: "AppOrderDetails",
                column: "ProductId",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AspNetUsers_CashierId",
                table: "AppOrders",
                column: "CashierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AppCustomers_CustomerId",
                table: "AppOrders",
                column: "CustomerId",
                principalTable: "AppCustomers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppProducts_ParentId",
                table: "AppProducts",
                column: "ParentId",
                principalTable: "AppProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppProducts_AppProductCategories_ProductCategoryId",
                table: "AppProducts",
                column: "ProductCategoryId",
                principalTable: "AppProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
