using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ROFR.NewHelper
{
    public  class AgriClass
    {
        private Stopwatch stopwatch;
        private string assignedStatePrefix = "AP";
        private string assignedStatePrefixCF = "CF";
        public AgriClass()
        {
            stopwatch = Stopwatch.StartNew();
        }

        public long nanoTime()
        {
            
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        public string GenerateLandParcelId()
        {
            string uniqid = assignedStatePrefix + Verhoeff.getFarmLandUniqueIdWithChecksum();
           // await Task.Delay(1000);
            return uniqid;
        }

        public string GenerateLandParcelIdCF()
        {
            string uniqid = assignedStatePrefixCF + Verhoeff.getFarmLandUniqueIdWithChecksum();
            // await Task.Delay(1000);
            return uniqid;
        }
    }
}