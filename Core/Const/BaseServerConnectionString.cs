namespace Core.Const
{
    public static class BaseServerConnectionString
    {
        private const string ConnectionString = "http://212.20.46.249:32769/";

        public static string GetFullUrl(string TailUrl)
        {
            return ConnectionString + TailUrl;
        }
    }
}
