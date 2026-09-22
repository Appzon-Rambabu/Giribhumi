using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;
using System.Dynamic;
using ROFR.Models;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using static ROFR.Models.FormHelper;
using System.Globalization;

namespace ROFR.helper
{
    public class Landsettlementpattas
    {
      public static DataTable GetmandalMasterAnalysis()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetmandalMasterAnalysis();
        }
        public static DataTable GetGirimandalMasterAnalysis(rofrObject obj)
        {
            ConnectionClass con = new ConnectionClass();
           return con.Data(obj);
        }
        public static DataTable GetvillageMasterAnalysis(string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetvillageMasterAnalysis(mandal);
        }

        public static DataTable GetData(string mandal, string village)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetData(mandal,village);
        }

        public static DataTable GetData(string ID)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetData(ID);
        }

        public static DataTable ItdaWiseGetData()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseGetData();
        }
        public static DataTable ItdaWiseCompartmentsData(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseCompartmentsData(Itda);
        }
        public static DataTable ItdaWiseCompartmentsInTwoMandals(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseCompartmentsInTwoMandals(Itda);
        }
        public static DataTable MandalCompartmentsInTwoMandals(string Itda, string Mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.MandalCompartmentsInTwoMandals(Itda,Mandal);
        }
        public static DataTable ItdawiseTotals(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdawiseTotals(Itda);
        }
        public static DataTable ItdawiseTotals()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdawiseTotals();
        }
        public static DataTable ForestDivisionWiseGetData()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ForestDivisionWiseGetData();
        }

        public static DataTable ItdaWiseGetData(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseGetData(Itda);
        }
       
        public static DataTable ForestRangeGetData(string FD)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ForestRangeGetData(FD);
        }
        public static DataTable ItdaWiseGetData(string Itda, string Mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseGetData(Itda, Mandal);
        }

        public static DataTable ForestBeatGetData(string fd, string fr)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ForestBeatGetData(fd, fr);
        }
        public static DataTable ItdaWiseGetData(string Itda, string Mandal,string village)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdaWiseGetData(Itda, Mandal,village);
        }

        public static DataTable ForestCompartmentWiseGetData(string fd, string fr, string fb)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ForestCompartmentWiseGetData(fd, fr, fb);
        }
        public static DataTable GetRdoDocuments(string Id)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetRdoDocuments(Id);
        }
        public static DataTable DeleteRdoDocuments(int Id)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.DeleteRdoDocuments(Id);
        }
        public static DataTable UploadRdoDocuments(int Id,string filename)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.UploadRdoDocuments(Id,filename);
        }
        public static DataTable Land_Transfer_file_retrieve(string Id)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Land_Transfer_file_retrieve(Id);
        }
        public static DataTable PopulationGetData()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.PopulationGetData();
        }
        public static DataTable GetPopulationData(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetPopulationData(Itda);
        }
        public static DataSet PopulationGetDat()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.PopulationGetDat();
        }
        public static DataTable PopulationGetData(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.PopulationGetData(Itda);
        }
        public static DataTable PopulationGetData(string Itda, string Mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.PopulationGetData(Itda, Mandal);
        }

        public static DataTable GetAllComparementsLatlongs()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetAllComparementsLatlongs();
        }

        public static DataTable ItdawiseComparementsLatlongs(string Itda, string Mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ItdawiseComparementsLatlongs(Itda, Mandal);
        }

        public static DataTable Rejected_claims_login(string username,string password)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Rejected_claims_login(username,password);
        }

        public static DataTable RejectedClaims()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaims();
        }
        public static DataTable RejectedClaimsItdawise(string Itdaname)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaimsItdawise(Itdaname);
        }
        public static DataTable RejectedClaimMandals(string Itdaname)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaimMandals(Itdaname);
        }
        public static DataTable RejectedClaimsClaimidwise(string Itdaname,string Mandal,string claimid)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaimsClaimidwise(Itdaname, Mandal, claimid);
        }
        public static DataTable RejectedClaimsMandalwise(string Itdaname, string Mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaimsMandalwise(Itdaname, Mandal);
        }

        public static DataTable Updateclaims(rejected_claims rcobj)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Updateclaims(rcobj);
        }
        public static DataTable Insertclaims(rejected_claims rcobj)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Insertclaims(rcobj);
        }
        public static DataTable GetClaimid(string itda,string district,string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetClaimid(itda,district,mandal);
        }

        public static DataTable RejectedClaimsVillages(string Itdaname,string district, string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.RejectedClaimsVillages(Itdaname,district,mandal);
        }
        public static DataTable LandSummaryTotals()
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.LandSummaryTotals();
        }
        public static DataTable LandSummaryTotals(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.LandSummaryTotals(Itda);
        }
        public static DataTable GetItdaMaster(string USERNAME,string Type)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
           
            return userObj.GetItdaMaster(USERNAME,Type);
        }
        public static DataTable GetDistrictMaster(string USERNAME, string itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
           
            return userObj.GetDistrictMaster(USERNAME, itda);
        }

        public static DataTable GetCropLoanData(string district, string start, string end, string Itda, string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetCropLoanData(district, start, end, Itda, mandal);
        }
        public static DataTable GetItdaBeneficiaryData(string Itda,string start, string end)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetItdaBeneficiaryData(Itda, start, end);
        }
        public static DataTable GetItdaBenData(string Itda, string start, string end)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetItdaBenData(Itda, start, end);
        }
        public static DataTable GetRtgs_FormatData(string Itda, string district, string mandal,string village,string status,string type)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetRtgs_FormatData(Itda, district, mandal,village,status,type);
        }
        public static DataTable ViewBeneficiaryPlots(string bid,string userprevileges,string username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ViewBeneficiaryPlots(bid,userprevileges,username);
        }
        public static DataTable BeneficiaryPassbook(string bid, string userprevileges, string username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.BeneficiaryPassbook(bid, userprevileges, username);
        }
        public static DataSet BeneficiaryePassbook(string bid, string userprevileges, string username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.BeneficiaryePassbook(bid, userprevileges, username);
        }
        public static DataSet EPassbook(string bid, string userprevileges, string username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.EPassbook(bid, userprevileges, username);
        }
        public static DataSet ViewPassbook(string bid, string userprevileges, string username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.ViewPassbook(bid, userprevileges, username);
        }
        public static DataTable GetCropLoanDataCount(string district,  string Itda, string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetCropLoanDataCount(district,  Itda, mandal);
        }
        public static DataTable GetItdabeneficiarycount(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetItdabeneficiarycount(Itda);
        }
        public static DataTable GetItdabencount(string Itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetItdabencount(Itda);
        }
        public static DataTable GetLtrDataCount(string Itda, string district, string mandal,string village,string hab)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetLtrDataCount(Itda, district,mandal,village,hab);
        }

        public static DataTable GetHealthMasters(string district,string facility,string hospital,string screen)

        {
            HealthConnection con = new HealthConnection();
            return con.Data(district,facility,hospital,screen);


        }
        public static DataTable GetPssData(string adhar, string screen)

        {
            HealthConnection con = new HealthConnection();
            return con.PssData(adhar,screen);


        }
        public static DataTable GetRofrMasters(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetRofrMasters(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }
        public static DataTable GetCaste(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Getcastemaster(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }

        public static DataTable GetSUBCaste(string USERNAME, string Caste, string Type, string itda, string mandal, string district,  string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetSubcastemaster(USERNAME, Type, itda,  mandal, district, Caste, village, habitation, userprevilages);
        }
        public static DataTable GetRofrMasters1(string USERNAME, string Type, string itda, string district, string mandal,string panchayat, string revvillage, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetRofrMasters1(USERNAME, Type, itda, district, mandal, panchayat, revvillage, village, habitation, userprevilages);
        }

        public static DataTable defaultCastefill(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.defaultcastefillmaster(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }


        public static DataTable GetadangalRofrMasters1(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetadangalMasters1(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }


        public static DataTable Getbeneficiarytransaction(string USERNAME, string Type, string district, string mandal, string village, string adhar)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Getbeneficiarytransaction(USERNAME, Type, district, mandal, village, adhar);
        }
        public static DataTable GetMastersUpdate(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetMastersUpdate(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }

        public static DataTable Beneficiary_Deletion_Form_Getdata(string USERNAME, string Type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Beneficiary_Deletion_Form_Getdata(USERNAME, Type, itda, district, userprevilages, itdaname, adharno);
        }
        public static DataTable Beneficiary_Deletion(string USERNAME, string Type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Beneficiary_Deletion(USERNAME, Type, itda, district, userprevilages, itdaname, adharno);
        }

        public static DataTable Beneficiary_Deletion_rofrtest( string username, string Type)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Beneficiary_Deletion_rofrtest(username, Type);
        }

        public static DataTable Beneficiary_Deletion_rofrtestsubmit(string username, string Reason, string Benid, string type,string id)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Beneficiary_Deletion_rofrtestsubmit(username, Reason, Benid,type,id);
        }


        public static DataTable Beneficiary_Deletion_rofrDisplay(string username, string Type,string mandal)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Beneficiary_Deletion_rofrdisplay(username, Type,mandal);
        }
        public static DataTable deletenoBeneficiary_Deletion(string USERNAME, string Type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.deletenolBeneficiary_Deletion(USERNAME, Type, itda, district, userprevilages, itdaname, adharno);
        }

        public static DataTable DELETELONADBeneficiary_Deletion(string USERNAME, string Type, string itda, string district, string userprevilages, string itdaname, string adharno)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.DELETENOLANDBeneficiary_Deletion(USERNAME, Type, itda, district, userprevilages, itdaname, adharno);
        }
        public static DataTable Beneficiary_Deletion_Form_Deletedata(addbeneficiary_details BeneficiaryDetailsobj, string Username, string reason)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.Beneficiary_Deletion_Form_Deletedata(BeneficiaryDetailsobj, Username, reason);
        }

        public static DataTable UpdateFarmer(addbeneficiary_details BeneficiaryDetailsobj, string Username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
          return  userObj.UpdateFarmer(BeneficiaryDetailsobj, Username);
        }
        public static DataTable UpdateFarmerLandDetails(addbeneficiary_details BeneficiaryDetailsobj, string Username)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
           return userObj.UpdateFarmerLandDetails(BeneficiaryDetailsobj, Username);
        }
        public static DataTable GetAdharPhotoUpdate(string USERNAME, string Type, string itda,string start,string end)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetAdharPhotoUpdate(USERNAME, Type, itda,start,end);
        }
        public static DataTable GetAdharUpdateImage(adhar_detials aobj)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetAdharUpdateImage(aobj);
        }
        public static DataTable Get1bdetails(string USERNAME,string type,string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Get1bdetails(USERNAME,type, itda, district, mandal, village,pattadar,pattno,cno,adharno, userprevilages);
        }
        public static DataTable Epassbook(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Epassbook(USERNAME, type, itda, district, mandal, village, pattadar, pattno, cno, adharno, userprevilages);
        }
        public static DataTable GetAdharwise_rofrdata(string USERNAME, string type, string bid,string adharno, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetAdharwise_rofrdata(USERNAME, type, bid, adharno, userprevilages);
        }
        public static DataTable UploadImage(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.UploadImage(USERNAME, type, itda, district, mandal, village, pattadar, pattno, cno, adharno, userprevilages);
        }
        public static DataTable GetMasters(string USERNAME, string Type,string itda, string district, string mandal, string village,string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
 
            return userObj.GetMasters(USERNAME, Type,itda, district, mandal, village,habitation,userprevilages);
        }

        public static DataSet GetAdhar_Analysis(string itda, string district)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetAdhar_Analysis(itda,district);
        }
        public static DataTable GetItdawiseBeneficiary(string itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetItdawiseBeneficiary(itda);
        }
        public static DataTable GetItdawiseBen(string itda)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetItdawiseBen(itda);
        }
        public static DataTable GetDistrictMissingData(string itda,string district)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetDistrictMissingData(itda,district);
        }
        public static DataSet GetLtrData(string ltrid)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetLtrData(ltrid);
        }

        public static DataTable GetLtrData(string Itda, string district, string mandal, string village,string habitation)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.GetLtrData(Itda, district, mandal, village,habitation);
        }

        public static DataTable UpadteLtrstatus(string Itda, string district, string mandal, string village,string hab)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.UpadteLtrstatus(Itda, district, mandal, village,hab);
        }
        public static DataTable UpdateCase(string ltrid, string refno, string casestatus, string caselevel)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            return userObj.UpdateCase(ltrid, refno, casestatus, caselevel);
        }
        public static DataTable Villageprofiledropdowns1(string itda, string district, string mandal, string gp, string hab, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Villageprofiledropdowns(itda, district, mandal, gp, hab, screen);
        }

        public static DataTable Report(string hab, string dept, string assest, string subassest, string screen)
        {
            HealthConnection con = new HealthConnection();
            return con.Report(hab, dept, assest, subassest, screen);
        }
        public dynamic Get_latlonglist(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Getlatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic submit_key(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Submit_key_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.key = dt.Rows[0]["API_KEY"].ToString();
                    obj_data.Reason = "key Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.key="";
                    obj_data.Reason = "No key Found";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.key = "";
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //12-11-2024
        public dynamic submit1_key(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Submit1_key_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.key = dt.Rows[0]["API_KEY"].ToString();
                    obj_data.Reason = "key Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.key = "";
                    obj_data.Reason = "No key Found";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.key = "";
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }


        public dynamic check_key(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                Landsettlementpattasd userObj = new Landsettlementpattasd();
                dynamic dt = userObj.check_key_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "SUCCESS")
                    {
                        obj_data.Status = "Success";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                    }

                }
                else
                {
                    obj_data.Status = "Failure";

                }

            }
            catch (Exception ex)
            {
                obj_data.Status = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //12-11-2024

        public dynamic check_key1(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                Landsettlementpattasd userObj = new Landsettlementpattasd();
                dynamic dt = userObj.check_key_data1(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "SUCCESS")
                    {
                        obj_data.Status = "Success";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                    }

                }
                else
                {
                    obj_data.Status = "Failure";

                }

            }
            catch (Exception ex)
            {
                obj_data.Status = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //20-11-2025 FarmId Check key

        public dynamic FarmID_check_key(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                Landsettlementpattasd userObj = new Landsettlementpattasd();
                dynamic dt = userObj.FarmID_check_key_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Column1"].ToString() == "SUCCESS")
                    {
                        obj_data.Status = "Success";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                    }

                }
                else
                {
                    obj_data.Status = "Failure";

                }

            }
            catch (Exception ex)
            {
                obj_data.Status = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        public DataTable check_newkey(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.check_keynew_data(obj);
                return dt;
                

            }
            catch (Exception ex)
            {
                obj_data.Status = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        public dynamic Get_Plots_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                dynamic dc = check_key(obj);

                if (dc.Status == "Success")
                {

                    DataTable dt = userObj.Get_Plt_data(obj);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        obj_data.Status = "Success";
                        obj_data.plotslist = dt;
                        obj_data.Reason = "Data Loaded Successfully";


                    }
                    else
                    {
                        obj_data.Status = "Failure";
                        obj_data.plotslist = new DataTable();
                        obj_data.Reason = " No Data Availbale";
                    }
                }

                else
                {
                    obj_data.Status = "Failure";
                    obj_data.plotslist = new DataTable();
                    obj_data.Reason = " No Data Availbale";

                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        public dynamic Get_Crop_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                DataTable dc = check_newkey(obj);

                if (dc.Rows[0]["Column1"].ToString() == "101")
                {

                    DataTable dt = userObj.Get_SPCrop_data(obj);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        obj_data.Status = "Success";
                        obj_data.Data = dt;
                        obj_data.Reason = "Data Loaded Successfully";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                        obj_data.Data = new DataTable();
                        obj_data.Reason = " No Data Availbale";
                    }
                }

                //else if (dc.Rows[0]["Column1"].ToString() == "102")
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Key expired";

                //}
                //else {
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Invalid key";

                //}
            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        public dynamic Get_land_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {
                dynamic dc = check_key(obj);
                if (dc.Status == "Success")
                {
                    DataTable dt = userObj.Get_lnd_data(obj);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        obj_data.Status = "Success";
                        obj_data.Landlist = dt;
                        obj_data.Reason = "Data Loaded Successfully";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                        obj_data.Landlist = new DataTable();
                        obj_data.Reason = " No Data Availbale";
                    }
                }

                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Landlist = new DataTable();
                    obj_data.Reason = "Invalid Key";

                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }



        public dynamic Get_Masterslatlonglist(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.GetMasterslatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic ITDAMANDALVILLAGEdropdowns(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.ITDAMANDALVILLAGEdropdowns(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Get_Itdalatlonglist(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.GetHealthMasters(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);
                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic AsetsDashboardValues(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.AsetsDashboardValues(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);

                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Villageprofiledropdowns(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Villageprofiledropdowns(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);

                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }
        public dynamic Piechartdata(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Piechartdata(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);

                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic GisReport(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.GisReport(obj.HABITATION, obj.Dept, obj.Asset, obj.SubAsset, obj.Type);

                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Villagewiseallassetslatongs(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Villagewiseallassetslatongs(obj.HABITATION, obj.Dept, obj.Asset, obj.SubAsset, obj.Type);
                FormHelper.Masters.HabAssetsData = dt;


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Report(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Report(obj.HABITATION, obj.DEPARTMENT, obj.Asset, obj.SubAsset, obj.Type);

                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Allassetslatongs(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                // DataTable dt = userObj.Villagewiseallassetslatongs(obj.HABITATION, obj.Dept, obj.Asset, obj.SubAsset, obj.Type);
                DataTable dt = FormHelper.Masters.HabAssetsData;


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Allassetslatongs1(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                var F = obj.Data;
                DataTable dt = convertStringToDataTable(obj.Data);
                DataTable allassetdata = FormHelper.Masters.HabAssetsData;
                DataTable dtfillter = allassetdata.AsEnumerable()
                                 .Where(x => dt.AsEnumerable()
                           .Any(z => z.Field<string>("DeptId") == x.Field<string>("DEPT")))
                           .CopyToDataTable();
                if (dtfillter != null && dtfillter.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dtfillter;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("DeptId");
            bool columnsAdded = true;

            foreach (string row in data.Split(','))
            {
                string[] keyValue = row.Split(',');
                DataRow dataRow = dataTable.NewRow();
                dataRow["DeptId"] = keyValue[0];


                if (!columnsAdded)
                {
                    DataColumn dataColumn = new DataColumn(keyValue[0]);
                    dataTable.Columns.Add(dataColumn);
                }


                // columnsAdded = true;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }


        public dynamic AssetFacility(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.AssetFacility(obj.HABITATION, obj.Dept, obj.Asset, obj.SubAsset, obj.Type);
                // FormHelper.Masters.HabAssetsData = dt;


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Villagefencing(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Villagefencing(obj.HABITATION, obj.Dept, obj.Asset, obj.SubAsset, obj.Type);
               // FormHelper.Masters.HabAssetsData = dt;


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic Subassetextradetails(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Subassetextradetails(obj.ITDA, obj.DISTRICT, obj.VILLAGE, obj.MANDAL, obj.Type);
                //FormHelper.Masters.HabAssetsData = dt;


                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public static DataTable GetRofrMasters11(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();
           
            return userObj.GetRofrMasters11(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }

        public static DataTable SaveComplaint(string name, string mobile, string aadhar, string address, string complaint, string mail, string itda, string dist, string mandal, string village, string patta)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.SaveComplaint(name, mobile, aadhar, address, complaint, mail, itda, dist, mandal, village, patta);
        }


        public dynamic DeptAssetcount(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.DeptAssetcount( obj.HABITATION);
                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Road(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Road(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);
                FormHelper.Masters.RoadsData = dt;
                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic Roadservice(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.Roadservice(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public dynamic imageRoad(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt= FormHelper.Masters.RoadsData;
                DataTable RoadsData = FormHelper.Masters.RoadsData;
                DataTable dtRoadsData = RoadsData.AsEnumerable()
                                 .Where(x => dt.AsEnumerable()
                           .Any(z => z.Field<string>("REF_ID") == obj.Type))
                           .CopyToDataTable();
                if (dtRoadsData != null && dtRoadsData.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dtRoadsData;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic EXCELVALUESFENCING(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {
                string orfile = obj.ITDA;
               // string orfile = "Finaldistrict.xlsx";
                DataTable dtExcel = new DataTable();
                string excelpath = HttpContext.Current.Server.MapPath("~/img/"+ orfile);
                string filename = Path.GetFileName(excelpath); // getting the file path of uploaded file
                string ext = Path.GetExtension(filename);
                if (filename != "")
                {
                    string type = String.Empty;

                    dtExcel= import(excelpath, ext);
                }
               
               
                DataTable dt = dtExcel;
                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public static DataTable import(string FilePath, string Extension)
        {
            DataTable dt1 = new DataTable();
            try
            {
                string conStr = "";

                switch (Extension)

                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, "Yes");

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable dt = new DataTable();

                cmdExcel.Connection = connExcel;



                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(dt);

                connExcel.Close();

              
                dt1 = dt;
               

            }
            catch (Exception ex)
            {
               
            }
            return dt1;
        }


        public dynamic ChartAsetsDashboardValues(latlongsModel obj)
        {

            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.ChartAsetsDashboardValues(obj.ITDA, obj.DISTRICT, obj.MANDAL, obj.VILLAGE, obj.HABITATION, obj.Type);
                FormHelper.Masters.AlldeptchartData = dt;
                // DataTable dt = userObj.GetItdalatlongsdata(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.itdalist = dt;
                    obj_data.Reason = "Data Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }


        public dynamic chartAllassetslatongs1(latlongsModel obj)
        {
            ChartsEducation _cedu = new ChartsEducation();
            CultureInfo cultures = new CultureInfo("en-US");
            dynamic obj_data = new ExpandoObject();
            try
            {
                var F = obj.ITDA;
                // DataTable dt = convertStringToDataTable(obj.Data);
                DataTable allassetdata1 = FormHelper.Masters.AlldeptchartData;
                DataTable dtfillter1 = allassetdata1.AsEnumerable()
                            .Where(r => r.Field<int>("DEPT_CODE") == Convert.ToInt32(obj.ITDA))
                            .CopyToDataTable();
                if (dtfillter1 != null && dtfillter1.Rows.Count > 0)
                {
                    List<EducationCharts> listeduchart = new List<EducationCharts>();
                    int i = 1;
                    foreach (DataColumn dr in dtfillter1.Columns)
                    {
                        if (i <= 2)
                        {
                            var a = dtfillter1.Columns[i].ToString();
                            EducationCharts _educhart = new EducationCharts();

                            _educhart.y = dtfillter1.Rows[0][dtfillter1.Columns[i].ToString()].ToString();
                            _educhart.d = Convert.ToDecimal(_educhart.y, cultures);
                            decimal d = Math.Round(_educhart.d);
                            _educhart.y = d.ToString();
                            if (dtfillter1.Columns[i].ToString() == "UPLOADED_PERCENTAGE")
                            {
                                _educhart.label = "UPLOADED";
                            }
                            else if (dtfillter1.Columns[i].ToString() == "PENDING_PERCENTAGE")
                            {
                                _educhart.label = "PENDING";
                            }


                            i++;
                            listeduchart.Add(_educhart);
                        }
                    }
                    obj_data.Status = "Success";
                    obj_data.itdalist = listeduchart;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Reason = " No Data Availbale";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Reason = ex.Message.ToString();
            }
            finally
            {

            }
            return obj_data;
        }

        public static DataTable GetRofrMasters2(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetRofrMasters2(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }

        public static DataTable GetRofrMasters3(string USERNAME, string Type, string itda, string district, string mandal, string village, string habitation, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.GetRofrMasters3(USERNAME, Type, itda, district, mandal, village, habitation, userprevilages);
        }

        public static DataTable Get1bdetails1(string USERNAME, string type, string itda, string district, string mandal, string village, string pattadar, string pattno, string cno, string adharno, string userprevilages)
        {
            Landsettlementpattasd userObj = new Landsettlementpattasd();

            return userObj.Get1bdetails1(USERNAME, type, itda, district, mandal, village, pattadar, pattno, cno, adharno, userprevilages);
        }

        
        //12-11-2024
        public dynamic Get_house_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                dynamic dc = check_key1(obj);

                //if (dc.Rows[0]["Column1"].ToString() == "101")
                //{

                    DataTable dt = userObj.Get_SPhouse_data(obj);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        obj_data.Status = "Success";
                        obj_data.Data = dt;
                        obj_data.Reason = "Data Loaded Successfully";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                        obj_data.Data = new DataTable();
                        obj_data.Reason = " No Data Availbale";
                    }
              //  }

                //else if (dc.Rows[0]["Column1"].ToString() == "102")
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Key expired";

                //}
                //else
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Invalid key";

                //}
            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //20-02-2025 key
        public dynamic FramIdsubmit_key(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            try
            {

                Landsettlementpattasd userObj = new Landsettlementpattasd();
                DataTable dt = userObj.FramIdSubmit_key_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {

                    obj_data.Status = "Success";
                    obj_data.key = dt.Rows[0]["API_KEY"].ToString();
                    obj_data.Reason = "key Loaded Successfully";


                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.key = "";
                    obj_data.Reason = "No key Found";
                }

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.key = "";
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //20-02-2025 

        public dynamic Get_FarmID_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                dynamic dc = FarmID_check_key(obj);

                //if (dc.Rows[0]["Column1"].ToString() == "101")
                //{

                DataTable dt = userObj.Get_SPFarmID_data(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.Data = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    obj_data.Data = new DataTable();
                    obj_data.Reason = " No Data Availbale";
                }
                //  }

                //else if (dc.Rows[0]["Column1"].ToString() == "102")
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Key expired";

                //}
                //else
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Data = new DataTable();
                //    obj_data.Reason = "Invalid key";

                //}
            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.Data = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }


        //21-02-2025

        public dynamic Get_Aadhar_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {
                //dynamic dc = check_key(obj);
                //if (dc.Status == "Success")
                //{
                    DataTable dt = userObj.Get_Aadhar_data_sp(obj);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        obj_data.Status = "Success";
                        obj_data.Landlist = dt;
                        obj_data.Reason = "Data Loaded Successfully";
                    }
                    else
                    {
                        obj_data.Status = "Failure";
                        //obj_data.Landlist = new DataTable();
                        obj_data.Reason = " No Data Availbale";
                    }
                //}

                //else
                //{
                //    obj_data.Status = "Failure";
                //    obj_data.Landlist = new DataTable();
                //    obj_data.Reason = "Invalid Key";

                //}

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }



        //02-05-2025

        public dynamic Get_Adangal_Details(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {
                
                DataTable dt = userObj.Get_Adangal_Details_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.Landlist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    //obj_data.Landlist = new DataTable();
                    obj_data.Reason = " No Data Availbale";
                }
                

            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                //ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }


        public dynamic Get_PlotIDData(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                DataTable dt = userObj.Get_PlotID_data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.Landlist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    //obj_data.Landlist = new DataTable();
                    obj_data.Reason = " No Data Availbale";
                }


            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                //ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }


        public dynamic Get_Ror_data(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                DataTable dt = userObj.Get_Ror_data_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.Landlist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    //obj_data.Landlist = new DataTable();
                    obj_data.Reason = " No Data Availbale";
                }


            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                //ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //--------------new method 20072026--------------------


        public dynamic Get_RofrCropInsurance(latlongsModel obj)
        {
            dynamic obj_data = new ExpandoObject();
            Landsettlementpattasd userObj = new Landsettlementpattasd();
            try
            {

                DataTable dt = userObj.Get_RofrCropInsurance_sp(obj);

                if (dt != null && dt.Rows.Count > 0)
                {
                    obj_data.Status = "Success";
                    obj_data.Landlist = dt;
                    obj_data.Reason = "Data Loaded Successfully";
                }
                else
                {
                    obj_data.Status = "Failure";
                    //obj_data.Landlist = new DataTable();
                    obj_data.Reason = " No Data Availbale";
                }


            }
            catch (Exception ex)
            {
                obj_data.Status = "Failure";
                obj_data.plotslist = new DataTable();
                obj_data.Reason = ex.Message.ToString();
                //ProjectRofrBAL.GetMasterDetails.ErrorEntry(ex, this.GetType().Name + "/" + System.Reflection.MethodBase.GetCurrentMethod().Name, obj.key + obj.url + obj.Ipaddress, HttpContext.Current.Request.UserHostAddress);

            }

            return obj_data;
        }

        //----------------------------------
    }
}