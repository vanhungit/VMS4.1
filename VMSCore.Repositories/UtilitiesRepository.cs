using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using VMSCore.Constant;

namespace VMSCore.Repositories
{
    public class UtilitiesRepository
    {
        //Convert yyyyMMdd to DateTime
        public DateTime? ConvertDateTime(string datetime_YYYYMMDD)
        {
            DateTime? datetime = null;
            if (datetime_YYYYMMDD.ToString() != "00000000" && datetime_YYYYMMDD.Length == 8)
            {
                int year = Convert.ToInt32(datetime_YYYYMMDD.Substring(0, 4));
                int month = Convert.ToInt32(datetime_YYYYMMDD.Substring(4, 2));
                int day = Convert.ToInt32(datetime_YYYYMMDD.Substring(6, 2));

                datetime = new DateTime(year, month, day);
            }
            return datetime;
        }

        // Tiến: Đổi tên cho dễ xài đọc vô hiểu luôn
        public DateTime? ConvertStringyyyyMMddToDateTime(string datetime_YYYYMMDD)
        {
            return ConvertDateTime(datetime_YYYYMMDD);
        }

        //Convert DateTime to dd/MM/yyyy
        public string ConvertStrDateTime(string datetime_YYYYMMDD)
        {
            return string.Format("{0:dd/MM/yyyy}", ConvertDateTime(datetime_YYYYMMDD));
        }

        // Tiến: Đổi tên cho dễ xài đọc vô hiểu luôn
        public string ConvertDateTimeToStringddMMyyyy(string datetime_YYYYMMDD)
        {
            return ConvertStrDateTime(datetime_YYYYMMDD);
        }


        public static void PushNotification(string[] deviceList, string header = "Thông báo", string content = "", object data = null)
        {
            var request = WebRequest.Create(ConstPushNotification.PushNotificationUrl) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + ConstPushNotification.RESTAPIKey);

            var serializer = new JavaScriptSerializer();
            var obj = new
            {
                app_id = ConstPushNotification.AppId,
                // OneSignal uses English as the default language so the field must be filled. 
                // However if you only want to send your message in one language you can place it under "en"
                headings = new { en = header },
                contents = new { en = content },
                data = data,
                include_player_ids = deviceList
            };
            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;
            string message = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                message = ex.Message;
            }
        }

        public static void PushNotification_WebPush(string content = "", string url = "")
        {
            var request = WebRequest.Create(ConstPushNotification.PushNotificationUrl) as HttpWebRequest;

            request.KeepAlive = true;
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";

            request.Headers.Add("authorization", "Basic " + ConstPushNotification.RESTAPIKey);

            var serializer = new JavaScriptSerializer();
            var obj = new
            {
                app_id = ConstPushNotification.AppId,
                // OneSignal uses English as the default language so the field must be filled. 
                // However if you only want to send your message in one language you can place it under "en"
                headings = new { en = "Thông báo" },
                //nội dung thông báo
                contents = new { en = content },
                //các đối tượng nhận thông báo
                included_segments = new string[] { "All" },
                //đường dẫn khi click vào notif
                web_url = url,
                //chỉ áp dụng trên chrome web
                isChromeWeb = true,
                //chỉ hiển thị trong vòng 5s (đối với chrome win10 luôn tắt sau 5s)
                //persistNotification = false
            };

            var param = serializer.Serialize(obj);
            byte[] byteArray = Encoding.UTF8.GetBytes(param);

            string responseContent = null;
            string message = null;
            string mess2 = null;

            try
            {
                using (var writer = request.GetRequestStream())
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }

                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseContent = reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                message = ex.Message;
                //lỗi do server trả về
                mess2 = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            }
        }
    }
}
