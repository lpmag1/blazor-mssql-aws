using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blazor.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InputTypes",
                columns: ["Id", "Name"],
                values: [new { Id = 1, Name = "Text" },
                         new { Id = 2, Name = "Number" },
                         new { Id = 3, Name = "Date" },
                         new { Id = 4, Name = "Select" }]
            );

            migrationBuilder.InsertData(
                table: "Forms",
                columns: ["Id", "Name"],
                values: [1, "Example Form"]
            );

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: ["Id", "Label", "InputTypeId", "FormId"],
                values: [new { Id = 1, Label = "First Name", InputTypeId = 1, FormId = 1 },
                         new { Id = 2, Label = "Age", InputTypeId = 2, FormId = 1 },
                         new { Id = 3, Label = "Birth Date", InputTypeId = 3, FormId = 1 },
                         new { Id = 4, Label = "Favorite Color", InputTypeId = 4, FormId = 1 }]
            );

            migrationBuilder.InsertData(
                table: "InputTypeOptions",
                columns: ["Id", "InputTypeId", "OptionValue"],
                values: [new { Id = 1, InputTypeId = 4, OptionValue = "Red" },
                         new { Id = 2, InputTypeId = 4, OptionValue = "Green" },
                         new { Id = 3, InputTypeId = 4, OptionValue = "Blue" }]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InputTypeOptions",
                keyColumn: "Id",
                keyValues: [1, 2, 3]
            );

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValues: [1, 2, 3, 4]
            );

            migrationBuilder.DeleteData(
                table: "Forms",
                keyColumn: "Id",
                keyValue: 1
            );

            migrationBuilder.DeleteData(
                table: "InputTypes",
                keyColumn: "Id",
                keyValues: [1, 2, 3, 4]
            );
        }
    }
}
