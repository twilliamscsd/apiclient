using System.Xml.Serialization;

namespace Csd.Api.Client.Models
{
    public class WeatherizationDataTransferRequest
    {

        [System.Xml.Serialization.XmlRoot("WeatherizationDataTransfer")]
        public partial class WeatherizationDataTransfer
        {
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("JobRecord")]
            public WeatherizationDataTransferJobRecord[] JobRecord { get; set; }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("LWJobRecord")]
            public WeatherizationDataTransferLWJobRecord[] LWJobRecord { get; set; }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AgencyCode { get; set; }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string BatchGUID { get; set; }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string EmailAddress { get; set; }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class WeatherizationDataTransferJobRecord 
        {
            public byte age3_to_5 { get; set; }

            public byte age6_to_18 { get; set; }

            public byte age19_to_59 { get; set; }

            public string application_control_code { get; set; }

            public string area_code { get; set; }

            public string building_control_code { get; set; }

            public string building_structure_type_code { get; set; }

            public string census_tract_number { get; set; }

            public string cooking_appliance_operation_status_code { get; set; }

            public string cooking_appliance_type { get; set; }

            public string cooking_energy_type_code { get; set; }

            public string cooling_appliance_operation_status_code { get; set; }

            public string cooling_appliance_type_code { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime date_of_birth { get; set; }

            public byte disabled { get; set; }

            public string dwelling_control_code { get; set; }

            public string dwelling_hud_funded { get; set; }

            public int building_number_of_units { get; set; }

            public int dwelling_tenure { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "gYearMonth")]
            public string expenditure_report_period { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime eligibility_date { get; set; }

            public string eligibility_type { get; set; }

            public string enviroscreen_score { get; set; }

            public byte farmworker { get; set; }

            public string first_name { get; set; }

            public string heating_appliance_operation_status_code { get; set; }

            public string heating_appliance_type_code { get; set; }

            public string heating_energy_type_code { get; set; }

            public byte household_size { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime intake_date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime job_assessment_date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime job_completed_date { get; set; }

            public string job_control_code { get; set; }

            public string last_name { get; set; }

            public byte limited_english { get; set; }

            public string mail_address { get; set; }

            public string mail_apt_unit_number { get; set; }

            public string mail_city { get; set; }

            public string mail_state_code { get; set; }

            public string mail_zip_code { get; set; }

            public string middle_initial { get; set; }

            public decimal monthly_cost { get; set; }

            public decimal monthly_income { get; set; }

            public byte native_american { get; set; }

            public byte age_60_or_over { get; set; }

            public string phone { get; set; }

            public string pos_address { get; set; }

            public string pos_apt_unit_number { get; set; }

            public string pos_city { get; set; }

            public string pos_county_code { get; set; }

            public string pos_state_code { get; set; }

            public string pos_zip_code { get; set; }

            public string recordset_status_code { get; set; }

            public string shpo_pds_id_number { get; set; }

            public string ssn { get; set; }

            public string tenant_status_type { get; set; }

            public byte age_2_or_under { get; set; }

            public string utility_account_number_electric { get; set; }

            public string utility_account_number_gas { get; set; }

            public string utility_company_code_electric { get; set; }

            public string utility_company_code_gas { get; set; }

            private string _utility_information_release_consent;
            public string utility_information_release_consent
            {
                get
                {
                    return _utility_information_release_consent;
                }
                set
                {
                    _utility_information_release_consent = value.Replace("/", "");
                }
            }

            public string utility_service_address_id_electric { get; set; }

            public string utility_service_address_id_gas { get; set; }

            public string water_heating_appliance_type { get; set; }

            public string water_heating_energy_type_code { get; set; }

            public string water_heating_appliance_operation_status_code { get; set; }

            public int year_built { get; set; }

            [XmlElement("MeasureRecord")]
            public WeatherizationDataTransferJobRecordMeasureRecord[] MeasureRecord { get; set; }
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlType(AnonymousType = true)]
        public partial class WeatherizationDataTransferJobRecordMeasureRecord 
        {
            public string measure_control_code { get; set; }

            public string lsp_contract_number { get; set; }

            public decimal measure_capacity { get; set; }

            public int measure_code { get; set; }

            public int measure_count { get; set; }

            public decimal measure_efficiency { get; set; }

            public string measure_non_feasibility_code { get; set; }

            public decimal measure_fees_amount { get; set; }

            [XmlElement(DataType = "date")]
            public System.DateTime measure_installation_date { get; set; }

            public decimal measure_labor_amount { get; set; }

            public decimal measure_labor_hours_count { get; set; }

            public decimal measure_materials_amount { get; set; }

            public decimal measure_rebate_amount { get; set; }

            public string measure_reweatherization_justification_code { get; set; }

            public string measure_report_group { get; set; }

            public decimal measure_subcontractor_amount { get; set; }

            public int measure_type_code { get; set; }

            public string measure_waiver_code { get; set; }

            public string subprogram_code { get; set; }
          
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class WeatherizationDataTransferLWJobRecord 
        {
            public byte age_18_and_under { get; set; }

            public string application_control_code { get; set; }

            public string area_code { get; set; }

            public decimal audit_driven_kwh_savings { get; set; }

            public decimal audit_driven_therm_savings { get; set; }

            public string audit_id { get; set; }

            public string building_structure_type_code { get; set; }

            public string census_tract_number { get; set; }

            public string cooling_appliance_type_code { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime date_of_birth { get; set; }

            public byte disabled { get; set; }

            public string dwelling_control_code { get; set; }

            public int dwelling_tenure { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "gYearMonth")]
            public string expenditure_report_period { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime eligibility_date { get; set; }

            public string eligibility_type { get; set; }

            public byte farmworker { get; set; }

            public string first_name { get; set; }

            public string heating_appliance_type_code { get; set; }

            public string heating_energy_type_code { get; set; }

            public byte household_size { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime job_assessment_date { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime job_completed_date { get; set; }

            public string job_control_code { get; set; }

            public string last_name { get; set; }

            public string leveraged_program { get; set; }

            public decimal leveraged_health_and_safety { get; set; }

            public decimal leveraged_home_repair { get; set; }

            public decimal leveraged_other_energy_efficiency { get; set; }

            public byte limited_english { get; set; }

            public string mail_address { get; set; }

            public string mail_apt_unit_number { get; set; }

            public string mail_city { get; set; }

            public string mail_state_code { get; set; }

            public string mail_zip_code { get; set; }

            public string middle_initial { get; set; }

            public decimal monthly_income { get; set; }

            public byte native_american { get; set; }

            public byte age_60_or_over { get; set; }

            public decimal package_sir { get; set; }

            public string phone { get; set; }

            public string pos_address { get; set; }

            public string pos_apt_unit_number { get; set; }

            public string pos_city { get; set; }

            public string pos_county_code { get; set; }

            public string pos_state_code { get; set; }

            public string pos_zip_code { get; set; }

            public string recordset_type { get; set; }

            public string tenant_type { get; set; }

            public string utility_account_number_electric { get; set; }

            public string utility_account_number_gas { get; set; }

            public string utility_company_code_electric { get; set; }

            public string utility_company_code_gas { get; set; }

            private string _utility_information_release_consent;
            public string utility_information_release_consent
            {
                get
                {
                    return _utility_information_release_consent;
                }
                set
                {
                    _utility_information_release_consent = value.Replace("/", "");
                }
            }

            public string utility_service_address_id_electric { get; set; }

            public string utility_service_address_id_gas { get; set; }

            public string water_heating_appliance_type_code { get; set; }

            public string water_heating_energy_type_code { get; set; }

            public int year_built { get; set; }

            [XmlElement("MeasureRecord")]
            public WeatherizationDataTransferLWJobRecordMeasureRecord[] MeasureRecord { get; set; }

            [XmlElement("SolarRecord")]
            public WeatherizationDataTransferLWJobRecordSolarRecord[] SolarRecord { get; set; }


        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class WeatherizationDataTransferLWJobRecordMeasureRecord 
        {
            public string measure_control_code { get; set; }

            public string ra_contract_number { get; set; }

            public decimal measure_existing_capacity { get; set; }

            public decimal measure_new_capacity { get; set; }

            public int measure_code { get; set; }

            public int measure_count { get; set; }

            public decimal measure_existing_efficiency { get; set; }

            public decimal measure_new_efficiency { get; set; }

            public decimal measure_reimbursement_amount { get; set; }

            public string measure_non_feasibility_code { get; set; }

            public string measure_leveraging_type { get; set; }

            public decimal measure_installation_cost { get; set; }

            [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
            public System.DateTime measure_installation_date { get; set; }

            public decimal measure_leveraged_amount { get; set; }

            public string measure_report_group { get; set; }

            public decimal measure_sir { get; set; }

            public int measure_type_code { get; set; }

            public string subprogram_code { get; set; }

        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class WeatherizationDataTransferLWJobRecordSolarRecord
        {

            public string ra_contract_number { get; set; }

            public int annual_average_access { get; set; }

            public decimal annual_pv_production { get; set; }

            public string array_type { get; set; }

            public int azimuth { get; set; }

            public string backup_water_heater_type { get; set; }

            public decimal dc_system_size { get; set; }

            public decimal dc_to_ac_size_ratio { get; set; }

            public decimal ground_coverage_ratio { get; set; }

            public decimal inverter_efficiency { get; set; }

            public string module_type { get; set; }

            public string solar_control_code { get; set; }

            public int solar_measure_code { get; set; }

            public int solar_measure_type_code { get; set; }

            public string solar_measure_report_group { get; set; }

            public decimal solar_installation_cost { get; set; }

            public decimal solar_leveraged_amount { get; set; }

            public string solar_leveraging_type { get; set; }

            public decimal solar_reimbursement_amount { get; set; }

            public string solar_subprogram_code { get; set; }

            public decimal system_losses { get; set; }

            public decimal tilt { get; set; }

            
        }

        public partial class JobRejectionReason
        {
            public string MeasureControlCode { get; set; }
            public string BusinessRuleCode { get; set; }
            public string ReasonText { get; set; }
        }
    }
}
