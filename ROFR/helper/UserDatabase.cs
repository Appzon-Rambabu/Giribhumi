using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

using System.Security;
using System.Text;
using System.Dynamic;
using System.Security.Cryptography;
using ROFR.helper;
namespace ROFR.helper
{
    public class UserDatabase
    {
        Profile.Security ps = new Profile.Security();
        public static bool AddUser(string username, string password)
        {
            SqlConnection Sqlcon = new SqlConnection("Data Source=DESKTOP-BLERDFH; Initial Catalog=ROFR; Integrated Security=TRUE");

            // string hashedPassword = Security.HashSHA1(password);


            using (SqlCommand cmd = new SqlCommand("INSERT INTO rofr_usermaste VALUES ( @password,@username)", Sqlcon))
            {

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", Profile.Security.HashSHA1(password));
                // cmd.Parameters.AddWithValue("@Designation", str);
                Sqlcon.Open();
                cmd.ExecuteNonQuery();
                Sqlcon.Close();
            }
            return true;
        }

        public dynamic checkGetUserId(string username)
        {
            DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Authentication(username);
            return dtUser;
        }

        public dynamic GetUserId(string username, string password)
        {
            // this is the value we will return
            dynamic login_return = new ExpandoObject();
            //int userId = 0;
            DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Authentication(username);

            string hashedPassword2 = Profile.Security.HashSHA1(password);
            if (dtUser.Rows.Count > 0)
            {
                login_return.user=username;
                login_return.tribal  = ps.createToken(username);
                int dbUserId = Convert.ToInt32(dtUser.Rows[0]["user_id"].ToString());
                string dbPassword = Convert.ToString(dtUser.Rows[0]["password"].ToString());
                string hashedPassword = Profile.Security.HashSHA1(password);
               // string hashedPassword1 = Profile.Security.HashSHA1(password);
                if (dbPassword == hashedPassword)
                {
                    // The password is correct
                   // userId = dbUserId;
                   // dbPassword = password;
                    login_return.userId= dbUserId;
                    login_return.pwd = dbPassword;
                    login_return.user_previlege= dtUser.Rows[0]["User_privileges"].ToString();
                    login_return.Isrofr = dtUser.Rows[0]["IsRofr"].ToString();
                    login_return.username = dtUser.Rows[0]["user_name"].ToString();
                    login_return.status= dtUser.Rows[0]["Login_status"].ToString();
                    login_return.dpcaptcha = dtUser.Rows[0]["captcha_update"].ToString();
                    login_return.newpwd = dtUser.Rows[0]["new_password"].ToString();
                    login_return.Lastlogin = dtUser.Rows[0]["Last_Login"].ToString();
                    //login_return.dupuname = dtUser.Rows[0]["dup_user_name"].ToString();

                }
                else
                {
                    login_return.userId = 0;
                    login_return.dpcaptcha = "";
                    login_return.status = "";
                }
            }
            else
            {
                login_return.userId = 0;
                login_return.dpcaptcha = "";
                login_return.status = "";
            
        }

            return login_return;
        }

        public dynamic GetPassword(string username, string password)
        {
            // this is the value we will return
            dynamic login_return = new ExpandoObject();
            //int userId = 0;
            string encrypt_password = string.Empty;
            encrypt_password = Profile.Security.HashSHA1(password);
            DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Password(username, encrypt_password);

          
               
            if (dtUser.Rows.Count > 0)
            {
               
                login_return.user = username;
                
                int dbUserId = Convert.ToInt32(dtUser.Rows[0]["user_id"].ToString());
                string dbPassword = Convert.ToString(dtUser.Rows[0]["password"].ToString());
               
                    // The password is correct
                    // userId = dbUserId;
                    // dbPassword = password;
                    login_return.userId = dbUserId;
                    login_return.pwd = dbPassword;
                    login_return.user_previlege = dtUser.Rows[0]["User_privileges"].ToString();
                    login_return.Isrofr = dtUser.Rows[0]["IsRofr"].ToString();
                    login_return.username = dtUser.Rows[0]["user_name"].ToString();
                    
              
            }
            else
            {
                login_return.userId = 0;
               

            }

            return login_return;
        }

        public dynamic Update_Password(string username, string password,string newpwd,string oldpwd)
        {
            // this is the value we will return
            dynamic login_return = new ExpandoObject();
            //int userId = 0;
            string encrypt_newpwd = string.Empty;
            encrypt_newpwd = Profile.Security.HashSHA1(newpwd);
            DataTable dtUser = ProjectRofrBAL.GetMasterDetails.Update_Password(username, password,newpwd,encrypt_newpwd,oldpwd);

            if (dtUser.Rows.Count > 0)
            {
              
              login_return.status = Convert.ToString(dtUser.Rows[0]["status"].ToString());

                login_return.Message = "Updated Successfully";
            }
            else
            {
                login_return.status = 0;
                login_return.Message = "Failed";

            }

            return login_return;
        }
        public dynamic Loginstatus(string username, string type)
        {
            dynamic login_return = new ExpandoObject();
            DataTable dtUser = ProjectRofrBAL.GetMasterDetails.User_Loginstatus(username, type);

            if (dtUser.Rows.Count > 0)
            {
                if (type == "17")
                {
                    int status = Convert.ToInt32(dtUser.Rows[0]["status"].ToString());
                    string status_text = dtUser.Rows[0]["Active_status"].ToString();
                    login_return.status = status;
                    login_return.status_text = status;
                    login_return.user = username;
                }
                else
                {
                    int status = Convert.ToInt32(dtUser.Rows[0]["status"].ToString());
                    login_return.status = status;
                    login_return.user = username;

                }
            }
            else
            {
                login_return.status = 0;


            }

            return login_return;
        }
    }
}