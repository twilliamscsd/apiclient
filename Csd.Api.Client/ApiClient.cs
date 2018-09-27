using Csd.Api.Client.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Csd.Api.Client
{
    public class ApiClient : ClientBase
    {
        public ApiClient(
            string csdApiUrl, 
            string azureApplicationId, 
            string secretKeyValue, 
            string azureAdInstance, 
            string azureDomain)
        {
            base.csdApiUrl = csdApiUrl;
            base.azureApplicationId = azureApplicationId;            
            base.secretKeyValue = secretKeyValue;
            base.azureAdInstance = azureAdInstance;
            base.azureDomain = azureDomain;            
        }

        /// <summary>
        /// Performs an HttpGet request to CSD's ping API
        /// </summary>
        /// <param name="text">A text value passed by the client</param>
        /// <returns>A ping response object</returns>
        public PingResponse GetPingResponse(string text)
        {
            var response = new PingResponse();

            try
            {
                // Get the Azure Authentication Token 
                var token = base.GetAccessToken();

                // Create an HttpClient and build the query
                HttpClient client = new HttpClient();
                var builder = new UriBuilder(new Uri(string.Format("{0}/{1}?text=", base.csdApiUrl, "ping", text)));
                var query = HttpUtility.ParseQueryString(builder.Query);

                // Assign the token to the authorization header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                
                HttpResponseMessage responseMessage = client.GetAsync(builder.Uri.ToString()).Result;

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Deserialize the response as a typed object in order to view it's returned properties
                    response = JsonConvert.DeserializeObject<PingResponse>(responseMessage.Content.ReadAsStringAsync().Result);

                    // Format the ping text 
                    response.message = $"Ping response:{response.message} - {response.Text}";
                }
                else
                {
                    response.status = responseMessage.StatusCode;
                    response.message = responseMessage.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                response.status = System.Net.HttpStatusCode.InternalServerError;
                response.message = ex.Message;
            }

            return response;
        }
        
        /// <summary>
        /// Post job batches using a request object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public WeatherizationDataTransferResponse PostJobBatches(WeatherizationDataTransferRequest.WeatherizationDataTransfer request)
        {
            var response = new WeatherizationDataTransferResponse();

            try
            {
                // Serialize the request object into XML
                var xmlString = ToXml<WeatherizationDataTransferRequest.WeatherizationDataTransfer>(request);

                // Get the Azure Authentication Token 
                var token = base.GetAccessToken();

                // Create an HttpClient
                HttpClient client = new HttpClient();
                var builder = new UriBuilder(new Uri(string.Format("{0}/{1}/{2}", base.csdApiUrl, "weatherization", "jobbatches")));

                // Assign the token to the authorization header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                // Create an HttpContent object using the XML from the request (you can also submit JSON, just change the type to application/json)
                var httpContent = new StringContent(xmlString, Encoding.UTF8, "application/xml");

                // Call the API as a HttpPost, put the newly created httpContent object into the body of the post
                HttpResponseMessage responseMessage = client.PostAsync(builder.Uri, httpContent).Result;

                // Check the status code for success
                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Deserialize the response as a typed object in order to view it's returned properties
                    response = JsonConvert.DeserializeObject<WeatherizationDataTransferResponse>(responseMessage.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    response.status = responseMessage.StatusCode;
                    response.message = responseMessage.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                response.status = System.Net.HttpStatusCode.InternalServerError;
                response.message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Post job batches using an xml string
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public WeatherizationDataTransferResponse PostJobBatches(string xmlString)
        {
            var response = new WeatherizationDataTransferResponse();

            try
            {
                // Get the Azure Authentication Token 
                var token = base.GetAccessToken();

                // Create an HttpClient
                HttpClient client = new HttpClient();
                var builder = new UriBuilder(string.Format("{0}/{1}/{2}",base.csdApiUrl, "weatherization", "jobbatches"));

                // Assign the token to the authorization header
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var httpContent = new StringContent(xmlString, Encoding.UTF8, "application/xml");

                HttpResponseMessage responseMessage = client.PostAsync(builder.Uri, httpContent).Result;

                if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Deserialize the response as a typed object in order to view it's returned properties
                    response = JsonConvert.DeserializeObject<WeatherizationDataTransferResponse>(responseMessage.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    response.status = responseMessage.StatusCode;
                    response.message = responseMessage.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                response.status = System.Net.HttpStatusCode.InternalServerError;
                response.message = ex.Message;
            }

            return response;
        }

        #region XML Helper Methods

        public string ToXml<T>(T value)
        {
            var stringwriter = new System.IO.StringWriter();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(stringwriter, value);
            return stringwriter.ToString();
        }

        #endregion XML Helper Methods
    }
}
