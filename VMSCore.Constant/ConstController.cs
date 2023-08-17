namespace VMSCore.Constant
{
    public static class ConstController
    {
        //Quyền: Thêm, Sửa, Xóa, Import, Export,..
        public const string Function = "Function";
        public const string Menu = "Menu";
        public const string Page = "Page";
        public const string MobileScreen = "MobileScreen";
        public const string Access = "Access";

        //Nhóm người dùng, Người dùng
        public const string Roles = "Roles";
        public const string Account = "Account";
        public const string Auth = "Auth";
        public const string Home = "Home";

        #region Dữ liệu nền
        //Công ty
        public const string Company = "Company";
        //Cửa hàng
        public const string Store = "Store";

        //1. Nhãn hiệu
        public const string ProfitCenter = "ProfitCenter";
        //2. Loại xe
        public const string ProductHierarchy = "ProductHierarchy";
        //3. Dòng xe
        public const string MaterialGroup = "MaterialGroup";
        //4. Phiên bản
        public const string Labor = "Labor";
        //5. Màu sắc
        public const string MaterialFreightGroup = "MaterialFreightGroup";
        //6. Đời xe
        public const string ExternalMaterialGroup = "ExternalMaterialGroup";
        //7. Kiểu xe
        public const string TemperatureCondition = "TemperatureCondition";
        //8. Option
        public const string ContainerRequirement = "ContainerRequirement";
        //9. Sản phẩm
        public const string Material = "Material";

        //Tỉnh thành
        public const string Province = "Province";
        //Quận huyện
        public const string District = "District";
        //Phường xã
        public const string Ward = "Ward";

        //Nhân viên
        public const string SalesEmployee = "SalesEmployee";
        //Khuyến mãi
        public const string Promotion = "Promotion";

        //Nhóm phụ tùng/PK
        public const string AccessoryCategory = "AccessoryCategory";
        //Nhóm công việc
        public const string ServiceType = "ServiceType";
        //Phụ tùng/Phụ kiện/Công việc
        public const string Accessory = "Accessory";
        #endregion

        #region Khách hàng
        public const string Customer = "Customer";
        //KH tiềm năng
        public const string Prospect = "Prospect";
        #endregion

        #region Bán hàng
        public const string SaleOrder = "SaleOrder";
        #endregion

        #region Quản lý hồ sơ trước bạ
        //Tiếp nhận hồ sơ
        public const string ConfirmRecord = "ConfirmRecord";
        //Chuyển hồ sơ cho cửa hàng
        public const string SendRecordToStore = "SendRecordToStore";
        //Cửa hàng xác nhận
        public const string StoreConfirmReceived = "StoreConfirmReceived";
        //Cửa hàng chuyển hồ sơ cho KH
        public const string SendRecordToCustomer = "SendRecordToCustomer";
        #endregion

        #region Dịch vụ
        //Loại đơn hàng DV
        public const string ServiceOrderType = "ServiceOrderType";
        //Lịch hẹn sửa chữa
        public const string Working = "Working";
        //Đơn hàng dịch vụ
        public const string ServiceOrder = "ServiceOrder";
        //Thông tin xe
        public const string VehicleInfo = "VehicleInfo";
        //Loại sửa chữa
        public const string FixingType = "FixingType";
        //Flag dịch vụ
        public const string ServiceFlag = "ServiceFlag";
        //Danh sách phụ tùng cần gửi yêu cầu lên hãng
        public const string ClaimAccessory = "ClaimAccessory";
        #endregion

        #region Kế toán
        //Thu tiền
        public const string ReceiptVoucher = "ReceiptVoucher";
        #endregion Kế toán

        #region Cài đặt
        public const string Setting = "Setting";
        //reset data
        public const string ResetTestData = "ResetTestData";
        //Đồng bộ
        public const string MasterData = "MasterData";
        #endregion

        #region Cấu hình
        //Cấu hình lệ phí biển số
        public const string LicensePrice = "LicensePrice";
        //Cấu hình phí bảo hiểm
        public const string Insurance = "Insurance";
        //Cấu hình nộp tiền NSNN
        public const string ConfigPaymentNationalBudget = "ConfigPaymentNationalBudget";
        #endregion

        #region Tiến Thu: không dùng
        public const string StoreType = "StoreType";
        public const string CustomerPromotion = "CustomerPromotion";
        public const string CustomerLevel = "CustomerLevel";
        public const string CustomerGift = "CustomerGift";
        public const string ConfigProspect = "ConfigProspect";
        public const string Brand = "Brand";
        public const string Category = "Category";
        public const string Configuration = "Configuration";
        public const string Style = "Style";
        public const string Color = "Color";
        public const string Specifications = "Specifications";
        public const string Warehouse = "Warehouse";
        public const string Product = "Product";
        public const string PlateFee = "PlateFee";
        public const string PeriodicallyChecking = "PeriodicallyChecking";
        #endregion
    }

    public static class ConstArea
    {
        public const string Permission = "Permission";
        public const string MasterData = "MasterData";
        public const string Sale = "Sale";
        public const string Service = "Service";
        public const string Utilities = "Utilities";
        public const string TransferDataFromSAP = "TransferDataFromSAP";
        public const string Customer = "Customer";
        public const string RecordProcessing = "RecordProcessing";
        public const string Accountancy = "Accountancy";
    }

    public static class ConstAction
    {
        public const string Login = "Login";
    }
}


