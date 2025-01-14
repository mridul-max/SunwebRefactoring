using AutoFixture;
using Moq;
using Refactoring.Models;
using Refactoring.Repositories;
namespace Refactoring.UnitTests
{
    public class ReportPrinterTests
    {
        [Fact]
        public void WithNoDetail_PrintsReport()
        {
            // Arrange
            var mockReportFormatStrategy = new Mock<IReportFormatStrategy>();
            mockReportFormatStrategy.Setup(x => x.GenerateReport(It.IsAny<List<AccommodationBase>>()))
                .Returns("Empty list of accommodations!\r\n");

            // Create an instance of your report generator
            var sut = new ReportGenerator(mockReportFormatStrategy.Object);

            // Act
            var actualResult = sut.GenerateReport(new List<AccommodationBase>());

            // Assert
            var expectedResult = "Empty list of accommodations!\r\n";
            Assert.Equal(expectedResult, actualResult);
        }

/*        [Fact]
        public void WithHotel_PrintsReport()
        {
            // Arrange
            var hotel = new Detail
            {
                Name = "Hotel",
                Rooms = 2,
                Price = 100,
                Margin = 10.5F
            };
            var details = new Detail[] { hotel };

            var expectedResult = 
                "Accommodation Report\r\n" +
                "==================================================\r\n" +
                " 1 Hotel Revenue: 200,00 Profit: 21,00\r\n" +
                "==================================================\r\n" +
                 "Totals\r\n" +
                " Count: 1\r\n" +
                " Revenue: 200,00\r\n" +
                " Profit: 21,00\r\n";

            var sut = new ReportPrinter();

            // Act
            var actualResult = sut.Print(details);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WithApartment_PrintsReport()
        {
            // Arrange
            var apartment = new Detail
            {
                Name = "Apartment",
                Participants = 2,
                Price = 70,
                Margin = 14
            };
            var details = new Detail[] { apartment };

            var expectedResult =
                "Accommodation Report\r\n" +
                "==================================================\r\n" +
                " 1 Apartment Revenue: 140,00 Profit: 19,60\r\n" +
                "==================================================\r\n" +
                 "Totals\r\n" +
                " Count: 1\r\n" +
                " Revenue: 140,00\r\n" +
                " Profit: 19,60\r\n";

            var sut = new ReportPrinter();

            // Act
            var actualResult = sut.Print(details);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WithCamping_PrintsReport()
        {
            // Arrange
            var camping = new Detail
            {
                Name = "Camping",
                Price = 35,
                Margin = 7,
                SpecialLevy = 10

            };
            var details = new Detail[] { camping };

            var expectedResult =
                "Accommodation Report\r\n" +
                "==================================================\r\n" +
                " 1 Camping Revenue: 35,00 Profit: -7,55\r\n" +
                "==================================================\r\n" +
                 "Totals\r\n" +
                " Count: 1\r\n" +
                " Revenue: 35,00\r\n" +
                " Profit: -7,55\r\n";

            var sut = new ReportPrinter();

            // Act
            var actualResult = sut.Print(details);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WithOneOfEach_PrintsReport()
        {
            // Arrange
            var hotel = new Detail
            {
                Name = "Hotel",
                Rooms = 3,
                Price = 121.10F,
                Margin = 13.5F
            };

            var apartment = new Detail
            {
                Name = "Apartment",
                Participants = 5,
                Price = 50,
                Margin = 11
            };

            var camping = new Detail
            {
                Name = "Camping",
                Price = 41,
                Margin = 4.5F,
                SpecialLevy = 7
            };

            var details = new Detail[] { hotel, apartment, camping };

            var expectedResult =
                "Accommodation Report\r\n" +
                "==================================================\r\n" +
                " 1 Hotel Revenue: 363,30 Profit: 49,05\r\n" +
                " 1 Apartment Revenue: 250,00 Profit: 27,50\r\n" +
                " 1 Camping Revenue: 41,00 Profit: -5,15\r\n" +
                "==================================================\r\n" +
                 "Totals\r\n" +
                " Count: 3\r\n" +
                " Revenue: 654,30\r\n" +
                " Profit: 71,40\r\n";

            var sut = new ReportPrinter();

            // Act
            var actualResult = sut.Print(details);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void WithMulipleOfEach_PrintsReport()
        {
            // Arrange
            var hotel1 = new Detail
            {
                Name = "Hotel",
                Rooms = 1,
                Price = 50,
                Margin = 15
            };

            var hotel2 = new Detail
            {
                Name = "Hotel",
                Rooms = 4,
                Price = 175.5F,
                Margin = 17.5F
            };

            var apartment1 = new Detail
            {
                Name = "Apartment",
                Participants = 1,
                Price = 50,
                Margin = 15
            };

            var apartment2 = new Detail
            {
                Name = "Apartment",
                Participants = 7,
                Price = 75,
                Margin = 20.75F
            };

            var camping1 = new Detail
            {
                Name = "Camping",
                Price = 20,
                Margin = 4,
                SpecialLevy = 1
            };

            var camping2 = new Detail
            {
                Name = "Camping",
                Price = 23.5F,
                Margin = 17.5F,
                SpecialLevy = 2
            };

            var camping3 = new Detail
            {
                Name = "Camping",
                Price = 29.5F,
                Margin = 11.5F,
                SpecialLevy = 3
            };


            var details = new Detail[] { hotel1, hotel2, apartment1, apartment2, camping1, camping2, camping3 };

            var expectedResult =
                "Accommodation Report\r\n" +
                "==================================================\r\n" +
                " 2 Hotels Revenue: 752,00 Profit: 130,35\r\n" +
                " 2 Apartments Revenue: 575,00 Profit: 116,44\r\n" +
                " 3 Camping Revenue: 73,00 Profit: 2,30\r\n" +
                "==================================================\r\n" +
                 "Totals\r\n" +
                " Count: 7\r\n" +
                " Revenue: 1400,00\r\n" +
                " Profit: 249,09\r\n";

            var sut = new ReportPrinter();

            // Act
            var actualResult = sut.Print(details);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }*/
    }
}