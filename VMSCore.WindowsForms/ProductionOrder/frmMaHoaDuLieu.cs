using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using MicrosoftHelper;

using SalesManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.WindowsForms
{
    public partial class frmMaHoaDuLieu : Form
    {
        DataTable dtable = new DataTable();
        string configFile = @"XMLTimer.xml";
        string Pathname = "";
        Staff objuser = new Staff();
        private readonly StaffRepository _staffRepository = new StaffRepository();
        public frmMaHoaDuLieu(string Lenh)
        {
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN"); //hiển thị ngôn ngữ việt nam
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en"); //hiển thị ngôn ngữ việt nam
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("de"); //hiển thị ngôn ngữ việt nam

            InitializeComponent();
            Pathname = XMLParser(configFile, "Table/LinkPath");
            dtable = new DataTable();
            gridView1.Invalidate();
            gridView1.IndicatorWidth = 40;
            dtable.Columns.Add("ID", typeof(long));
            dtable.Columns.Add("ProductOrder", typeof(string));
            dtable.Columns.Add("Code1", typeof(string));
            dtable.Columns.Add("Code2", typeof(string));
            dtable.Columns.Add("Sorted", typeof(long));
            dtable.Columns.Add("Active", typeof(int));
            gridControl1.DataSource = dtable;
            ReadXml_User();
            this.Text = "Encode data";
            lctextLenh.Text = "Lệnh Sản Xuất";
            lctextCodeTao.Text = "Số lượng cần tạo";
            lctextCodeDatao.Text = "Số lượng đã tạo";
            btnGenCode.Text = "Gen Code";
            btnCodeNap.Text = "Tạo Code Nap";
            btnImport.Text = "Import Code";
            gridView1.Columns["Sorted"].Caption = "Thứ tự";
            gridView1.Columns["ProductOrder"].Caption = "Lệnh sản xuất";
            gridView1.Columns["Code1"].Caption = "Code Gen";
            gridView1.Columns["Code2"].Caption = "Code mã hóa";
            gridView1.Columns["Active"].Caption = "Trạng Thái";
            txtLenh.Text = Lenh;
        }
        
        public void ReadXml_User()
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream("account.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("account");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                //xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                //if (xmlnode[i].ChildNodes.Item(2).InnerText.Trim() == "True")
                {
                    objuser = _staffRepository.GetStaffByUserName(xmlnode[i].ChildNodes.Item(0).InnerText.Trim());
                }
            }
            fs.Close();
        }
        public string XMLParser(string configFile, string Tagname)
        {
            string Trave = "";
            XmlDocument xml = new XmlDocument();
            xml.Load(configFile);
            //---XPath expression 1---
            XmlNode node = xml.SelectSingleNode(Tagname);
            Trave = (node.InnerText);
            return Trave;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (calcSoLuong.Text != "")
            {
                long Bien = (long)calcSoLuong.Value;
                long Low = 0;
                long maxrow = 0;
                //long maxrow = new CodeANSIEntity().GetMaxNumber();
                //long Low = (long)calcCodeDatao.Value;
                for (long i = Low; i < Bien + Low; i++)
                {
                    //DataRow row = dtable.NewRow();
                    //row[0] = maxrow + i + 1;
                    //row[1] = txtLenh.Text;
                    //row[2] = txtLenh.Text + String.Format("{0:0000}", i + 1);
                    //row[3] = ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1)).Substring(ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1)).Length - 12);
                    ////row[3] = ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1));
                    //row[4] = i + 1;
                    //row[5] = 0;
                    //dtable.Rows.Add(row);
                    string MaHoa = Guid.NewGuid() + "";
                    DataRow row = dtable.NewRow();
                    row[0] = maxrow + i + 1;
                    row[1] = txtLenh.Text;
                    row[2] = MaHoa.ToUpper();
                    row[3] = MaHoa.ToUpper() + "";
                    //row[3] = ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1));
                    row[4] = i + 1;
                    row[5] = 0;
                    dtable.Rows.Add(row);
                }
                //for (long i = Low; i < Bien + Low; i++)
                //{
                //    string MaHoa = Guid.NewGuid() + "";
                //    DataRow row = dtable.NewRow();
                //    row[0] = maxrow + i + 1;
                //    row[1] = txtLenh.Text;
                //    row[2] = txtLenh.Text + "|" + MaHoa.ToUpper();
                //    row[3] = MaHoa.ToUpper() + "";
                //    //row[3] = ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1));
                //    row[4] = i + 1;
                //    row[5] = 0;
                //    dtable.Rows.Add(row);
                //}
            }
        }
        public string ThemBangGia(DataTable dtable)
        {
            string Trave = "0";
            try
            {


                string consString = DataProvider.ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("Table_Insert_Code"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tableBangGia", dtable);
                       
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Trave = "1";
            }
            catch (Exception ex)
            {
                Trave = ex.ToString();
            }
            return Trave;
        }
        public string ThemCodeNap(DataTable dtable, string CreateBy, string ModifiBy, DateTime CreateDate, DateTime ModifiDate)
        {
            string Trave = "0";
            try
            {


                string consString = DataProvider.ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlCommand cmd = new SqlCommand("Table_Insert_CodeExtend"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tableBangGia", dtable);
                        cmd.Parameters.AddWithValue("@CreatedDate", CreateDate);
                        cmd.Parameters.AddWithValue("@CreatedBy", CreateBy);
                        cmd.Parameters.AddWithValue("@ModifiedDate", ModifiDate);
                        cmd.Parameters.AddWithValue("@ModifiedBy", ModifiBy);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                Trave = "1";
            }
            catch (Exception ex)
            {
                Trave = ex.ToString();
            }
            return Trave;
        }
        public string ASCIITOHex(string ascii)
        {

            StringBuilder sb = new StringBuilder();

            byte[] inputBytes = Encoding.UTF8.GetBytes(ascii);

            foreach (byte b in inputBytes)
            {

                sb.Append(string.Format("{0:x2}", b));

            }

            return sb.ToString();

        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator)
            {
                if (e.RowHandle >= 0)
                {
                    e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                }
            }
        }
        public static string GetHash(string plainText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            // Compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(plainText));
            // Get hash result after compute it
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static string EncryptString(string Message, string Passphrase)
        {

            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Buoc 1: Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Cai dat bo ma hoa

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = CipherMode.ECB;

            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert chuoi (Message) thanh dang byte[]

            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Ma hoa chuoi

            try
            {

                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();

                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);

            }

            finally
            {

                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan

                TDESAlgorithm.Clear();

                HashProvider.Clear();

            }

            // Step 6. Tra ve chuoi da ma hoa bang thuat toan Base64

            return Convert.ToBase64String(Results);

        }
        public static string DecryptString(string Message, string Passphrase)
        {

            byte[] Results;

            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. Bam chuoi su dung MD5

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Tao doi tuong TripleDESCryptoServiceProvider moi

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Cai dat bo giai ma

            TDESAlgorithm.Key = TDESKey;

            TDESAlgorithm.Mode = CipherMode.ECB;

            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert chuoi (Message) thanh dang byte[]

            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Bat dau giai ma chuoi

            try
            {

                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();

                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);

            }
            catch
            {
                return "112";
            }
            finally
            {

                // Xoa moi thong tin ve Triple DES va HashProvider de dam bao an toan

                TDESAlgorithm.Clear();

                HashProvider.Clear();

            }

            // Step 6. Tra ve ket qua bang dinh dang UTF8

            return UTF8.GetString(Results);

        }
        /// <summary>
        /// Attempt to empty the folder. Return false if it fails (locked files...).
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns>true on success</returns>
        public static bool EmptyFolder(string pathName)
        {
            bool errors = false;
            DirectoryInfo dir = new DirectoryInfo(pathName);

            foreach (FileInfo fi in dir.EnumerateFiles())
            {
                try
                {
                    fi.IsReadOnly = false;
                    fi.Delete();

                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (fi.Exists)
                    {
                        System.Threading.Thread.Sleep(10);
                        fi.Refresh();
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e.Message);
                    errors = true;
                }
            }

            foreach (DirectoryInfo di in dir.EnumerateDirectories())
            {
                try
                {
                    EmptyFolder(di.FullName);
                    di.Delete();

                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (di.Exists)
                    {
                        System.Threading.Thread.Sleep(10);
                        di.Refresh();
                    }
                }
                catch (IOException e)
                {
                    Debug.WriteLine(e.Message);
                    errors = true;
                }
            }

            return !errors;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //txtLenh.Text = EncryptString("123456789AAAA02", "1");
            if (MessageBox.Show("Bạn muốn tạo dữ liệu ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                //EmptyFolder(Pathname);
                ProductionOrderDetailCode jobdefine = new ProductionOrderDetailCode();
                int i = 1;
                string TraVe = "0";
                WaitDialog.CreateWaitDialog("Đang tải dữ liệu ...", "Xuất Báo Cáo");
                //ThemBangGia(dtable);
                foreach (DataRow datarow in dtable.Rows)
                {
                    try
                    {
                        {
                            jobdefine = new ProductionOrderDetailCode();
                            jobdefine.Id = Guid.NewGuid();
                            jobdefine.Code = jobdefine.Id.ToString();
                            jobdefine.ProductionOrderCode = new ProductionOrderRepository().GetByCode(txtLenh.Text).Code;
                            jobdefine.LevelPackage = (int)calcCap.Value;
                            jobdefine.Code1 = datarow["Code1"].ToString().Trim();
                            jobdefine.LineCode = "";
                            jobdefine.GroupDeviceCode = "";
                            jobdefine.DeviceCode = "";
                            jobdefine.TypeDeviceCode = "";
                            jobdefine.DeviceHandeCode = "";
                            jobdefine.DeviceConfirmCode = "";
                            jobdefine.Code2 = "";
                            jobdefine.Sorted = new ProductionOrderDetailCodeRepository().GetMaxProductionOrderDetailCode() + 1;
                            jobdefine.Qty = 1;
                            jobdefine.PrintCount = 0;
                            jobdefine.CreatorId = objuser.Username;
                            jobdefine.CreationTime = DateTime.Now;
                            jobdefine.LastModifierId = objuser.Username;
                            jobdefine.LastModificationTime = DateTime.Now;
                            jobdefine.Active = true;
                            ProductionOrderDetailCode objEnum = new ProductionOrderDetailCodeRepository().Add(jobdefine);
                            if (objEnum.Code == "")
                            {
                                if (MessageBox.Show("Bị lỗi " + jobdefine.Code + ", Bạn muốn tiếp tục ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                                {
                                    break;
                                }
                            }
                            i++;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                
                WaitDialog.CloseWaitDialog();
            }
            //GhiFile();

        }
        public void GhiFile()
        {
            String filepath = "";// đường dẫn của file muốn tạo
            long Bien = 0;
            long CodeNap = 0;
            if(((long)calcSoLuong.Value) % 1000 > 0)
            {
                Bien = (long)calcSoLuong.Value / 1000 + 1;
            }
            else
            {
                Bien = (long)calcSoLuong.Value / 1000;
            }
            if (((long)calcCodeDatao.Value) % 1000 > 0)
            {
                CodeNap = (long)calcCodeDatao.Value / 1000 + 1;
            }
            else
            {
                CodeNap = (long)calcCodeDatao.Value / 1000;
            }
            for (int i = 1; i <= Bien;i++)
            {
                filepath = Pathname + @"\" + String.Format("{0:0000}", i + CodeNap) + ".ini";
                //filepath = @"D:\Code Nap\" + String.Format("{0:0000}", i + CodeNap) + ".ini";

                FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
                sWriter.WriteLine("["+1+"]");
                for(int j = (i-1)*1000; j< i*1000; j++)
                {
                    if (j < calcSoLuong.Value)
                    {
                        sWriter.WriteLine((j + (calcCodeDatao.Value) + 1) + "=" + dtable.Rows[j]["Code2"].ToString());
                    }
                    else
                    {
                        break;
                    }
                }
                sWriter.Flush();
                fs.Close();
            }
            // Ghi và đóng file
           
        }

        private void frmMaHoaDuLieu_Load(object sender, EventArgs e)
        {
            //txtLenh.Text = new DOCUMENT_CHECKEntity().DOCUMENTMax().ID;
            //calcCodeDatao.Value = new CodeANSIEntity().GetMaxNumberByOrder(txtLenh.Text);
        }
        public void LoadExcel(string FileName)
        {
            //String ConString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + txtPathName.Text.Trim() + ";" + "Extended Properties=Excel 8.0;";
            //string ConString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=Excel 12.0;"; //Create Connection to Excel work book
            //OleDbConnection ObjConnection = new OleDbConnection(ConString);
            //ObjConnection.Open();
            //OleDbCommand objCommand = new OleDbCommand("SELECT * FROM [Sheet1$]", ObjConnection);
            //OleDbDataAdapter MyAdapt = new OleDbDataAdapter();
            //MyAdapt.SelectCommand = objCommand;
            //DataSet ds = new DataSet();
            //MyAdapt.Fill(ds, "[Sheet1$]");
            //ObjConnection.Close();
            //DataTable dt_Table = ds.Tables["[Sheet1$]"];
            //ObjConnection.Close();
            //int i = 0;
            //foreach (DataRow datarow in dt_Table.Rows)
            //{
            //    long Bien = (long)dt_Table.Rows.Count;
            //    long Low = 0;
            //    long maxrow = new CodeANSIEntity().GetMaxNumber();
            //    //long Low = (long)calcCodeDatao.Value;
            //    //for (long i = Low; i < 1000; i++)
            //    if (!new CodeANSIEntity().CheckCodeANSI(datarow["Code Encode"].ToString().Trim()))
            //    {
            //        DataRow row = dtable.NewRow();
            //        row[0] = maxrow + i + 1;
            //        row[1] = txtLenh.Text;
            //        row[2] = datarow["Code Gen"].ToString().Trim();
            //        row[3] = datarow["Code Encode"].ToString().Trim(); ;
            //        //row[3] = ASCIITOHex(txtLenh.Text + String.Format("{0:0000}", i + 1));
            //        row[4] = i + 1;
            //        row[5] = 0;
            //        dtable.Rows.Add(row);
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("Code đã tồn tại", "Thông Báo");
            //        break;
            //    }
            //    i++;

            //}
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            string FileName = openFileDialog.FileName;
            if (FileName != "")
            {
                //MessageBox.Show("Tiếp tục xử lý !", "Thông Báo");
                try
                {
                    WaitDialog.CreateWaitDialog("Importing data code ...", "Import code from Third party");
                    LoadExcel(FileName);
                    calcSoLuong.Value = dtable.Rows.Count;
                    WaitDialog.CloseWaitDialog();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lại file !", "Thông Báo");
            }
        }
    }
}
