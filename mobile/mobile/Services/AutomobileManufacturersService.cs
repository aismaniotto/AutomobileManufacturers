using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using mobile.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace mobile.Services
{
    /**
     * Inspired by 
     * https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/src/Mobile/eShopOnContainers/eShopOnContainers.Core/Services/RequestProvider/RequestProvider.cs
     */

    public class AutomobileManufacturersService
    {
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly string _baseUri = "https://automobile-manufacturers.herokuapp.com/quiz";

        public AutomobileManufacturersService()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public async Task<List<Question>> GetQuestions()
        {
            var uri = _baseUri;
            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync(uri);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            List<Question> result = await Task.Run(() =>
                JsonConvert.DeserializeObject<List<Question>>(serialized, _serializerSettings));
            return result;
        }

        public async Task<float> SubmitAnswers(List<Answer> answers)
        {
            var uri = _baseUri;
            var httpClient = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(answers, _serializerSettings));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            await HandleResponse(response);
            string serialized = await response.Content.ReadAsStringAsync();

            float result = await Task.Run(() =>
                JsonConvert.DeserializeObject<float>(serialized, _serializerSettings));

            return result;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(content);
            }
        }
    }
}
