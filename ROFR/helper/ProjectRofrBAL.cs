using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;
using System.Dynamic;
using Newtonsoft.Json;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ROFR.helper
{
    public class ProjectRofrBAL
    {
        public class GetMasterDetails
        {

            public static void ErrorEntry(Exception ex, string ErrorArea, string Username, string Ip)
            {
                ProjectRofrDAL.GetMasterDetails obj = new ProjectRofrDAL.GetMasterDetails();
                obj.ErrorLogEntry(ex, ErrorArea, Username, Ip);
            }
            public static DataTable GetDistrictMasterDetails()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetDistrictMasterDetails();
            }

            public static DataTable GetAllDivisionsMasterDetails()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetAllDivisionsMasterDetails();
            }
            public static DataTable GetMandalMasterDetails(string district, string mandal)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetMandalMasterDetails(district, mandal);
            }

            public static DataTable GetMaapingBeatMasterDetails(string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetMaapingBeatMasterDetails(district, mandal, village);
            }
            public static DataTable GetVillageMasterDetails(string district, string mandal, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetVillageMasterDetails(district, mandal, type);
            }

            public static DataTable GetFillterDivisionsDetails(string district, string mandal, string village, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetFillterDivisionsDetails(district, mandal, village, type);
            }

            public static DataTable GetFillterRangeDetails(string district, string mandal, string village, string division, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetFillterRangeDetails(district, mandal, village, division, type);
            }

            public static DataTable GetFillterBeatDetails(string district, string mandal, string village, string division, string Range, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetFillterBeatDetails(district, mandal, village, division, Range, type);
            }

            public static DataTable GetBeatMasterDetails(string division, string range)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetBeatMasterDetails(division, range);
            }
            public static DataTable GetForestMasterDetails(string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestMasterDetails(district);
            }

            public static DataSet GetupperdivisionsMasterDetails(string district, string id, string type, string mandal, string village, string division, string Range)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetupperdivisionsMasterDetails(district, id, type, mandal, village, division, Range);
            }

            public static DataTable GetRevenuemandalMasterDetails(string district, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetRevenuemandalMasterDetails(district, type);
            }

            public static DataTable GetRangeMasterDetails(string division)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetRangeMasterDetails(division);
            }

            public static DataTable GetForestRangeMasterDetails(string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestRangeMasterDetails(district);
            }

            public static DataTable GetForestBeatMasterDetails(string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeatMasterDetails(district);
            }
            public static DataTable User_Authentication(string UserName)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authentication(UserName);
            }
            public static DataTable User_Password(string UserName,string password)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Password(UserName,password);
            }
            public static DataTable Update_Password(string UserName, string oldpwd,string newpwd, string encrpyt_pwd,string old_pwds)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Update_Password(UserName, oldpwd, newpwd,encrpyt_pwd,old_pwds);
            }
            public static DataTable User_Authentication_update(string UserName, string status,string date)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authentication_update(UserName,status,date);
            }
            public static DataTable User_Authentication_logout_update(string UserName, string status, string logoutdate, string lastlogindate)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authentication_logout_update(UserName, status, logoutdate, lastlogindate);
            }
            public static DataTable User_Authentication_captchaupdate(string UserName, string status)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authentication_captchaupdate(UserName, status);
            }

            public static DataTable User_Authentication_pwdupdate(string UserName)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authentication_pwdupdate(UserName);
            }
            public static DataTable User_Authenticationlog(string UserName, string Ipaddress, string Status)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Authenticationlog(UserName, Ipaddress, Status);
            }

            public static DataSet GetDataMasterDetails(string ITDANAME, string Director)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetDataMasterDetails(ITDANAME, Director);
            }

            public static DataTable GetRecordsCount(string district, string mandal, string village, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetRecordsCount(district, mandal, village, username);
            }

            public static DataTable GetForestRecordsCount(string district, string FD, string FR, string FB, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestRecordsCount(district, FD, FR, FB, username);
            }

            public static DataTable GetBeneficiariesData(string district, string mandal, string village, string start, string end, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetBeneficiariesData(district, mandal, village, start, end, username);
            }

            public static DataTable GetForestBeneficiariesData(string district, string FD, string FR, string FB, string start, string end, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiariesData(district, FD, FR, FB, start, end, username);
            }

            public static DataTable GetForestBeneficiariesDetails(string FD, string FR, string FB, string start, string end, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiariesDetails(FD, FR, FB, start, end, username);
            }

            public static DataTable GetMeeBeneficiariesDetails(string FD, string FR, string FB, string COMPARTMENT_NO, string PLOT_NO, string AADHAAR_NO, string ROFR_PATTA_NO, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetMeeBeneficiariesDetails(FD, FR, FB, COMPARTMENT_NO, PLOT_NO, AADHAAR_NO, ROFR_PATTA_NO, username);
            }

            public static DataTable GetForestBeneficiariesRecordsCount(string FD, string FR, string FB, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiariesRecordsCount(FD, FR, FB, username);
            }

            public static DataSet GetBeneficiaryDetailsAnalysis(string district, string username)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetBeneficiaryDetailsAnalysis(district, username);
            }
            public static DataTable GetDistWiseBeneficiaryMasterCount(string type, string itda, string dist, string mandal,string village,string username,string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetDistWiseBeneficiaryMasterCount(type,itda,dist,mandal,village,username,userprevileges);
            }
            public static DataTable GetRythuBharosaStatus(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetRythuBharosaStatus(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable GetRythuBharosaStatus_May20(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetRythuBharosaStatus_May20(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable GetRythuBharosaStatus_Oct20(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetRythuBharosaStatus_Oct20(type, itda, dist, mandal, village, username, userprevileges);
            }

            public static DataTable GetFarmerImagesReport(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetFarmerImagesReport(type, itda, dist, mandal, village, username, userprevileges);
            }

            public static DataTable Get_Land_Images_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Land_Images_Report(type, itda, dist, mandal, village, username, userprevileges);
            }
            public dynamic Get_Land_Images_Report1(dynamic root)
            {
                dynamic obj_data = new ExpandoObject();
                try
                {
                    var json = JsonConvert.SerializeObject(root);
                    dynamic objre = JsonConvert.DeserializeObject<ExpandoObject>(json);
                    ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                    DataTable dt = Obj.Get_Land_Images_Report(objre.type, objre.itda, objre.Dist, objre.Mandal, objre.Village, objre.user, objre.userpre);

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

            public static DataTable Get_Land_Status_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Land_Status_Report(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable Get_Land_Invalid_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Land_Invalid_Report(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable Get_Dlc_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Dlc_Report(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable Get_Latlongs_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Latlongs_Report(type, itda, dist, mandal, village, username, userprevileges);
            }
            public static DataTable GetMandatoryFieldsAnalysis(string type,string userprevileges,string username)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetMandatoryFieldsAnalysis(type,userprevileges, username);
            }
          
              public static DataTable GetAdharDetails(string itda, string userprevileges, string username)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetAdharDetails(itda, userprevileges, username);
            }
            public static DataTable GetAdharData(string start,string end)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetAdharData(start,end);
            }
            public static DataTable GetAdharUpdate(adhar_detials aobj)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetAdharUpdate(aobj);
            }
            public static DataTable GetAdharcount()
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetAdharcount();
            }
            public static DataTable GetNonMandatoryFieldsAnalysis(string type, string userprevileges, string username)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetNonMandatoryFieldsAnalysis(type, userprevileges, username);
            }
            public static DataTable GetMasterDetailsAnalysis()
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetMasterDetailsAnalysis();
            }

            public static DataTable GetForestBeneficiaryDetailscountValidate(string district, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiaryDetailscountValidate(district, Itda, mandal, village);
            }

            public static DataTable GetcropForestBeneficiaryDetailscountValidate(string district, string Itda, string mandal)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetcropForestBeneficiaryDetailscountValidate(district, Itda, mandal);
            }

            public static DataTable GetadharForestBeneficiaryDetailscountValidate(string district, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetadharForestBeneficiaryDetailscountValidate(district, Itda, mandal, village);
            }

            public static DataTable GetForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal, village);
            }

            public static DataTable GetcropForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetcropForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal);
            }

            public static DataTable GetadharForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetadharForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal, village);
            }

            public static DataTable GetForestBeneficiaryDetailscountapproval(string district, string Director, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiaryDetailscountapproval(district, Director, Itda, mandal, village);
            }

            public static DataTable GetForestBeneficiaryDetailsapproval(string district, string start, string end, string Director, string Itda, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetForestBeneficiaryDetailsapproval(district, start, end, Director, Itda, mandal, village);
            }


            public static void UpdateValidateBeneficiaryDetails(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateValidateBeneficiaryDetails(BeneficiaryDetailsobj, Username);
            }
            public static void UpdateRtgsFormatData(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateRtgsFormatData(BeneficiaryDetailsobj, Username);
            }

            public static void UpdateforestmasterDetails(BeneficiaryDetails BeneficiaryDetailsobj, string level)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateforestmasterDetails(BeneficiaryDetailsobj, level);
            }

            public static DataTable AddBeneficiaryDetails(addbeneficiary_details addbeneficiaryobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
              return userObj.AddBeneficiary(addbeneficiaryobj);
            }

            public static DataTable File_retrieve(string Id)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.File_retrieve(Id);
            }
            public static DataTable pdfFile_retrieve(string Id)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.pdfFile_retrieve(Id);
            }

            public static void AddBeneficiaryUploadFiles(addbeneficiary_details addbeneficiaryobj, string byteString, string imgString, string username, string ipaddress)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.AddBeneficiaryUploadFiles(addbeneficiaryobj, byteString, imgString, username, ipaddress);
            }

            public static DataTable GetDivisionMaster()
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.GetDivisionMaster();
            }

            public static void UpdateForestDivision(string Id, string district, string FDcode, string FDname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateForestDivision(Id, district, FDcode, FDname, Ipaddress, username);
            }
            public static void InsertForestDivision(string district, string FDcode, string FDname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.InsertForestDivision(district, FDcode, FDname, Ipaddress, username);
            }

            public static void DeleteForestDivision(string Id, string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.DeleteForestDivision(Id, district);
            }

            public static void InsertForestBeat(string district, string mandal, string village, string division, string Range, string Fbcode, string Fbname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.InsertForestBeat(district, mandal, village, division, Range, Fbcode, Fbname, Ipaddress, username);
            }

            public static void UpdateForestBeat(string Id, string district, string mandal, string village, string division, string Range, string Fbcode, string Fbname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateForestBeat(Id, district, mandal, village, division, Range, Fbcode, Fbname, Ipaddress, username);
            }

            public static void DeleteForestBeat(string Id, string district, string mandal, string village, string division, string Range)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.DeleteForestBeat(Id, district, mandal, village, division, Range);
            }

            public static void InsertForestRange(string district, string mandal, string division, string Frcode, string Frname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.InsertForestRange(district, mandal, division, Frcode, Frname, Ipaddress, username);
            }

            public static void UpdateForestRange(string Id, string district, string mandal, string division, string Frcode, string Frname, string Ipaddress, string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateForestRange(Id, district, mandal, division, Frcode, Frname, Ipaddress, username);
            }

            public static void DeleteForestRange(string Id, string district, string mandal, string division)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.DeleteForestRange(Id, district, mandal, division);
            }

            public static void HabitationDelete(string Id, string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.HabitationDelete(Id, district, mandal, village);
            }

            public static DataSet UniqueHabitation(string id, string district, string mandal, string village)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.UniqueHabitation(id, district, mandal, village);
            }

            public static DataSet Getdashboard()
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Getdashboard();
            }
            public static DataSet validaadhar(string itda, string district)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.validaadhar(itda,district);
            }
            public static void UpdateAadhaar_status(string id, string status)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateAadhaar_status(id, status);
            }
            public static DataSet GetnewDashboard()
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetnewDashboard();
            }
            public static DataSet Checkadhar(string username, string adhar)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Checkadhar(username, adhar);
            }
            public static DataTable AddBeneficiaryMaster(addbeneficiary_details addbeneficiaryobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.AddBeneficiaryMaster((addbeneficiaryobj));
            }
            public static DataTable Check_newadhaar(string username,string adhar,string newaadhar)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Check_newadhaar(username,adhar,newaadhar);
            }
            public static void Update14COLUMNSBeneficiaryDetails(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.Update14COLUMNSBeneficiaryDetails(BeneficiaryDetailsobj, Username);
            }

            public static void UpdateCropLoan(BeneficiaryDetails BeneficiaryDetailsobj, string Username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                userObj.UpdateCropLoan(BeneficiaryDetailsobj, Username);
            }
            public static DataTable GetMandalwiseDetailsAnalysis(string itda, string district)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetMandalwiseDetailsAnalysis(itda, district);
            }
            public static DataTable land_transfer_regulation(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.land_transfer_regulation(land_transfer_obj);
            }
            public static DataTable land_transfer_regulation1(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.land_transfer_regulation1(land_transfer_obj);
            }
            public static DataTable Getltrid(string itda,string districtcode)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Getltrid(itda,districtcode);
            }

            public static DataTable land_transfer_files(BeneficiaryDetails BeneficiaryDetailsobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.land_transfer_files(BeneficiaryDetailsobj);
            }
            public static DataTable CropLoanFiles(BeneficiaryDetails BeneficiaryDetailsobj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.CropLoanFiles(BeneficiaryDetailsobj);
            }
            public static DataTable LTR_Add(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.LTR_Add((land_transfer_obj));
            }
            public static DataTable LTR_Agent(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.LTR_Agent((land_transfer_obj));
            }
            public static DataTable LTR_Gov(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.LTR_Gov((land_transfer_obj));
            }
            public static DataTable LTR_Highcourt(land_transfer_regulation land_transfer_obj)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.LTR_Highcourt((land_transfer_obj));
            }
            public static DataTable GetNAdharData(string start, string end)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetNAdharData(start, end);
            }

            public static DataTable GetNAdharUpdate(adhar_detials aobj)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetNAdharUpdate(aobj);
            }

            public static DataTable GetNAdharcount()
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetNAdharcount();
            }
            public static DataTable ExceuteQuery(string sqlQuery)
            {
                ProjectRofrDAL.GetMasterDetails sqlObj = new ProjectRofrDAL.GetMasterDetails();
                return sqlObj.ExceuteQuery(sqlQuery);
            }

            public static DataTable Homedashboardcounr(string itda, string district)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Homedashboardcounr(itda, district);
            }
            public static DataTable Get_Loan_Report(Loan_details ldobj)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Loan_Report(ldobj);
            }
            public static DataTable Homedashboardcounr(string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Homedashboardcounr(username);
            }

            public static DataSet Homedashboardcounr1(string username)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.Homedashboardcounr1(username);
            }
            public static DataTable Phase1_Phase2_data(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Phase1_Phase2_data(type, itda, dist, mandal, village, username, userprevileges);
            }

            //New GetLatLongsPhases
            public static DataTable Get_Latlongs_Phases_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges, string Phasetype)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Latlongs_Phases_Report(type, itda, dist, mandal, village, username, userprevileges, Phasetype);
            }

            //New GetDLCPhaseWiseReport
            public static DataTable Get_Dlc_Phase_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges, string phasetype)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Dlc_Phase_Report(type, itda, dist, mandal, village, username, userprevileges, phasetype);
            }
            public static DataTable Get_Land_Images_Phases_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges, string phasetype)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Land_Images_Phases_Report(type, itda, dist, mandal, village, username, userprevileges, phasetype);
            }
            public dynamic Get_latlonglist(dynamic root)
            {
                dynamic obj_data = new ExpandoObject();
                try
                {
                    var json = JsonConvert.SerializeObject(root);
                    dynamic objre = JsonConvert.DeserializeObject<ExpandoObject>(json);
                    ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                    DataTable dt = userObj.Getlatlongsdata(objre);

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

            public static DataTable GetRythuBharosaStatus_May21(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.GetRythuBharosaStatus_May21(type, itda, dist, mandal, village, username, userprevileges);
            }

            public static DataTable Get_Beneficiary_Data_for_Rythubharosa_Report(string type, string itda, string dist, string mandal, string village, string username, string userprevileges)
            {
                ProjectRofrDAL.GetMasterDetails Obj = new ProjectRofrDAL.GetMasterDetails();
                return Obj.Get_Beneficiary_Data_for_Rythubharosa_Report(type, itda, dist, mandal, village, username, userprevileges);
            }

            public static Bitmap ResizeImage(Image image, int width, int height)
            {
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);

                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }

                return destImage;
            }

          

            public static Image image (string url)
            {
                System.Net.HttpWebRequest request = null;
                System.Net.HttpWebResponse response = null;
                byte[] b = null;
                Image img;
                request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                response = (System.Net.HttpWebResponse)request.GetResponse();
                img = Image.FromFile(url);
                if (request.HaveResponse)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        img = Image.FromFile(url);
                        Stream receiveStream = response.GetResponseStream();
                        using (BinaryReader br = new BinaryReader(receiveStream))
                        {
                            b = br.ReadBytes(500000000);
                            br.Close();
                        }
                    }
                }
               
                return img;
               
            }

            public static string imageurltoimage(string Path)
            {

                //  FileStream stream = new FileStream(ImagePath, FileMode.Open, FileAccess.Read);

                //byte[] ImgData = new byte[stream.Length];

                // stream.Read(ImgData, 0, Convert.ToInt32(stream.Length));

                // stream.Close();
                using (Image image = Image.FromFile(Path))
                {
                    using (MemoryStream m = new MemoryStream())
                    {
                        image.Save(m, image.RawFormat);
                        byte[] imageBytes = m.ToArray();

                        // Convert byte[] to Base64 String
                        string base64String = Convert.ToBase64String(imageBytes);
                        return base64String;
                    }
                }

               

            }


            public static DataTable User_Loginstatus(string UserName, string type)
            {
                ProjectRofrDAL.GetMasterDetails userObj = new ProjectRofrDAL.GetMasterDetails();
                return userObj.User_Loginstatus(UserName, type);
            }
        }
    }
}