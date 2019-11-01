using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCoreBookStore.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Technical Books", null },
                    { 2, "Inspirational Books", null },
                    { 3, "Religious Books", null },
                    { 4, "Novels", null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "ImageInformation", "ImageThumbnailUrl", "ImageUrl", "Instock", "IsBookOftheWeek", "LongDescription", "Name", "Notes", "Price", "ShortDescription" },
                values: new object[,]
                {
                    { 1, "Ian Sommerville", 1, null, null, "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/85/579781/1.jpg?8371", true, true, "The ninth edition of Software Engineering presents a broad perspective of software engineering, focusing on the processes and techniques fundamental to the creation of reliable, software systems. Increased coverage of agile methods and software reuse, along with coverage of 'traditional' plan-driven software engineering, gives readers the most up-to-date view of the field currently available. Practical case studies, a full set of easy-to-access supplements, and extensive web resources make teaching the course easier than ever.", "Software Engineering 9th Edition By Ian Sommerville", null, 0m, "Intended for introductory and advanced courses in software engineering." },
                    { 2, "Robert T. Kiyosaki", 2, null, null, "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/72/039022/1.jpg?8072", true, true, "Explode the myth that you need to earn a high income to become richChallenge the belief that your house is an assetShow parents why they can't rely on the school system to teach their kids about moneyDefine once and for all an asset and a liabilityTeach you what to teach your kids about money for their future financial success.", "Rich Dad Poor Dad", null, 0m, "Explode the myth that you need to earn a high income." },
                    { 3, "Dag Heward Mills ", 2, null, null, "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/86/89324/1.jpg?1192", true, true, "Bishop Dag Heward-Mills, an exceptional Christian leader, reveals one of his secrets: 'If anyone were to ask me what the greatest secret of my relationship with God is, I would say, without hesitation, that it is the power of the quiet times I have with Him everyday.' He has decided to write this book.", " Understanding The Quiet Time (the secret of spiritual strength)", null, 0m, "Bishop Dag Heward-Mills, an exceptional Christian leader, reveals one of his secrets." },
                    { 4, "STP Information Services Ltd", 2, null, null, "https://ng.jumia.is/unsafe/fit-in/680x680/filters:fill(white)/product/86/89324/1.jpg?1192", true, true, "UTME CBT Exam Software. JPro can set exam, mark it, score you and monitor your progress.It also includes Maths tutor, Grammar tutor and more. You can also use it as a Mock Exam simulator.", " University Entrance Practice Software (For UTME)", null, 0m, "UTME CBT Exam Software" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);
        }
    }
}
