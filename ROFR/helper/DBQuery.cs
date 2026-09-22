using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net;

namespace ROFR.helper
{
    public class DBQuery : DBClass
    {

        public DBQuery()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string getDashBoardDetails()
        {
            try
            {
                string strResult = string.Empty;
                DataTable dtResult = retdt("select Distinct Vehicletype,COUNT(*) as [TOTAL TRIPS],SUM(netweight) from [IGMS].[dbo].[Garbagewt_details] where cast(transtime as date)='" + DateTime.Now.ToString("yyyy-MM-dd") + "' group by Vehicletype", "DashBoard");
                if (dtResult != null && dtResult.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtResult.Rows)
                    {
                        if (strResult == string.Empty)
                            strResult = "<tr><td style=\"color:black;font-weight:bold;\">" + dr[0].ToString() + "</td><td style=\"color:black;font-weight:bold;width:70px;text-align:right;\">" + dr[1].ToString() + "</td><td style=\"color:black;font-weight:bold;width:70px;text-align:right;\">" + dr[2].ToString() + "</td></tr>";
                        else
                            strResult += "<tr><td style=\"color:black;font-weight:bold;\">" + dr[0].ToString() + "</td><td style=\"color:black;font-weight:bold;width:70px;text-align:right;\">" + dr[1].ToString() + "</td><td style=\"color:black;font-weight:bold;width:70px;text-align:right;\">" + dr[2].ToString() + "</td></tr>";
                    }
                    strResult = "<table border=\"1\" cellpadding=\"3\" cellspacing=\"5\" width=\"430px;\"><tr><td colspan=\"3\" style=\"color:White;font-size:14px; font-weight:bold;background-image: url(images/bg-link.jpg);\" align=\"center\">DashBoard</td></tr><tr><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:70;text-align:center;\">VEHICLE TYPE</td><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:100px;text-align:center;\">TOTAL TRIPS</td><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:200px;text-align:center;\">TOTAL WEIGHT (IN TONS)</td></tr>" + strResult + "</table>";
                }
                else
                {
                    strResult = "<table border=\"1\" cellpadding=\"3\" cellspacing=\"5\" width=\"430px;\"><tr><td colspan=\"3\" style=\"color:White;font-size:14px; font-weight:bold;background-image: url(images/bg-link.jpg);\" align=\"center\">DashBoard</td></tr><tr><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:70;text-align:center;\">VEHICLE TYPE</td><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:100px;text-align:center;\">TOTAL TRIPS</td><td style=\"color:White;font-weight:bold;background-image: url(images/bg-link.jpg);width:200px;text-align:center;\">TOTAL WEIGHT (IN TONS)</td></tr>NO DATA FOUND</table>";
                    strResult = "<table border=\"1\" cellpadding=\"3\" cellspacing=\"5\" width=\"300px;\"><tr><td colspan=\"3\" style=\"color:White;font-size:14px; font-weight:bold;background-image: url(images/bg-link.jpg);\" align=\"center\">DashBoard</td></tr><tr><td>Data Not Found</td></table>";
                }
                return strResult;
            }
            catch
            {
                return "<table border=\"1\" cellpadding=\"3\" cellspacing=\"3\"><tr><td colspan=\"3\" style=\"color:Black;font-size:14px; font-weight:bold;\" align=\"center\">DashBoard</td></tr><tr><td>Data Not Found</td></table>";
            }
        }
        public DataTable GetLoginDetails(string StrUsername, string strPassword)
        {
            try
            {
                DataTable dtLogin = retdt("Select Username,Password from tbl_Password where UPPER(Username) ='" + StrUsername + "'", "");
                if (dtLogin != null && dtLogin.Rows.Count > 0)
                    return dtLogin;
                else
                    return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable Getwarddata(string zoneid)
        {
            try
            {
                DataTable ward_list = retdt("select distinct Ward from Bin_Master where Zone='" + zoneid + "'", "");
                if (ward_list != null && ward_list.Rows.Count > 0)
                    return ward_list;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable GetCountOfAllVehicles()
        {
            try
            {
                DataTable dtResult = retdt("select count(1) from Vehicle_Details where Is_active='Yes'", "vehicledetails");
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        #region Vehicle Details
        public DataTable Getvehicledetails()
        {
            try
            {
                DataTable dtResult = retdt("select Vehicle_no,Driver_Name,Zone,Ownedby,[status] from Vehicle_Details where Is_active='Yes'", "vehicledetails");
                if (dtResult != null && dtResult.Rows.Count > 0)
                    return dtResult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Vehicle Repair details
        public DataTable GetAllVehicleRepairDetails(string d1, string d2, string d3, string d4, string zone, string vehicleno, string repairtype)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && vehicleno == "")
                    {
                        tripresult = retdt("select  vehicle_no as [VEHICLE NO],COUNT(distinct REPAIR_TYPE) [REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where CAST(TRANS_DATE as date)='" + d1 + "' and ZONE='" + zone + "' group by vehicle_no", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype == "")
                    {
                        tripresult = retdt("select distinct REPAIR_TYPE,cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR COUNT],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED COUNT] from vehicle_repair_details where CAST(TRANS_DATE as date) ='" + d1 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' group by REPAIR_TYPE", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype != "")
                    {
                        tripresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,OWNED_BY,REPAIR_TYPE,DESCRIPTION,convert(varchar,REPAIR_DATE,103) as [REPAIR DATE],convert(varchar,COMPLETE_DATE,103) as [COMPLETE DATE] from vehicle_repair_details  where CAST(TRANS_DATE as date) ='" + d1 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' and REPAIR_TYPE='" + repairtype + "'", "vehicledetails");
                    }
                    else
                    {
                        tripresult = retdt("select ZONE,COUNT(distinct vehicle_no)[TOTAL VEHICLES],COUNT(distinct REPAIR_TYPE) [TOTAL REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where CAST(TRANS_DATE as date)='" + d1 + "' group by zone", "vehicledetails");
                    }

                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && vehicleno == "")
                    {
                        tripresult = retdt("select  vehicle_no as [VEHICLE NO],COUNT(distinct REPAIR_TYPE) [REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where CAST(TRANS_DATE as date) Between '" + d2 + "' and '" + d3 + "' and ZONE='" + zone + "' group by vehicle_no", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype == "")
                    {
                        tripresult = retdt("select distinct REPAIR_TYPE,cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR COUNT],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED COUNT] from vehicle_repair_details where CAST(TRANS_DATE as date) Between '" + d2 + "' and '" + d3 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' group by REPAIR_TYPE", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype != "")
                    {
                        tripresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,OWNED_BY,REPAIR_TYPE,DESCRIPTION,convert(varchar,REPAIR_DATE,103) as [REPAIR DATE],convert(varchar,COMPLETE_DATE,103) as [COMPLETE DATE] from vehicle_repair_details  where CAST(TRANS_DATE as date) Between '" + d2 + "' and '" + d3 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' and REPAIR_TYPE='" + repairtype + "'", "vehicledetails");
                    }
                    else
                    {
                        tripresult = retdt("select ZONE,COUNT(distinct vehicle_no)[TOTAL VEHICLES],COUNT(distinct REPAIR_TYPE) [TOTAL REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where CAST(TRANS_DATE as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "vehicledetails");
                    }

                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && vehicleno == "")
                    {
                        tripresult = retdt("select  vehicle_no as [VEHICLE NO],COUNT(distinct REPAIR_TYPE) [REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where month(TRANS_DATE)='" + d4 + "' and ZONE='" + zone + "' group by vehicle_no", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype == "")
                    {
                        tripresult = retdt("select distinct REPAIR_TYPE,cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR COUNT],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED COUNT] from vehicle_repair_details where month(TRANS_DATE)='" + d4 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' group by REPAIR_TYPE", "vehicledetails");
                    }
                    else if (zone != "" && vehicleno != "" && repairtype != "")
                    {
                        tripresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,OWNED_BY,REPAIR_TYPE,DESCRIPTION,convert(varchar,REPAIR_DATE,103) as [REPAIR DATE],convert(varchar,COMPLETE_DATE,103) as [COMPLETE DATE] from vehicle_repair_details  where month(TRANS_DATE)='" + d4 + "' and ZONE='" + zone + "' and vehicle_no='" + vehicleno + "' and REPAIR_TYPE='" + repairtype + "'", "vehicledetails");
                    }
                    else
                    {
                        tripresult = retdt("select ZONE,COUNT(distinct vehicle_no)[TOTAL VEHICLES],COUNT(distinct REPAIR_TYPE) [TOTAL REPAIR TYPES],cast(sum((case when REPAIR_STATUS='R' then 1 else 0 end)) as int)  as [REPAIR VEHICLES],cast(sum((case when REPAIR_STATUS='C' then 1 else 0 end)) as int)  as [COMPLETED VEHICLES] from vehicle_repair_details where month(TRANS_DATE)='" + d4 + "' group by zone", "vehicledetails");
                    }

                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }

        }
        #endregion

        #region TripDetails
        public DataTable Getvehicletypezonetripdetails(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS] from Garbagewt_details_Test where Zone='" + zone + "' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.Vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.Zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES], COUNT(gw.vehicleno) as [TOTAL TRIPS]  from zone_master zm   left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region WeightDetails
        public DataTable Getvehicletypezoneweightdetails(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.Vehicleno) as [TOTAL VEHICLES],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and cast(transtime as date)='" + d1 + "' group by zm.Zone ", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone group by zm.zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region Trip and WeightDetails
        public DataTable Getvehicletypezonetripweightdetails(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and zm.zone=gw.zone group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) from zone_master zm  left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone  group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region MSF Wise Trip and WeightDetails
        public DataTable Getvehicletypezonetripweightdetailsgajuwaka(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Gajuwaka' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Gajuwaka' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Gajuwaka' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Gajuwaka' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Gajuwaka' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and gd.yard='Gajuwaka' and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Gajuwaka' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Gajuwaka' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Gajuwaka' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Gajuwaka' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and zm.zone=gw.zone and gw.yard='Gajuwaka' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Gajuwaka' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Gajuwaka' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Gajuwaka' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Gajuwaka' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) from zone_master zm  left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone and gw.yard='Gajuwaka' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable Getvehicletypezonetripweightdetailskapuluppada(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Kapuluppada' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Kapuluppada' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Kapuluppada' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Kapuluppada' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Kapuluppada' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and gd.yard='Kapuluppada' and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Kapuluppada' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Kapuluppada' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Kapuluppada' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Kapuluppada' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and zm.zone=gw.zone and gw.yard='Kapuluppada' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Kapuluppada' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Kapuluppada' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Kapuluppada' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Kapuluppada' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) from zone_master zm  left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone and gw.yard='Kapuluppada' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable Getvehicletypezonetripweightdetailsmudasarlova(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Mudasarlova' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Mudasarlova' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Mudasarlova' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Mudasarlova' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Mudasarlova' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and gd.yard='Mudasarlova' and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Mudasarlova' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Mudasarlova' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Mudasarlova' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Mudasarlova' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and zm.zone=gw.zone and gw.yard='Mudasarlova' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Mudasarlova' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Mudasarlova' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Mudasarlova' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Mudasarlova' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) from zone_master zm  left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone and gw.yard='Mudasarlova' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable Getvehicletypezonetripweightdetailstownkotharoad(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Town kotharoad' and cast(transtime as date)='" + d1 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Town kotharoad' and cast(transtime as date)='" + d1 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Town kotharoad' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe == "Dumper Placer" || vhletpe == "Double Dumper")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Town kotharoad' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as time), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Town kotharoad' and cast(transtime as date)='" + d1 + "'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date)='" + d1 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.Zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.Vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Zone_Master zm left join Garbagewt_details gd on zm.Zone=gd.zone and gd.yard='Town kotharoad' and cast(transtime as date)='" + d1 + "' group by zm.Zone", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Town kotharoad' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Town kotharoad' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Town kotharoad' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Town kotharoad' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        //tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by zone", "Trips");
                        tripresult = retdt("select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gw on cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and zm.zone=gw.zone and gw.yard='Town kotharoad' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and yard='Town kotharoad' and month(cast(transtime as date))= '" + d4 + "' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and yard='Town kotharoad' and month(cast(transtime as date))= '" + d4 + "' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and yard='Town kotharoad' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and yard='Town kotharoad' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt(" select zm.zone,COUNT(distinct gw.ward) As [TOTAL WARDS],COUNT(distinct gw.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gw.vehicleno) as [TOTAL VEHICLES],COUNT(gw.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gw.netweight/1000) as numeric(38,2)),0) from zone_master zm  left join Garbagewt_details gw on month(cast(transtime as date))= '" + d4 + "' and zm.zone=gw.zone and gw.yard='Town kotharoad' group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region Private Vehicles
        public DataTable Getprivatevehiclesreport(string d1, string d2, string d3, string d4, string zone, string ward, string vhletpe, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date)='" + d1 + "' and ownedby='Private' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date)='" + d1 + "' and ownedby='Private' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date)='" + d1 + "' and ownedby='Private' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        if (vhletpe != "Dumper Placer" || vhletpe != "Dumper Placer")
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "' and ownedby='Private'", "Trips");
                        }
                        else
                        {
                            tripresult = retdt("select Vehicleno as [VEHICLE NUMBER],Vehicletype as [VEHICLE TYPE],bin_Location as [LOCATION],Bin_No as [BIN NUMBER],Totalweight as [TOTAL WEIGHT],netweight as [NET WEIGHT],convert(varchar(10), cast(transtime as date), 103) as [TRIP DATE],convert(varchar(10), cast(transtime as date), 108) as[TRIP TIME] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and cast(transtime as date)='" + d1 + "' and ownedby='Private'", "Trips");
                        }
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select zm.zone,COUNT(distinct gd.ward) As [TOTAL WARDS],COUNT(distinct gd.Vehicletype) as [VEHICLE TYPES],COUNT(distinct gd.vehicleno) as [TOTAL VEHICLES],COUNT(gd.vehicleno) as [TOTAL TRIPS],isnull(cast(SUM(gd.netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from zone_master zm left join Garbagewt_details gd on cast(transtime as date)='" + d1 + "' and ownedby='Private' and zm.zone=gd.zone group by zm.zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and ownedby='Private' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and ownedby='Private' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and ownedby='Private' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as date), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and Vehicleno='" + vhleno + "' and ownedby='Private' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and ownedby='Private' group by zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (zone != "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select WARD,COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where Zone='" + zone + "' and month(cast(transtime as date))= '" + d4 + "' and ownedby='Private' group by Ward", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe == "" && vhleno == "")
                    {
                        tripresult = retdt("select Vehicletype,COUNT(distinct vehicleno) as [Total Vehicles],COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and month(cast(transtime as date))= '" + d4 + "' and ownedby='Private' group by Vehicletype", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and month(cast(transtime as date))= '" + d4 + "' and ownedby='Private' group by vehicleno", "Trips");
                    }
                    else if (zone != "" && ward != "" && vhletpe != "" && vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,bin_Location,Bin_No,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as date), 108) as[Trip Time] from Garbagewt_details where Zone='" + zone + "' and ward='" + ward + "' and Vehicletype='" + vhletpe + "' and ownedby='Private' and Vehicleno='" + vhleno + "' and month(cast(transtime as date))= '" + d4 + "'", "Trips");
                    }
                    else if (zone == "" && ward == "" && vhletpe == "" && vhleno == "")
                    {
                        //row_number() over (order by zone) as 'sno',
                        tripresult = retdt("select ZONE,COUNT(distinct ward) As [TOTAL WARDS],COUNT(distinct Vehicletype) as [VEHICLE TYPES],COUNT(distinct vehicleno) as [TOTAL VEHICLES],COUNT(*) as [TOTAL TRIPS],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[TOTAL WEIGHT] from Garbagewt_details where month(cast(transtime as date))= '" + d4 + "' and ownedby='Private' group by zone", "Trips");

                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region Bin Report
        public DataTable GetBinDetails(string d1, string d2, string d3)
        {
            try
            {
                if (d2 != "-1")
                {
                    DataTable dtBin = retdt("select wm.ward_no,isnull(count(bm.bin_no),0),isnull(bt.Bin_count,0) as [CLEANED BINS],(isnull(count(bm.bin_no),0)-isnull(bt.Bin_count,0)) as [UNCLEANED BINS] from Ward_master wm left join Bin_master bm on wm.ward_no=bm.ward left join Bin_Transaction bt on wm.ward_no=bt.ward and cast(bt.trans_date as date)='" + d1 + "' where bm.zone='" + d2 + "' group by wm.ward_no,bt.Bin_count order by wm.ward_no", "BINDETAILS");
                    if (dtBin != null && dtBin.Rows.Count > 0)
                        return dtBin;
                    else
                        return new DataTable();
                }
                else
                {
                    DataTable dtBin = retdt("select zm.Zone,ISNULL(a.[TOTAL WARDS],0),ISNULL(a.[TOTAL BINS],0),ISNULL(b.[Bin Count],0),ISNULL((a.[TOTAL BINS]-b.[Bin Count]),0) as UnCleaned from ((select Zone from Zone_Master) zm left join (select distinct Zone as ZONE,COUNT(distinct Ward) as [TOTAL WARDS],COUNT(distinct Bin_No) as [TOTAL BINS] from Bin_Master group by Zone) a on a.ZONE=zm.zone left join (select distinct zone, SUM(Bin_Count) as [Bin Count] from Bin_Transaction  where cast(Trans_date as date)='" + d1 + "' group by Zone) b  on a.ZONE=b.Zone) order by zm.zone ", "BINDETAILS");
                    if (dtBin != null && dtBin.Rows.Count > 0)
                        return dtBin;
                    else
                        return new DataTable();
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetBinDetailsLevels(string Level, string dt1, string dt2, string dt3)
        {
            DataTable dtBin = new DataTable();
            try
            {
                if (Level == "B")
                {
                    dtBin = retdt("select bin_no as Bin,(case when cast(transtime as date)= '" + dt1 + "' then'Cleaned' else 'Uncleaned' end) as status,bin_Location from Garbagewt_details   where zone='" + dt2 + "'  and Ward='" + dt3 + "' and cast(transtime as date)= '" + dt1 + "' and vehicletype in ('Dumper Placer','Double Dumper')", "");
                }
                if (Level == "bin")
                {
                    dtBin = retdt("select distinct Bin_no from Bin_Master where zone='" + dt2 + "'  and Ward='" + dt3 + "'", "");
                }
                if (dtBin != null && dtBin.Rows.Count > 0)
                    return dtBin;
                else
                    return new DataTable();

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetBinDetail(string d1, string d2, string d3, string Level, string Parameter)
        {
            DataTable dtBin = new DataTable();

            try
            {
                if (!string.IsNullOrEmpty(d1))
                {
                    if (Level == "z")
                    {
                        dtBin = retdt("select a.Zone,COUNT(distinct a.Ward) as [Total Wards],COUNT(distinct a.Bin_No) as [Total Bins],(case when SUM(b.Bin_Count)!='' then SUM(distinct b.Bin_Count) else '0' end) AS [Cleaned Bins] from  Bin_Master a left join Bin_Transaction b on a.Zone=b.Zone where a.Zone='" + Parameter + "' and cast(b.Trans_date as date)='" + d1 + "' group by a.zone", "BINDETAILS");

                    }
                    if (Level == "W")
                    {
                        string[] a = Parameter.Split('^');
                        dtBin = retdt("select a.Ward,COUNT(distinct a.Bin_No) as [Total Bins],(case when SUM(b.Bin_Count)!='' then SUM(distinct b.Bin_Count) else '0' end) AS [Cleaned Bins] from  Bin_Master a left join Bin_Transaction b on a.Ward=b.Ward where a.Zone='" + a[1].ToString() + "' and cast(b.Trans_date as date)='" + d1 + "' and a.Zone=b.Zone group by a.Ward", "");
                    }

                    if (Level == "B")
                    {
                        string[] a = Parameter.Split('^');

                        dtBin = retdt("select bin_no as Bin,(case when cast(transtime as date)= CAST(getdate() as DATE) then'Cleaned' else 'Uncleaned' end) as status from Garbagewt_details   where zone='" + a[2].ToString() + "'  and Ward='" + a[0].ToString() + "' and cast(b.Trans_date as date)='" + d1 + "' and CAST(b.Trans_date AS date)= CAST(getdate() AS date)", "");
                    }
                    if (Level == "bin")
                    {
                        string[] a = Parameter.Split('^');
                        dtBin = retdt("select distinct Bin_no as Bin from Bin_Master   where zone='" + a[2].ToString() + "'  and Ward='" + a[0].ToString() + "'", "");
                    }
                    if (dtBin != null && dtBin.Rows.Count > 0)
                        return dtBin;
                    else
                        return new DataTable();

                }

                else
                {
                    return new DataTable();
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Location Report
        public DataTable GetLocationDetails(string d1, string d2, string d3)
        {
            try
            {
                if (d2 != "-1")
                {
                    //DataTable dtlocation = retdt("select wm.Ward_no,COUNT(bm.Bin_Location),(case when SUM(b.Location_Count)!='' then SUM(distinct b.Location_Count) else '0' end) AS [CLEANED BINS], (COUNT(distinct bm.Bin_Location)-(case when SUM(b.Location_Count)!='' then SUM(distinct b.Location_Count) else '0' end)) as [UNCLEANED BINS] from Ward_Master wm left join BinLocation_Master bm on wm.Ward_no=bm.Ward left join Location_Transaction b on bm.Zone=b.Zone and cast(b.Trans_date as date)='" + d1 + "' and b.Zone='" + d2 + "' and bm.Ward=b.Ward group by wm.Ward_no ", "LOCATIONDETAILS");
                    DataTable dtlocation = retdt("select wm.ward_no,isnull(count(bm.Bin_Location),0),isnull(bt.Location_Count,0) as [CLEANED LOCATIONS],(isnull(count(bm.Bin_Location),0)-isnull(bt.Location_Count,0)) as [UNCLEANED LOCATIONS] from Ward_master wm left join BinLocation_Master bm on wm.ward_no=bm.ward left join Location_Transaction bt on wm.ward_no=bt.ward and cast(bt.trans_date as date)='" + d1 + "' where bm.zone='" + d2 + "' group by wm.ward_no,bt.Location_Count order by wm.ward_no", "LOCATIONDETAILS");
                    if (dtlocation != null && dtlocation.Rows.Count > 0)
                        return dtlocation;
                    else
                        return new DataTable();
                }
                else
                {
                    DataTable dtlocation = retdt("select zm.Zone,ISNULL(a.[TOTAL WARDS],0),ISNULL(a.[TOTAL LOCATIONS],0),ISNULL(b.[LOCATION Count],0),ISNULL((a.[TOTAL LOCATIONS]-b.[LOCATION Count]),0) as UnCleaned from ((select Zone from Zone_Master) zm left join (select distinct Zone as ZONE,COUNT(distinct Ward) as [TOTAL WARDS],COUNT(distinct Bin_Location) as [TOTAL LOCATIONS] from BinLocation_Master group by Zone) a  on a.ZONE=zm.zone left join (select distinct zone, SUM(Location_Count) as [LOCATION Count]  from Location_Transaction where cast(Trans_date as date)='" + d1 + "' group by zone) b on a.zone=b.zone) order by zm.zone", "LOCATIONDETAILS");
                    if (dtlocation != null && dtlocation.Rows.Count > 0)
                        return dtlocation;
                    else
                        return new DataTable();
                }
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetLocationDetailsLevels(string Level, string dt1, string dt2, string dt3)
        {
            DataTable dtBin = new DataTable();
            try
            {
                if (Level == "B")
                {
                    dtBin = retdt("select bin_Location as [Bin Location],(case when cast(transtime as date)= '" + dt1 + "' then'Cleaned' else 'Uncleaned' end) as status from Garbagewt_details   where zone='" + dt2 + "'  and Ward='" + dt3 + "' and cast(transtime as date)= '" + dt1 + "' and vehicletype in ('Dumper Placer','Double Dumper')", "");
                }
                if (Level == "bin")
                {
                    dtBin = retdt("select distinct Bin_Location from BinLocation_Master where zone='" + dt2 + "' and Ward='" + dt3 + "'", "");
                }
                if (dtBin != null && dtBin.Rows.Count > 0)
                    return dtBin;
                else
                    return new DataTable();

            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Sanitory
        public DataTable Getsanitoryetails()
        {
            try
            {
                //DataTable sanitorydt = retdt("select receivedby,materialtype,quantity,received_date,convert(varchar(10),cast(transtime as date),103) as cast(transtime as date) from sanitory_store", "Sanitory");
                DataTable sanitorydt = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from sanitory_store", "Sanitory");
                if (sanitorydt != null && sanitorydt.Rows.Count > 0)
                    return sanitorydt;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable Getsanitoryetailsdat(string d1, string d2, string d3, string d4)
        {
            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from sanitory_store where cast(received_date as date)='" + d1 + "'", "Sanitory");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from sanitory_store where cast(received_date as date)>='" + d2 + "' and cast(received_date as date)<='" + d3 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from sanitory_store where month(received_date)='" + d4 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetStockDistributionData(string strMaterial, string strStockInDate)
        {
            try
            {
                DataTable stockresult = retdt("select materialtype [Material Type], receivedby [Distributed To],quantity [Quantity],zone [Zone],convert(varchar(10), distribution_date,103) [Distribution Date] from sanitory_distribution where replace(materialtype,' ','')=replace('" + strMaterial + "',' ','') and cast(stockin_date as date)='" + strStockInDate + "'", "Trips");
                if (stockresult != null && stockresult.Rows.Count > 0)
                    return stockresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region New_Vehicle_Data
        public DataTable Getnewvehicledetails()
        {
            try
            {
                //DataTable sanitorydt = retdt("select receivedby,materialtype,quantity,received_date,convert(varchar(10),cast(transtime as date),103) as cast(transtime as date) from sanitory_store", "Sanitory");
                DataTable sanitorydt = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details", "Sanitory");
                if (sanitorydt != null && sanitorydt.Rows.Count > 0)
                    return sanitorydt;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable Getnewvehicledetailsdat(string d1, string d2, string d3, string d4)
        {
            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where cast(received_date as date)='" + d1 + "'", "Sanitory");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where cast(received_date as date)>='" + d2 + "' and cast(received_date as date)<='" + d3 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where month(received_date)='" + d4 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetStockDistributionvehicleData(string strvehicletype, string strStockInDate)
        {
            try
            {
                DataTable stockresult = retdt("select vehicletype [Vehicle Type], receivedby [Distributed To],quantity [Quantity],zone [Zone],convert(varchar(10), distribution_date,103) [Distribution Date] from Newvehicle_distribution where replace(vehicletype,' ','')=replace('" + strvehicletype + "',' ','') and cast(stockin_date as date)='" + strStockInDate + "'", "Trips");
                if (stockresult != null && stockresult.Rows.Count > 0)
                    return stockresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Vehicle_Spare_Data
        public DataTable Getsparevehicledetails()
        {
            try
            {
                //DataTable sanitorydt = retdt("select receivedby,materialtype,quantity,received_date,convert(varchar(10),cast(transtime as date),103) as cast(transtime as date) from sanitory_store", "Sanitory");
                DataTable sanitorydt = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from vehicleSpare_store", "Sanitory");
                if (sanitorydt != null && sanitorydt.Rows.Count > 0)
                    return sanitorydt;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable Getvehiclesparedetailsdat(string d1, string d2, string d3, string d4)
        {
            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,materialtype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where cast(received_date as date)='" + d1 + "'", "Sanitory");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where cast(received_date as date)>='" + d2 + "' and cast(received_date as date)<='" + d3 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    DataTable tripresult = retdt("select receivedby,vehicletype,quantity,Balance,convert(varchar,received_date,103) received_date from new_vehicles_details where month(received_date)='" + d4 + "'", "Trips");
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        public DataTable GetvehiclespareDistributionData(string strMaterial, string strStockInDate)
        {
            try
            {
                DataTable stockresult = retdt("select materialtype [Material Type], receivedby [Distributed To],quantity [Quantity],zone [Zone],convert(varchar(10), distribution_date,103) [Distribution Date] from vehicleSpare_distribution where replace(materialtype,' ','')=replace('" + strMaterial + "',' ','') and cast(stockin_date as date)='" + strStockInDate + "'", "Trips");
                if (stockresult != null && stockresult.Rows.Count > 0)
                    return stockresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Graphs
        #region Vehicle Type
        public DataTable GetRepairdetails(string strVehicleNo)
        {
            try
            {
                DataTable wtresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,[STATUS],REMARKS,REPAIR_DATE,COMPLETE_DATE from vehicle_repair_details where VEHICLE_NO='" + strVehicleNo + "'", "Trip details");
                if (wtresult != null && wtresult.Rows.Count > 0)
                    return wtresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetRunningetails(string strVehicleNo)
        {
            try
            {
                DataTable wtresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,[STATUS],ZONE,WARD from vehicle_details where  VEHICLE_NO='" + strVehicleNo + "'", "Trip details");
                if (wtresult != null && wtresult.Rows.Count > 0)
                    return wtresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable GetRunningvehicledetails(string strVehicleNo)
        {
            try
            {
                DataTable wtresult = retdt("select VEHICLE_NO,VEHICLE_TYPE,DRIVER_NAME,[STATUS],REMARKS,REPAIR_DATE,COMPLETE_DATE from vehicle_details where yard_status='1' and VEHICLE_NO='" + strVehicleNo + "'", "Trip details");
                if (wtresult != null && wtresult.Rows.Count > 0)
                    return wtresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public SqlDataReader GetTripDetailsForGraph()
        {
            try
            {
                return ExecuteDataReader("select COUNT(vehicleno) [Total Trips],Year(cast(transtime as date)) [Transaction Year] from Garbagewt_details group by Year(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetvehicletypeTripDetailsForMonthGraph(string Month, string Year, string vehicletype)
        {
            try
            {
                return ExecuteDataReader("select COUNT(vehicleno) [Total Trips],day(cast(transtime as date)) [Transaction Day] from Garbagewt_details where yard_status='1' and MONTH(cast(transtime as date))='" + Month + "' and Year(cast(transtime as date))='" + Year + "' and vehicletype='" + vehicletype + "' group by day(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetvehicletypeTripDetailsForYearGraph(string Year, string vehicletype)
        {
            try
            {
                return ExecuteDataReader("select COUNT(vehicleno) [Total Trips],datename(month,cast(transtime as date)) [Transaction Month],month(cast(transtime as date)) from Garbagewt_details where yard_status='1' and Year(cast(transtime as date))='" + Year + "' and vehicletype='" + vehicletype + "' group by datename(month,cast(transtime as date)),month(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetWeightDetailsForGraph()
        {
            try
            {
                return ExecuteDataReader("select sum(netweight/1000) [Total Weight],Year(cast(transtime as date)) [Transaction year] from Garbagewt_details group by Year(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetvehicletypeWeightDetailsForMonthGraph(string Month, string Year, string vehicletype)
        {
            try
            {
                return ExecuteDataReader("select sum(netweight/1000) [Total Weight],day(cast(transtime as date)) [Transaction Day] from Garbagewt_details where yard_status='1' and MONTH(cast(transtime as date))='" + Month + "' and Year(cast(transtime as date))='" + Year + "' and vehicletype='" + vehicletype + "' group by day(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetvehicletypeWeightDetailsForYearGraph(string Year, string vehicletype)
        {
            try
            {
                return ExecuteDataReader("select sum(netweight/1000) [Total Weight],datename(month,cast(transtime as date)) [Transaction Month],month(cast(transtime as date)) from Garbagewt_details where yard_status='1' and Year(cast(transtime as date))='" + Year + "' and vehicletype='" + vehicletype + "' group by datename(month,cast(transtime as date)),month(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Zone
        public SqlDataReader GetzoneTripDetailsForMonthGraph(string Month, string Year, string zone)
        {
            try
            {
                return ExecuteDataReader("select COUNT(vehicleno) [Total Trips],day(cast(transtime as date)) [Transaction Day] from Garbagewt_details where yard_status='1' and MONTH(cast(transtime as date))='" + Month + "' and Year(cast(transtime as date))='" + Year + "' and Zone='" + zone + "' group by day(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetzoneTripDetailsForYearGraph(string Year, string zone)
        {
            try
            {
                return ExecuteDataReader("select COUNT(vehicleno) [Total Trips],datename(month,cast(transtime as date)) [Transaction Month] from Garbagewt_details where yard_status='1' and Year(cast(transtime as date))='" + Year + "' and Zone='" + zone + "' group by datename(month,cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetzoneWeightDetailsForMonthGraph(string Month, string Year, string zone)
        {
            try
            {
                return ExecuteDataReader("select sum(netweight/1000) [Total Weight],day(cast(transtime as date)) [Transaction Day] from Garbagewt_details where yard_status='1' and MONTH(cast(transtime as date))='" + Month + "' and Year(cast(transtime as date))='" + Year + "' and Zone='" + zone + "' group by day(cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public SqlDataReader GetzoneWeightDetailsForYearGraph(string Year, string zone)
        {
            try
            {
                return ExecuteDataReader("select sum(netweight/1000) [Total Weight],datename(month,cast(transtime as date)) [Transaction Month] from Garbagewt_details where yard_status='1' and Year(cast(transtime as date))='" + Year + "' and Zone='" + zone + "' group by datename(month,cast(transtime as date))");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Dash Board
        //DateTime dto = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        public DataTable dashboardtripweightdata(string dto)
        {
            DataTable tripresult = new DataTable();


            try
            {
                tripresult = retdt("select a.Zone,count(b.Vehicleno),cast(ISNULL(SUM(b.netweight/1000),0) as decimal(10,2)) from Zone_Master a full outer join Garbagewt_details b on a.Zone=b.zone and cast(b.transtime as date)='" + dto + "' where a.Zone is not null  group by a.Zone order by a.Zone", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardzonebindata(string dto)
        {
            DataTable tripresult = new DataTable();


            try
            {
                tripresult = retdt("select res.Zone,isnull(res.bincount,0),isnull(res1.toatal,0),isnull((isnull(res.bincount,0)-isnull(res1.toatal,0)),0) from (select zm.Zone,zm.Zone_id,COUNT(bm.Bin_No) as bincount from Zone_Master zm left join Bin_Master bm on zm.Zone=bm.Zone  and bm.Is_Active='YES' group by zm.Zone,zm.Zone_id) res left join (select Zone,SUM(Bin_Count) as toatal from Bin_Transaction where CAST(Trans_date as date)='" + dto + "' group by zone) res1 on res.Zone=res1.zone", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardzonelocationdata(string dto)
        {
            DataTable tripresult = new DataTable();
            try
            {
                tripresult = retdt("select res.Zone,isnull(res.locationcount,0),isnull(res1.toatal,0),isnull((isnull(res.locationcount,0)-isnull(res1.toatal,0)),0) from (select zm.Zone,zm.Zone_id,COUNT(bm.Bin_location) as locationcount from Zone_Master zm left join BinLocation_Master bm on zm.Zone=bm.Zone and bm.Is_Active='YES' group by zm.Zone,zm.Zone_id) res left join (select Zone,SUM(Location_Count) as toatal from Location_Transaction where CAST(Trans_date as date)='" + dto + "' group by zone) res1 on res.Zone=res1.zone", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardvehicletypedata(string dto)
        {
            DataTable tripresult = new DataTable();
            try
            {
                tripresult = retdt("select a.vehicle_Type,count(b.Vehicleno),cast(ISNULL(SUM(netweight/1000),0) as decimal(10,2)) from vehicleType_master a left join Garbagewt_details b on a.vehicle_Type=b.Vehicletype and cast(b.transtime as date)='" + dto + "' where a.vehicle_Type is not null group by a.vehicle_Type order by a.vehicle_Type", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardvehiclestatusdata(string dto)
        {
            DataTable tripresult = new DataTable();

            try
            {
                tripresult = retdt("select distinct status,count(*) from Vehicle_Details group by status", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardweightmaterial(string dto)
        {
            DataTable tripresult = new DataTable();


            try
            {
                tripresult = retdt("select material,cast(ISNULL((sum(case when triptype='in' then netweight else 0 end)/1000),0) as decimal(10,2)) as in_netweight,cast(ISNULL((sum(case when triptype='out' then netweight else 0 end)/1000),0) as decimal(10,2)) as out_netweight from Garbagewt_details where cast(transtime as date)='" + dto + "' group  by material", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardweightindata(string dto)
        {
            DataTable tripresult = new DataTable();


            try
            {
                tripresult = retdt("select cast(ISNULL(SUM(netweight/1000),0) as decimal(10,2)) from Garbagewt_details where cast(transtime as date)='" + dto + "' and Triptype!='OUT'", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public DataTable dashboardweightoutdata(string dto)
        {
            DataTable tripresult = new DataTable();


            try
            {
                tripresult = retdt("select cast(ISNULL(SUM(netweight/1000),0) as decimal(10,2)) from Garbagewt_details where cast(transtime as date)='" + dto + "' and Triptype='OUT'", "Trips");
                if (tripresult != null && tripresult.Rows.Count > 0)
                    return tripresult;
                else
                    return new DataTable();
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        #endregion

        #region Compactor Details
        public DataTable getcompactordetails(string d1, string d2, string d3, string d4, string vhleno)
        {
            DataTable tripresult = new DataTable();

            if (!string.IsNullOrEmpty(d1))
            {
                try
                {
                    if (vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,zone,ward,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details where cast(transtime as date)='" + d1 + "' and Vehicletype='Compactor' and Vehicleno='" + vhleno + "'", "Trips");
                    }
                    else if (vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Vehicletype='Compactor' and cast(transtime as date)='" + d1 + "' group by vehicleno", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d2) && !string.IsNullOrEmpty(d3))
            {
                try
                {
                    if (vhleno != "")
                    {
                        tripresult = retdt("select Vehicleno,Vehicletype,zone,ward,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as time), 108) as[Trip Time] from Garbagewt_details_Test_Test where cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' and Vehicletype='Compactor' and Vehicleno='" + vhleno + "'", "Trips");
                    }
                    else if (vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details_Test where Vehicletype='Compactor' and cast(transtime as date) Between '" + d2 + "' and '" + d3 + "' group by vehicleno", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else if (!string.IsNullOrEmpty(d4))
            {
                try
                {
                    if (vhleno != "")
                    {
                        tripresult = retdt(" select Vehicleno,Vehicletype,zone,ward,Totalweight,netweight,convert(varchar(10), cast(transtime as date), 103) as [Trip Date],convert(varchar(10), cast(transtime as date), 108) as[Trip Time] from Garbagewt_details_Test where month(cast(transtime as date))= '" + d4 + "' and Vehicletype='Compactor' and Vehicleno='" + vhleno + "'", "Trips");
                    }
                    else if (vhleno == "")
                    {
                        tripresult = retdt("select vehicleno,COUNT(*) as [Total trips],isnull(cast(SUM(netweight/1000) as numeric(38,2)),0) as[Total Weight] from Garbagewt_details where Vehicletype='Compactor' and month(cast(transtime as date))= '" + d4 + "' group by vehicleno", "Trips");
                    }
                    if (tripresult != null && tripresult.Rows.Count > 0)
                        return tripresult;
                    else
                        return new DataTable();
                }
                catch (Exception ex)
                {
                    return new DataTable();
                }
            }
            else
            {
                return new DataTable();
            }
        }
        #endregion

        #region Encryptand Decrypt string
        public string Encrypt(string strToEncrypt)
        {
            try
            {
                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string strKey = (string)settingsReader.GetValue("SecurityKey", typeof(String));

                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = strKey;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        public string Decrypt(string strEncrypted)
        {
            try
            {
                System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
                // Get the key from config file
                string strKey = (string)settingsReader.GetValue("SecurityKey", typeof(String));

                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;
                string strTempKey = strKey;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strTempKey));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = Convert.FromBase64String(strEncrypted);
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        #endregion

        #region Send Message
        public string sendMessage(string phoneNo, string message)
        {

            string url = "http://login.bulksmsgateway.in/sendmessage.php";
            string result = "";
            message = HttpUtility.UrlPathEncode(message);
            String strPost = "?user=" + HttpUtility.UrlPathEncode("satish22") + "&password=" + HttpUtility.UrlPathEncode("9253557") + "&sender=" + HttpUtility.UrlPathEncode("testID") + "&mobile=" + HttpUtility.UrlPathEncode(phoneNo) + "&type=" + HttpUtility.UrlPathEncode("3") + "&message=" + message;
            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url + strPost);
            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(strPost);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                myWriter.Close();
            }
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader sr.Close();
            }
            return result;
        }
        #endregion
    }
}