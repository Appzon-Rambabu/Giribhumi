using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROFR.helper;


namespace ROFR.helper
{
    public class Multipledlcbal
    {
        public static DataTable GetbenmandalDetails(string itda, string district, string username)
        {
            Multipledal userObj = new Multipledal();
            return userObj.GetbenmandalDetails(itda, district, username);
        }

        public static DataTable GetForestBeneficiaryDetailscountValidate(string district, string Itda, string mandal)
        {
            Multipledal userObj = new Multipledal();
            return userObj.GetForestBeneficiaryDetailscountValidate(district, Itda, mandal);
        }

        public static DataTable GetForestBeneficiaryDetailsValidate(string district, string start, string end, string Itda, string mandal)
        {
            Multipledal userObj = new Multipledal();
            return userObj.GetForestBeneficiaryDetailsValidate(district, start, end, Itda, mandal);
        }
    
}
}