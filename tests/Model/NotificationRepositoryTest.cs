using System;
using Xunit;
using Moq;
using imout.Core.Model.Repository;
using imout.Core.Utils;

namespace tests.Model
{

    public class NotificationRepositoryTest
    {
        [Fact]
        public void test()
        {
            var storageMock = new Mock<IStorageWrapper>();
            NotificationRepository sut = new NotificationRepository(storageMock.Object);
        }
        
        
    }
}
