using Newtonsoft.Json;
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


namespace VMSCore.Infrastructure.Base.Repositories
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
        
        public StatusResponse HamDongBoTable(string table, string Link, string jsonSend, DataToken objToken, Staff objuser)
        {
            StatusResponse objrp = new StatusResponse();
            if (table != "")
            {
                string TimeStart = "", TimeEnd = "";
                TimeStart = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                //DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = CallAPIPost(Link, objToken.access_token, jsonSend);
                TimeEnd = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                objrp = JSONParserResponse(ds);
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
        public StatusResponse HamDongBoTableDelete(string table, string Link, string jsonSend, DataToken objToken, Staff objuser)
        {
            StatusResponse objrp = new StatusResponse();
            if (table != "")
            {
                string TimeStart = "", TimeEnd = "";
                TimeStart = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                //string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2W3E*");
                //DataToken objToken = objSync.JSONParserMapToken(Data);
                string ds = CallAPIPost(Link, objToken.access_token, jsonSend);
                TimeEnd = String.Format("{0:HH:mm:ss.000}", DateTime.Now);
                objrp = JSONParserResponse(ds);
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
        public void DongBoAll(string TableName, string jsonsend, Staff objuser)
        {
            SyncDataFunction objSync = new SyncDataFunction();
            string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
            DataToken objToken = objSync.JSONParserMapToken(Data);
            switch (TableName)
            {
                case "MACHINE_SYNC":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/device-status-group-desktop", jsonsend, objToken, objuser);
                    break;
                case "Company":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Factory":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "WorkShop":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Stage":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;

                case "DeviceGroup":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "TypeDevice":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Device":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Device_PROTOCOL":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ConnectConfig":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "StatusConfig":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ErrorConfig":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "WarningConfig":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                ////////////////////
                case "Protocol":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProtocolParam":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                ////////////////
                case "ProductionOrder":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetail":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailCode":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderRawDetail":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailMAP":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailCheck":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                /////////////////
                case "Line":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "LineDevice":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                //////
                case "ProductGroup":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductType":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Product":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "UNIT":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "UNITCONVERT":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "MaterialProduct":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                /////
                case "Shift":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Staff":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Skills":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "StaffSkill":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ShiftStaff":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Department":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "DepartmentStaff":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                ////
                case "Role":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "RoleUser":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "Button":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "ObjectEntity":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
                case "RoleObjectButtonMapping":
                    HamDongBoTable(TableName,  "https://api-vms41.vmspms.vn/api/sync?tableName="+TableName, jsonsend, objToken, objuser);
                    break;
            }
        }
        public void DongBoAllDelete(string TableName, string jsonsend, Staff objuser)
        {
            SyncDataFunction objSync = new SyncDataFunction();
            string Data = objSync.CallAPIPOSTToken("https://api-vms41.vmspms.vn/connect/token", "desktopvmspms", "1q2w3E*");
            DataToken objToken = objSync.JSONParserMapToken(Data);
            switch (TableName)
            {
                case "MACHINE_SYNC":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/device-status-group-desktop", jsonsend, objToken, objuser);
                    break;
                case "Company":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Factory":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "WorkShop":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Stage":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;

                case "DeviceGroup":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "TypeDevice":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Device":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Device_PROTOCOL":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ConnectConfig":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "StatusConfig":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ErrorConfig":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "WarningConfig":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                ////////////////////
                case "Protocol":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProtocolParam":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                ////////////////
                case "ProductionOrder":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetail":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailCode":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderRawDetail":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailMAP":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductionOrderDetailCheck":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                /////////////////
                case "Line":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "LineDevice":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                //////
                case "ProductGroup":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ProductType":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Product":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "UNIT":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "UNITCONVERT":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "MaterialProduct":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                /////
                case "Shift":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Staff":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Skills":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "StaffSkill":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ShiftStaff":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Department":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "DepartmentStaff":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                ////
                case "Role":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "RoleUser":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "Button":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "ObjectEntity":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
                case "RoleObjectButtonMapping":
                    HamDongBoTable(TableName, "https://api-vms41.vmspms.vn/api/sync/delete?tableName=" + TableName, jsonsend, objToken, objuser);
                    break;
            }
        }
        public StatusResponse JSONParserResponse(string JSONdata)
        {
            DataContractJsonSerializer jsonSer = new DataContractJsonSerializer(typeof(StatusResponse));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JSONdata));
            StatusResponse objStudent = (StatusResponse)jsonSer.ReadObject(stream);
            return objStudent;
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
       
    }
}
