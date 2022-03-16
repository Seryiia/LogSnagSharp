using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading;

namespace LogSnagTest
{
    [TestClass]
    public class LogSnagTest
    {
        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void InvalidAuthIdThrowsWebException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("invalid", "c-sharp");
            client.Publish("test", "InvalidAuthIdThrowsWebException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void InvalidProjectThrowsWebException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c", "invalid");
            client.Publish("test", "NotSettingProjectOptionsFails Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NotSettingProjectThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.Publish("test", "NotSettingProjectOptionsFails Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyProjectThrowsInvalidOperationException()
        {LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c", "");
            client.Publish("test", "EmptyProjectThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyChannelThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c", "c-sharp");
            client.Publish("", "EmptyChannelThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyEventNameThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c", "c-sharp");
            client.Publish("test", "");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyProjectThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("", "test", "PublishToProjectEmptyProjectThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyChannelThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "", "PublishToProjectEmptyChannelThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyEventNameThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "test", "");
        }

        [TestMethod]
        public void EventOnlyPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.SetProject("c-sharp");
            client.Publish("test", "EventOnlyPublishTest Event");
        }

        [TestMethod]
        public void EventDescriptionPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.SetProject("c-sharp");
            client.Publish("test", "EventDescriptionPublishTest Event", "A test testing description publishing");
        }

        [TestMethod]
        public void EventDescriptionIconPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.SetProject("c-sharp");
            client.Publish("test", "EventDescriptionIconPublishTest Event", "A test testing icon publishing", "⌛");
        }

        [TestMethod]
        public void EventDescriptionIconPushNotifPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.SetProject("c-sharp");
            client.Publish("test", "EventDescriptionIconPublishTest Event", "A test testing push notif publishing", "⌛", true);
        }

        [TestMethod]
        public void PublishToProjectEventOnlyPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "test", "ExplictEventOnlyPublishTest Event");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "test", "ExplicitEventDescriptionPublishTest Event", "A test testing description publishing");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionIconPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "test", "ExplictEventDescriptionIconPublishTest Event", "A test testing icon publishing", "⌛");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionIconPushNotifPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag("20b24bdc32917e35e38b58f5e7d6019c");
            client.PublishToProject("c-sharp", "test", "ExplictEventDescriptionIconPushNotifPublishTest Event", "A test testing push notif publishing", "⌛", true);
        }
    }
}
