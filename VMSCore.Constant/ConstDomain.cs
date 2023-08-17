using System.Web.Configuration;

namespace VMSCore.Constant
{
    public class ConstDomain
    {
        //Test
        //public const string Domain = "http://192.168.0.105:3000";
        //Thật
        public static string Domain = WebConfigurationManager.AppSettings["DomainUrl"].ToString();
        public static string DomainImageCustomerPromotion = Domain + "/Upload/CustomerPromotion/thum";
        public static string DomainImageCustomerGift = Domain + "/Upload/Gift/thum";
        public static string DomainImageParentCategory = Domain + "/Upload/Brand/thum";
        public static string DomainImageCategory = Domain + "/Upload/Category/thum";
        public static string DomainImageProduct = Domain + "/Upload/Color/thum";
        public static string DomainBanner = Domain + "/Upload/Banner/thum";
        public static string DomainImageAccessoryCategory = Domain + "/Upload/AccessoryCategory/thum";
        public static string DomainImageStore = Domain + "/Upload/Store/Image/thum";
        public static string DomainLogoStore = Domain + "/Upload/Store/Logo/thum";
        public static string DomainImageAccessory = Domain + "/Upload/Accessory/thum";
        public static string DomainPeriodicallyChecking = Domain + "/Upload/PeriodicallyChecking/thum";
        public static string DomainPeriodicallyCheckingAPI = Domain + "/Upload/PeriodicallyChecking/";
        public static string DomainImageDefaultProduct = Domain + "/Upload/Color/thum";
        //Icon
        public static string DomainIcon = Domain + "/Upload/MaterialGroup/thum";
        //Hình loại xe
        public static string DomainProductHierarchy = Domain + "/Upload/ProductHierarchy/thum";
        //Hình sản phẩm (Material)
        public static string DomainMaterial = Domain + "/Upload/Material/thum";
        //Hình mô tả sản phẩm (MaterialDescription)
        public static string DomainMaterialDescription = Domain + "/Upload/MaterialDescription/thum";
        //noimage
        public static string NoImageUrl = Domain + "/Upload/noimage.jpg";
        public const string NoImage = "/Upload/noimage.jpg";

        //doamin API
        public static string DomainAPI = WebConfigurationManager.AppSettings["APIDomainUrl"].ToString();

        //token, key 
        public const string tokenConst = "454FC8F419313554549E2DED09B9AF94";
        public const string keyConst = "77f430e1-66fd-48dc-8057-77935e53be20";
    }
}
