using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Project_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TablesImplementaion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goverments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goverments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gov_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Goverments_Gov_Id",
                        column: x => x.Gov_Id,
                        principalTable: "Goverments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MG_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGroups_MainGroups_MG_Id",
                        column: x => x.MG_Id,
                        principalTable: "MainGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gov_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zones_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Zones_Goverments_Gov_Id",
                        column: x => x.Gov_Id,
                        principalTable: "Goverments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subGroups2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sub_Id = table.Column<int>(type: "int", nullable: false),
                    MG_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subGroups2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subGroups2_MainGroups_MG_Id",
                        column: x => x.MG_Id,
                        principalTable: "MainGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subGroups2_SubGroups_Sub_Id",
                        column: x => x.Sub_Id,
                        principalTable: "SubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gov_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Zone_Id = table.Column<int>(type: "int", nullable: false),
                    Class_Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Classifications_Class_Id",
                        column: x => x.Class_Id,
                        principalTable: "Classifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Goverments_Gov_Id",
                        column: x => x.Gov_Id,
                        principalTable: "Goverments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Zones_Zone_Id",
                        column: x => x.Zone_Id,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gov_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Zone_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stores_Goverments_Gov_Id",
                        column: x => x.Gov_Id,
                        principalTable: "Goverments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stores_Zones_Zone_Id",
                        column: x => x.Zone_Id,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    MG_Id = table.Column<int>(type: "int", nullable: false),
                    Sub_Id = table.Column<int>(type: "int", nullable: false),
                    Sub2_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_MainGroups_MG_Id",
                        column: x => x.MG_Id,
                        principalTable: "MainGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_SubGroups_Sub_Id",
                        column: x => x.Sub_Id,
                        principalTable: "SubGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_subGroups2_Sub2_Id",
                        column: x => x.Sub2_Id,
                        principalTable: "subGroups2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NetPrice = table.Column<double>(type: "float", nullable: false),
                    Transaction_Types = table.Column<int>(type: "int", nullable: false),
                    Payment_Type = table.Column<int>(type: "int", nullable: false),
                    IsPosted = table.Column<bool>(type: "bit", nullable: false),
                    IsReviewed = table.Column<bool>(type: "bit", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_AspNetUsers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomersStores",
                columns: table => new
                {
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersStores", x => new { x.Store_Id, x.Cus_Id });
                    table.ForeignKey(
                        name: "FK_CustomersStores_AspNetUsers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomersStores_Stores_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invItemStores",
                columns: table => new
                {
                    Store_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    ReservedQuantity = table.Column<double>(type: "float", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invItemStores", x => new { x.Store_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_invItemStores_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invItemStores_Stores_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemsUnits",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsUnits", x => new { x.Unit_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_ItemsUnits_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsUnits_Units_Unit_Id",
                        column: x => x.Unit_Id,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Cus_Id = table.Column<int>(type: "int", nullable: false),
                    Store_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => new { x.Store_Id, x.Item_Id, x.Cus_Id });
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_AspNetUsers_Cus_Id",
                        column: x => x.Cus_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Stores_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoiceDetails",
                columns: table => new
                {
                    Invoice_Id = table.Column<int>(type: "int", nullable: false),
                    Item_Id = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Unit_Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Factor = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoiceDetails", x => new { x.Invoice_Id, x.Item_Id });
                    table.ForeignKey(
                        name: "FK_invoiceDetails_Invoice_Invoice_Id",
                        column: x => x.Invoice_Id,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoiceDetails_Items_Item_Id",
                        column: x => x.Item_Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_City_Id",
                table: "AspNetUsers",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Class_Id",
                table: "AspNetUsers",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Gov_Id",
                table: "AspNetUsers",
                column: "Gov_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Zone_Id",
                table: "AspNetUsers",
                column: "Zone_Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Gov_Id",
                table: "Cities",
                column: "Gov_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomersStores_Cus_Id",
                table: "CustomersStores",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_invItemStores_Item_Id",
                table: "invItemStores",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Cus_Id",
                table: "Invoice",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_invoiceDetails_Item_Id",
                table: "invoiceDetails",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MG_Id",
                table: "Items",
                column: "MG_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Sub_Id",
                table: "Items",
                column: "Sub_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Sub2_Id",
                table: "Items",
                column: "Sub2_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsUnits_Item_Id",
                table: "ItemsUnits",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Cus_Id",
                table: "ShoppingCartItems",
                column: "Cus_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_Item_Id",
                table: "ShoppingCartItems",
                column: "Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_City_Id",
                table: "Stores",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Gov_Id",
                table: "Stores",
                column: "Gov_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Zone_Id",
                table: "Stores",
                column: "Zone_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubGroups_MG_Id",
                table: "SubGroups",
                column: "MG_Id");

            migrationBuilder.CreateIndex(
                name: "IX_subGroups2_MG_Id",
                table: "subGroups2",
                column: "MG_Id");

            migrationBuilder.CreateIndex(
                name: "IX_subGroups2_Sub_Id",
                table: "subGroups2",
                column: "Sub_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_City_Id",
                table: "Zones",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Gov_Id",
                table: "Zones",
                column: "Gov_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomersStores");

            migrationBuilder.DropTable(
                name: "invItemStores");

            migrationBuilder.DropTable(
                name: "invoiceDetails");

            migrationBuilder.DropTable(
                name: "ItemsUnits");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "subGroups2");

            migrationBuilder.DropTable(
                name: "Classifications");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "SubGroups");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "MainGroups");

            migrationBuilder.DropTable(
                name: "Goverments");
        }
    }
}
