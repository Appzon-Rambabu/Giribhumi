using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;

namespace ROFR.helper
{
    public class MastersDataAnalysisBAL
    {
        public class MastersDataAnalysis
        {
            public static DataTable GetextentlandbenvillageDetails(string itda,string district, string mandal, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetextentlandbenvillageDetails(itda,district, mandal, username);
            }
            public static DataTable Getextentlandbenhabitations(string Itda, string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getextentlandbenhabitations(Itda, district, mandal, village);
            }

            public static DataTable Getextentlandbenpattadhar(string Itda, string district, string mandal, string village, string habitation)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getextentlandbenpattadhar(Itda, district, mandal, village, habitation);
            }
            public static DataTable Getextentlandbenpattadharextent(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getextentlandbenpattadharextent(Itda, district, mandal, village, habitation, PATTADAAR);
            }
            public static DataTable GetDistrictdetails(string USERNAME, string Type, string district, string mandal)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetDistrictdetails(USERNAME, Type, district, mandal);
            }
            public static DataTable GetDistrictMasterAnalysis(string district, string mandal, string division, string Type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetDistrictMasterAnalysis(district, mandal, division, Type);
            }

            public static DataTable GetMandalMasterAnalysis(string district, string mandal, string end, string Type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetMandalMasterAnalysis(district, mandal, end, Type);
            }

            public static DataTable Getbasedonvillagestartandend(string start, string end)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbasedonvillagestartandend(start, end);
            }

            public static DataTable GetForestDivisionAnalysis(string district, string division, string end, string Type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestDivisionAnalysis(district, division, end, Type);
            }

            public static DataTable GetForestRangeAnalysis(string district, string division, string end, string Type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestRangeAnalysis(district, division, end, Type);
            }

            public static DataTable GetAllBeats()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetAllBeats();
            }

            public static DataTable GetvillageBeats(string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetvillageBeats(district, mandal, village);
            }

            public static DataTable GetrangeBeats(string district, string mandal, string division, string range)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetrangeBeats(district, mandal, division, range);
            }

            public static DataTable GetHabitations(string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetHabitations(district, mandal, village);
            }

            public static DataTable GetHabitationsforest(string district, string mandal, string village, string habitation)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetHabitationsforest(district, mandal, village, habitation);
            }

            public static DataTable GetbenmandalDetails(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetbenmandalDetails(district, username);
            }
            public static DataTable GetbenvillageDetails(string district, string mandal, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetbenvillageDetails(district, mandal, username);
            }

            public static DataTable GetbenitdaDetails(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetbenitdaDetails(district, username);
            }

            public static DataTable GetDLCcount(string ITDA,string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetDLCcount(ITDA,district, mandal, village);
            }

            public static DataTable GetDlcBeneficiaryDetails(string itda,string district, string mandal, string village,string Habitation)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetDlcBeneficiaryDetails(itda,district, mandal, village, Habitation);
            }


            public static DataTable GetdlcmandalDetails(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetdlcmandalDetails(district, username);
            }
            public static DataTable GetBeneficiaryMasterAnalysis(string itda, string district, string benficiary)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetBeneficiaryMasterAnalysis(itda, district, benficiary);
            }

            public static DataTable Getbenhabitions(string Itda, string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenhabitations(Itda, district, mandal, village);
            }

            public static DataTable Getbenpattadhar(string Itda, string district, string mandal, string village, string habitation)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenpattadhar(Itda, district, mandal, village, habitation);
            }

            public static DataTable Getbenpattadharextent(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string bid)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenpattadharextent(Itda, district, mandal, village, habitation, PATTADAAR,bid);
            }

            public static DataTable Getbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenlatlongsdata(Itda, district, mandal, village, habitation, PATTADAAR, extent);
            }

            public static DataTable Getbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenlatlongsdata(Itda, district, mandal, village, habitation, PATTADAAR, extent, id);
            }

            public static DataTable INSERTlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id, BeneficiaryDetails BeneficiaryDetailsobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.INSERTlatlongsdata(Itda, district, mandal, village, habitation, PATTADAAR, extent, id, BeneficiaryDetailsobj);
            }

            public static DataTable INSERTMultiplelatlongsdata(string Itda,  BeneficiaryDetails BeneficiaryDetailsobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.INSERTMultiplelatlongsdata(Itda,  BeneficiaryDetailsobj);
            }

            public static DataTable addINSERTlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent, string id, string LAT, string LONG)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.addINSERTlatlongsdata(Itda, district, mandal, village, habitation, PATTADAAR, extent, id, LAT, LONG);
            }

            public static DataTable updatelatlongsdata(string latid, string id, string LAT, string LONG)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.updatelatlongsdata(latid, id, LAT, LONG);
            }

            public static DataTable DELETElatlongsdata(string latid, string id)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.DELETElatlongsdata(latid, id);
            }

            public static DataTable GetextentlandbenitdaDetails(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetextentlandbenitdaDetails(district, username);
            }

            public static DataTable GetextentlandbenmandalDetails(string itda,string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetextentlandbenmandalDetails(itda,district, username);
            }

            public static DataTable Getextentlandbenlatlongsdata(string Itda, string district, string mandal, string village, string habitation, string PATTADAAR, string extent)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getextentlandbenlatlongsdata(Itda, district, mandal, village, habitation, PATTADAAR, extent);
            }

            public static DataTable GetltrMasterAnalysis(string Itda, string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetltrMasterAnalysis(Itda, district, mandal, village);
            }

            public static DataTable Landstatusreport()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Landstatusreport();
            }
            public static DataTable Landstatusreport_Beneficiary()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Landstatusreport_Beneficiary();
            }

            public static DataTable Nothavinglanddetailsreport()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Nothavinglanddetailsreport();
            }

            public static DataTable Nothavinglanddetailslevelreport(string Itda, string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Nothavinglanddetailslevelreport(Itda, district);
            }

            public static DataTable Getnregaadharrecords(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getnregaadharrecords(district, username);
            }
            public static DataTable Getnregaadharrecordsinsert(string ITDA_NAME, string Aadhaar_NO, string JobCardID, string JobCardName, string JobCardStatus, string WorkCode, string WorkName, string WorkStatus, string Activity, string EstimtedCost, string Expenditure, string CreatedDate, string CompletionDate, string LandExtent)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getnregaadharrecordsinsert(ITDA_NAME, Aadhaar_NO, JobCardID, JobCardName, JobCardStatus, WorkCode, WorkName, WorkStatus, Activity, EstimtedCost, Expenditure, CreatedDate, CompletionDate, LandExtent);
            }

            public dynamic Getbenallrecordsnerga()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getbenallrecordsnerga();
            }
        }
    }
}