using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConvertCriptJulioCesar
{
    public sealed class Message
    {
        private static string My_Token = "TOKEN_EXEMPLO";
        private static HttpClient lHttpClient = new HttpClient();
        private static string Url_Post = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=";
        private static string Url_Get = "https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token=";
        public async static Task<Answer> GetMessage()
        {
            try
            {
                string lResponse = string.Empty;
                var model = new Answer();

                var response = await lHttpClient.GetAsync(string.Concat(Url_Get, My_Token));
                if (response.IsSuccessStatusCode)
                {
                    lResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<Answer>(lResponse);
                }
                return model;

            }
            catch (Exception lEx)
            {

                throw lEx;
            }
        }

        public static async Task<string> PostMessage(string pFileName)
        {
            string result = string.Empty;
            try
            {
                using (var lFormContent = new MultipartFormDataContent())
                {
                    lFormContent.Headers.ContentType.MediaType = "multipart/form-data";
                    FileStream lFileStream = File.OpenRead(Path.Combine(Directory.GetCurrentDirectory(), pFileName));
                    lFormContent.Add(new StreamContent(lFileStream), "answer", Path.GetFileName(Path.Combine(Directory.GetCurrentDirectory(), pFileName)));

                    var lResponse = await lHttpClient.PostAsync(string.Concat(Url_Post, My_Token), lFormContent);

                    result = await lResponse.Content.ReadAsStringAsync();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }
    }
}
