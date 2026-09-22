using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
//using System.Windows.Forms;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using AjaxControlToolkit;
using ROFR.helper;
using System.Globalization;
namespace ROFR.test
{
    public partial class Manual_Dataentry_Test : System.Web.UI.Page
    {
        DBQuery objDBQuery = new DBQuery();
        DataTable dt;
        string tripno = string.Empty, dtripno = string.Empty, trtype = string.Empty, data = string.Empty, ss = string.Empty, yard = string.Empty;
        string str = string.Empty, message = string.Empty, Total = string.Empty, Cleaned = string.Empty, Uncleaned = string.Empty, rstatus = string.Empty;
        double netwet = 0.0;
        int bincnt = 0, loccount = 0;
        bool check = true;
        DateTime dto = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        protected void Page_Load(object sender, EventArgs e)
        {
            message_lbl.Text = "";
        }

        protected void getvhe_txt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int a; int b;


                string vehdts = "select * from Vehicle_Details where vehicle_no like '%" + getvhe_txt.Text.Trim() + "%'";
                dt = objDBQuery.retdt(vehdts, "");
                if (dt.Rows.Count > 0)
                {
                    mvehicleno_txt.Text = dt.Rows[0][1].ToString();
                    mvehicletype_txt.Text = dt.Rows[0][2].ToString();
                    mzone_txt.Text = dt.Rows[0][4].ToString();
                    mward_txt.Text = dt.Rows[0][5].ToString();
                    mdrivername_txt.Text = dt.Rows[0][7].ToString();
                    mowner_txt.Text = dt.Rows[0][8].ToString();
                    mvehiclewt_txt.Text = dt.Rows[0][3].ToString();
                   // mmaterial_txt.Text = dt.Rows[0][6].ToString();
                    tag_txt.Text = dt.Rows[0][0].ToString();
                    // mgrosswt_txt.Text = mgrosswt_txt.Text.Trim();
                    //mgrosswt_txt.Text = "9854";
                }
                else
                {
                    //MessageBox.Show("Please Check The Vehicle Number......!", "Check The Vehicle Number", MessageBoxButtons.OK);
                    message_lbl.Text = "Please Check The Vehicle Number......!";
                    return;
                }
                string tripno = "select max(tripno) from Garbagewt_details_Test";
                dt = objDBQuery.retdt(tripno, "");
                if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                {
                    tripno = "1";
                    tripnor_lbl.Text = tripno.Trim();
                }
                else
                {
                    a = Convert.ToInt32(dt.Rows[0][0].ToString());
                    a = a + 1;
                    tripnor_lbl.Text = a.ToString().Trim();
                }

                string date = dto.ToString("dd-MM-yyyy");

                string dtrip = "select max(dtripno)from Garbagewt_details_Test where Vehicleno='" + mvehicleno_txt.Text + "' and (transtime) LIKE '" + "%" + date + "%" + "'";

                dt = objDBQuery.retdt(dtrip, "");
                if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                {
                    dtripno = "1";
                    dtripval_lbl.Text = dtripno.Trim();
                }
                else
                {
                    b = Convert.ToInt32(dt.Rows[0][0].ToString());
                    b = b + 1;
                    dtripval_lbl.Text = b.ToString().Trim();
                }
                if (DateTime.Now.Hour >= 19)
                {
                    mshift_ddl.Text = "Night";
                }
                else
                {
                    mshift_ddl.Text = "Day";
                }

                if (mvehicletype_txt.Text == "Dumper Placer" || mvehicletype_txt.Text == "Double Dumper")
                {


                    //Bin checklist Box
                    // DataTable dt_bin = objDBQuery.retdt("select a.Bin_no from Bin_Master a  where a.Zone='" + mzone_txt.Text.Trim() + "' and a.ward='" + mward_txt.Text.Trim() + "'", "");


                    //Location Dropdown
                    //  DataTable location = objDBQuery.retdt("select a.Bin_Location from BinLocation_Master a  where a.Zone='" + mzone_txt.Text.Trim() + "' and a.ward='" + mward_txt.Text.Trim() + "'", "");

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void mgrosswt_txt_TextChanged(object sender, EventArgs e)
        {
            int i = 0; int k = 0; int l = 0;
            int.TryParse(mnetwt_txt.Text, out i);
            int.TryParse(mvehiclewt_txt.Text, out k);
            l = i + k;
            mgrosswt_txt.Text = l.ToString();
            //garbagetype_txt.Text = material_ddl.SelectedItem.Text.Trim();
        }
        protected void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                yard = "1";
                int b;
                if (mvehicletype_txt.Text == "Transfer Container")
                {
                    trtype = "OUT";
                }
                else
                {
                    trtype = "IN";
                }
                if (mshift_ddl.Text.Trim() == "-1")
                {
                    message_lbl.Text = "Please Select Shift......!";
                    return;
                }

                if (binzone_ddl.Text.Trim() == "-1")
                {
                    message_lbl.Text = "Please Select Yard......!";
                    return;
                }

                if (ddltrip.Text.Trim() == "-1")
                {
                    message_lbl.Text = "Please Select Trip Type......!";
                    return;
                }

                if (ddlgrabagematerial.Text.Trim() == "-1")
                {
                    message_lbl.Text = "Please Select Trip Material......!";
                    return;
                }
                string date = dto.ToString("dd-MM-yyyy");

                string dtrip = "select max(dtripno)from Garbagewt_details_Test where Vehicleno='" + mvehicleno_txt.Text + "' and (transtime) LIKE '" + "%" + date + "%" + "'";

                dt = objDBQuery.retdt(dtrip, "");
                if (dt.Rows[0][0].ToString() == "" || dt.Rows[0][0].ToString() == null)
                {
                    dtripno = "1";
                    dtripval_lbl.Text = dtripno.Trim();
                }
                else
                {
                    b = Convert.ToInt32(dt.Rows[0][0].ToString());
                    b = b + 1;
                    dtripval_lbl.Text = b.ToString().Trim();
                }



                mnetwt_txt.Text = (Convert.ToInt32(mgrosswt_txt.Text) - Convert.ToInt32(mvehiclewt_txt.Text)).ToString();
                string scanins = "insert into Garbagewt_details_Test(Dtripno,Vehicleno,Vehicletype,Triptype,ownedby,vehicleintime,vehicleouttime,vehicleweight,Totalweight,netweight,drivername,transtime,Material,bin_no,bin_Location,ward,zone,shift,yard,yard_status) values('" + dtripval_lbl.Text.Trim() + "','" + mvehicleno_txt.Text.Trim() + "','" + mvehicletype_txt.Text.Trim() + "','" + ddltrip.SelectedItem.Text.Trim() + "','" + mowner_txt.Text.Trim() + "','" + dto + "','" + dto + "'," + mvehiclewt_txt.Text.Trim() + "," + mgrosswt_txt.Text.Trim() + "," + mnetwt_txt.Text.Trim() + ",'" + mdrivername_txt.Text.Trim() + "','" + dto + "','" + ddlgrabagematerial.SelectedItem.Text.Trim() + "','" + "" + "','" + "" + "','" + mward_txt.Text.Trim() + "','" + mzone_txt.Text.Trim() + "','" + mshift_ddl.SelectedItem.Text.Trim() + "','" + binzone_ddl.SelectedItem.Text.Trim() + "','" + "Yes" + "')";
                if (!objDBQuery.update(scanins, ""))
                {
                    //MessageBox.Show("Insertion Failed");
                    message_lbl.Text = "Trip Details Insertion Failed......!";
                    return;
                }

                if (mvehicletype_txt.Text == "Dumper Placer" || mvehicletype_txt.Text == "Double Dumper")
                {

                }

                message_lbl.Text = "Trip Details Inserted Successfully";

            }
            catch (Exception ex)
            {

            }
        }


    }
}