using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace VMSCore.Extensions
{
    public class RepositoryLibrary
    {
        public static void ResizeStream(int maxWidth, int maxHeight, Stream filePath, string outputPath)
        {
            var image = System.Drawing.Image.FromStream(filePath);

            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);


            var thumbnailBitmap = new Bitmap(newWidth, newHeight);

            var thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
            thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbnailGraph.DrawImage(image, imageRectangle);

            thumbnailBitmap.Save(outputPath, image.RawFormat);
            thumbnailGraph.Dispose();
            thumbnailBitmap.Dispose();
            image.Dispose();
        }
        public string Hash(string text)
        {
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
            StringBuilder hashSb = new StringBuilder();
            foreach (byte b in hash)
            {
                hashSb.Append(b.ToString("X2"));
            }
            return hashSb.ToString();
        }
        public string GetCodeMD5(string StringEncode)
        {
            //Tạo MD5 
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(StringEncode);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        //Get MD5
        public static string GetMd5Sum(string str)
        {
            // First we need to convert the string into bytes, which
            // means using a text encoder.

            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();
            // Create a buffer large enough to hold the string

            byte[] unicodeText = new byte[str.Length * 2];

            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it

            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] result = md5.ComputeHash(unicodeText);

            // Build the final string by converting each byte

            // into hex and appending it to a StringBuilder

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {

                sb.Append(result[i].ToString("X2"));

            }
            // And return it
            return sb.ToString();
        }

        public static string RandomString(int size)
        {

            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToLower();
        }

        public void SendEmailTo(string EmailTo, string Subject, string Body, string SmtpMail = null)
        {
            string Username = WebConfigurationManager.AppSettings["SmtpUser"].ToString();
            string Password = WebConfigurationManager.AppSettings["SmtpPassword"].ToString();
            string MailFrom = string.IsNullOrEmpty(SmtpMail) ? WebConfigurationManager.AppSettings["SmtpMailFrom"].ToString() : SmtpMail;
            string MailServer = WebConfigurationManager.AppSettings["SmtpServer"].ToString();
            //string SmtpMailFrom = WebConfigurationManager.AppSettings["SmtpMailFrom"].ToString();
            bool EnableSsl = bool.Parse(WebConfigurationManager.AppSettings["EnableSsl"].ToString());
            int Port = Int32.Parse(WebConfigurationManager.AppSettings["SmtpPort"].ToString());

            MailMessage mail = new MailMessage();
            mail.To.Add(EmailTo);
            mail.From = new MailAddress(MailFrom);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = MailServer;
            smtp.Port = Port;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            (Username, Password);// Enter seders User name and password
            smtp.EnableSsl = EnableSsl;
            smtp.Send(mail);
        }

        public static DateTime? VNStringToDateTime(string inputDate)
        {
            DateTime? retDate = null;
            try
            {
                string[] dateArr;
                if (inputDate != null)
                {
                    //9/1/2018
                    if (inputDate.Length == 8)
                    {
                        dateArr = inputDate.Split('/');
                        if (dateArr.Length == 3 && dateArr[0].Length == 1 && dateArr[1].Length == 1 && dateArr[2].Length == 4)
                        {
                            int day, month, year;
                            int.TryParse(dateArr[0], out day);
                            int.TryParse(dateArr[1], out month);
                            int.TryParse(dateArr[2], out year);
                            retDate = new DateTime(year, month, day);
                        }
                    }

                    //9/10/2018
                    //10/9/2018
                    else if (inputDate.Length == 9)
                    {
                        dateArr = inputDate.Split('/');
                        if (dateArr.Length == 3 && dateArr[0].Length == 1 && dateArr[1].Length == 2 && dateArr[2].Length == 4)
                        {
                            int day, month, year;
                            int.TryParse(dateArr[0], out day);
                            int.TryParse(dateArr[1], out month);
                            int.TryParse(dateArr[2], out year);
                            retDate = new DateTime(year, month, day);
                        }
                        else if (dateArr.Length == 3 && dateArr[0].Length == 2 && dateArr[1].Length == 1 && dateArr[2].Length == 4)
                        {
                            int day, month, year;
                            int.TryParse(dateArr[0], out day);
                            int.TryParse(dateArr[1], out month);
                            int.TryParse(dateArr[2], out year);
                            retDate = new DateTime(year, month, day);
                        }
                    }
                    //20/06/2018
                    else if (inputDate.Length == 10)
                    {
                        dateArr = inputDate.Split('/');
                        if (dateArr.Length == 3 && dateArr[0].Length == 2 && dateArr[1].Length == 2 && dateArr[2].Length == 4)
                        {
                            int day, month, year;
                            int.TryParse(dateArr[0], out day);
                            int.TryParse(dateArr[1], out month);
                            int.TryParse(dateArr[2], out year);
                            retDate = new DateTime(year, month, day);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return retDate;
        }

        public static TimeSpan? VNStringToTimeSpan(string inputTime)
        {

            TimeSpan? retTime = null;
            //"10:30"
            try
            {
                string[] dateArr;
                if (inputTime != null && inputTime.Length == 5)
                {
                    dateArr = inputTime.Split(':');
                    if (dateArr.Length == 2 && dateArr[0].Length == 2 && dateArr[1].Length == 2)
                    {
                        int houses, minutes;
                        int.TryParse(dateArr[0], out houses);
                        int.TryParse(dateArr[1], out minutes);
                        retTime = new TimeSpan(houses, minutes, 0);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return retTime;
        }
    }
}
