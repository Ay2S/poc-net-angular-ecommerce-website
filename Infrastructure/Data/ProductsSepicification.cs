
using Core.Entities;
using Core.Specifications;

namespace Infrastructure.Data
{
    public class ProductsSpecification : BaseSpecification<Product>
    {
        public ProductsSpecification() => AddIncludes();
        
        public ProductsSpecification(int id) : base(x => x.Id == id)
            => AddIncludes();

        void AddIncludes()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
        }
    }
}