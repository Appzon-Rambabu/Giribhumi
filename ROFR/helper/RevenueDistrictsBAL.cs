using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;

namespace ROFR.helper
{
    public class RevenueDistrictsBAL
    {
        public class RevenueDistricts
        {
            public static DataTable GetDistrictMasterAnalysis(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetDistrictMasterAnalysis(USERNAME, Type, district, mandal);
            }

            public static DataTable GetForestMasterAnalysis(string USERNAME, string Type, string district, string division, string range)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetForestMasterAnalysis(USERNAME, Type, district, division, range);
            }

            public static DataTable GetForestDivisionMasterAnalysis(string USERNAME, string Type, string division, string range)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetForestDivisionMasterAnalysis(USERNAME, Type, division, range);
            }

            public static DataTable GetDistrictdetails(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetDistrictdetails(USERNAME, Type, district, mandal);
            }

            public static DataTable GetItdadetails(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetItdadetails(USERNAME, Type, district, mandal);
            }

            public static DataTable GetCurdForestDivisionMasterAnalysis(string USERNAME, string Type, string division, string range)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetCurdForestDivisionMasterAnalysis(USERNAME, Type, division, range);
            }

            public static void InsertForesthab(string district, string mandal, string village, string villagename, string habname, string revname, string Ipaddress, string username)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                userObj.InsertForesthab(district, mandal, village, villagename, habname, revname, Ipaddress, username);
            }

            public static void UpdateForesthab(string Id, string district, string mandal, string village, string habname, string revname, string Ipaddress, string username)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                userObj.UpdateForesthab(Id, district, mandal, village, habname, revname, Ipaddress, username);
            }

            public static DataTable Getadddetails(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.Getadddetails(USERNAME, Type, district, mandal);
            }

            public static DataTable Getcheckergridmasters(string USERNAME, string Type, string district, string mandal, string village)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.Getcheckergridmasters(USERNAME, Type, district, mandal, village);
            }
            public static DataTable Search(string USERNAME,string itda, string district, string mandal, string village,string pattadhar,string aadhar, string pattano,string start,string end)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.Search(USERNAME, itda, district, mandal, village,pattadhar,aadhar,pattano,start,end);
            }
            public static DataTable GetItdaMaster(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetItdaMaster(USERNAME, Type, district, mandal);
            }
            public static DataTable Getbeneficiarytransaction(string USERNAME, string Type, string district, string mandal, string village, string adhar)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.Getbeneficiarytransaction(USERNAME, Type, district, mandal, village, adhar);
            }

            public static DataTable GetExtentlandItdadetails(string USERNAME, string Type, string district, string mandal)
            {
                RevenueDistrictsDAL.RevenueDistricts userObj = new RevenueDistrictsDAL.RevenueDistricts();
                return userObj.GetExtentlandItdadetails(USERNAME, Type, district, mandal);
            }
        }
    }
}