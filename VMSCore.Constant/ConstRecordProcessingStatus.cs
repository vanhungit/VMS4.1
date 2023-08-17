namespace VMSCore.Constant
{
    public static class ConstRecordProcessingStatus
    {
        //Đã xác nhận
        public const int DaXacNhan = 1;

        //Đã xuất phiếu KTCLXX
        public const int KTCLXX = 2;

        //Hoàn thành hồ sơ trước bạ
        public const int HoanThanh = 3;

        //Đã chuyển hồ sơ cho cửa hàng
        public const int ChuyenChoCH = 4;

        //Cửa hàng xác nhận nhận hồ sơ
        public const int CHNhanHoSo = 5;

        //Đã chuyển hồ sơ cho KH
        public const int ChuyenChoKH = 6;

        public const string Btn_XacNhan = "Xác nhận";
        public const string Btn_PhieuKTCLXX = "Xuất phiếu KTCLXX";
        public const string Btn_Print_HoSo = "In hồ sơ trước bạ";
        public const string Btn_HoanThanh = "Hoàn thành hồ sơ";
    }
}
