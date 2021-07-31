using System;
using Xunit;
using Moq;
using imout.Core.Model.Repository;
using imout.Core.Utils;
using imout.Core.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using FluentAssertions;

namespace tests.Model
{

    public class NotificationRepositoryTest
    {
        [Fact]
        public void Get_ShouldReturnListOfNotifications_IfStorageNotEmpty()
        {
            List<Notification> expected = new List<Notification>()
            {
                generateNotification()
            };
                
            string notificationsJson = JsonConvert.SerializeObject(expected);
            var storageMock = new Mock<IStorageWrapper>();
            storageMock.Setup(x => x.Get()).Returns(notificationsJson);

            NotificationRepository sut = new NotificationRepository(storageMock.Object);
            List<Notification>actual = sut.Get();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Get_ShouldReturnEmptyListOfNotifications_IfStorageIsEmpty()
        {
            List<Notification> expected = new List<Notification>();

            string notificationsJson = JsonConvert.SerializeObject(expected);
            var storageMock = new Mock<IStorageWrapper>();
            storageMock.Setup(x => x.Get()).Returns(notificationsJson);

            NotificationRepository sut = new NotificationRepository(storageMock.Object);
            List<Notification> actual = sut.Get();

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Set_ShouldCallStorageWrapper_WithSerializedNotificationList()
        {
            List<Notification> notifications = new List<Notification>()
            {
                generateNotification()
            };
            string expected = JsonConvert.SerializeObject(notifications);

            var storageMock = new Mock<IStorageWrapper>();
            storageMock.Setup(x => x.Set(It.IsAny<string>()));

            NotificationRepository sut = new NotificationRepository(storageMock.Object);
            sut.Set(notifications);

            storageMock.Verify(x => x.Set(expected), Times.Once());
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
