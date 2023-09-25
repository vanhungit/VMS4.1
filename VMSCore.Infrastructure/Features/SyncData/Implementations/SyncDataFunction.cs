using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Infrastructure.Features.SyncData.Implementations
{
    public class SyncDataFunction
    {
        EntityDataContext db = new EntityDataContext();
        public DataToken JSONParserMapToken(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(DataToken));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            DataToken objStudent = (DataToken)jsonSer.ReadObject(stream);
            return objStudent;
        }
        public DataTable BOXDEFINE_MAP_GetByDate(DateTime Start, DateTime End)
        {
            var From = new SqlParameter("@FromDate", Start);
            var To = new SqlParameter("@ToDate", End);

            DataTable dtable = (DataTable)db.DataTable("EXEC ReportBoxData_Getlist_ByDate @FromDate, @ToDate", From, To);

            return dtable;
        }
        public DataTable sproc_GetListTableSync()
        {
            DataTable dtable = (DataTable)db.DataTable("EXEC sproc_GetListTableSync");

            return dtable;
        }
        public DataTable sproc_GetListOverView()
        {
            DataTable dtable = (DataTable)db.DataTable("EXEC sproc_GetListOverView");

            return dtable;
        }
        public DataTable sproc_GetListMachine()
        {
            DataTable dtable = (DataTable)db.DataTable("EXEC sproc_GetListMachine");

            return dtable;
        }
        public StatusResponse HamDongBoTable(string table, string Link, string jsonSend, DataToken objToken, Staff objuser)
        {
            StatusResponse objrp = new StatusResponse();
            if (table != "")
            {
                string TimeStart = "", TimeEnd = "";
                TimeStart = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                SyncDataFunction objSync = new SyncDataFunction();
                //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                //DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = objSync.CallAPIPost(Link, objToken.access_token, jsonSend);
                TimeEnd = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                objrp = objSync.JSONParserResponse(ds);
                MACHINE_SYNC_LOG objMachineLog = new MACHINE_SYNC_LOG();
                objMachineLog.Id = Guid.NewGuid();
                objMachineLog.Code = objMachineLog.Id.ToString();
                objMachineLog.Name = table;
                objMachineLog.MethodName = Link;
                objMachineLog.TypeGiaoDich = "POST";
                objMachineLog.TokenCode = objToken.access_token;
                objMachineLog.JsonSend = jsonSend;
                objMachineLog.JsonReceiv = ds;
                objMachineLog.Status = objrp.idStatus.ToString();
                objMachineLog.Sorted = new MACHINE_SYNC_LOGRepository().GetMaxMACHINE_SYNC_LOG() + 1;
                objMachineLog.Description = objrp.jsonData + "|" + TimeStart + "|" + TimeEnd;
                objMachineLog.UserName = objuser.Username;
                objMachineLog.CreatedBy = objuser.Username;
                objMachineLog.ModifiedBy = objuser.Username;
                objMachineLog.CreatedDate = DateTime.Now;
                objMachineLog.ModifiedDate = DateTime.Now;
                objMachineLog.Active = true;
                new MACHINE_SYNC_LOGRepository().Add(objMachineLog);
                
            }
            return objrp;
        }
        public DataTable GetCodeMap(int LevelCode, string Lenh)
        {
            var _LevelCode = new SqlParameter("@LevelCode", LevelCode);
            var _Lenh = new SqlParameter("@Lenh", Lenh);

            DataTable dtable = (DataTable)db.DataTable("EXEC GetCodeMap @LevelCode, @Lenh", _LevelCode, _Lenh);

            return dtable;
        }
        public StatusResponse JSONParserResponse(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(StatusResponse));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            StatusResponse objStudent = (StatusResponse)jsonSer.ReadObject(stream);
            return objStudent;
        }
        public string JSONToStringDataMachine(DataMachineModelView objStudent)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(DataMachineModelView));
            jsonSer.WriteObject(stream, objStudent);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
        public string JSONToStringDataMachineList(List<DataMachineModelView> objStudent)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(List<DataMachineModelView>));
            jsonSer.WriteObject(stream, objStudent);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
        public string JSONToStringProductOrder(ProductOrderView objStudent)
        {
            MemoryStream stream = new MemoryStream();
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(ProductOrderView));
            jsonSer.WriteObject(stream, objStudent);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            return sr.ReadToEnd();
        }
        public string CallAPIGet(string Link, string TokenData)
        {
            string Trave = "";
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            string MaHoa = "Bearer " + TokenData;
            httpWebRequest.Headers.Add("Authorization", MaHoa);
            //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            //{
            //    string json = "[{\"color\":\"WHITE\"," +
            //                    "\"duration\":5," +
            //                  "\"pattern\":\"FLASH_4_TIMES\"}]";

            //    streamWriter.Write(json);
            //}

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return Trave;
        }
        public string CallAPIPost(string Link, string TokenData, string JsonPost)
        {
            string Trave = "";
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            string MaHoa = "Bearer " + TokenData;
            httpWebRequest.Headers.Add("Authorization", MaHoa);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonPost;

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return Trave;
        }
        public string CallAPIGet(string Link, string TokenData, string JsonPost)
        {
            string Trave = "";
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";
            string MaHoa = "Bearer " + TokenData;
            httpWebRequest.Headers.Add("Authorization", MaHoa);
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = JsonPost;

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return Trave;
        }
        public string CallAPIPOSTToken(string Link, string UserName, string Pass)
        {
            string Trave = "";
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Link);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.Method = "POST";

            httpWebRequest.Headers.Add("Cookie", ".AspNetCore.Culture=c%3Den%7Cuic%3Den");

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string postData = "grant_type=password&scope=offline_access%20IndustrialSolution&client_id=IndustrialSolution_App&username=" + UserName + "&password=" + Pass;
                //byte[] postArray = Encoding.ASCII.GetBytes(postData);
                streamWriter.Write(postData);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Trave = result;
                }
            }
            else
            {
                Trave = httpResponse.StatusDescription;
            }
            return (Trave);
        }
        public ModelMapCode CodeCapGetAllModel(string QRCode)
        {
            ModelMapCode objMap = new ModelMapCode();
            objMap.StatusCreate = false;
            objMap.LevelCode = 0;
            objMap.StatusMapSon = false;
            objMap.StatusDAD = false;
            objMap.objGen = new ProductionOrderDetailCodeRepository().GetOneByCondition(x => x.Code1 == QRCode.Trim());
            if (objMap.objGen != null)
            {
                objMap.LevelCode = (int)objMap.objGen.LevelPackage;
                objMap.StatusCreate = true;
                objMap.listMap = new ProductionOrderDetailMAPRepository().GetByCodeMapSon(QRCode);
                ProductionOrderDetailMAP objCha = new ProductionOrderDetailMAPRepository().GetByCodeMapDad(QRCode);
                if(objMap.listMap.KeyCuon != null)
                {
                    objMap.StatusMapSon = true;
                }
                if (objCha.KeyBox != null)
                {
                    objMap.StatusDAD = true;
                }
            }
            return objMap;
        }
    }
}
