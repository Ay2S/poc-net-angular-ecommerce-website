namespace Core.Specifications.ProductSpecs
{
    public class ProductSpecParams
    {
        public string Sort { get; set; }

        public int? BrandId { get; set; }

        public int? TypeId { get; set; }

        public int PageIndex { get; set; } = 1;

        const int MAX_PAGE_SIZE = 50;
        int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
        }

        string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}