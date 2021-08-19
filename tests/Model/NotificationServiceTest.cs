using System;
using System.Collections.Generic;

using Xunit;
using Moq;

using imout.Core.Model;
using imout.Core.Model.Service;
using imout.Core.Model.Repository;
using Newtonsoft.Json;

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
            var repositoryMock = new Mock<IRepository>();

            NotificationService sut = new NotificationService(repositoryMock.Object);

            Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        }

        [Fact]
        public void Update_WillCallRepositorySet_WithUpdatedNotificationData()
        {
            // Arrange
            Notification notification = generateNotification();
            Guid expectedId = notification.Id;
            string expectedName = "New name";

            List<Notification> storageList = new List<Notification>()
            {
                notification
            };

            Notification notificationUpdated = CloneNotification(notification);
            notificationUpdated.Name = expectedName;


            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);
            repositoryMock.Setup(x => x.Set(It.IsAny<List<Notification>>()));

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);
            sut.Update(notificationUpdated);
            string actualName = storageList[0].Name;
            Guid actualId = storageList[0].Id;
            List<Notification> storageListUpdated = new List<Notification>() {
                notificationUpdated
            };

            // Assert
            Assert.Equal(expectedName, actualName);
            Assert.Equal(expectedId, actualId);
            repositoryMock.Verify((m) => m.Set(storageListUpdated), Times.Once());
        }

        [Fact]
        public void Update_EmptyStorage_WillThrow()
        {
            // Arrange
            Notification notification = generateNotification();
            List<Notification> storageList = new List<Notification>();

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<Exception>(() => sut.Update(notification));
        }

        [Fact]
        public void Update_Null_Throws()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Update(null));
        }

        [Fact]
        public void Update_NonexistingNotification_WillThrow()
        {
            // Arrange
            Notification notification = generateNotification();
            List<Notification> storageList = new List<Notification>() {
                generateNotification(),
                generateNotification(),
                generateNotification()
            };

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<Exception>(() => sut.Update(notification));
        }

        [Fact]
        public void Update_UpdatedNotification_WontStoreSameNotificationTwice()
        {
            // Arrange
            Notification notification = generateNotification();
            List<Notification> storageList = new List<Notification>() {
                notification,
                generateNotification(),
                generateNotification(),
            };
            Notification notificationUpdated = CloneNotification(notification);
            notificationUpdated.Name = "New Name";
            List<Notification> actualList = null;

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);
            repositoryMock
                    .Setup(x => x.Set(It.IsAny<List<Notification>>()))
                    .Callback<List<Notification>>(n => actualList = n );

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);
            sut.Update(notificationUpdated);

            int actual = actualList.FindAll(n => n.Id == notification.Id).Count;
            int expected = 1;

            // Assert
            Assert.Equal(expected, actual);

        }

        [Fact]
        public void Delete_UnexistingNotification_WillThrow()
        {
            // Arrange
            Notification notification = generateNotification();
            List<Notification> storageList = new List<Notification>() {
                generateNotification(),
                generateNotification(),
                generateNotification()
            };

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<Exception>(() => sut.Delete(notification));
        }

        [Fact]
        public void Delete_Notification_Successfully()
        {
            // Arrange
            Notification notification = generateNotification();
            List<Notification> storageList = new List<Notification>() {
                notification,
                generateNotification(),
                generateNotification()
            };
            List<Notification> actualList = null;

            var repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(x => x.Get()).Returns(storageList);
            repositoryMock
                .Setup(x => x.Set(It.IsAny<List<Notification>>()))
                .Callback<List<Notification>>(n => actualList = n);

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);
            sut.Delete(notification);
            int actual = actualList.FindAll(n => n.Id == notification.Id).Count;
            int expected = 0;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Delete_Null_Throws()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();

            // Act
            NotificationService sut = new NotificationService(repositoryMock.Object);

            // Assert
            Assert.Throws<ArgumentNullException>(() => sut.Delete(null));
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

        private Notification CloneNotification(Notification notificationToClone)
        {
            string serializedNotification = JsonConvert.SerializeObject(notificationToClone);
            return JsonConvert.DeserializeObject<Notification>(serializedNotification);
        }
    }
}
