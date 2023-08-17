using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Extensions;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;
using VMSCore.Infrastructure.Features.SystemManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.Report
{
    public partial class fmrReport : Form
    {
        public fmrReport()
        {
            InitializeComponent();
        }
        private readonly DeviceRepository deviceRepository = new DeviceRepository();
        private readonly DeviceConnectHistoryRepository deviceConnectHistoryRepository = new DeviceConnectHistoryRepository();
        private void btnReport_Click(object sender, EventArgs e)
        {

            var dbUtil = new DatabaseUtil("VMSCoreDb");

            //Dictionary<string, object> parameters = new Dictionary<string, object>()
            //{
            //    { "@dateFrom", Convert.ToDateTime("2023-06-29") },
            //    { "@dateTo", Convert.ToDateTime("2023-07-04") },
            //    { "@companyId", "Company1" }
            //};


            // Cách 1 đơn giản (INT, DATETIME, NVACHAR)
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@dateFrom", DBNull.Value },
                { "@dateTo", DBNull.Value },
                { "@companyId", "Company1" },
                { "@count", 0 } // Initialize count with 0
            };

            var dataSet = dbUtil.GetDataSetFromStoredProcedure("sproc_reportHistoryDevice", parameters);


            // Cách 2 phức tạp hơn, có thể chọn INPUT OUTPUT khi gọi store procedure
            List<SqlParameter> parameters2 = new List<SqlParameter>
            {
                new SqlParameter
                {
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@dateFrom",
                    Value = DBNull.Value
                },
                new SqlParameter
                {
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@dateTo",
                    Value = Convert.ToDateTime("2023-07-04")
                },
                new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@companyId",
                    Value = "Company1"
                },
                new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output,
                    ParameterName = "@count" // trong store procedure cần thêm param @count INT OUTPUT
                }
            };

            var dataSet2 = dbUtil.GetDataSetFromStoredProcedure("sproc_reportHistoryDevice", parameters2);
            // Trong store procedure có SET @count, ở đây lấy giá trị ra
            //int count = (int)parameters2.Find(p => p.ParameterName == "@count").Value; 


            if (dataSet.Tables.Count > 0)
            {
                dataGridView1.DataSource = dataSet.Tables[0];
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        //var invoiceIdParam = new SqlParameter
        //{
        //    SqlDbType = SqlDbType.Int,
        //    Direction = ParameterDirection.Input,
        //    ParameterName = "@InvoiceID",
        //    Value = 123 // Example invoice ID
        //};

        //var totalCostParam = new SqlParameter
        //{
        //    SqlDbType = SqlDbType.Decimal,
        //    Direction = ParameterDirection.Output,
        //    ParameterName = "@TotalCost",
        //};

        //var itemCountParam = new SqlParameter
        //{
        //    SqlDbType = SqlDbType.Int,
        //    Direction = ParameterDirection.Output,
        //    ParameterName = "@ItemCount",
        //};

        //var parameters = new List<SqlParameter> { invoiceIdParam, totalCostParam, itemCountParam };

        //dbUtil.ExecuteStoredProcedure("CalculateTotal", parameters);

        // Sau khi thực thi, bạn có thể lấy giá trị của các tham số đầu ra.
        //decimal totalCost = (decimal)totalCostParam.Value;
        //int itemCount = (int)itemCountParam.Value;

    }
}
