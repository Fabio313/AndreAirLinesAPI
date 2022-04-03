using Microsoft.EntityFrameworkCore.Migrations;

namespace APIAndreAirLines.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseId",
                table: "Passagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_PrecoBaseId",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "PrecoBaseId",
                table: "Passagem");

            migrationBuilder.AddColumn<string>(
                name: "SiglaOrigem",
                table: "PrecoBase",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SiglaDestino",
                table: "PrecoBase",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrecoBaseSiglaDestino",
                table: "Passagem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrecoBaseSiglaOrigem",
                table: "Passagem",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase",
                columns: new[] { "SiglaOrigem", "SiglaDestino" });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PrecoBaseSiglaOrigem_PrecoBaseSiglaDestino",
                table: "Passagem",
                columns: new[] { "PrecoBaseSiglaOrigem", "PrecoBaseSiglaDestino" });

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseSiglaOrigem_PrecoBaseSiglaDestino",
                table: "Passagem",
                columns: new[] { "PrecoBaseSiglaOrigem", "PrecoBaseSiglaDestino" },
                principalTable: "PrecoBase",
                principalColumns: new[] { "SiglaOrigem", "SiglaDestino" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseSiglaOrigem_PrecoBaseSiglaDestino",
                table: "Passagem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_PrecoBaseSiglaOrigem_PrecoBaseSiglaDestino",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "SiglaOrigem",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "SiglaDestino",
                table: "PrecoBase");

            migrationBuilder.DropColumn(
                name: "PrecoBaseSiglaDestino",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "PrecoBaseSiglaOrigem",
                table: "Passagem");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PrecoBase",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PrecoBaseId",
                table: "Passagem",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PrecoBase",
                table: "PrecoBase",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PrecoBaseId",
                table: "Passagem",
                column: "PrecoBaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_PrecoBase_PrecoBaseId",
                table: "Passagem",
                column: "PrecoBaseId",
                principalTable: "PrecoBase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
