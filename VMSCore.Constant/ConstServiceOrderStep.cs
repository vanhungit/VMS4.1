namespace VMSCore.Constant
{
    public static class ConstServiceOrderStep
    {
        public const int TIEPNHAN_0 = 0; // Mới tạo phiếu dịch vụ
        public const int SUACHUA_1 = 1; // KTT đã phân công sửa chữa
        public const int KIEMTRACUOI_2 = 2; // KTT đã kiểm tra cuối
        public const int HOANTHANH_3 = 3; // Đơn hàng đã hoàn thành => Lưu lên SAP
        public const int DANHANXE_4 = 4; // Nhân viên xác nhận KH đã nhận xe

        // 0: Tiếp nhận
        // 1: Sửa chữa
        // 2: Kiểm tra cuối
        // 3: Hoàn thành
        // 4: Đã nhận xe
    }
}
