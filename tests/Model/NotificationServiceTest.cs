using System;
using System.Collections.Generic;

using Xunit;
using Moq;

using imout.Core.Model;
using imout.Core.Model.Service;
using imout.Core.Model.Repository;

namespace tests.Model
{
    public class NotificationServiceTest
    {
        [Fact]
        public void Create_WillCallRepositorySet_WithAListOfOneNotificationIfStorageIsEmpty()
        {
            Notification notification = generateNotification();
            List<Notification> expected = new List<Notification>()
            {
                notification
            };
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(new List<Notification>());
            repositoryMock.Setup(x => x.Set(It.IsAny<List<Notification>>()));

            NotificationService sut = new NotificationService(repositoryMock.Object);
            sut.Create(notification);

            repositoryMock.Verify(x => x.Set(expected), Times.Once);
        }
        
        [Fact]
        public void Create_WillCallRepositorySet_WithFiveNotificationsIfStorageHasFour()
        {
            // Arrange
            List<Notification> storageList = new List<Notification>()
            {
                generateNotification(),
                generateNotification(),
                generateNotification(),
                generateNotification()
            };
            Notification notification = generateNotification();
            
            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);
            repositoryMock.Setup(x => x.Set(It.IsAny<List<Notification>>()));

            int expectedListLength = storageList.Count + 1;
            Guid expectedLastIdInList = notification.Id;

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);
            sut.Create(notification);
            int actualListLength = storageList.Count;
            Guid actualLastIdInList = storageList[actualListLength - 1].Id;

            // Assert
            Assert.Equal(expectedListLength, actualListLength);
            Assert.Equal(expectedLastIdInList, actualLastIdInList);
        }

        [Fact]
        public void Create_NullAsArgument_ThrowsArgumentNullException()
        {
            // Arrange
            List<Notification> storageList = new List<Notification>();
            Notification notification = null;

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);
            repositoryMock.Setup(x => x.Set(It.IsAny<List<Notification>>()));

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Create(notification));
        }

        private Notification generateNotification()
        {
            Guid guid = Guid.NewGuid();
            Notification notification = new Notification(guid);
            notification.Name = "Notification 1";
            notification.TriggerLevel = 2;
            notification.Message = "I'm Out";

            return notification;
        }
    }
}
