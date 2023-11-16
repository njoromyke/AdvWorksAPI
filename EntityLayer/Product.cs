using System.Drawing;
using System.Text.Json.Serialization;

namespace AdvWorksAPI.EntityLayer
{
    public class Product
    {

        public Product()
        {
            Name = string.Empty;
            ProductNumber = string.Empty;
            Color = string.Empty;
            Size = string.Empty;
        }

        public int ProductID { get; set; }
        public string Name { get; set; }
        [JsonPropertyOrder(-1)]
        public string ProductNumber { get; set; }
        public string? Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice {get; set; }
        public string? Size { get; set; }
        public decimal? Weight { get;set; }

        [JsonPropertyName("categoryId")]
        public int ProductCategoryID { get; set; }

        [JsonPropertyName("modelId")]
        public int ProductModelID {get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate {get; set; }


    }
}
