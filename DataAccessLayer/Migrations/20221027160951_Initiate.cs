using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class Initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ap_approvalPathUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_approvalPathUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ap_registeredDocuments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_registeredDocuments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ap_userSetsToNotify",
                columns: table => new
                {
                    NotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_userSetsToNotify", x => x.NotifyUserSetId);
                });

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
                name: "AuthenticationADAssignedGroups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ADGroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationADAssignedGroups", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimGroups",
                columns: table => new
                {
                    ClaimGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimGroups", x => x.ClaimGroupId);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Claim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationHttpMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationHttpMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationUserClaimsHolders",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationUserClaimsHolders", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "OperationLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReFaRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedFor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReFaRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SampleTodos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleTodos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapPlants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapPlants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SapWorkContracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapWorkContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VS_Employees_1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SapNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostCenterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnitID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationalUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VS_Employees_1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingShift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ap_approvalRequests",
                columns: table => new
                {
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    approvalPathUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    registeredDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPending = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_approvalRequests", x => x.ApprovalRequestId);
                    table.ForeignKey(
                        name: "FK_ap_approvalRequests_ap_approvalPathUsers_approvalPathUserId",
                        column: x => x.approvalPathUserId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ap_approvalRequests_ap_registeredDocuments_registeredDocumentId",
                        column: x => x.registeredDocumentId,
                        principalTable: "ap_registeredDocuments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ap_userBased_Configs",
                columns: table => new
                {
                    Conf_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    approvalPathUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RegisteredDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_userBased_Configs", x => x.Conf_Id);
                    table.ForeignKey(
                        name: "FK_ap_userBased_Configs_ap_approvalPathUsers_approvalPathUserId",
                        column: x => x.approvalPathUserId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ap_userBased_Configs_ap_registeredDocuments_RegisteredDocumentId",
                        column: x => x.RegisteredDocumentId,
                        principalTable: "ap_registeredDocuments",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ap_approvalFlowOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowNumber = table.Column<int>(type: "int", nullable: false),
                    notifiedUserSetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ap_approvalFlowOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ap_approvalFlowOrder_ap_userSetsToNotify_notifiedUserSetsId",
                        column: x => x.notifiedUserSetsId,
                        principalTable: "ap_userSetsToNotify",
                        principalColumn: "NotifyUserSetId");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalPathUsersNotifiedUserSets",
                columns: table => new
                {
                    approvalPathUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userSetsToNotifiyNotifyUserSetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalPathUsersNotifiedUserSets", x => new { x.approvalPathUsersId, x.userSetsToNotifiyNotifyUserSetId });
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersNotifiedUserSets_ap_approvalPathUsers_approvalPathUsersId",
                        column: x => x.approvalPathUsersId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalPathUsersNotifiedUserSets_ap_userSetsToNotify_userSetsToNotifiyNotifyUserSetId",
                        column: x => x.userSetsToNotifiyNotifyUserSetId,
                        principalTable: "ap_userSetsToNotify",
                        principalColumn: "NotifyUserSetId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "apd_priorityIndexes",
                columns: table => new
                {
                    PriorityIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityIndex = table.Column<int>(type: "int", nullable: true),
                    ApprovalDefinitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_priorityIndexes", x => x.PriorityIndexId);
                    table.ForeignKey(
                        name: "FK_apd_priorityIndexes_apd_approvalDefinitions_ApprovalDefinitionId",
                        column: x => x.ApprovalDefinitionId,
                        principalTable: "apd_approvalDefinitions",
                        principalColumn: "ApprovalDefinitionId");
                    table.ForeignKey(
                        name: "FK_apd_priorityIndexes_apd_approvalDocuments_ApprovalDocumentId",
                        column: x => x.ApprovalDocumentId,
                        principalTable: "apd_approvalDocuments",
                        principalColumn: "ApprovalDocumentId");
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
                    ApprovalDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalDestinations", x => x.ApprovalDestinationId);
                    table.ForeignKey(
                        name: "FK_apd_approvalDestinations_apd_workFlowIndexes_WorkFlowIndexId",
                        column: x => x.WorkFlowIndexId,
                        principalTable: "apd_workFlowIndexes",
                        principalColumn: "WorkFlowIndexId");
                });

            migrationBuilder.CreateTable(
                name: "apd_approvalRequests",
                columns: table => new
                {
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovalDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_approvalRequests", x => x.ApprovalRequestId);
                    table.ForeignKey(
                        name: "FK_apd_approvalRequests_apd_approvalDocuments_ApprovalDocumentId",
                        column: x => x.ApprovalDocumentId,
                        principalTable: "apd_approvalDocuments",
                        principalColumn: "ApprovalDocumentId");
                    table.ForeignKey(
                        name: "FK_apd_approvalRequests_apd_workFlowUsers_WorkFlowUserId",
                        column: x => x.WorkFlowUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimValues",
                columns: table => new
                {
                    ClaimValueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthenticationClaimId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimValues", x => x.ClaimValueId);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValues_AuthenticationClaims_AuthenticationClaimId",
                        column: x => x.AuthenticationClaimId,
                        principalTable: "AuthenticationClaims",
                        principalColumn: "ClaimId");
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimRequirements",
                columns: table => new
                {
                    RequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequirementName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    beenReviewed = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthenticationHttpMethodsId = table.Column<int>(type: "int", nullable: true),
                    AuthenticationClaimGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimRequirements", x => x.RequirementId);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirements_AuthenticationClaimGroups_AuthenticationClaimGroupId",
                        column: x => x.AuthenticationClaimGroupId,
                        principalTable: "AuthenticationClaimGroups",
                        principalColumn: "ClaimGroupId");
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirements_AuthenticationHttpMethods_AuthenticationHttpMethodsId",
                        column: x => x.AuthenticationHttpMethodsId,
                        principalTable: "AuthenticationHttpMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OperationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: true),
                    TimeSpan = table.Column<int>(type: "int", nullable: true),
                    TimePeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationDetails_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "OperationLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationListId = table.Column<int>(type: "int", nullable: true),
                    SAPNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Achivement = table.Column<int>(type: "int", nullable: true),
                    Efficiency = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationRecords_OperationLists_OperationListId",
                        column: x => x.OperationListId,
                        principalTable: "OperationLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SapCostCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SapPlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapCostCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapCostCenters_SapPlants_SapPlantId",
                        column: x => x.SapPlantId,
                        principalTable: "SapPlants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkingShiftId = table.Column<int>(type: "int", nullable: false),
                    WorkingShiftsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftGroups_WorkingShift_WorkingShiftsId",
                        column: x => x.WorkingShiftsId,
                        principalTable: "WorkingShift",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApprovalFlowOrderApprovalPathUsers",
                columns: table => new
                {
                    ApprovalFlowOrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalPathUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalFlowOrderApprovalPathUsers", x => new { x.ApprovalFlowOrdersId, x.ApprovalPathUsersId });
                    table.ForeignKey(
                        name: "FK_ApprovalFlowOrderApprovalPathUsers_ap_approvalFlowOrder_ApprovalFlowOrdersId",
                        column: x => x.ApprovalFlowOrdersId,
                        principalTable: "ap_approvalFlowOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalFlowOrderApprovalPathUsers_ap_approvalPathUsers_ApprovalPathUsersId",
                        column: x => x.ApprovalPathUsersId,
                        principalTable: "ap_approvalPathUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalFlowOrderUserBased_Config",
                columns: table => new
                {
                    approvalFlowsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userBased_ConfigsConf_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalFlowOrderUserBased_Config", x => new { x.approvalFlowsId, x.userBased_ConfigsConf_Id });
                    table.ForeignKey(
                        name: "FK_ApprovalFlowOrderUserBased_Config_ap_approvalFlowOrder_approvalFlowsId",
                        column: x => x.approvalFlowsId,
                        principalTable: "ap_approvalFlowOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalFlowOrderUserBased_Config_ap_userBased_Configs_userBased_ConfigsConf_Id",
                        column: x => x.userBased_ConfigsConf_Id,
                        principalTable: "ap_userBased_Configs",
                        principalColumn: "Conf_Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ApprovalDestinationsApprovalDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalConfigurationsApprovalDestinations", x => new { x.ApprovalConfigurationsApprovalConfigurationId, x.ApprovalDestinationsApprovalDestinationId });
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalConfigurations_ApprovalConfigurationsApprovalConfigurationId",
                        column: x => x.ApprovalConfigurationsApprovalConfigurationId,
                        principalTable: "apd_approvalConfigurations",
                        principalColumn: "ApprovalConfigurationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalConfigurationsApprovalDestinations_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                        column: x => x.ApprovalDestinationsApprovalDestinationId,
                        principalTable: "apd_approvalDestinations",
                        principalColumn: "ApprovalDestinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalDestinationsWorkFlowUsers",
                columns: table => new
                {
                    ApprovalDestinationsApprovalDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalDestinationsWorkFlowUsers", x => new { x.ApprovalDestinationsApprovalDestinationId, x.WorkFlowUsersUserId });
                    table.ForeignKey(
                        name: "FK_ApprovalDestinationsWorkFlowUsers_apd_approvalDestinations_ApprovalDestinationsApprovalDestinationId",
                        column: x => x.ApprovalDestinationsApprovalDestinationId,
                        principalTable: "apd_approvalDestinations",
                        principalColumn: "ApprovalDestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalDestinationsWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apd_workFlowLogs",
                columns: table => new
                {
                    WorkFlowLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApprovalRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkFlowIndexId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_workFlowLogs", x => x.WorkFlowLogId);
                    table.ForeignKey(
                        name: "FK_apd_workFlowLogs_apd_approvalRequests_ApprovalRequestId",
                        column: x => x.ApprovalRequestId,
                        principalTable: "apd_approvalRequests",
                        principalColumn: "ApprovalRequestId");
                    table.ForeignKey(
                        name: "FK_apd_workFlowLogs_apd_workFlowIndexes_WorkFlowIndexId",
                        column: x => x.WorkFlowIndexId,
                        principalTable: "apd_workFlowIndexes",
                        principalColumn: "WorkFlowIndexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimGroupAuthenticationClaimValue",
                columns: table => new
                {
                    AuthenticationClaimGroupsClaimGroupId = table.Column<int>(type: "int", nullable: false),
                    AuthenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimGroupAuthenticationClaimValue", x => new { x.AuthenticationClaimGroupsClaimGroupId, x.AuthenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimGroups_AuthenticationClaimGroupsClaimGroupId",
                        column: x => x.AuthenticationClaimGroupsClaimGroupId,
                        principalTable: "AuthenticationClaimGroups",
                        principalColumn: "ClaimGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimValues_AuthenticationClaimValuesClaimValueId",
                        column: x => x.AuthenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimValueAuthenticationUserClaimsHolder",
                columns: table => new
                {
                    AuthenticationUserClaimsHoldersUserId = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimValueAuthenticationUserClaimsHolder", x => new { x.AuthenticationUserClaimsHoldersUserId, x.authenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValueAuthenticationUserClaimsHolder_AuthenticationClaimValues_authenticationClaimValuesClaimValueId",
                        column: x => x.authenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimValueAuthenticationUserClaimsHolder_AuthenticationUserClaimsHolders_AuthenticationUserClaimsHoldersUserId",
                        column: x => x.AuthenticationUserClaimsHoldersUserId,
                        principalTable: "AuthenticationUserClaimsHolders",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                columns: table => new
                {
                    AuthenticationADAssignedGroupsid = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimRequirementsRequirementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationADAssignedGroupAuthenticationClaimRequirement", x => new { x.AuthenticationADAssignedGroupsid, x.authenticationClaimRequirementsRequirementId });
                    table.ForeignKey(
                        name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationADAssignedGroups_AuthenticationADAssignedGroupsid",
                        column: x => x.AuthenticationADAssignedGroupsid,
                        principalTable: "AuthenticationADAssignedGroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationADAssignedGroupAuthenticationClaimRequirement_AuthenticationClaimRequirements_authenticationClaimRequirementsR~",
                        column: x => x.authenticationClaimRequirementsRequirementId,
                        principalTable: "AuthenticationClaimRequirements",
                        principalColumn: "RequirementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthenticationClaimRequirementAuthenticationClaimValue",
                columns: table => new
                {
                    AuthenticationClaimsRequirementsRequirementId = table.Column<int>(type: "int", nullable: false),
                    authenticationClaimValuesClaimValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthenticationClaimRequirementAuthenticationClaimValue", x => new { x.AuthenticationClaimsRequirementsRequirementId, x.authenticationClaimValuesClaimValueId });
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirementAuthenticationClaimValue_AuthenticationClaimRequirements_AuthenticationClaimsRequirementsRequi~",
                        column: x => x.AuthenticationClaimsRequirementsRequirementId,
                        principalTable: "AuthenticationClaimRequirements",
                        principalColumn: "RequirementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthenticationClaimRequirementAuthenticationClaimValue_AuthenticationClaimValues_authenticationClaimValuesClaimValueId",
                        column: x => x.authenticationClaimValuesClaimValueId,
                        principalTable: "AuthenticationClaimValues",
                        principalColumn: "ClaimValueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SapOrganizationalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SapCostCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapOrganizationalUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapOrganizationalUnits_SapCostCenters_SapCostCenterId",
                        column: x => x.SapCostCenterId,
                        principalTable: "SapCostCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShiftGroupVS_Employees_1",
                columns: table => new
                {
                    VS_EmployeesId = table.Column<int>(type: "int", nullable: false),
                    shiftGroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftGroupVS_Employees_1", x => new { x.VS_EmployeesId, x.shiftGroupsId });
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_1_ShiftGroups_shiftGroupsId",
                        column: x => x.shiftGroupsId,
                        principalTable: "ShiftGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShiftGroupVS_Employees_1_VS_Employees_1_VS_EmployeesId",
                        column: x => x.VS_EmployeesId,
                        principalTable: "VS_Employees_1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "apd_requestDestinations",
                columns: table => new
                {
                    RequestDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HasCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apd_requestDestinations", x => x.RequestDestinationId);
                    table.ForeignKey(
                        name: "FK_apd_requestDestinations_apd_workFlowLogs_WorkFlowLogId",
                        column: x => x.WorkFlowLogId,
                        principalTable: "apd_workFlowLogs",
                        principalColumn: "WorkFlowLogId");
                });

            migrationBuilder.CreateTable(
                name: "SapEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapNo = table.Column<int>(type: "int", nullable: false),
                    EpfNo = table.Column<int>(type: "int", nullable: true),
                    Rfid = table.Column<int>(type: "int", nullable: true),
                    LogonId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Salutaion = table.Column<string>(type: "varchar(10)", nullable: true),
                    Initials = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Position = table.Column<string>(type: "varchar(100)", nullable: true),
                    WorkContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "varchar(20)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaritalStatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", nullable: true),
                    EmployeeStatus = table.Column<string>(type: "varchar(100)", nullable: true),
                    Source = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SapOrganizationalUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapPlantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SapWorkContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SapEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapOrganizationalUnits_SapOrganizationalUnitId",
                        column: x => x.SapOrganizationalUnitId,
                        principalTable: "SapOrganizationalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapPlants_SapPlantId",
                        column: x => x.SapPlantId,
                        principalTable: "SapPlants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SapEmployee_SapWorkContracts_SapWorkContractId",
                        column: x => x.SapWorkContractId,
                        principalTable: "SapWorkContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestDestinationsWorkFlowUsers",
                columns: table => new
                {
                    RequestDestinationsRequestDestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkFlowUsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDestinationsWorkFlowUsers", x => new { x.RequestDestinationsRequestDestinationId, x.WorkFlowUsersUserId });
                    table.ForeignKey(
                        name: "FK_RequestDestinationsWorkFlowUsers_apd_requestDestinations_RequestDestinationsRequestDestinationId",
                        column: x => x.RequestDestinationsRequestDestinationId,
                        principalTable: "apd_requestDestinations",
                        principalColumn: "RequestDestinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestDestinationsWorkFlowUsers_apd_workFlowUsers_WorkFlowUsersUserId",
                        column: x => x.WorkFlowUsersUserId,
                        principalTable: "apd_workFlowUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthenticationHttpMethods",
                columns: new[] { "Id", "HttpMethod" },
                values: new object[,]
                {
                    { 1, "GET" },
                    { 2, "POST" },
                    { 3, "PUT" },
                    { 4, "DELETE" },
                    { 5, "PATCH" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalFlowOrder_notifiedUserSetsId",
                table: "ap_approvalFlowOrder",
                column: "notifiedUserSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalRequests_approvalPathUserId",
                table: "ap_approvalRequests",
                column: "approvalPathUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_approvalRequests_registeredDocumentId",
                table: "ap_approvalRequests",
                column: "registeredDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_userBased_Configs_approvalPathUserId",
                table: "ap_userBased_Configs",
                column: "approvalPathUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ap_userBased_Configs_RegisteredDocumentId",
                table: "ap_userBased_Configs",
                column: "RegisteredDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalDestinations_WorkFlowIndexId",
                table: "apd_approvalDestinations",
                column: "WorkFlowIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalRequests_ApprovalDocumentId",
                table: "apd_approvalRequests",
                column: "ApprovalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_approvalRequests_WorkFlowUserId",
                table: "apd_approvalRequests",
                column: "WorkFlowUserId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_definitionValues_ApprovalDefinitionId",
                table: "apd_definitionValues",
                column: "ApprovalDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_priorityIndexes_ApprovalDefinitionId",
                table: "apd_priorityIndexes",
                column: "ApprovalDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_priorityIndexes_ApprovalDocumentId",
                table: "apd_priorityIndexes",
                column: "ApprovalDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_requestDestinations_WorkFlowLogId",
                table: "apd_requestDestinations",
                column: "WorkFlowLogId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_ApprovalRequestId",
                table: "apd_workFlowLogs",
                column: "ApprovalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_apd_workFlowLogs_WorkFlowIndexId",
                table: "apd_workFlowLogs",
                column: "WorkFlowIndexId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalConfigurationsApprovalDestinations_ApprovalDestinationsApprovalDestinationId",
                table: "ApprovalConfigurationsApprovalDestinations",
                column: "ApprovalDestinationsApprovalDestinationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlowOrderApprovalPathUsers_ApprovalPathUsersId",
                table: "ApprovalFlowOrderApprovalPathUsers",
                column: "ApprovalPathUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlowOrderUserBased_Config_userBased_ConfigsConf_Id",
                table: "ApprovalFlowOrderUserBased_Config",
                column: "userBased_ConfigsConf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalPathUsersNotifiedUserSets_userSetsToNotifiyNotifyUserSetId",
                table: "ApprovalPathUsersNotifiedUserSets",
                column: "userSetsToNotifiyNotifyUserSetId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationADAssignedGroupAuthenticationClaimRequirement_authenticationClaimRequirementsRequirementId",
                table: "AuthenticationADAssignedGroupAuthenticationClaimRequirement",
                column: "authenticationClaimRequirementsRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimGroupAuthenticationClaimValue_AuthenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimGroupAuthenticationClaimValue",
                column: "AuthenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirementAuthenticationClaimValue_authenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimRequirementAuthenticationClaimValue",
                column: "authenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationClaimGroupId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationClaimGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimRequirements_AuthenticationHttpMethodsId",
                table: "AuthenticationClaimRequirements",
                column: "AuthenticationHttpMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValueAuthenticationUserClaimsHolder_authenticationClaimValuesClaimValueId",
                table: "AuthenticationClaimValueAuthenticationUserClaimsHolder",
                column: "authenticationClaimValuesClaimValueId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthenticationClaimValues_AuthenticationClaimId",
                table: "AuthenticationClaimValues",
                column: "AuthenticationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationDetails_OperationListId",
                table: "OperationDetails",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationRecords_OperationListId",
                table: "OperationRecords",
                column: "OperationListId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestDestinationsWorkFlowUsers_WorkFlowUsersUserId",
                table: "RequestDestinationsWorkFlowUsers",
                column: "WorkFlowUsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SapCostCenters_SapPlantId",
                table: "SapCostCenters",
                column: "SapPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapOrganizationalUnitId",
                table: "SapEmployee",
                column: "SapOrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapPlantId",
                table: "SapEmployee",
                column: "SapPlantId");

            migrationBuilder.CreateIndex(
                name: "IX_SapEmployee_SapWorkContractId",
                table: "SapEmployee",
                column: "SapWorkContractId");

            migrationBuilder.CreateIndex(
                name: "IX_SapOrganizationalUnits_SapCostCenterId",
                table: "SapOrganizationalUnits",
                column: "SapCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroups_WorkingShiftsId",
                table: "ShiftGroups",
                column: "WorkingShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftGroupVS_Employees_1_shiftGroupsId",
                table: "ShiftGroupVS_Employees_1",
                column: "shiftGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ap_approvalRequests");

            migrationBuilder.DropTable(
                name: "apd_priorityIndexes");

            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsApprovalDestinations");

            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsApprovalDocuments");

            migrationBuilder.DropTable(
                name: "ApprovalConfigurationsDefinitionValues");

            migrationBuilder.DropTable(
                name: "ApprovalDestinationsWorkFlowUsers");

            migrationBuilder.DropTable(
                name: "ApprovalFlowOrderApprovalPathUsers");

            migrationBuilder.DropTable(
                name: "ApprovalFlowOrderUserBased_Config");

            migrationBuilder.DropTable(
                name: "ApprovalPathUsersNotifiedUserSets");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroupAuthenticationClaimRequirement");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimGroupAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirementAuthenticationClaimValue");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValueAuthenticationUserClaimsHolder");

            migrationBuilder.DropTable(
                name: "OperationDetails");

            migrationBuilder.DropTable(
                name: "OperationRecords");

            migrationBuilder.DropTable(
                name: "ReFaRequests");

            migrationBuilder.DropTable(
                name: "RequestDestinationsWorkFlowUsers");

            migrationBuilder.DropTable(
                name: "SampleTodos");

            migrationBuilder.DropTable(
                name: "SapEmployee");

            migrationBuilder.DropTable(
                name: "ShiftGroupVS_Employees_1");

            migrationBuilder.DropTable(
                name: "apd_approvalConfigurations");

            migrationBuilder.DropTable(
                name: "apd_definitionValues");

            migrationBuilder.DropTable(
                name: "apd_approvalDestinations");

            migrationBuilder.DropTable(
                name: "ap_approvalFlowOrder");

            migrationBuilder.DropTable(
                name: "ap_userBased_Configs");

            migrationBuilder.DropTable(
                name: "AuthenticationADAssignedGroups");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimRequirements");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimValues");

            migrationBuilder.DropTable(
                name: "AuthenticationUserClaimsHolders");

            migrationBuilder.DropTable(
                name: "OperationLists");

            migrationBuilder.DropTable(
                name: "apd_requestDestinations");

            migrationBuilder.DropTable(
                name: "SapOrganizationalUnits");

            migrationBuilder.DropTable(
                name: "SapWorkContracts");

            migrationBuilder.DropTable(
                name: "ShiftGroups");

            migrationBuilder.DropTable(
                name: "VS_Employees_1");

            migrationBuilder.DropTable(
                name: "apd_approvalDefinitions");

            migrationBuilder.DropTable(
                name: "ap_userSetsToNotify");

            migrationBuilder.DropTable(
                name: "ap_approvalPathUsers");

            migrationBuilder.DropTable(
                name: "ap_registeredDocuments");

            migrationBuilder.DropTable(
                name: "AuthenticationClaimGroups");

            migrationBuilder.DropTable(
                name: "AuthenticationHttpMethods");

            migrationBuilder.DropTable(
                name: "AuthenticationClaims");

            migrationBuilder.DropTable(
                name: "apd_workFlowLogs");

            migrationBuilder.DropTable(
                name: "SapCostCenters");

            migrationBuilder.DropTable(
                name: "WorkingShift");

            migrationBuilder.DropTable(
                name: "apd_approvalRequests");

            migrationBuilder.DropTable(
                name: "apd_workFlowIndexes");

            migrationBuilder.DropTable(
                name: "SapPlants");

            migrationBuilder.DropTable(
                name: "apd_approvalDocuments");

            migrationBuilder.DropTable(
                name: "apd_workFlowUsers");
        }
    }
}
