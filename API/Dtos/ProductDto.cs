
namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        public string ProductTypeName { get; set; }

        public string ProductBrandName { get; set; }
    }
}