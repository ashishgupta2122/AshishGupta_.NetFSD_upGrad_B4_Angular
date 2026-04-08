using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantEvents",
                table: "ParticipantEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "UserInfos");

            migrationBuilder.RenameTable(
                name: "Speakers",
                newName: "SpeakersDetails");

            migrationBuilder.RenameTable(
                name: "Sessions",
                newName: "SessionInfos");

            migrationBuilder.RenameTable(
                name: "ParticipantEvents",
                newName: "ParticipantEventDetails");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "EventDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_SpeakerId",
                table: "SessionInfos",
                newName: "IX_SessionInfos_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_Sessions_EventId",
                table: "SessionInfos",
                newName: "IX_SessionInfos_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionUrl",
                table: "SessionInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SessionTitle",
                table: "SessionInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SessionInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos",
                column: "EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakersDetails",
                table: "SpeakersDetails",
                column: "SpeakerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionInfos",
                table: "SessionInfos",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantEventDetails",
                table: "ParticipantEventDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventDetails",
                table: "EventDetails",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfos_EventDetails_EventId",
                table: "SessionInfos",
                column: "EventId",
                principalTable: "EventDetails",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionInfos_SpeakersDetails_SpeakerId",
                table: "SessionInfos",
                column: "SpeakerId",
                principalTable: "SpeakersDetails",
                principalColumn: "SpeakerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfos_EventDetails_EventId",
                table: "SessionInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionInfos_SpeakersDetails_SpeakerId",
                table: "SessionInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserInfos",
                table: "UserInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakersDetails",
                table: "SpeakersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionInfos",
                table: "SessionInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipantEventDetails",
                table: "ParticipantEventDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventDetails",
                table: "EventDetails");

            migrationBuilder.RenameTable(
                name: "UserInfos",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "SpeakersDetails",
                newName: "Speakers");

            migrationBuilder.RenameTable(
                name: "SessionInfos",
                newName: "Sessions");

            migrationBuilder.RenameTable(
                name: "ParticipantEventDetails",
                newName: "ParticipantEvents");

            migrationBuilder.RenameTable(
                name: "EventDetails",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_SessionInfos_SpeakerId",
                table: "Sessions",
                newName: "IX_Sessions_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SessionInfos_EventId",
                table: "Sessions",
                newName: "IX_Sessions_EventId");

            migrationBuilder.AlterColumn<string>(
                name: "SessionUrl",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SessionTitle",
                table: "Sessions",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "EmailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Speakers",
                table: "Speakers",
                column: "SpeakerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sessions",
                table: "Sessions",
                column: "SessionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipantEvents",
                table: "ParticipantEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Events_EventId",
                table: "Sessions",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Speakers_SpeakerId",
                table: "Sessions",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "SpeakerId");
        }
    }
}
