using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMSCore.EntityModels;
using VMSCore.Infrastructure.Features.SharedDirectoryManagement.Repositories.Implementations;

namespace VMSCore.Demo.WindowsForms.ShareDirectoryManagement
{
    public partial class frmProductOther : Form
    {
        private readonly ProductionOrderRepository _productionOrderRepository = new ProductionOrderRepository();
        private readonly ProductionOrderDetailCodeRepository _productionOrderDetailCodeRepository = new ProductionOrderDetailCodeRepository();
        private readonly ProductionOrderDetailRepository _productionOrderDetailRepository = new ProductionOrderDetailRepository();
        public frmProductOther()
        {
            InitializeComponent();
            dataGridView1.DataSource = _productionOrderRepository.GetAll();
            dataGridView1.Columns["Id"].ReadOnly = true;

        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                if (dataGridView.Rows[e.RowIndex].DataBoundItem is ProductionOrder modifiedOrder)
                {
                    var propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
                    var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Update the modified property of the modifiedOrder object
                    var propertyInfo = typeof(ProductionOrder).GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(modifiedOrder, newValue);
                        _productionOrderRepository.Update(modifiedOrder);
                    }
                    
                }
            }
        }
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                if (dataGridView.Rows[e.RowIndex].DataBoundItem is ProductionOrderDetail modifiedOrder)
                {
                    var propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
                    var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Update the modified property of the modifiedOrder object
                    var propertyInfo = typeof(ProductionOrderDetail).GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(modifiedOrder, newValue);
                        _productionOrderDetailRepository.Update(modifiedOrder);
                    }
                    
                }
            }
        }
        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                if (dataGridView.Rows[e.RowIndex].DataBoundItem is ProductionOrderDetailCode modifiedOrder)
                {
                    var propertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
                    var newValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    // Update the modified property of the modifiedOrder object
                    var propertyInfo = typeof(ProductionOrderDetailCode).GetProperty(propertyName);
                    if (propertyInfo != null)
                    {
                        propertyInfo.SetValue(modifiedOrder, newValue);
                        _productionOrderDetailCodeRepository.Update(modifiedOrder);
                    }
                    
                }
            }
        }
        public List<ProductionOrder> GenerateDefaultProductionOrders()
        {
            var productionOrders = new List<ProductionOrder>();
            var productOrtherDetail = new List<ProductionOrderDetail>();
            var productOrtherDetailCode = new List<ProductionOrderDetailCode>();
            for (int i = 1; i <= 5; i++)
            {
                var productionOrder = new ProductionOrder
                {
                    Code = string.Concat("PO", i),
                    CompanyId = "36ef4072-7cd5-4693-9316-dee10586bccf",
                    FromDate = DateTime.Now.ToString(),
                    ToDate = DateTime.Now.AddDays(i + 1).ToString(),
                    LineId = "11eddeba-e076-425c-9725-89c4e82367ff",
                    NumberTemp = i.ToString(),
                    CreatorId = "00d7c553-c76d-4f76-acc6-bc931d3665c1",
                    Active=true,
                    CreationTime=DateTime.Now,
                    ExpireDate= DateTime.Now.AddDays(i+7),
                    LogDate = DateTime.Now,
                    LastModifierId= "00d7c553-c76d-4f76-acc6-bc931d3665c1",
                    LastModificationTime= DateTime.Now,
                    LevelDate=i,
                    LinkWeb= "LinkWeb",
                    Lot=i.ToString(),
                    ManufactureDate=DateTime.Now,
                    OrderString=i.ToString(),
                    ParentId=i,
                    ProductionOrderCode= string.Concat("PO", i),
                    Reason=string.Empty,
                    StaffId= "00d7c553-c76d-4f76-acc6-bc931d3665c1",
                    Status=1,
                    StockId=i.ToString(),
                    Id=Guid.NewGuid()
                    // Set other properties accordingly
                };
                productionOrders.Add(productionOrder);

                productOrtherDetail = GenerateDefaultProductionOrderDetails(productionOrder.Id);
                _productionOrderDetailRepository.AddRange(productOrtherDetail);
                productOrtherDetailCode = GenerateDefaultProductionOrderDetailCodes(productionOrder.Id);
                _productionOrderDetailCodeRepository.AddRange(productOrtherDetailCode);
            }

            return productionOrders;
        }
        private List<ProductionOrderDetail> GenerateDefaultProductionOrderDetails(Guid productionOrderId)
        {
            var productionOrderDetails = new List<ProductionOrderDetail>();

            for (int i = 1; i <= 5; i++)
            {
                var productionOrderDetail = new ProductionOrderDetail
                {
                    ProductionOrderId = productionOrderId,
                    Active=true,
                    Code = string.Concat("POD ",i),
                    CompanyId= "36ef4072-7cd5-4693-9316-dee10586bccf",
                    CreationTime=DateTime.Now,
                    CreatorId= "00d7c553-c76d-4f76-acc6-bc931d3665c1",
                    DepartmentId="DP1",
                    InboundId= i,
                    LastModificationTime=DateTime.Now,
                    LineId= "11eddeba-e076-425c-9725-89c4e82367ff",
                    LastModifierId = "00d7c553-c76d-4f76-acc6-bc931d3665c1",
                    LogDate= DateTime.Now,
                    LotNumber= i.ToString(),
                    ModelId="desktop",
                    Note1 = string.Concat("Note1_", i),
                    Note2 = string.Concat("Note2_", i),
                    Note3 = string.Concat("Note3_", i),
                    NumberTemp = i.ToString(),
                    ProductId = string.Concat("product ", i),
                    ProductName = string.Concat("ProductName ", i),
                    Quantity = i,
                    RefType=i,
                    StockId=i.ToString(),
                    Unit= "Unit",
                    Id=Guid.NewGuid()
                };

                productionOrderDetails.Add(productionOrderDetail);
            }

            return productionOrderDetails;
        }
        private List<ProductionOrderDetailCode> GenerateDefaultProductionOrderDetailCodes(Guid productionOrderId)
        {
            var productionOrderDetailCodes = new List<ProductionOrderDetailCode>();

            for (int i = 1; i <= 2; i++)
            {
                var productionOrderDetailCode = new ProductionOrderDetailCode
                {
                    Code1 = string.Concat("Code1", i),
                    Code2 = string.Concat("Code2", i),
                    Active = true,
                    Code = string.Concat("Code", i),
                    IdLine = "11eddeba-e076-425c-9725-89c4e82367ff",
                    ProductionOrderId = productionOrderId,
                    Id = Guid.NewGuid()
                };

                productionOrderDetailCodes.Add(productionOrderDetailCode);
            }

            return productionOrderDetailCodes;
        }
        private void btnProductOrther_Click(object sender, EventArgs e)
        {
            var data = GenerateDefaultProductionOrders();
            _productionOrderRepository.AddRange(data);
            dataGridView1.DataSource = _productionOrderRepository.GetAll();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];

            var productOrtherId = Convert.ToString(selectedRow.Cells["Id"].Value);
            if (e.ColumnIndex == dataGridView1.Columns["buttondelete"].Index)
            {
                _productionOrderRepository.DeleteByCondition(x =>x.Id == Guid.Parse(productOrtherId));
                _productionOrderDetailRepository.DeleteByCondition(x => x.ProductionOrderId == Guid.Parse(productOrtherId));
                _productionOrderDetailCodeRepository.DeleteByCondition(x => x.ProductionOrderId == Guid.Parse(productOrtherId));
                dataGridView1.DataSource = _productionOrderRepository.GetAll();
            }
            else
            {
                var guid = Guid.Parse(productOrtherId);
                dataGridView2.DataSource = _productionOrderDetailRepository.GetAllByCondition(x => x.ProductionOrderId.Equals(guid));
                dataGridView3.DataSource = _productionOrderDetailCodeRepository.GetAllByCondition(x => x.ProductionOrderId == Guid.Parse(productOrtherId)).ToList();
                dataGridView2.Columns["Id"].ReadOnly = true;
                dataGridView2.Columns["ProductionOrderId"].ReadOnly = true;
                dataGridView3.Columns["Id"].ReadOnly = true;
                dataGridView3.Columns["ProductionOrderId"].ReadOnly = true;
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];

            var id = Convert.ToString(selectedRow.Cells["Id"].Value);
            var ProductionOrderId = Convert.ToString(selectedRow.Cells["ProductionOrderId"].Value);
            if (e.ColumnIndex == dataGridView2.Columns["DeleteDetail"].Index)
            {
                _productionOrderDetailRepository.DeleteByCondition(x => x.Id == Guid.Parse(id));
                dataGridView2.DataSource = _productionOrderDetailRepository.GetAllByCondition(x => x.ProductionOrderId == Guid.Parse(ProductionOrderId));
            }
            
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];

            var id = Convert.ToString(selectedRow.Cells["Id"].Value);
            var ProductOrtherId = Convert.ToString(selectedRow.Cells["ProductionOrderId"].Value);
            if (e.ColumnIndex == dataGridView3.Columns["DeteleDetailCode"].Index)
            {
                _productionOrderDetailCodeRepository.DeleteByCondition(x => x.Id == Guid.Parse(id));
                dataGridView3.DataSource = _productionOrderDetailCodeRepository.GetAllByCondition(x => x.ProductionOrderId == Guid.Parse(ProductOrtherId));

            }
            
        }


    }
}
