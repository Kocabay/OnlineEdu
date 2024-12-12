namespace OnlineEdu.WebUI.Helpers
{
    public static class HtppClientInstance
    {
        public static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7052/api/");
            return client;
        }

    }
}
