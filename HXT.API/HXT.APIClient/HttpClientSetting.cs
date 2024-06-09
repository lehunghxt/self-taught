namespace HXT.APIClient
{
    public class HttpClientSetting
    {
        public string Admin { get; set; }
        public string POS { get; set; }
        public string Social { get; set; }
    }

    public class GlobalAppSetting
    {
        public HttpClientSetting HttpClientSetting { get; set; }
    }
}
