using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class apdinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "apd_approvalConfigurations",
                columns: table => new
                {
                    ApprovalConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalConfigurations", x => x.ApprovalConfigurationId);
                });

            migrationBuilder.CreateTable(
                name: "apd_approvalDefinitions",
                columns: table => new
                {
                    ApprovalDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalDefinitions", x => x.ApprovalDefinitionId);
                });

            migrationBuilder.CreateTable(
                name: "apd_approvalDocuments",
                columns: table => new
                {
                    ApprovalDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalDocuments", x => x.ApprovalDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "apd_workFlowIndexes",
                columns: table => new
                {
                    WorkFlowIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowIndex = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_workFlowIndexes", x => x.WorkFlowIndexId);
                });

            migrationBuilder.CreateTable(
                name: "apd_workFlowUsers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_workFlowUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "apd_definitionValues",
                columns: table => new
                {
                    DefinitionValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_definitionValues", x => x.DefinitionValueId);
                    table.ForeignKey(
                        name: "FK_apd_definitionValues_apd_approvalDefinitions_ApprovalDefinitionId",
                        column: x => x.ApprovalDefinitionId,
                        principalTable: "apd_approvalDefinitions",
                        principalColumn: "ApprovalDefinitionId");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalConfigurationsApprovalDocuments",
                columns: table => new
                {
                    ApprovalConfigurationsApprovalConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalDocumentsApprovalDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalConfigurationsApprovalDocuments", x => new { x.ApprovalConfigurationsApprovalConfigurationId, x.ApprovalDocumentsApprovalDocumentId });
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDocuments_apd_approvalConfigurations_ApprovalConfigurationsApprovalConfigurationId",
                        column: x => x.ApprovalConfigurationsApprovalConfigurationId,
                        principalTable: "apd_approvalConfigurations",
                        principalColumn: "ApprovalConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDocuments_apd_approvalDocuments_ApprovalDocumentsApprovalDocumentId",
                        column: x => x.ApprovalDocumentsApprovalDocumentId,
                        principalTable: "apd_approvalDocuments",
                        principalColumn: "ApprovalDocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apd_approvalDestinations",
                columns: table => new
                {
                    ApprovalDestination = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkFlowIndexeWorkFlowIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalDestinations", x => x.ApprovalDestination);
                    table.ForeignKey(
                        name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexeWorkFlowIndexId",
                        column: x => x.WorkFlowIndexeWorkFlowIndexId,
                        principalTable: "apd_workFlowIndexes",
                        principalColumn: "WorkFlowIndexId");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalConfigurationsDefinitionValues",
                columns: table => new
                {
                    ApprovalConfigurationsApprovalConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefinitionValuesDefinitionValueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalConfigurationsDefinitionValues", x => new { x.ApprovalConfigurationsApprovalConfigurationId, x.DefinitionValuesDefinitionValueId });
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsDefinitionValues_apd_approvalConfigurations_ApprovalConfigurationsApprovalConfigurationId",
                        column: x => x.ApprovalConfigurationsApprovalConfigurationId,
                        principalTable: "apd_approvalConfigurations",
                        principalColumn: "ApprovalConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsDefinitionValues_apd_definitionValues_DefinitionValuesDefinitionValueId",
                        column: x => x.DefinitionValuesDefinitionValueId,
                        principalTable: "apd_definitionValues",
                        principalColumn: "DefinitionValueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalConfigurationsApprovalDestinations",
                columns: table => new
                {
                    ApprovalConfigurationsApprovalConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalDestinationsApprovalDestination = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalConfigurationsApprovalDestinations", x => new { x.ApprovalConfigurationsApprovalConfigurationId, x.ApprovalDestinationsApprovalDestination });
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalConfigurations_ApprovalConfigurationsApprovalConfigurationId",
                        column: x => x.ApprovalConfigurationsApprovalConfigurationId,
                        principalTable: "apd_approvalConfigurations",
                        principalColumn: "ApprovalConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                        column: x => x.ApprovalDestinationsApprovalDestination,
                        principalTable: "apd_approvalDestinations",
                        principalColumn: "ApprovalDestination",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalDestinationsWorkFlowUsers",
                columns: table => new
                {
                    ApprovalDestinationsApprovalDestination = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDestinationsWorkFlowUsers", x => new { x.ApprovalDestinationsApprovalDestination, x.WorkFlowUsersUserId });
                    table.ForeignKey(
                        name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestination",
                        column: x => x.ApprovalDestinationsApprovalDestination,
                        principalTable: "apd_approvalDestinations",
                        principalColumn: "ApprovalDestination",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalDestinationsWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexeWorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexeWorkFlowIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_definitionValues_ApprovalDefinitionId",
                table: "apd_definitionValues",
                column: "ApprovalDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestination",
                table: "ApprovalConfigurationsApprovalDestinations",
                column: "ApprovalDestinationsApprovalDestination");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalConfigurationsApprovalDocuments_ApprovalDocumentsApprovalDocumentId",
                table: "ApprovalConfigurationsApprovalDocuments",
                column: "ApprovalDocumentsApprovalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalConfigurationsDefinitionValues_DefinitionValuesDefinitionValueId",
                table: "ApprovalConfigurationsDefinitionValues",
                column: "DefinitionValuesDefinitionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalDestinationsWorkFlowUsers_WorkFlowUsersUserId",
                table: "ApprovalDestinationsWorkFlowUsers",
                column: "WorkFlowUsersUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsApprovalDestinations");

            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsApprovalDocuments");

            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsDefinitionValues");

            migrationBuilder.DropTable(
                name: "ApprovalDestinationsWorkFlowUsers");

            migrationBuilder.DropTable(
                name: "apd_approvalDocuments");

            migrationBuilder.DropTable(
                name: "apd_approvalConfigurations");

            migrationBuilder.DropTable(
                name: "apd_definitionValues");

            migrationBuilder.DropTable(
                name: "apd_approvalDestinations");

            migrationBuilder.DropTable(
                name: "apd_workFlowUsers");

            migrationBuilder.DropTable(
                name: "apd_approvalDefinitions");

            migrationBuilder.DropTable(
                name: "apd_workFlowIndexes");
        }
    }
}
