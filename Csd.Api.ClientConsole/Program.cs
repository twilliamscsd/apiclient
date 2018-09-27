using Csd.Api.Client;
using Csd.Api.Client.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;


namespace Csd.Api.ClientConsole
{
    class Program
    {
        private static string _csdApiUrl { get; set; }
        private static string _azureApplicationId { get; set; }
        private static string _secretKeyValue { get; set; }
        private static string _azureAdInstance { get; set; }
        private static string _azureDomain { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()                
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            _csdApiUrl = configuration.GetSection("AzureAdCsdApi:CsdApiUrl").Value;
            _azureApplicationId = configuration.GetSection("AzureAdCsdApi:ApplicationId").Value;
            _secretKeyValue = configuration.GetSection("AzureAdCsdApi:SecretKeyValue").Value;
            _azureAdInstance = configuration.GetSection("AzureAdCsdApi:Instance").Value;
            _azureDomain = configuration.GetSection("AzureAdCsdApi:Domain").Value;

            DisplayMainMenu();

            var selection = Console.ReadLine();

            switch(selection)
            {
                case "1":
                    PerformPingRequest();
                    break;
                case "2":
                    PerformWeatherizationDataTransferJobBatchSubmission();
                    break;
                case "3":
                    PerformWeatherizationDataTransferJobBatchSubmissionXmlFile();
                    break;
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Enter the menu item number to perform an API call:\r\n{0}{1}{2}",
                "1. Ping \r\n",
                "2. WX - JobBatch Submission - Request object\r\n",
                "3. WX - JobBatch Submission - XML File\r\n");
        }

        static void PerformPingRequest()
        {
            Console.WriteLine("Enter some text to be returned in the ping request");
            var returnText = Console.ReadLine();

            if (!string.IsNullOrEmpty(returnText))
            {
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
            }            
        }        

        static void PerformWeatherizationDataTransferJobBatchSubmission()
        {
            // Create a client with the required security information
            ApiClient client = new ApiClient(_csdApiUrl, _azureApplicationId, _secretKeyValue, _azureAdInstance, _azureDomain);

            /*
             * Building a request object is optional, you can also just post the XML directly in the body of the API call:  
             * View PostJobBatches(string xmlString) for an example.
             * 
             * In this example the XML is deserialized into a request object in order to model a system where the
             * data may have been loaded from a database prior to being posted to the API.
             * */


            WeatherizationDataTransferRequest.WeatherizationDataTransfer request = new WeatherizationDataTransferRequest.WeatherizationDataTransfer
            {
                AgencyCode = "",
                BatchGUID = "",
                EmailAddress = "",
                JobRecord = GetTestJobRecords()
            };

            // Call the API and get your response object
            var response = client.PostJobBatches(request);

            /*
             * From here you are free to perform any business related needs with the response object
             */
            if (response != null)
            {
                Console.WriteLine("Csd Api Call Completed");
                Console.WriteLine("Status:{0} Message: {1}", response.status, response.message);
            }
        }

        static void PerformWeatherizationDataTransferJobBatchSubmissionXmlFile()
        {
            Console.WriteLine("Enter the path to the XML file for upload");
            var inputPath = Console.ReadLine();
            if (File.Exists(inputPath))
            {
                // Create a client with the required security information
                ApiClient client = new ApiClient(_csdApiUrl, _azureApplicationId, _secretKeyValue, _azureAdInstance, _azureDomain);

                string xmlString = System.IO.File.ReadAllText(inputPath);

                var response = client.PostJobBatches(xmlString);

                /*
                * From here you are free to perform any business related needs with the response object
                */
                if (response != null)
                {
                    Console.WriteLine("Csd Api Call Completed");
                    Console.WriteLine("Status:{0} Message: {1}", response.status, response.message);
                }
            }
            else
            {
                Console.WriteLine("Invalid path");
                DisplayMainMenu();

            }
        }

        #region JobRecord Test Data

        static WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecord[] GetTestJobRecords()
        {
            WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecord[] jobRecords = new WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecord[1];
            jobRecords[0] = new WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecord();
            jobRecords[0].age3_to_5 = 0;
            jobRecords[0].age6_to_18 = 0;
            jobRecords[0].application_control_code = "999999999999";
            jobRecords[0].area_code = "916";
            jobRecords[0].building_control_code = null;
            jobRecords[0].building_structure_type_code = "ST";
            jobRecords[0].census_tract_number = "";
            jobRecords[0].cooking_appliance_operation_status_code = "OPER";
            jobRecords[0].cooking_appliance_type = "RNG";
            jobRecords[0].cooking_energy_type_code = "NGAS";
            jobRecords[0].cooking_appliance_operation_status_code = "OPER";
            jobRecords[0].cooling_appliance_type_code = "ACC";
            jobRecords[0].date_of_birth = DateTime.Parse("1959-07-01");
            jobRecords[0].disabled = 1;
            jobRecords[0].dwelling_control_code = "999999999999";
            jobRecords[0].dwelling_hud_funded = "N";
            jobRecords[0].dwelling_tenure = 101;
            jobRecords[0].expenditure_report_period = "2018-05";
            jobRecords[0].eligibility_date = DateTime.Parse("2018-05-01");
            jobRecords[0].enviroscreen_score = "96-100";
            jobRecords[0].farmworker = 0;
            jobRecords[0].first_name = "test";
            jobRecords[0].heating_appliance_operation_status_code = "NOOP";
            jobRecords[0].heating_appliance_type_code = "FAU";
            jobRecords[0].heating_energy_type_code = "NGAS";
            jobRecords[0].household_size = 2;
            jobRecords[0].job_assessment_date = DateTime.Parse("2018-05-01");
            jobRecords[0].job_completed_date = DateTime.Parse("2018-05-10");
            jobRecords[0].job_control_code = "999999999999";
            jobRecords[0].last_name = "test";
            jobRecords[0].limited_english = 0;
            jobRecords[0].mail_address = "1234 Main";
            jobRecords[0].mail_apt_unit_number = null;
            jobRecords[0].mail_city = "Anytown";
            jobRecords[0].mail_state_code = "CA";
            jobRecords[0].mail_zip_code = "99999";
            jobRecords[0].middle_initial = null;
            jobRecords[0].monthly_cost = 77.750m;
            jobRecords[0].monthly_income = 775.75m;
            jobRecords[0].native_american = 0;
            jobRecords[0].age_60_or_over = 0;
            jobRecords[0].phone = "9999999999";
            jobRecords[0].pos_address = "1234 Main";
            jobRecords[0].pos_apt_unit_number = null;
            jobRecords[0].pos_city = "Anytown";
            jobRecords[0].pos_state_code = "CA";
            jobRecords[0].pos_zip_code = "99999";
            jobRecords[0].recordset_status_code = "WX";
            jobRecords[0].shpo_pds_id_number = null;
            jobRecords[0].ssn = "999999999";
            jobRecords[0].tenant_status_type = "OWN";
            jobRecords[0].utility_account_number_electric = "9999999999";
            jobRecords[0].utility_account_number_gas = "9999999999";
            jobRecords[0].utility_company_code_electric = "A";
            jobRecords[0].utility_company_code_gas = "A";
            jobRecords[0].utility_information_release_consent = "BOTH";
            jobRecords[0].utility_service_address_id_electric = null;
            jobRecords[0].utility_service_address_id_gas = null;
            jobRecords[0].water_heating_appliance_type = "CONV";
            jobRecords[0].water_heating_energy_type_code = "NGAS";
            jobRecords[0].water_heating_appliance_operation_status_code = "OPER";
            jobRecords[0].year_built = 1996;

            jobRecords[0].MeasureRecord = GetTestJobRecordMeasureRecords();

            return jobRecords;
        }

        static WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecordMeasureRecord[] GetTestJobRecordMeasureRecords()
        {
            WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecordMeasureRecord[] measureRecords = new WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecordMeasureRecord[1];
            measureRecords[0] = new WeatherizationDataTransferRequest.WeatherizationDataTransferJobRecordMeasureRecord();
            measureRecords[0].measure_control_code = "99999999-TEST-WXDB-MEAS-200000000D02";
            measureRecords[0].lsp_contract_number = "16B-4008";
            measureRecords[0].measure_capacity = 0;
            measureRecords[0].measure_code = 1;
            measureRecords[0].measure_count = 1;
            measureRecords[0].measure_efficiency = 0;
            measureRecords[0].measure_non_feasibility_code = null;
            measureRecords[0].measure_fees_amount = 0;
            measureRecords[0].measure_installation_date = DateTime.Now;
            measureRecords[0].measure_labor_amount = 100;
            measureRecords[0].measure_labor_hours_count = 9.0m;
            measureRecords[0].measure_materials_amount = 0;
            measureRecords[0].measure_rebate_amount = 0;
            measureRecords[0].measure_reweatherization_justification_code = null;
            measureRecords[0].measure_report_group = "160";
            measureRecords[0].measure_subcontractor_amount = 0;
            measureRecords[0].measure_type_code =55;
            measureRecords[0].measure_waiver_code = null;
            measureRecords[0].subprogram_code = "LHWX";

            return measureRecords;
        }

        #endregion JobRecord Test Data
    }
}
