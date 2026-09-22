using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.IO;

using System.Reflection;
using System.Security.Claims;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using System.Net;
using System.IdentityModel.Tokens.Jwt;

namespace ROFR.helper
{
    public class Profile
    {
        public class Security
        {

            public static string HashSHA1(string value)
            {
                var sha1 = System.Security.Cryptography.SHA1.Create();
                var inputBytes = Encoding.ASCII.GetBytes(value);
                var hash = sha1.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (var i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }

            //public dynamic check_s_captch(captch root)
            //{

            //    captchgens retrn = new captchgens();
            //    var ids = "";
            //    ids = DateTime.Now.Ticks.ToString();
            //    var serila = serNumber();

            //    Bitmap objBitmap = new Bitmap(180, 100);
            //    Graphics objGraphics = Graphics.FromImage(objBitmap);
            //    objGraphics.Clear(Color.White);
            //    Random objRandom = new Random();
            //    objGraphics.DrawLine(Pens.White, objRandom.Next(0, 50), objRandom.Next(10, 30), objRandom.Next(0, 200), objRandom.Next(0, 50));
            //    objGraphics.DrawRectangle(Pens.White, objRandom.Next(0, 20), objRandom.Next(0, 20), objRandom.Next(50, 80), objRandom.Next(0, 20));
            //    objGraphics.DrawLine(Pens.White, objRandom.Next(0, 20), objRandom.Next(10, 50), objRandom.Next(100, 200), objRandom.Next(0, 80));
            //    Brush objBrush =
            //        default(Brush);
            //    HatchStyle[] aHatchStyles = new HatchStyle[]
            //    {
            //   HatchStyle.LargeGrid, HatchStyle.LightDownwardDiagonal, HatchStyle.LightHorizontal
            //    };
            //    RectangleF oRectangleF = new RectangleF(0, 0, 300, 300);
            //    objBrush = new HatchBrush(aHatchStyles[objRandom.Next(aHatchStyles.Length - 3)], Color.FromArgb((objRandom.Next(100, 255)), (objRandom.Next(100, 255)), (objRandom.Next(100, 255))), Color.White);
            //    objGraphics.FillRectangle(objBrush, oRectangleF);
            //    string captchaText = string.Format("{0:X}", objRandom.Next(1000000, 9999999));
            //    Font objFont = new Font("Courier New", 28, FontStyle.Bold);
            //    objGraphics.DrawString(captchaText, objFont, Brushes.Black, 15, 30);
            //    objGraphics.Flush();
            //    objGraphics.Dispose();
            //    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".Gif";
            //    objBitmap.Save(Path.Combine(HttpContext.Current.Server.MapPath("capth"), ids + serila.ToString() + fileName), ImageFormat.Gif);


            //    root.Capchid = captchaText;
            //    root.id = ids.ToString().Trim();

            //    //bool captchgen = true;
            //    bool captchgen = _SandInsert.APMDC_SP_IN_CAPTCHA(root);
            //    if (captchgen == true)
            //    {

            //        byte[] imageBytes = System.IO.File.ReadAllBytes(Path.Combine(HttpContext.Current.Server.MapPath("capth"), ids + serila + fileName));
            //        string base64String = Convert.ToBase64String(imageBytes);
            //        retrn.idval = Encrypt(ids, "");

            //        retrn.code = "100";
            //        retrn.imgurl = base64String;

            //        DirectoryInfo diInfo = new DirectoryInfo(Path.Combine(HttpContext.Current.Server.MapPath("~/capth")));
            //        FileInfo[] files = diInfo.GetFiles();
            //        for (int i = 0; i < files.Length; i++)
            //        {
            //            string filePath = Path.Combine(HttpContext.Current.Server.MapPath("capth/" + files[i].ToString()));
            //            if (File.Exists(filePath))
            //            {
            //                File.Delete(filePath);
            //            }
            //        }
            //        return retrn;

            //    }
            //    else
            //    {
            //        retrn.idval = "";
            //        retrn.code = "99";
            //        retrn.imgurl = "Error.htm";
            //        return retrn;
            //    }
            //}
            public int serNumber()
            {
                Random r = new Random();
                int random_num = r.Next(0, 99999);
                return random_num;
            }

            public static string Base64_Encode(string plainText)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            public static string Base64_Decode(string base64EncodedData)
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            public  string createToken(string user)
            {

                DateTime issuedAt = DateTime.UtcNow;
                DateTime expires = DateTime.UtcNow.AddMinutes(15);
                var tokenHandler = new JwtSecurityTokenHandler();
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, user)
            });

                const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed7";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
                var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
                var token =
                    (JwtSecurityToken)
                        tokenHandler.CreateJwtSecurityToken(issuer: "Bhagya", audience: "Giribhumi",
                            subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);


                var sureshgoud = token;
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }

            public string openToken(string user)
            {

                DateTime issuedAt = DateTime.UtcNow;
                DateTime expires = DateTime.UtcNow.AddMinutes(180);
                var tokenHandler = new JwtSecurityTokenHandler();
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, DateTime.Now.Ticks.ToString())
            });

                const string sec = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed7";
                var now = DateTime.UtcNow;
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(sec));
                var signingCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature);
                var token =
                    (JwtSecurityToken)
                        tokenHandler.CreateJwtSecurityToken(issuer: "Bhagya", audience: "Giribhumi",
                            subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);


                var sureshgoud = token;
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }

            public static string Encrypt(string strMessage, string sTokenKey)
            {
                return Convert.ToBase64String(Utilities.Encrypt(Encoding.UTF8.GetBytes(strMessage), Utilities.suresh(sTokenKey)));
            }

            public static string Decrypt(string strEncMsg, string sTokenKey)
            {
                return Encoding.UTF8.GetString(Utilities.Decrypt(Convert.FromBase64String(strEncMsg), Utilities.suresh(sTokenKey)));
            }
        }
        public class Utilities
        {
            public static RijndaelManaged suresh(string secretKey)
            {
                byte[] numArray = new byte[16];
                byte[] bytes = Encoding.UTF8.GetBytes(secretKey);
                Array.Copy((Array)bytes, (Array)numArray, Math.Min(numArray.Length, bytes.Length));
                RijndaelManaged rijndaelManaged = new RijndaelManaged();
                rijndaelManaged.Mode = CipherMode.CBC;
                rijndaelManaged.Padding = PaddingMode.PKCS7;
                rijndaelManaged.KeySize = 128;
                rijndaelManaged.BlockSize = 128;
                rijndaelManaged.Key = numArray;
                rijndaelManaged.IV = numArray;
                return rijndaelManaged;
            }

            public static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
            {
                return rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            public static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
            {
                return rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            }

            public static string Encrypt(string strMessage, string sTokenKey)
            {
                return Convert.ToBase64String(Utilities.Encrypt(Encoding.UTF8.GetBytes(strMessage), Utilities.suresh(sTokenKey)));
            }

            public static string Decrypt(string strEncMsg, string sTokenKey)
            {
                return Encoding.UTF8.GetString(Utilities.Decrypt(Convert.FromBase64String(strEncMsg), Utilities.suresh(sTokenKey)));
            }

            public static T GetFromQueryString<T>(string QString) where T : new()
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                foreach (string str in QString.Split("&".ToCharArray()))
                {
                    string[] strArray = str.Split("=".ToCharArray());
                    nameValueCollection.Add(strArray[0], HttpContext.Current.Server.UrlDecode(strArray[1]));
                }
                T obj1 = new T();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    string ValueToConvert = nameValueCollection[property.Name];
                    object obj2 = Utilities.Parse(property.PropertyType, ValueToConvert);
                    if (obj2 != null)
                        property.SetValue((object)obj1, obj2, (object[])null);
                }
                return obj1;
            }

            public static object Parse(Type dataType, string ValueToConvert)
            {
                return TypeDescriptor.GetConverter(dataType).ConvertFromString((ITypeDescriptorContext)null, CultureInfo.InvariantCulture, ValueToConvert);
            }



            public static string SecurityKey()
            {
                return "Giribhumi@123";
            }
        }
    }
}