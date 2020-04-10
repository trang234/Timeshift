using NUnit.Framework;
using System;
using TimeshiftBLL.BLL;

namespace Tests
{
    public class TimeshiftBLLTesting
    {
        [Test]
        public void When_ChangeSystemDate_Expect_Successfully()
        {
            // Arrange
            DateTime dt = new DateTime(2010, 10, 10);
            bool expected = true;
            Timeshift timeshift = new Timeshift();

            // Action
            bool isTrue = timeshift.ChangeDateTime(dt);

            // Assert
            Assert.AreEqual(expected, isTrue);
        }

        [Test]
        public void When_InputTheStringDateTimeParam_Expect_ConvertToDateTimeCorrectly()
        {
            // Arrange
            String dtStr = "2018-03-05";

            // Action
            DateTime dt = DateTime.ParseExact(dtStr,
                "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            // Assert
            Assert.AreEqual("2018-03-05", dt.ToString("yyyy-MM-dd"));
        }

        [Test]
        public void When_InputTheStringDateTimeParam_Expect_TheDateTimeChangedAsInput()
        {
            // Arrange
            String dtStr = "2018-03-05";
            DateTime dt = DateTime.ParseExact(dtStr,
                "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            Timeshift timeshift = new Timeshift();
            string expectedDateTime = "";

            // Action
            bool flage = timeshift.ChangeDateTime(dt);
            expectedDateTime = timeshift.GetCurrentDateTime();

            // Assert
            Assert.AreEqual(dtStr, expectedDateTime);
        }
    }
}