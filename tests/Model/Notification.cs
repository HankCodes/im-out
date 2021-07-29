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
        [InlineData("This name is 41 characters long aaaaaaaa ")]
        public void NameSetter_ShouldThrow_IfNameIsOutOfBounds(string name)
        {
            Action act = () => sut.Name = name;
            
            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(act);
        }

    }
}
