namespace VMSCore.Constant
{
    public static class ConstSaleOrder
    {
        //loại đơn hàng
        public const string BanLe = "Bán lẻ";
        public const string Coc = "Cọc";

        //loại khách hàng
        public const int CaNhan = 0;
        public const int DoanhNghiep = 1;

        //giá bán phụ tùng theo xe
        public const string GiaBanPhuTungTheoXe = "ZPX1";

        //Loại đơn hàng truyền lên SAP
        public const string DonHangBanXe = "ZOR6";
        public const string DonHangBanDV = "ZOR7";
        public const string DonHangBanPT = "ZOR8";

        public const string Detail_Xe = "MAXE";
        public const string Detail_BienSo = "BIENSO";
        public const string Detail_DichVu = "PHIDICHVU";
        public const string Detail_Null = "NULL";

        //Loại đơn hàng thu tiền
        //1. Bán hàng
        public const int BanHang = 1;
        //2. Dịch vụ
        public const int DichVu = 2;

    }
}
