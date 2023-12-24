namespace AdvWorksAPI.EntityLayer
{
    public class JwtSettings
    { 
        public JwtSettings()
        {
            Key = "Key";
            Issuer = "http://localhost:5045";
            Audience = "Audience";
            MinutesToExpiration = 10;
        }

        public string Key { get; set; } 
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesToExpiration { get; set; }
    }
}
