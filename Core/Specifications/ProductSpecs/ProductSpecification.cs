using Core.Entities;

namespace Core.Specifications.ProductSpecs
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams productParams) : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search))
            && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId)
            && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
            // Filtering by 'brand' / 'type' IF given // &&: And Also // ||: Or Else 
        {
            AddIncludes();
            AddOrderBy(p => p.Name);
            ApplyPagination(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        break;
                }
            }
        }
        
        public ProductSpecification(int id) : base(x => x.Id == id)
            => AddIncludes();

        void AddIncludes()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}