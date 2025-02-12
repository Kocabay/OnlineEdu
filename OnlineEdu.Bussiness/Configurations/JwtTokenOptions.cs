namespace OnlineEdu.Bussiness.Configurations
{
    public class JwtTokenOptions
    {
        public string Issuer { get; set; } //api.onlineedu.com
        public string Audience { get; set; } //www.onlineedu.com
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }
    }
}
