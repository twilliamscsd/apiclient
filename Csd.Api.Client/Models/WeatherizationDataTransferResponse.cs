using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Csd.Api.Client.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WeatherizationDataTransferResponse 
    {
        public BatchRecord[] BatchRecords { get; set; }

        public HttpStatusCode status { get; set; }
        public string message { get; set; }

        public class BatchRecord
        {

            private string[] batchRejectionReasonsField;

            /// <remarks/>
            public string BatchGUID { get; set; }


            /// <remarks/>
            public DateTime BatchReceivedDate { get; set; }


            /// <remarks/>
            public string BatchStatus { get; set; }


            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("BatchRejectionReason", IsNullable = false)]
            public string[] BatchRejectionReasons
            {
                get
                {
                    return this.batchRejectionReasonsField;
                }
                set
                {
                    this.batchRejectionReasonsField = value;
                }
            }

            public JobRecord[] JobRecord { get; set; }
        }
        public class JobRecord
        {
            public string jobControlCode { get; set; }
            public DateTime jobStatusDate { get; set; }
            public string jobRecordsetStatusCode { get; set; }
            public string jobReportingPeriod { get; set; }
            public string jobStatus { get; set; }
            public JobProgram[] jobProgramRecord { get; set; }
            public JobRejection[] jobRejectRecord { get; set; }
        }

        public class JobProgram
        {
            public string jobProgramCode { get; set; }
            public string jobProgramStatus { get; set; }
            public int jobProgramEARSAdjustmentNumber { get; set; }
        }

        public class JobRejection
        {
            public string jobRejectMeasureControlCode { get; set; }
            public string jobRejectBusinessRuleCode { get; set; }
            public string jobRejectReason { get; set; }
        }
    }
}
