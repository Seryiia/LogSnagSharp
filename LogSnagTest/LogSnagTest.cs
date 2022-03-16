using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading;

namespace LogSnagTest
{
    [TestClass]
    public class LogSnagTest
    {
        // This auth ID is a public unit test ID that is limited both hourly and by IP
        // This tests can be run by any cloning repository but are subjected to limiting
        readonly String LOGSNAG_AUTH_ID = "20b24bdc32917e35e38b58f5e7d6019c";
        readonly String TEST_PROJECT = "c-sharp";
        readonly String TEST_CHANNEL = "test";
        readonly String INVALID = "invalid";

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void InvalidAuthIdThrowsWebException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(INVALID, TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "InvalidAuthIdThrowsWebException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void InvalidProjectThrowsWebException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID, INVALID);
            client.Publish(TEST_CHANNEL, "NotSettingProjectOptionsFails Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NotSettingProjectThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.Publish(TEST_CHANNEL, "NotSettingProjectOptionsFails Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyProjectThrowsInvalidOperationException()
        {LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID, "");
            client.Publish(TEST_CHANNEL, "EmptyProjectThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyChannelThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID, TEST_PROJECT);
            client.Publish("", "EmptyChannelThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void EmptyEventNameThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID, TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyProjectThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject("", TEST_CHANNEL, "PublishToProjectEmptyProjectThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyChannelThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, "", "PublishToProjectEmptyChannelThrowsInvalidOperationException Test Event");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PublishToProjectEmptyEventNameThrowsInvalidOperationException()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, TEST_CHANNEL, "");
        }

        [TestMethod]
        public void EventOnlyPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.SetProject(TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "EventOnlyPublishTest Event");
        }

        [TestMethod]
        public void EventDescriptionPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.SetProject(TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "EventDescriptionPublishTest Event", "A test testing description publishing");
        }

        [TestMethod]
        public void EventDescriptionIconPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.SetProject(TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "EventDescriptionIconPublishTest Event", "A test testing icon publishing", "⌛");
        }

        [TestMethod]
        public void EventDescriptionIconPushNotifPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.SetProject(TEST_PROJECT);
            client.Publish(TEST_CHANNEL, "EventDescriptionIconPublishTest Event", "A test testing push notif publishing", "⌛", true);
        }

        [TestMethod]
        public void PublishToProjectEventOnlyPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, TEST_CHANNEL, "ExplictEventOnlyPublishTest Event");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, TEST_CHANNEL, "ExplicitEventDescriptionPublishTest Event", "A test testing description publishing");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionIconPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, TEST_CHANNEL, "ExplictEventDescriptionIconPublishTest Event", "A test testing icon publishing", "⌛");
        }

        [TestMethod]
        public void PublishToProjectEventDescriptionIconPushNotifPublishTest()
        {
            LogSnag.LogSnag client = new LogSnag.LogSnag(LOGSNAG_AUTH_ID);
            client.PublishToProject(TEST_PROJECT, TEST_CHANNEL, "ExplictEventDescriptionIconPushNotifPublishTest Event", "A test testing push notif publishing", "⌛", true);
        }
    }
}
