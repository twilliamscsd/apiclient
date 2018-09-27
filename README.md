# CSD API Client

A simple API client which can be used as a template for integrating with CSD's API services.

### Prerequisites

This solution uses Microsoft .Net Core 2.0.1 Framework

## Getting Started

Under the project Csd.Api.ClientConsole, set the values for "ApplicationId" and "SecretKeyValue" in the appSettings.json file to match the values provided for authorized users in order to begin use.

```
{
  "AzureAdCsdApi": {
    "Instance": "https://login.windows.net/{0}",
    "Domain": "CommSvcsDev.onmicrosoft.com",
    "ApplicationId": "",
    "SecretKeyValue": "",
    "DwellingExclusionsURL": "https://services.csd.ca.gov/api/dwellingexclusions"
  }
}
```

## Using the Ping API

Open the Csd.Api.ClientConsole project and review the code under "Program.cs".  In the method for "Main" view the code required to make a new Ping request:

```
// Create a client with the required security information
ApiClient client = new ApiClient(_csdApiUrl, _azureApplicationId, _secretKeyValue, _azureAdInstance, _azureDomain);
/*
* A response object models what the API is going to return.  All CSD API responses
* have a 'status' and a 'message' at the top most level of the returned object.
* A status is the HTTPStatusCode (ie 200, 404, 500, etc)
* A message will give detailed info on the API transaction
* */

// Call the API and get your response object
var response = client.GetPingResponse(returnText);

/*
* From here you are free to perform any business related needs with the response object
*/
if (response != null)
{
  Console.WriteLine("Csd Api Call Completed");
  Console.WriteLine("Status:{0} Message: {1}", response.status, response.message);
}
```

Run the application.  You will be prompted to type some text which will be passed in the request to the API and returned back with a status message. You can inspect the returned "response" object from the API by setting a break point on the line which evaluates 
```
"if (response != null)".
```

## Built With

* [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300) - Framework
* [Microsoft Visual Studio 2017](https://www.visualstudio.com/downloads/) - IDE

## Authors

* **Tony Williams** - *Initial work* - tony.williams@csd.ca.gov
