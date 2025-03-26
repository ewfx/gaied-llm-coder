using Google.Api.Gax.ResourceNames;
using Google.Cloud.AIPlatform.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace GenAI
{
    public class ReadDocGenAI
    {
        public string TextInput(
            string projectId = "deep-voyage-448109-d0",
            string region = "us-central1",
            string publisher = "google",
            string model = "gemini-1.5-flash-001")
        {

            var predictionServiceClient = new PredictionServiceClientBuilder
            {
                Endpoint = $"{region}-aiplatform.googleapis.com"
            }.Build();
            LocationName location = new LocationName(projectId, region);

            string prompt = @"please search for 5 important keywords from the given document.";

            var generatecontentrequest = new GenerateContentRequest
            {
                Model = $"{location}/publishers/{publisher}/models/{model}",
                Contents =
                {
                    new Content
                    {
                        Role = "user",
                        Parts =
                        {
                            new Part { Text = prompt },
                            new Part { FileData = new() { MimeType = "application/pdf", FileUri = "gs://hack-2025/Intel Message.pdf" }}
                        }
                    }
                }
            };
            GenerateContentResponse response = predictionServiceClient.GenerateContent(generatecontentrequest);

            string responsetext = response.Candidates[0].Content.Parts[0].Text;
            Console.WriteLine(responsetext);

            return responsetext;
        }
    }
}
