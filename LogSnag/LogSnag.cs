using System;
using System.IO;
using System.Net;
using System.Text.Json;

namespace LogSnag
{
    public class LogSnag
    {
        private const String LOGSNAG_URL = "https://api.logsnag.com/v1/log";
        private String AuthorizationToken { get; }
        private String? Project { get; set; }
        
        public LogSnag(String authToken)
        {
            AuthorizationToken = authToken;
        }

        public LogSnag(String authToken, String project)
        {
            AuthorizationToken = authToken;
            Project = project;
        }

        public void SetProject(String project)
        {
            Project = project;
        }

        public void Publish(String channel, String eventName, String? description = null, String? icon = null, bool? sendPushNotif = null)
        {
            if(String.IsNullOrEmpty(Project))
            {
                throw new InvalidOperationException("Project must be set using SetProject() before calling Publish()"); 
            }

            // Use configured project
            PublishToProject(Project, channel, eventName, description, icon, sendPushNotif);
        }

        public void PublishToProject(String project, String channel, String eventName, String? description = null, String? icon = null, bool? sendPushNotif = null)
        {
            // Validate
            if (String.IsNullOrEmpty(project) || String.IsNullOrEmpty(channel) || String.IsNullOrEmpty(eventName))
            {
                throw new InvalidOperationException("Publish attempted with an empty project, channel, or event name.");
            }

            // Construct the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(LOGSNAG_URL);
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers["Authorization"] = $"Bearer {AuthorizationToken}";

            // Construct and send the request
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                // Don't write null values
                JsonSerializerOptions options = new()
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                // Serialize payload
                String json = JsonSerializer.Serialize(new
                {
                    project = project,
                    channel = channel,
                    @event = eventName, // Language keywords must be prefixed with @ to be used as a variable name
                    description = description,
                    icon = icon,
                    notify = sendPushNotif
                }, options);

                streamWriter.Write(json);
            }

            // Verify response processes properly
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
        }
    }
}
