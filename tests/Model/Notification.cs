using System;
using Xunit;
using imout.Core.Model;

namespace tests
{
    public class NotificationTest
    {
        Notification sut = new Notification(Guid.NewGuid());

        [Theory]
        [InlineData("")]
        [InlineData("This name is 41 characters long aaaaaaaaa")]
        public void NameProperty_ShouldThrow_IfNameLengthIsOutOfBounds(string name)
        {
            Action act = () => sut.Name = name;
            
            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData("A")]
        [InlineData("This name is 40 characters long aaaaaaaa")]
        public void NameProperty_ShouldStoreName_IfNameLengthIsInsideBounds(string name)
        {
            string expected = name;
            string actual;

            sut.Name = name;

            actual = sut.Name;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(21)]
        public void TriggerLevelProperty_ShouldThrow_IfValueIsOutsideBounds(int level)
        {
            Action act = () => sut.TriggerLevel = level;

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(20)]
        public void TriggerLevelProperty_ShouldReturnSetValue_IfValueIsInsideBounds(int level)
        {
            int expected = level;
            int actual;

            sut.TriggerLevel = level;

            actual = sut.TriggerLevel;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("This name is 101 characters long aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void MessageProperty_ShouldThrow_IfMessageLengthIsOutOfBounds(string message)
        {
            Action act = () => sut.Message = message;

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Theory]
        [InlineData("a")]
        [InlineData("This name is 100 characters long aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void MessageProperty_ShouldReturnSetValue_IfMessageLengthIsInsideBounds(string message)
        {
            string expected = message;
            string actual;

            sut.Message= message;

            actual = sut.Message;

            Assert.Equal(expected, actual);
        }
    }
}
