using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.EntityLayer
{
    public class AdvWorksApiDefaults
    {
        public AdvWorksApiDefaults()
        {
            Created= DateTime.Now;
            ProductCategoryID = 1;
            InfoMessageDefault = string.Empty;
            ProductModelID = 2;
            JWTSettings = new();

        }

        public DateTime Created { get; set; }   
        public string InfoMessageDefault { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductModelID {get; set; }

        public JwtSettings JWTSettings { get; set; }
    }
}
