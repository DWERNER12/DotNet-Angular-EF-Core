using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removelotofevent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventsAssignedSpeakers_EventsAssignedSpeakers_EventAssignedSpeakerEventId_EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers");

            migrationBuilder.DropIndex(
                name: "IX_EventsAssignedSpeakers_EventAssignedSpeakerEventId_EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers");

            migrationBuilder.DropColumn(
                name: "EventAssignedSpeakerEventId",
                table: "EventsAssignedSpeakers");

            migrationBuilder.DropColumn(
                name: "EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers");

            migrationBuilder.DropColumn(
                name: "Lot",
                table: "Events");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventAssignedSpeakerEventId",
                table: "EventsAssignedSpeakers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lot",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventsAssignedSpeakers_EventAssignedSpeakerEventId_EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers",
                columns: new[] { "EventAssignedSpeakerEventId", "EventAssignedSpeakerSpeakerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventsAssignedSpeakers_EventsAssignedSpeakers_EventAssignedSpeakerEventId_EventAssignedSpeakerSpeakerId",
                table: "EventsAssignedSpeakers",
                columns: new[] { "EventAssignedSpeakerEventId", "EventAssignedSpeakerSpeakerId" },
                principalTable: "EventsAssignedSpeakers",
                principalColumns: new[] { "EventId", "SpeakerId" });
        }
    }
}
