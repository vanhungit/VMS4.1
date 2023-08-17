namespace VMSCore.Resources
{
    public static class LocalizationHelper
    {
        public static string GetString(string key)
        {
            return Resources.LanguageResource.ResourceManager.GetString(key, System.Threading.Thread.CurrentThread.CurrentUICulture);
        }
    }
}
