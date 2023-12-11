namespace MONACO_ASP.Infracstructures.Settings
{
    public record class WebSettings
    {
        public int ExpireTimeMinutes { get; set; } = 60;

        public string CookieSchemaAuth { get; set; } = "Authentication";

        public string AuthenticationCookie { get; set; } = "Authentication";

    }
}
