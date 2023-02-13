using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private const string API_URL = "ApiUrl";
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config) => _config = config;
        
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) return _config[API_URL] + source.PictureUrl;
            return null;
        }
    }
}