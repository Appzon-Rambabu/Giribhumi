using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace ROFR.Models
{
    public class TokenResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Bearer { get; set; }
        public string DetailedMessage { get; set; }
    }
    public class Inputdet
    {
        public string DistrictCode { get; set; }
    }
    public class HouseholdResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public  List<Household> HHData { get; set; }
    }

    public class Household
    {
        public int DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string CitizenNumber { get; set; }
        public string CitizenName { get; set; }
    }

    //11-02-2025 ADD
    public class IBCBResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<IBCBhold> IBCBData { get; set; }
    }
    public class IBCBhold
    {
        public int DistrictCode { get; set; }
        public string DistrictName { get; set; }
        public string CitizenNumber { get; set; }
        public string CitizenName { get; set; }
        public string MandalName { get; set; }
        public string MandalCode { get; set; }
        public string PanchayatName { get; set; }
        public string PanchayatCode { get; set; }
        public string VillageName { get; set; }
        public string VillageCode { get; set; }
        public string Void { get; set; }

        public string VoName { get; set; }
        public string VOAName { get; set; }
        public string VoAMobilNo { get; set; }
        public string ShgId { get; set; }
        public string ShgName { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberMobileNo { get; set; }
        public string MemberUID { get; set; }

    }
    public class Inputdata
    {
        public string DistrictId { get; set; }
    }
}