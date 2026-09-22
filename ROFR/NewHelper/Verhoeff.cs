using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ROFR.NewHelper;
using System.Security.Cryptography;
using System.Text;
namespace ROFR.NewHelper
{
    public class Verhoeff
    {
        AgriClass ctemp = new AgriClass();
        
        static int[,] d = new int[,] {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 1, 2, 3, 4, 0, 6, 7, 8, 9, 5 },
        { 2, 3, 4, 0, 1, 7, 8, 9, 5, 6 },
        { 3, 4, 0, 1, 2, 8, 9, 5, 6, 7 },
        { 4, 0, 1, 2, 3, 9, 5, 6, 7, 8 },
        { 5, 9, 8, 7, 6, 0, 4, 3, 2, 1 },
        { 6, 5, 9, 8, 7, 1, 0, 4, 3, 2 },
        { 7, 6, 5, 9, 8, 2, 1, 0, 4, 3 },
        { 8, 7, 6, 5, 9, 3, 2, 1, 0, 4 },
        { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }
    };

        // The permutation table
        static int[,] p = new int[,] {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 },
        { 1, 5, 7, 6, 2, 8, 3, 0, 9, 4 },
        { 5, 8, 0, 3, 7, 9, 6, 1, 4, 2 },
        { 8, 9, 1, 6, 0, 4, 3, 5, 2, 7 },
        { 9, 4, 5, 3, 1, 2, 6, 8, 7, 0 },
        { 4, 2, 8, 6, 5, 7, 3, 9, 0, 1 },
        { 2, 7, 9, 3, 8, 0, 6, 4, 1, 5 },
        { 7, 0, 4, 6, 9, 1, 3, 2, 5, 8 }
    };

        // The inverse table
        static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

        /*
		 * For a given number generates a Verhoeff digit
		 *
		 */
        //step 4
        public static string generateVerhoeff(String num)
        {

            int c = 0;
            int[] myArray = stringToReversedIntArray(num);

            for (int i = 0; i < myArray.Length; i++)
            {
                c = d[c, p[((i + 1) % 8), myArray[i]]];
            }

            return inv[c].ToString();
        }


        public static long Get11Disgtno()
        {
            AgriClass ctemp = new AgriClass();
            long timeSeed = ctemp.nanoTime();
            Random random = new Random((int)(timeSeed & 0xFFFFFFFF));
            double rn = random.NextDouble();
            double randSeed = rn * 1000;
            long midSeed = (long)(timeSeed * randSeed);
            // return midSeed + "";
            string s = midSeed.ToString();
            if (s.Length >= 11)
            {
                string subStr = s.Substring(0, 11);
                long finalSeed = long.Parse(subStr);
                return finalSeed;
            }
            else
            {
                // Handle the case where s is shorter than 11 characters
                long finalSeed = long.Parse(s); // Convert directly
                return finalSeed;
            }
        }



        /*
		 * Validates that an entered number is Verhoeff compliant.
		 * NB: Make sure the check digit is the last one.
		 */
        public static Boolean validateVerhoeff(String num)
        {

            int c = 0;
            int[] myArray = stringToReversedIntArray(num);

            for (int i = 0; i < myArray.Length; i++)
            {

                c = d[c, p[(i % 8), myArray[i]]];
            }

            return (c == 0);
        }

        /*
		 * Converts a string to a reversed integer array.
		 */

        // Step 5
       

        public static int generateLastFiveSequenceNumbers()
        {
            Random randomNumber = new Random();
            int result = 0;
            for (int i = 0; i < 10; i++)
            {
                result = result * 10 + (randomNumber.Next(9) + 1);
            }
            return result;
        }

        private static long LIMIT = 10000L;
        private static long last = 0;

        public static long getID()
        {
            // 10 digits.
            //long id = System.currentTimeMillis() / LIMIT;
            long currentTimeMillis = (long)((DateTime.Now.Ticks));
           // long currentTimeMillis = DateTimeOffset.UtcNow.AddSeconds();
            long id = currentTimeMillis / LIMIT;
            if (id <= last)
            {
                id = (last + 1) % LIMIT;
            }
            return last = id;
        }

        public static bool IsUnique(long id)
        {
            // Store previously generated IDs (could be in memory, or in a database for permanent storage)
            HashSet<long> generatedIds = new HashSet<long>();

            // Check if the ID is already generated
            if (generatedIds.Contains(id))
            {
                return false; // ID is duplicate
            }

            // Add ID to the list to keep track of generated IDs
            generatedIds.Add(id);
            return true; // ID is unique
        }


        public static string getFarmerUniqueIdWithChecksum()
        {
            long id = generate10DigitNumber();
            // Long[] ary = new Long[] { 987654321L, 987654322L,  987654324L};
            // Long id = ary[new Random().nextInt(ary.length)];
            // System.out.println(id);
            string verhoff = generateVerhoeff(id.ToString());
            string finalVerhoff = id + verhoff;
            return finalVerhoff;
        }

        public static long generate10DigitNumber()
        {
            AgriClass ctemp = new AgriClass();
            long timeSeed = ctemp.nanoTime();
            Random random = new Random();
            double rn = random.Next();
            double randSeed = rn * 1000;
            long midSeed = (long)(timeSeed * randSeed);
            string s = midSeed + "";
            string subStr = s.Substring(0, 10);
            long finalSeed = long.Parse(subStr);
            return finalSeed;
        }
        //step 3
        public static Int64 generate11DigitNumber1()
        {
            AgriClass ctemp = new AgriClass();
            long timeSeed = ctemp.nanoTime();
            Random random = new Random();
            double rn = random.NextDouble();
            double randSeed = rn * 1000;
            Int64 midSeed = (Int64)(timeSeed * randSeed);
            string s = midSeed + "";
            string subStr = s.Substring(0, 11);
            Int64 finalSeed = Int64.Parse(subStr);
            return finalSeed;
        }
        

        
        //step 2
        public static string getFarmLandUniqueIdWithChecksum()
        {
            Int64 id = generate11DigitNumber1();
            string verhoff = generateVerhoeff(id.ToString());
            string finalVerhoff = id + verhoff;
            return finalVerhoff;
        }

        

        public static bool validateAadhaarNumber(String UID)
        {

            int c = 0;
            int[] myArray = StringToReversedIntArray(UID);

            for (int i = 0; i <= myArray.Length - 1; i++)
            {
                // c = d[c, p[(i % 8), myArray[i]]];
                //c = d[c, p[(i % 8)][myArray[i].intValue()]];

                c = d[c, p[(i % 8), myArray[i]]];

            }

            return c == 0;

        }
        /// <summary>
        /// Converts a string to a reversed integer array.
        /// </summary>
        /// <param name="num"></param>
        /// <returns>Reversed integer array</returns>
        public static int[] StringToReversedIntArray(String num)
        {
            int[] myArray = new int[num.Length];

            for (int i = 0; i < num.Length; i++)
            {
                myArray[i] = int.Parse(num.Substring(i, i + 1));
            }
            List<int> integerList = new List<int>(myArray);
            integerList.Reverse();

            myArray = integerList.ToArray();

            return myArray;

        }

        public static int[] stringToReversedIntArray(string num)
        {

            int[] myArray = new int[num.Length];

            for (int i = 0; i < num.Length; i++)
            {
                myArray[i] = int.Parse(num.Substring(i, 1));
            }

            myArray = reverse(myArray);

            return myArray;

        }

        /*
		 * Reverses an int array
		 */
        //Step 6
        public static int[] reverse(int[] myArray)
        {
            int[] reversed = new int[myArray.Length];

            for (int i = 0; i < myArray.Length; i++)
            {
                reversed[i] = myArray[myArray.Length - (i + 1)];
            }

            return reversed;
        }
    }
}