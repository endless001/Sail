using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sail.Administration.Migrations.ConfigurationDb
{
    public partial class Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_control",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    OpenAuth = table.Column<int>(nullable: false),
                    BlackList = table.Column<string>(nullable: true),
                    WhiteList = table.Column<string>(nullable: true),
                    WhiteHostName = table.Column<string>(nullable: true),
                    ClientIpFlowLimit = table.Column<int>(nullable: false),
                    ServiceFlowLimit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_control", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grpc_rule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    Port = table.Column<int>(nullable: false),
                    HeaderTransform = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grpc_rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "http_rule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    RuleType = table.Column<int>(nullable: false),
                    Rule = table.Column<string>(nullable: true),
                    NeedHttps = table.Column<int>(nullable: false),
                    NeedWebsocket = table.Column<int>(nullable: false),
                    NeedStripUri = table.Column<int>(nullable: false),
                    UrlRewrite = table.Column<string>(nullable: true),
                    HeaderTransform = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_http_rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LoadType = table.Column<int>(nullable: false),
                    ServiceName = table.Column<string>(nullable: true),
                    ServiceDesc = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tcp_rule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    Port = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tcp_rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AppId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    WhiteIps = table.Column<string>(nullable: true),
                    Qpd = table.Column<int>(nullable: false),
                    Qps = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_control");

            migrationBuilder.DropTable(
                name: "grpc_rule");

            migrationBuilder.DropTable(
                name: "http_rule");

            migrationBuilder.DropTable(
                name: "service");

            migrationBuilder.DropTable(
                name: "tcp_rule");

            migrationBuilder.DropTable(
                name: "tenant");
        }
    }
}
