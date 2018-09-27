using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Globalization;

namespace Csd.Api.Client
{
    public class ClientBase
    {
        public string azureApplicationId { get; set; }
        public string secretKeyValue { get; set; }
        public string azureAdInstance { get; set; }
        public string azureDomain { get; set; }
        public string csdApiUrl { get; set; }

        public string GetAccessToken()
        {
            AuthenticationContext context = new AuthenticationContext(String.Format(CultureInfo.InvariantCulture, azureAdInstance, azureDomain));
            var clientCredential = new ClientCredential(azureApplicationId, secretKeyValue);
            AuthenticationResult result = context.AcquireTokenAsync(azureApplicationId, clientCredential).Result;
            return result.AccessToken;
        }
    }
}
