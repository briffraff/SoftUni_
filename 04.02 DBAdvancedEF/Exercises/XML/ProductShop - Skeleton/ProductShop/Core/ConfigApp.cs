namespace ProductShop.Core
{
    public class ConfigApp
    {
        private const string pcHome = "RR-PC\\SQLEXPRESS";
        private const string pcWork = "BG-BORKO\\SQLEXPRESS";

        private const string pcName = pcHome;
        private const string databaseName = "ProductShopXML";
        private const string isTrusted = "true";

        public string ConnectionString()
        {
            string Wire = $"Server = {pcName}; Database={databaseName}; Trusted_Connection={isTrusted}; MultipleActiveResultSets=true";
            return Wire;
        }

    }
}
