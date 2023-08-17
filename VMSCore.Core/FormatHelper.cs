using System.Globalization;

namespace VMSCore.Core
{
    public static class FormatHelper
    {
        public static string FormatCurrency(this object str)
        {
            if (str != null && !string.IsNullOrEmpty(str.ToString()))
            {
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo("pt-BR");
                return string.Format(cultureInfo, "{0:n0}", str);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
