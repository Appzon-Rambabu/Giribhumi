using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROFR.Models
{
    public class crfclass
    {
       public class crfinsertion
        {
            public string Itda_Code { get; set; }
            public string Itda_Name { get; set; }
            public string District_Code { get; set; }
            public string District { get; set; }
            public string Mandal_Code { get; set; }
            public string Mandal { get; set; }
            public string Panchayat_Code { get; set; }
            public string Panchayat { get; set; }
            public string Rev_Village_code { get; set; }
            public string Rev_Village { get; set; }
            public string Village_Code { get; set; }
            public string Village { get; set; }
            public string HabitationCode { get; set; }
            public string Habitation { get; set; }
            public string Forest_DivisionCode { get; set; }
            public string Forest_Division { get; set; }
            public string Forest_RangeCode { get; set; }
            public string Forest_Range { get; set; }
            public string Forest_BeatCode { get; set; }
            public string Forest_Beat { get; set; }
            public string Forest_Block { get; set; }
            public string Compartment_No { get; set; }
            public string Khasra_No { get; set; }
            public string ROFR_PATTANO { get; set; }
            public string Boundaries_Description { get; set; }
            public string Total_CFR_Members { get; set; }
            public string Total_Extent { get; set; }
            public string CFR_Nature { get; set; }
            public string Utilization_Status { get; set; }
            public string Support_Required { get; set; }
            public string Remarks { get; set; }
            public string CFR_Document { get; set; }
            public string user_name { get; set; }
            public string IPADDRESS { get; set; }
        }

        public class LandDetailsResponse
        {
            public string Code { get; set; }
            public string village_lgd_code { get; set; }
            public LandIdentifiers land_identifiers { get; set; }
            public string total_plot_area { get; set; }
            public string total_plot_area_decimal_part { get; set; }
            public string area_unit { get; set; }
            public List<OwnerDetails> owner_details { get; set; }
            public string Message { get; set; }
            
            public string RequestedAt { get; set; }
        }

        public class LandIdentifiers
        {
            public string survey_number { get; set; }
            public string unique_land_code { get; set; }
        }

        public class OwnerDetails
        {
            public string khata_number { get; set; }
            public string farm_id { get; set; }
            public string owner_number { get; set; }
            public string main_owner_number { get; set; }
            public string owner_name_ror { get; set; }
            public string owner_name_english { get; set; }
            public string owner_extent { get; set; }
            public string owner_extent_decimal_part { get; set; }
            public string owner_share { get; set; }
            public string land_usage_type { get; set; }
            public string owner_category { get; set; }
            public string identifier_type { get; set; }
            public string identifier_name_ror { get; set; }
            public string identifier_name_english { get; set; }
            public string government_liability { get; set; }
            public string private_liability { get; set; }
            public string Resurvey { get; set; }
        }

    }
}