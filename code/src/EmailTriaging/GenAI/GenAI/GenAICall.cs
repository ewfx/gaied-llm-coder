using Google.Api.Gax.ResourceNames;
using Google.Cloud.AIPlatform.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI
{
    public class TextInputSample
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
            while (true)
            {
                string prompt = Console.ReadLine()!;

                var generateContentRequest = new GenerateContentRequest
                {
                    Model = $"{location}/publishers/{publisher}/models/{model}",
                    Contents =
            {
                new Content
                {
                    Role = "USER",
                    Parts =
                    {
                        new Part { Text = prompt }
                    }
                }
            }
                };
                string responseText = "";
                try
                {
                    var response = predictionServiceClient.GenerateContent(generateContentRequest);
                    responseText = response.Candidates[0].Content.Parts[0].Text;
                    Console.WriteLine(responseText);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            ////    string prompt = @"You are a very professional document summarization specialist.Please summarize the given document.";
            ////    var generateContentRequest = new GenerateContentRequest
            ////    {
            ////        Model = $"{location}/publishers/{publisher}/models/{model}",
            ////        Contents =
            ////    {
            ////        new Content
            ////        {
            ////            Role = "USER",
            ////            Parts =
            ////            {
            ////                new Part { Text = prompt },
            ////                new Part { FileData = new() { MimeType = "application/pdf", FileUri = "gs://termsandconditionsdocsbucket/sample-terms-conditions-agreement.pdf" }}
            ////            }
            ////        }
            ////    }
            ////    };
            ////    GenerateContentResponse response = predictionServiceClient.GenerateContent(generateContentRequest);

            ////    string responseText = response.Candidates[0].Content.Parts[0].Text;
            ////    Console.WriteLine(responseText);

            ////    return responseText;
            ////}
        }
    }
}
